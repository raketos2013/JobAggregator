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
import { UserService } from '../../../services/user-service';
import { MatSnackBar, MatSnackBarModule } from '@angular/material/snack-bar';

@Component({
  selector: 'app-card-vacancy',
  imports: [MatIconModule,
    MatCardModule,
    MatChipsModule,
    MatPaginatorModule,
    CommonModule,
    MatButtonModule,
    RouterModule,
    MatSnackBarModule
  ],
  templateUrl: './card-vacancy.html',
  styleUrl: './card-vacancy.css'
})
export class CardVacancy {
  public authService = inject(AuthService)
  public userService = inject(UserService)
  
  @Input() vacancy!: Vacancy;

  @Output() viewDetailsClicked = new EventEmitter<number>();

  constructor(
    private router: Router, 
    private snackBar: MatSnackBar
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

  saveVacancy(){
    let user = this.authService.getUserData();
    
    if(user != null){
      console.log("222222----"+user.id)
      this.userService.saveVacancy(this.vacancy.id, user.id)
                      .subscribe((res) => {
                                  this.showNotification();
                                });;
    }
      
  }

  private showNotification(): void {
      this.snackBar.open('Вакансия сохранена', 'Закрыть', {
        duration: 5000, // Автоматически закроется через 5 секунд
        panelClass: ['success-snackbar']
      });
    }
}
