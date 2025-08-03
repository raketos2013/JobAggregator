import { Component, inject, ViewChild } from '@angular/core';
import { FormArray, FormBuilder, FormControl, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from "@angular/material/card";
import { MatFormFieldModule } from "@angular/material/form-field";
import { MatInputModule } from '@angular/material/input';
import {MatSelectModule} from '@angular/material/select';
import { MatIconModule } from "@angular/material/icon";
import { MatChipsModule } from "@angular/material/chips";
import { CommonModule } from '@angular/common';
import { MatChipListbox } from '@angular/material/chips';
import { VacancyService } from '../../../services/vacancy-service';
import { VacancyDTO } from '../../../models/DTOs/vacancyDTO';

@Component({
  selector: 'app-create-vacancy',
  imports: [MatCardModule, 
            MatFormFieldModule, 
            MatSelectModule, 
            MatButtonModule, 
            MatInputModule, 
            ReactiveFormsModule, 
            MatIconModule, 
            MatChipsModule,
            CommonModule,
            FormsModule],
  templateUrl: './create-vacancy.html',
  styleUrl: './create-vacancy.css'
})
export class CreateVacancy {
  private readonly vacancyService = inject(VacancyService)
  @ViewChild('chipList') chipList!: MatChipListbox;
  vacancyForm: FormGroup;
  skillInputControl = new FormControl('');
  

  constructor(private fb: FormBuilder) {
    this.vacancyForm = this.fb.group({
      title: ['', Validators.required],
      location: ['', Validators.required],
      salary: [null],
      currency: ['BYN'],
      employmentType: ['FULL'],
      description: ['', Validators.required],
      requirements: this.fb.array([this.createHandbookItem()]),
      responsibilities: this.fb.array([this.createHandbookItem()]),
      offers: this.fb.array([this.createHandbookItem()]),
      skills: this.fb.array([])
    });
  }

  createHandbookItem(value: string = ''): FormGroup {
    return this.fb.group({
      name: [value]
    });
  }

  get requirements(): FormArray {
    return this.vacancyForm.get('requirements') as FormArray;
  }

  get responsibilities(): FormArray {
    return this.vacancyForm.get('responsibilities') as FormArray;
  }

  get offers(): FormArray {
    return this.vacancyForm.get('offers') as FormArray;
  }

  get skills(): FormArray {
    return this.vacancyForm.get('skills') as FormArray;
  }

  addRequirement() {
    this.requirements.push(this.createHandbookItem());
  }

  removeRequirement(index: number): void {
    this.requirements.removeAt(index);
    
    // // Если удалили последнее поле - добавляем новое пустое
    // if (this.requirements.length === 0) {
    //   this.addRequirement();
    // }
  }

  addResponsibility() {
    this.responsibilities.push(this.createHandbookItem());
  }

  removeResponsibility(index: number): void {
    this.responsibilities.removeAt(index);
    // if (this.responsibilities.length === 0) {
    //   this.addResponsibility(); // Автоматически добавляем новое пустое поле
    // }
  }

  addOffer() {
    this.offers.push(this.createHandbookItem());
  }

  removeOffer(index: number): void {
    this.offers.removeAt(index);
    // if (this.offers.length === 0) {
    //   this.addOffer(); // Автоматически добавляем новое пустое поле
    // }
  }

  addSkill(event: any): void {
    const value = (event.value || '').trim();
    if (value) {
      this.skills.push(this.createHandbookItem(value));
      this.skillInputControl.reset();
    }
  }

  removeSkill(index: number): void {
    this.skills.removeAt(index);
  }

  onSubmit() {
    if (this.vacancyForm.valid) {
      // const formValue = {
      //   ...this.vacancyForm.value,
      //   requirements: this.vacancyForm.value.requirements.filter((r: string) => r),
      //   responsibilities: this.vacancyForm.value.responsibilities.filter((r: string) => r),
      //   offers: this.vacancyForm.value.offers.filter((r: string) => r),
      //   skills: this.vacancyForm.value.skills.map((s: any) => s.name)
      // };
      console.log('Данные вакансии:', this.vacancyForm.value);
      const vacancy: VacancyDTO = {
        name: this.vacancyForm.value.title,
        description: this.vacancyForm.value.description,
        location: this.vacancyForm.value.location,
        salary: this.vacancyForm.value.salary,
        organizationId: 1,
        scheduleType: this.vacancyForm.value.employmentType,
        requirements: this.vacancyForm.value.requirements,
        responsibilities: this.vacancyForm.value.responsibilities,
        offers: this.vacancyForm.value.offers,
        skills: this.vacancyForm.value.skills
      }
      this.vacancyService.createVacancy(vacancy);
    }
  }
}
