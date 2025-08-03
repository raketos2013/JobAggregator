import { HttpClient } from "@angular/common/http";
import { inject, Injectable } from "@angular/core";
import { environment } from "../environments/environment";
import { Router } from "@angular/router";
import { UserApplication } from "../models/user-application";

@Injectable({
    providedIn: 'root',
})
export class ApplicationService{
    private readonly httClient = inject(HttpClient);
    private readonly router = inject(Router);

    getUserApplications(){
        // return this.httClient.get<UserApplication[]>(`${environment.apiUrl}/vacancies`);
        return [];
    }

    // getVacancyById(id: number){
    //     return this.httClient.get<Vacancy>(`${environment.apiUrl}/vacancies/${id}`);
    // }

    // createVacancy(vacancy: VacancyDTO){
    //     this.httClient.post<Vacancy>(`${environment.apiUrl}/Vacancies`, vacancy)
    //           .subscribe((res) => {
    //             this.router.navigate([`/vacancies/${res.id}`]);
    //           });
    // }

   
}