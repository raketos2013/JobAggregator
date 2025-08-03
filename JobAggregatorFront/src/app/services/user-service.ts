import { HttpClient } from "@angular/common/http";
import { inject, Injectable } from "@angular/core";
import { environment } from "../environments/environment";
import { Router } from "@angular/router";
import { User } from "../models/user";

@Injectable({
    providedIn: 'root',
})
export class UserService{
    private readonly httClient = inject(HttpClient);
    private readonly router = inject(Router);

    getUsers(){
        return this.httClient.get<User[]>(`${environment.apiUrl}/Users`);
    }

    getUserById(id: number){
        return this.httClient.get<User>(`${environment.apiUrl}/users/${id}`);
    }

    // createVacancy(vacancy: VacancyDTO){
    //     this.httClient.post<Vacancy>(`${environment.apiUrl}/Vacancies`, vacancy)
    //           .subscribe((res) => {
    //             this.router.navigate([`/vacancies/${res.id}`]);
    //           });
    // }

    // getSavedVacancies(userId : number){
    //     return this.httClient.get<Vacancy[]>(`${environment.apiUrl}/vacancies`);
    // }
}