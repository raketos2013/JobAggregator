import { Component, inject, signal } from '@angular/core';
import { FormBuilder, FormControl, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { MatFormFieldModule } from '@angular/material/form-field';
import { AuthService } from '../../services/auth-service';
import { MatIconModule } from '@angular/material/icon';
import { CommonModule } from '@angular/common';
import { MatCardModule } from '@angular/material/card';
import { Router, RouterModule } from '@angular/router';
import { MatProgressSpinnerModule, MatSpinner } from '@angular/material/progress-spinner';

const materialModules = [
    FormsModule,
    MatFormFieldModule,
    MatInputModule,
    ReactiveFormsModule,
    MatButtonModule,
    MatIconModule,
    CommonModule,
    ReactiveFormsModule,
    MatCardModule,
    MatFormFieldModule,
    MatInputModule,
    MatButtonModule,
    MatIconModule,
    RouterModule,
    MatProgressSpinnerModule
];

@Component({
  selector: 'app-login',
  imports: [materialModules],
  templateUrl: './login.html',
  styleUrl: './login.css'
})

export class Login {


  private fb = inject(FormBuilder);
  private authService = inject(AuthService);
  private router = inject(Router);

  hidePassword = true;
  isLoading = false;
  errorMessage = '';

  
  loginForm = this.fb.group({
    login: ['', [Validators.required, Validators.minLength(4)]],
    password: ['', [Validators.required, Validators.minLength(6)]]
  });



  onSubmit(): void {
    if (this.loginForm.invalid) return;

    this.isLoading = true;
    this.errorMessage = '';

    const { login, password } = this.loginForm.value;

    this.authService.login(login!, password!);

    // this.authService.login(email!, password!).subscribe({
    //   next: () => {
    //     this.router.navigate(['/']);
    //   },
    //   error: (err) => {
    //     this.errorMessage = err.message || 'Ошибка авторизации';
    //     this.isLoading = false;
    //   }
    // });
  }

  get login() {
    return this.loginForm.get('login');
  }

  get password() {
    return this.loginForm.get('password');
  }



  //private readonly authService = inject(AuthService);
  // loginFormControl = new FormControl('', [
  //   Validators.required
  // ]);
  // passwordFormControl = new FormControl('', [
  //   Validators.required
  // ]);

  // onSubmit() {
  //   this.authService.login(this.loginFormControl.value!, this.passwordFormControl.value!);
  //   // if (this.loginFormControl.valid && this.passwordFormControl.valid) {
  //   //   this.authService.login(this.loginFormControl.value!, this.passwordFormControl.value!);
  //   // } else {
  //   //   console.error('Login or password is invalid');
  //   // }
  // }

    hide = signal(true);
    clickEvent(event: MouseEvent) {
      this.hide.set(!this.hide());
      event.stopPropagation();
    }

    protected readonly value = signal('');

  protected onInput(event: Event) {
    this.value.set((event.target as HTMLInputElement).value);
  }
}