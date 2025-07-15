import { Component, inject, signal } from '@angular/core';
import { FormControl, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { MatFormFieldModule } from '@angular/material/form-field';
import { AuthService } from '../../services/auth-service';
import { MatIconModule } from '@angular/material/icon';

const materialModules = [
    FormsModule,
    MatFormFieldModule,
    MatInputModule,
    ReactiveFormsModule,
    MatButtonModule,
    MatIconModule
];

@Component({
  selector: 'app-login',
  imports: [materialModules],
  templateUrl: './login.html',
  styleUrl: './login.css'
})

export class Login {
  private readonly authService = inject(AuthService);
  loginFormControl = new FormControl('', [
    Validators.required
  ]);
  passwordFormControl = new FormControl('', [
    Validators.required
  ]);

  onSubmit() {
    this.authService.login(this.loginFormControl.value!, this.passwordFormControl.value!);
    // if (this.loginFormControl.valid && this.passwordFormControl.valid) {
    //   this.authService.login(this.loginFormControl.value!, this.passwordFormControl.value!);
    // } else {
    //   console.error('Login or password is invalid');
    // }
  }

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