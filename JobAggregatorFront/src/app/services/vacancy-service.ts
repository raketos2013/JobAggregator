import { HttpClient } from "@angular/common/http";
import { inject, Injectable } from "@angular/core";
import { Vacancy } from "../models/vacancy";
import { environment } from "../environments/environment";
import { Router } from "@angular/router";
import { VacancyDTO } from "../models/DTOs/vacancyDTO";

@Injectable({
    providedIn: 'root',
})
export class VacancyService{
    private readonly httClient = inject(HttpClient);
    private readonly router = inject(Router);

    getVacancies(){
        return this.httClient.get<Vacancy[]>(`${environment.apiUrl}/vacancies`);
    }

    getVacancyById(id: number){
        return this.httClient.get<Vacancy>(`${environment.apiUrl}/vacancies/${id}`);
    }

    createVacancy(vacancy: VacancyDTO){
        this.httClient.post<Vacancy>(`${environment.apiUrl}/Vacancies`, vacancy)
              .subscribe((res) => {
                this.router.navigate([`/vacancies/${res.id}`]);
              });
    }

    
}