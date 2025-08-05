import { Component } from '@angular/core';
import { VacancyFilter } from "../vacancy-filter/vacancy-filter";
import { Vacancies } from "../vacancies/vacancies";
import { VacancySidebar } from "../vacancy-sidebar/vacancy-sidebar";
import { CommonModule } from '@angular/common';
import { Router } from '@angular/router';

@Component({
  selector: 'app-vacancy-main',
  imports: [VacancyFilter, Vacancies, VacancySidebar, CommonModule],
  templateUrl: './vacancy-main.html',
  styleUrl: './vacancy-main.css'
})
export class VacancyMain {
  constructor(private router: Router) {}
  
  isVacanciesPage(): boolean {
    return this.router.url === '/vacancies';
  }
}
