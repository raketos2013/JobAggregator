import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { MatIconModule } from '@angular/material/icon';
import { MatListModule } from '@angular/material/list';
import { RouterModule } from '@angular/router';

interface Resume {
  id: number;
  position: string;
  isMain: boolean;
  updated: string;
  views: number;
  status: 'published' | 'draft' | 'archived';
}


@Component({
  selector: 'app-my-resumes',
  imports: [CommonModule,
    MatCardModule,
    MatButtonModule,
    MatIconModule,
    MatListModule,
    RouterModule
],
  templateUrl: './my-resumes.html',
  styleUrl: './my-resumes.css'
})
export class MyResumes {
  resumes: Resume[] = [
    {
      id: 1,
      position: 'Frontend Developer (Angular)',
      isMain: true,
      updated: '2 дня назад',
      views: 24,
      status: 'published'
    },
    {
      id: 2,
      position: 'Fullstack Developer',
      isMain: false,
      updated: '1 неделю назад',
      views: 8,
      status: 'published'
    },
    {
      id: 3,
      position: 'JavaScript Developer',
      isMain: false,
      updated: '1 месяц назад',
      views: 42,
      status: 'archived'
    }
  ];

  getStatusColor(status: string): string {
    switch(status) {
      case 'published': return '#69f0ae';
      case 'draft': return '#ffd740';
      case 'archived': return '#f44336';
      default: return '#bdbdbd';
    }
  }

}
