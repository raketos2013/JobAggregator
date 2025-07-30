import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { MatCardModule } from '@angular/material/card';
import { MatListModule } from '@angular/material/list';

@Component({
  selector: 'app-resume-sidebar',
  imports: [CommonModule, MatCardModule, MatListModule],
  templateUrl: './resume-sidebar.html',
  styleUrl: './resume-sidebar.css'
})
export class ResumeSidebar {
  newsItems = [
    {
      title: 'Новые тенденции в IT-рекрутинге',
      date: '15 мая 2023',
      excerpt: 'Как изменился рынок труда за последний год'
    },
    {
      title: 'Самые востребованные навыки 2023',
      date: '10 мая 2023',
      excerpt: 'Топ-10 технологий, которые стоит изучить'
    },
    {
      title: 'Как правильно составить резюме',
      date: '5 мая 2023',
      excerpt: 'Советы от HR-экспертов'
    }
  ];
}
