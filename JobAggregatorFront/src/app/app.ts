import { Component, signal } from '@angular/core';
import { Toolbar } from "./toolbar/toolbar";
import { Router, RouterOutlet } from '@angular/router';
import { Navbar } from "./navbar/navbar";
import { Vacancies } from "./pages/vacancies/vacancies/vacancies";
import { VacancyFilter } from './pages/vacancies/vacancy-filter/vacancy-filter';
import { VacancySidebar } from './pages/vacancies/vacancy-sidebar/vacancy-sidebar';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-root',
  imports: [Navbar, Vacancies, VacancyFilter, VacancySidebar, CommonModule],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
  protected title = 'Jobber';

  constructor(private router: Router) {}

  isVacanciesPage(): boolean {
    return this.router.url === '/vacancies';
  }
}
