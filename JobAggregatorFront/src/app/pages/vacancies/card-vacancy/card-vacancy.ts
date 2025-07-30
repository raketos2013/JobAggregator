import { Component, EventEmitter, inject, Input, Output } from '@angular/core';
import { Vacancy } from '../../../models/vacancy';
import { MatIconModule } from "@angular/material/icon";
import { MatCardModule } from '@angular/material/card';
import { MatChipsModule } from '@angular/material/chips';
import { MatPaginatorModule } from '@angular/material/paginator';
import { CommonModule } from '@angular/common';
import { MatButtonModule } from '@angular/material/button';
import { Router, RouterModule } from '@angular/router';
import { AuthService } from '../../../services/auth-service';

@Component({
  selector: 'app-card-vacancy',
  imports: [MatIconModule,
    MatCardModule,
    MatChipsModule,
    MatPaginatorModule,
    CommonModule,
    MatButtonModule,
    RouterModule
  ],
  templateUrl: './card-vacancy.html',
  styleUrl: './card-vacancy.css'
})
export class CardVacancy {
  public authService = inject(AuthService);
  @Input() vacancy!: Vacancy;

   @Output() viewDetailsClicked = new EventEmitter<number>();

  constructor(
    private router: Router 
  ) {}

  handleCardClick(event: MouseEvent): void {
    // Переход только если клик был не по кнопке
    if (!(event.target as HTMLElement).closest('button')) {
      this.viewDetailsClicked.emit(this.vacancy.id);
    }
  }

  viewDetails(event: MouseEvent): void {
    event.stopPropagation();
    this.viewDetailsClicked.emit(this.vacancy.id);
    this.router.navigate(['/vacancies', this.vacancy.id]);
  }


  //@Output() favoriteToggled = new EventEmitter<number>();

  // toggleFavorite(): void {
  //   this.favoriteToggled.emit(this.vacancy.id);
  // }
}
