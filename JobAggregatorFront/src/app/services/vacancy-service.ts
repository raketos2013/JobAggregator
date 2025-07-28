import { HttpClient } from "@angular/common/http";
import { inject, Injectable } from "@angular/core";
import { Vacancy } from "../models/vacancy";

@Injectable({
    providedIn: 'root',
})
export class VacancyService{
    private readonly httClient = inject(HttpClient);

    getVacancies(){
        return this.httClient.get<Vacancy[]>('https://localhost:7261/api/vacancies');
    }

    getVacancyById(id: number){
        return this.httClient.get<Vacancy>(`https://localhost:7261/api/vacancies/${id}`);
    }
}