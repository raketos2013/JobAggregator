import { CommonModule } from '@angular/common';
import { Component, inject, OnInit, signal } from '@angular/core';
import { VacancyCard } from '../vacancy-card/vacancy-card';
import { Vacancy } from '../models/vacancy';
import { VacancyService } from '../services/vacancy-service';
import { MatGridListModule } from '@angular/material/grid-list';

@Component({
  selector: 'app-vacancy-list',
  imports: [CommonModule, 
            VacancyCard,
            MatGridListModule],
  templateUrl: './vacancy-list.html',
  styleUrl: './vacancy-list.css'
})
export class VacancyList implements OnInit {
  //vacancies: Vacancy[] = [];
  vacancies = signal<Vacancy[]>([]);
  private readonly vacancyService = inject(VacancyService);

  ngOnInit(): void{
    this.vacancyService.getVacancies().subscribe((res) => this.vacancies.set(res));
  }

}