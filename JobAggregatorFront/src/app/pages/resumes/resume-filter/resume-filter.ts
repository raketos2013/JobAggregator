import { CommonModule } from '@angular/common';
import { Component, EventEmitter, Output } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { MatExpansionModule } from '@angular/material/expansion';
import { MatInputModule } from '@angular/material/input';
import {MatSelectModule} from '@angular/material/select';
import {MatCheckboxModule} from '@angular/material/checkbox';
import { MatSliderModule } from "@angular/material/slider";
import { MatRadioModule } from "@angular/material/radio";
import { MatListModule } from "@angular/material/list";

@Component({
  selector: 'app-resume-filter',
  imports: [CommonModule,
    FormsModule,
    MatCardModule,
    MatInputModule,
    MatSelectModule,
    MatCheckboxModule,
    MatButtonModule,
    MatExpansionModule, MatSliderModule, MatRadioModule, MatListModule],
  templateUrl: './resume-filter.html',
  styleUrl: './resume-filter.css'
})
export class ResumeFilter {
  @Output() filtersChanged = new EventEmitter<any>();

  filters = {
    search: '',
    salaryRange: [0, 300000],
    experience: '',
    skills: [] as string[],
    location: ''
  };

  experienceOptions = [
    'Нет опыта',
    '1-3 года',
    '3-5 лет',
    'Более 5 лет'
  ];

  skillOptions = [
    'Angular',
    'React',
    'TypeScript',
    'JavaScript',
    'Node.js',
    'HTML/CSS'
  ];

  applyFilters(): void {
    this.filtersChanged.emit(this.filters);
  }

  resetFilters(): void {
    this.filters = {
      search: '',
      salaryRange: [0, 300000],
      experience: '',
      skills: [],
      location: ''
    };
    this.filtersChanged.emit(this.filters);
  }

}
