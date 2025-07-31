import { Component, Input } from '@angular/core';
import { User } from '../../../models/user';
import { MatIconModule } from "@angular/material/icon";
import { MatDividerModule } from "@angular/material/divider";
import { CommonModule } from '@angular/common';
import { MatButtonModule } from '@angular/material/button';

@Component({
  selector: 'app-profile-info',
  imports: [MatIconModule, MatDividerModule, CommonModule, MatButtonModule],
  templateUrl: './profile-info.html',
  styleUrl: './profile-info.css'
})
export class ProfileInfo {
  user = {
    name: 'Иван Петров',
    email: 'ivan.petrov@example.com',
    phone: '+375 (44) 123-45-67',
    avatar: 'assets/default-avatar.png',
    position: 'Frontend Developer (Angular)',
    experience: '3 года',
    location: 'Minsk',
    skills: ['Angular', 'TypeScript', 'RxJS', 'NgRx', 'HTML/CSS']
  };

}
