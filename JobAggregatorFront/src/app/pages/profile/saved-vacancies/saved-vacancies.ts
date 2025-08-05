import { Component, inject, OnInit, signal } from '@angular/core';
import { MatProgressSpinnerModule } from "@angular/material/progress-spinner";
import { MatCardModule } from "@angular/material/card";
import { MatIconModule } from "@angular/material/icon";
import { CommonModule } from '@angular/common';
import { VacancyService } from '../../../services/vacancy-service';
import { Vacancy } from '../../../models/vacancy';
import { Router, RouterModule } from '@angular/router';
import { MatButtonModule } from '@angular/material/button';
import { UserService } from '../../../services/user-service';
import { AuthService } from '../../../services/auth-service';

@Component({
  selector: 'app-saved-vacancies',
  imports: [MatProgressSpinnerModule, 
            MatCardModule, 
            MatIconModule,
            CommonModule,
            MatButtonModule,
            RouterModule],
  templateUrl: './saved-vacancies.html',
  styleUrl: './saved-vacancies.css'
})
export class SavedVacancies implements OnInit{
  vacancies = signal<Vacancy[]>([]);
  loading = true;

  private readonly userService = inject(UserService);
  private readonly authService = inject(AuthService)

  ngOnInit(): void {
    this.loadSavedVacancies();
  }

  loadSavedVacancies(): void {
    let user = this.authService.getUserData();
    if(user == null) return;
    this.userService.getSavedVacancies(user.id).subscribe({
      next: (vacancies) => {
        this.vacancies.set(vacancies);
        this.loading = false;
      },
      error: (err) => {
        console.error('Error loading vacancies', err);
        this.loading = false;
      }
    });
  }

  removeVacancy(vacancyId: number): void {
    let user = this.authService.getUserData();
    if(user == null) return;
    this.userService.unsaveVacancy(vacancyId, user.id).subscribe({
      next: () => {
        this.loadSavedVacancies()
      },
      error: (err) => console.error('Error removing vacancy', err)
    });
  }

}
