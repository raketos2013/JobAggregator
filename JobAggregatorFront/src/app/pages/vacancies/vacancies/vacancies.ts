import { Component, inject, OnInit, signal } from '@angular/core';
import { Vacancy } from '../../../models/vacancy';
import { VacancyService } from '../../../services/vacancy-service';
import { MatPaginatorModule } from '@angular/material/paginator';
import { CardVacancy } from '../card-vacancy/card-vacancy';
import { MatCardModule } from '@angular/material/card';
import { MatChipsModule } from '@angular/material/chips';
import { MatIconModule } from "@angular/material/icon";
import { CommonModule } from '@angular/common';
import { Router } from '@angular/router';
import { MatButtonModule } from '@angular/material/button';

@Component({
  selector: 'app-vacancies',
  imports: [CardVacancy,
            MatCardModule,
            MatChipsModule,
            MatPaginatorModule, 
            MatIconModule, 
            CommonModule,
            MatButtonModule],
  templateUrl: './vacancies.html',
  styleUrl: './vacancies.css'
})
export class Vacancies implements OnInit{
  vacancies = signal<Vacancy[]>([]);
  private readonly vacancyService = inject(VacancyService);
  //private readonly router = inject(Router);


   constructor(
    private router: Router 
  ) {}

  ngOnInit(): void{
    this.vacancyService.getVacancies().subscribe((res) => this.vacancies.set(res));
    console.log(this.vacancies());
  }



  viewVacancyDetails(vacancyId: number): void {
    this.router.navigate(['/vacancies', vacancyId]);
  }

  // onFavoriteToggle(vacancyId: number): void {
  //   this.vacancyService.toggleFavorite(vacancyId);
  // }

}
