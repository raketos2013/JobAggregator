import { Component, inject, Input } from '@angular/core';
import { User } from '../../../models/user';
import { CommonModule } from '@angular/common';
import { MatFormFieldModule } from "@angular/material/form-field";
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatInputModule } from '@angular/material/input';
import { MatButton, MatButtonModule } from '@angular/material/button';
import { UserService } from '../../../services/user-service';
import { MatSnackBar, MatSnackBarModule } from '@angular/material/snack-bar';

@Component({
  selector: 'app-profile-info',
  imports: [CommonModule, 
            MatFormFieldModule,
            FormsModule,
            MatButtonModule,
            MatInputModule,
            MatSnackBarModule],
  templateUrl: './profile-info.html',
  styleUrl: './profile-info.css'
})
export class ProfileInfo {
  private readonly userService = inject(UserService)
  @Input() user!: User;
  isEditing = false;

  constructor(
    private snackBar: MatSnackBar
  ) {}


    requestManagerRole(): void {
      this.userService.requestManagerRole().subscribe({
        next: () => {
          this.showNotification();
        },
        error: (err) => {
          console.error('Ошибка запроса роли', err);
        }
      });
    }
    private showNotification(): void {
      this.snackBar.open('Запрос на роль Manager успешно отправлен!', 'Закрыть', {
        duration: 5000, // Автоматически закроется через 5 секунд
        panelClass: ['success-snackbar']
      });
    }
}
