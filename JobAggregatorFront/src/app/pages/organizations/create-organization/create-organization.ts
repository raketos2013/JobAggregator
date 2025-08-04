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
import { CommonModule } from '@angular/common';
import { OrganizationDTO } from '../../../models/DTOs/organizationDTO';
import { AuthService } from '../../../services/auth-service';

@Component({
  selector: 'app-create-organization',
  imports: [MatCardModule, 
            MatFormFieldModule, 
            MatIconModule, 
            MatButtonModule, 
            MatInputModule, 
            MatChipsModule, 
            ReactiveFormsModule, 
            CommonModule],
  templateUrl: './create-organization.html',
  styleUrl: './create-organization.css'
})
export class CreateOrganization {
  organizationForm: FormGroup;
  skillInputControl = new FormControl('');
  private readonly authService = inject(AuthService)

  constructor(
    private fb: FormBuilder,
    private organizationService: OrganizationService
  ) {
    this.organizationForm = this.fb.group({
      name: ['', [Validators.required, Validators.maxLength(100)]],
      description: ['', [Validators.required, Validators.maxLength(1000)]],
      website: ['', [Validators.pattern('https?://.+')]],
      email: ['', [Validators.required, Validators.email]],
      phoneNumber: ['', [Validators.pattern('[0-9]{9}')]],
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
      // const formValue: Organization = {
      //   ...this.organizationForm.value,
      //   vacancies: null // При создании организации вакансий нет
      // };

      const organization: OrganizationDTO = {
        name: this.organizationForm.value.name,
        description: this.organizationForm.value.description,
        website: this.organizationForm.value.website,
        email: this.organizationForm.value.email,
        phoneNumber: this.organizationForm.value.phoneNumber,
        address: this.organizationForm.value.address,
        activities: this.organizationForm.value.activities
      }
      let user = this.authService.getUserData()
      if(user != null){
        console.log('ORG')
        console.log(organization)
        console.log('USR')
        console.log(user.id)
        this.organizationService.createOrganization(organization, user.id);
      }
      
    }
}
}