import { Component, inject, Input, signal } from '@angular/core';
import { ActivatedRoute, RouterModule } from '@angular/router';
import { VacancyService } from '../../../services/vacancy-service';
import { Vacancy } from '../../../models/vacancy';
import { CommonModule } from '@angular/common';
import { MatCardModule } from '@angular/material/card';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { MatChipsModule } from '@angular/material/chips';
import { MatDividerModule } from '@angular/material/divider';

@Component({
  selector: 'app-vacancy-details',
  imports: [ CommonModule,
    MatCardModule,
    MatIconModule,
    MatButtonModule,
    MatChipsModule,
    MatDividerModule,
  RouterModule],
  templateUrl: './vacancy-details.html',
  styleUrl: './vacancy-details.css'
})
export class VacancyDetails {
    private readonly vacancyService = inject(VacancyService)
    private readonly route = inject(ActivatedRoute);
    @Input() vacancyId?: number;
    vacancy = signal<Vacancy>({} as Vacancy);

    // ngOnInit(): void {
    //   const vacancyId = Number(this.route.snapshot.paramMap.get('id'))
    //   this.vacancyService.getVacancyById(vacancyId).subscribe((res) => {
    //     this.vacancy.set(res);
    //   });
    // }

    ngOnInit(): void {
    if (!this.vacancyId) {
      this.vacancyId = +this.route.snapshot.paramMap.get('id')!;
    }
    this.loadVacancy();
  }

  loadVacancy(): void {
    if (this.vacancyId) {
      this.vacancyService.getVacancyById(this.vacancyId).subscribe((res) => {
        this.vacancy.set(res);
      });
    }
  }

  applyForVacancy(): void {
    console.log('Applying for vacancy:', this.vacancyId);
    // Здесь будет логика отклика на вакансию
  }
}
