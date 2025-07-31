import { Component, inject } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from "@angular/material/card";
import { MatFormFieldModule } from "@angular/material/form-field";
import { MatInputModule } from '@angular/material/input';
import {MatSelectModule} from '@angular/material/select';

@Component({
  selector: 'app-create-vacancy',
  imports: [MatCardModule, MatFormFieldModule, MatSelectModule, MatButtonModule, MatInputModule
  ],
  templateUrl: './create-vacancy.html',
  styleUrl: './create-vacancy.css'
})
export class CreateVacancy {
  private fb = inject(FormBuilder);
  // constructor(private fb: FormBuilder) {}
 
  vacancyForm = this.fb.group({
    title: ['', Validators.required],
    description: [''],
    salary: [null],
    experience: ['no']
  });

  

  onSubmit() {
    if (this.vacancyForm.valid) {
      console.log('Вакансия:', this.vacancyForm.value);
      // Отправка на сервер
    }
  }
}
