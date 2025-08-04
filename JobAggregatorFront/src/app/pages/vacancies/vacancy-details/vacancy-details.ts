import { Component, inject, Input, OnInit, signal } from '@angular/core';
import { ActivatedRoute, RouterModule } from '@angular/router';
import { VacancyService } from '../../../services/vacancy-service';
import { Vacancy } from '../../../models/vacancy';
import { CommonModule } from '@angular/common';
import { MatCardModule } from '@angular/material/card';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { MatChipsModule } from '@angular/material/chips';
import { MatDividerModule } from '@angular/material/divider';
import { OrganizationService } from '../../../services/organization-service';
import { Organization } from '../../../models/organization';
import { AuthService } from '../../../services/auth-service';
import { UserService } from '../../../services/user-service';
import { User } from '../../../models/user';

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
export class VacancyDetails implements OnInit{
  public authService = inject(AuthService)
    public userService = inject(UserService)
    
    private readonly vacancyService = inject(VacancyService)
    private readonly organizationService = inject(OrganizationService)
    private readonly route = inject(ActivatedRoute);
    @Input() vacancyId?: number;
    vacancy = signal<Vacancy>({} as Vacancy);

    user = signal<User>({} as User);

    organization = signal<Organization>({} as Organization);

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
        this.organizationService.getOrganizationById(res.organizationId).subscribe((res) => {
          this.organization.set(res)
        })
      });
      
    }
  }

  saveVacancy(){
    let user = this.authService.getUserData();
    console.log("222222")
    if(user != null)
      this.userService.saveVacancy(this.vacancyId, user.id).subscribe((res) => {this.user.set(res)});
  }

  applyForVacancy(): void {
    console.log('Applying for vacancy:', this.vacancyId);
    // Здесь будет логика отклика на вакансию
  }
}
