import { HttpClient } from "@angular/common/http";
import { inject, Injectable } from "@angular/core";
import { Vacancy } from "../models/vacancy";
import { environment } from "../environments/environment";

@Injectable({
    providedIn: 'root',
})
export class VacancyService{
    private readonly httClient = inject(HttpClient);

    getVacancies(){
        return this.httClient.get<Vacancy[]>(`${environment.apiUrl}/vacancies`);
    }

    getVacancyById(id: number){
        return this.httClient.get<Vacancy>(`${environment.apiUrl}/vacancies/${id}`);
    }
}