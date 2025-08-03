import { Component, Input } from '@angular/core';
import { User } from '../../../models/user';
import { CommonModule } from '@angular/common';
import { MatFormFieldModule } from "@angular/material/form-field";
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatInputModule } from '@angular/material/input';
import { MatButton, MatButtonModule } from '@angular/material/button';

@Component({
  selector: 'app-profile-info',
  imports: [CommonModule, 
            MatFormFieldModule,
            FormsModule,
            MatButtonModule,
            MatInputModule],
  templateUrl: './profile-info.html',
  styleUrl: './profile-info.css'
})
export class ProfileInfo {
  @Input() user!: User;
    isEditing = false;

    requestManagerRole(): void {
      // Логика запроса роли менеджера
    }
}
