import { CommonModule } from '@angular/common';
import { Component, inject, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { MatButton, MatButtonModule } from '@angular/material/button';
import { MatCardModule } from "@angular/material/card";
import { MatFormFieldModule } from "@angular/material/form-field";
import { MatInputModule } from '@angular/material/input';
import { CreateUserDTO } from '../../models/DTOs/create-userDTO';
import { UserService } from '../../services/user-service';

@Component({
  selector: 'app-registration',
  imports: [MatCardModule, 
            MatFormFieldModule,
            CommonModule,
            MatButtonModule,
            MatInputModule,
            ReactiveFormsModule,
            ],
  templateUrl: './registration.html',
  styleUrl: './registration.css'
})
export class Registration implements OnInit{
  registerForm!: FormGroup;
  private readonly userService = inject(UserService)

  constructor(private fb: FormBuilder) {}

  ngOnInit(): void {
    this.registerForm = this.fb.group({
      name: ['', Validators.required],
      lastName: [''],
      login: ['', [Validators.required, Validators.minLength(5)]],
      password: ['', [Validators.required, Validators.minLength(6)]]
    });
  }

  onSubmit(): void {
    if (this.registerForm.valid) {
      console.log('Регистрация:', this.registerForm.value);

      // Здесь добавить запрос к API
      let userDTO: CreateUserDTO = {
        login: this.registerForm.value.login,
        password: this.registerForm.value.password,
        name: this.registerForm.value.name,
        lastName: this.registerForm.value.lastName
      }

      this.userService.createUser(userDTO)
    }
  }

}
