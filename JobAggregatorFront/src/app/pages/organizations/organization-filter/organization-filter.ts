import { Component, EventEmitter, Output } from '@angular/core';
import { MatCardModule } from "@angular/material/card";
import { MatInputModule } from "@angular/material/input";
import { MatExpansionModule } from "@angular/material/expansion";
import { MatListModule } from "@angular/material/list";
import { CommonModule } from '@angular/common';
import { MatRadioModule } from "@angular/material/radio";
import { MatCheckboxModule } from "@angular/material/checkbox";
import { MatButtonModule } from '@angular/material/button';

@Component({
  selector: 'app-organization-filter',
  imports: [MatCardModule, 
            MatInputModule, 
            MatExpansionModule, 
            MatListModule, 
            CommonModule, 
            MatRadioModule, 
            MatCheckboxModule,
            MatButtonModule],
  templateUrl: './organization-filter.html',
  styleUrl: './organization-filter.css'
})
export class OrganizationFilter {
  @Output() filtersChanged = new EventEmitter<any>();
  
  filters = {
    search: '',
    industries: [] as string[],
    location: '',
    companySize: '',
    hasVacancies: false,
    hiringNow: false
  };

  industryOptions = [
    'IT и технологии',
    'Финансы и банкинг',
    'Медицина и фармацевтика',
    'Розничная торговля',
    'Производство',
    'Образование',
    'Маркетинг и реклама',
    'Строительство'
  ];

  companySizeOptions = [
    'Малый бизнес (1-50)',
    'Средний бизнес (50-500)',
    'Крупный бизнес (500+)',
    'Корпорация (5000+)'
  ];

  applyFilters(): void {
    this.filtersChanged.emit(this.filters);
  }

  resetFilters(): void {
    this.filters = {
      search: '',
      industries: [],
      location: '',
      companySize: '',
      hasVacancies: false,
      hiringNow: false
    };
    this.filtersChanged.emit(this.filters);
  }

}
