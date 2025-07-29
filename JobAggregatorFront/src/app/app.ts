import { Component, signal } from '@angular/core';
import { Toolbar } from "./toolbar/toolbar";
import { Router, RouterOutlet, RouterModule } from '@angular/router';
import { Navbar } from "./navbar/navbar";
import { Vacancies } from "./pages/vacancies/vacancies/vacancies";
import { VacancyFilter } from './pages/vacancies/vacancy-filter/vacancy-filter';
import { VacancySidebar } from './pages/vacancies/vacancy-sidebar/vacancy-sidebar';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-root',
  imports: [Navbar, CommonModule, RouterModule],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
  protected title = 'Jobber';

  constructor(private router: Router) {}


}
