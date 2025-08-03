import { CommonModule } from '@angular/common';
import { Component, inject, OnInit, ViewChild } from '@angular/core';
import { FormArray, FormBuilder, FormControl, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from "@angular/material/card";
import { MatFormFieldModule } from "@angular/material/form-field";
import { MatIconModule } from "@angular/material/icon";
import { MatInputModule } from '@angular/material/input';
import { MatChipGrid, MatChipsModule } from '@angular/material/chips';
import { ResumeService } from '../../../services/resume-service';
import { MatSelectModule } from '@angular/material/select';
import { AuthService } from '../../../services/auth-service';
import { Language } from '../../../models/language';
import { LanguageService } from '../../../services/language-service';
import { ResumeDTO } from '../../../models/DTOs/resumeDTO';
import { Gender } from '../../../models/enums/gender';

@Component({
  selector: 'app-create-resume',
  imports: [MatCardModule,
    MatFormFieldModule,
    MatIconModule,
    CommonModule,
    MatButtonModule,
    MatInputModule,
    MatButtonModule,
    MatInputModule,
    FormsModule,
    ReactiveFormsModule,
    MatSelectModule, MatChipsModule],
  templateUrl: './create-resume.html',
  styleUrl: './create-resume.css'
})
export class CreateResume implements OnInit{
   private readonly resumeService = inject(ResumeService);
  private readonly authService = inject(AuthService);
  private readonly languageService = inject(LanguageService);
  
  @ViewChild('chipGrid') chipGrid!: MatChipGrid;
  
  resumeForm: FormGroup;
  skillInputControl = new FormControl('');
  userFullName: string = '';
  genders = Object.values(Gender)
    .filter(value => typeof value === 'number') as Gender[];
  availableLanguages: Language[] = [];
  photoPreview: string | null = null;
  photoFile: File | null = null;

  constructor(private fb: FormBuilder) {
    // Получаем данные пользователя из токена
    const userData = this.authService.getUserData();
    this.userFullName = `${userData?.lastname} ${userData?.name}` || '';
    console.log(userData?.role)
    console.log(userData?.id)

    this.resumeForm = this.fb.group({
      experience: [''],
      links: [''],
      age: [null, [Validators.min(14), Validators.max(99)]],
      gender: [Gender.Male],
      languages: this.fb.array([]),
      education: [''],
      skills: this.fb.array([])
    });
  }

  ngOnInit(): void {
    this.loadLanguages();
  }

 getGenderString(gender: Gender): string {
  if (gender == null) return 'Не указан';
  if (!Object.values(Gender).includes(gender)) return 'Не указан';
    const genderMap: Record<Gender, string> = {
      [Gender.Male]: 'Мужской',
      [Gender.Female]: 'Женский'
    };
    return genderMap[gender] || 'Не указан';
  }

  get languages(): FormArray {
    return (this.resumeForm.get('languages') as FormArray) || this.fb.array([]);
  }

  get skills(): FormArray {
    return (this.resumeForm.get('skills') as FormArray) || this.fb.array([]);
  }

  createLanguage(): FormGroup {
    return this.fb.group({
      language: ['', Validators.required]
      // name: ['', Validators.required],
      // code: ['', Validators.required]
      // level: ['', Validators.required]
    });
  }

  createSkill(value: string = ''): FormGroup {
    return this.fb.group({
      name: [value || '', Validators.required]
    });
  }

  addLanguage(): void {
    this.languages.push(this.createLanguage());
  }

  removeLanguage(index: number): void {
    if (this.languages.length > 0) { // Проверка на пустоту
      this.languages.removeAt(index);
   }
  }

  addSkill(event: any): void {
    const value = (event.value || '').trim();
    if (value) {
      this.skills.push(this.createSkill(value));
      this.skillInputControl.reset();
    }
  }

  removeSkill(index: number): void {
    if (this.skills.length > 0) { // Проверка на пустоту
      this.skills.removeAt(index);
    }
  }

  onPhotoUpload(event: any): void {
    const file = event.target.files?.[0]; // Safe navigation
    if (file) {
      this.photoFile = file;
      const reader = new FileReader();
      reader.onload = () => {
        this.photoPreview = reader.result as string;
      };
      reader.readAsDataURL(file);
    }
  }

  removePhoto(): void {
    this.photoPreview = null;
    this.photoFile = null;
  }

  private loadLanguages(): void {
    this.languageService.getLanguages().subscribe({
      next: (languages) => {
        this.availableLanguages = languages || []; // Защита от undefined
        if (this.availableLanguages.length > 0) {
        this.languages.controls.forEach(control => {
          const code = control.get('code')?.value;
          const lang = this.availableLanguages.find(l => l.code === code);
          if (lang) {
            control.get('name')?.setValue(lang.name);
          }
        });
      }
      },
      error: (err) => {
        console.error('Ошибка загрузки языков', err);
        this.availableLanguages = []; // Fallback
      }
    });
  }

  onSubmit(): void {
    if (this.resumeForm.valid) {
      // const formData = new FormData();
      // const formValue = {
      //   ...this.resumeForm.value,
      //   skills: (this.resumeForm.value.skills || []).map((s: any) => s?.name), // Защита
      //   languages: this.resumeForm.value.languages || [] // Защита
      // };
      

      // formData.append('data', JSON.stringify(formValue));
      
      // if (this.photoFile) {
      //   formData.append('photo', this.photoFile);
      // }

      console.log('Данные для отправки:', this.resumeForm.value);

      const resumeDTO: ResumeDTO = {
        userId: 1,
        experience: this.resumeForm.value.experience,
        links: this.resumeForm.value.links,
        age: this.resumeForm.value.age,
        gender: this.resumeForm.value.gender,
        photo: '',
        languages: this.resumeForm.value.languages.map((lang: any) => lang.language),
        education: this.resumeForm.value.education,
        skills: this.resumeForm.value.skills
      }

      this.resumeService.createResume(resumeDTO);
    }
  }

}
