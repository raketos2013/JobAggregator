import { Component, inject } from '@angular/core';
import { FormArray, FormBuilder, FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from "@angular/material/card";
import { MatFormFieldModule } from "@angular/material/form-field";
import { MatIconModule } from "@angular/material/icon";
import { MatInputModule } from '@angular/material/input';
import { MatChipsModule } from "@angular/material/chips";
import { Organization } from '../../../models/organization';
import { OrganizationService } from '../../../services/organization-service';

@Component({
  selector: 'app-create-organization',
  imports: [MatCardModule, MatFormFieldModule, MatIconModule, MatButtonModule, MatInputModule, MatChipsModule, ReactiveFormsModule],
  templateUrl: './create-organization.html',
  styleUrl: './create-organization.css'
})
export class CreateOrganization {
  organizationForm: FormGroup;
  skillInputControl = new FormControl('');

  constructor(
    private fb: FormBuilder,
    private organizationService: OrganizationService
  ) {
    this.organizationForm = this.fb.group({
      name: ['', [Validators.required, Validators.maxLength(100)]],
      description: ['', [Validators.required, Validators.maxLength(1000)]],
      website: ['', [Validators.pattern('https?://.+')]],
      email: ['', [Validators.required, Validators.email]],
      phoneNumber: ['', [Validators.pattern('[0-9]{10,15}')]],
      address: [''],
      activities: this.fb.array([])
    });
  }

  get activities(): FormArray {
    return this.organizationForm.get('activities') as FormArray;
  }

  createActivity(name: string = ''): FormGroup {
    return this.fb.group({
      name: [name || '', Validators.required]
    });
  }

  addActivity(event: any): void {
    const value = (event.value || '').trim();
    if (value) {
      this.activities.push(this.createActivity(value));
      this.skillInputControl.reset();
    }
  }

  removeActivity(index: number): void {
    this.activities.removeAt(index);
  }

  onSubmit(): void {
    if (this.organizationForm.valid) {
      const formValue: Organization = {
        ...this.organizationForm.value,
        vacancies: null // При создании организации вакансий нет
      };

      // this.organizationService.createOrganization(formValue).subscribe({
      //   next: (org) => {
      //     console.log('Организация создана:', org);
      //     // Перенаправление на страницу организации
      //   },
      //   error: (err) => {
      //     console.error('Ошибка создания организации:', err);
      //   }
      // });
    }
}
}