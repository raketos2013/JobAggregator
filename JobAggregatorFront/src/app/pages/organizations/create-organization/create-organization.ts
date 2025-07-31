import { Component, inject } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from "@angular/material/card";
import { MatFormFieldModule } from "@angular/material/form-field";
import { MatIconModule } from "@angular/material/icon";
import { MatInputModule } from '@angular/material/input';

@Component({
  selector: 'app-create-organization',
  imports: [MatCardModule, MatFormFieldModule, MatIconModule, MatButtonModule, MatInputModule],
  templateUrl: './create-organization.html',
  styleUrl: './create-organization.css'
})
export class CreateOrganization {
  private fb = inject(FormBuilder);
  employerForm = this.fb.group({
    name: ['', Validators.required],
    description: [''],
    website: ['']
  });

  selectedFile: File | null = null;

  // constructor(private fb: FormBuilder) {}

  onFileSelected(event: any) {
    this.selectedFile = event.target.files[0];
  }

  onSubmit() {
    if (this.employerForm.valid) {
      const formData = new FormData();
      formData.append('data', JSON.stringify(this.employerForm.value));
      if (this.selectedFile) {
        formData.append('logo', this.selectedFile);
      }
      console.log('Организация:', formData);
      // Отправка на сервер
    }
  }
}
