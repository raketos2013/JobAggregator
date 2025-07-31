import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormArray, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from "@angular/material/card";
import { MatFormFieldModule } from "@angular/material/form-field";
import { MatIconModule } from "@angular/material/icon";
import { MatInputModule } from '@angular/material/input';

@Component({
  selector: 'app-create-resume',
  imports: [MatCardModule, MatFormFieldModule, MatIconModule, CommonModule, MatButtonModule, MatInputModule],
  templateUrl: './create-resume.html',
  styleUrl: './create-resume.css'
})
export class CreateResume implements OnInit{
  resumeForm!: FormGroup;
  constructor(private fb: FormBuilder) {}
  ngOnInit(): void {
    this.resumeForm = this.fb.group({
      fullName: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
      phone: ['', Validators.required],
      experience: this.fb.array([])
    });
  }
  get experience(): FormArray {
    return this.resumeForm.get('experience') as FormArray;
  }
  addExperience(): void {
    const expGroup = this.fb.group({
      company: ['', Validators.required],
      position: ['', Validators.required]
    });
    this.experience.push(expGroup);
  }
  removeExperience(index: number): void {
    this.experience.removeAt(index);
  }
  onSubmit(): void {
    if (this.resumeForm.valid) {
      console.log('Резюме отправлено:', this.resumeForm.value);
      // Здесь можно добавить отправку на сервер
    } else {
      console.error('Форма невалидна!');
    }
  }

}
