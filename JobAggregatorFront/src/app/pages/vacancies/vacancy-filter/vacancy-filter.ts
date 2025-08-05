import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { MatExpansionModule } from '@angular/material/expansion';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { MatListModule } from '@angular/material/list';
import { MatRadioModule } from '@angular/material/radio';
import { MatSliderModule } from '@angular/material/slider';

@Component({
  selector: 'app-vacancy-filter',
  imports: [  CommonModule,
    MatCardModule,
    MatFormFieldModule,
    MatInputModule,
    MatIconModule,
    MatExpansionModule,
    MatRadioModule,
    MatSliderModule,
    MatListModule,
    MatButtonModule,],
  templateUrl: './vacancy-filter.html',
  styleUrl: './vacancy-filter.css'
})
export class VacancyFilter {
  experienceOptions = [
    { value: 'no', label: 'Нет опыта' },
    { value: '1-3', label: '1-3 года' },
    { value: '3-5', label: '3-5 лет' },
    { value: '5+', label: 'Более 5 лет' }
  ];

  employmentTypes = [
    { value: 'full', label: 'Полная занятость' },
    { value: 'part', label: 'Частичная занятость' },
    { value: 'remote', label: 'Удалённая работа' },
    { value: 'project', label: 'Проектная работа' }
  ];
}
