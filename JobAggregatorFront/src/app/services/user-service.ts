import { HttpClient } from "@angular/common/http";
import { inject, Injectable } from "@angular/core";
import { environment } from "../environments/environment";
import { Router } from "@angular/router";
import { User } from "../models/user";
import { Vacancy } from "../models/vacancy";
import { UserIdDTO } from "../models/DTOs/userIdDTO";
import { CreateUserDTO } from "../models/DTOs/create-userDTO";
import { AuthService } from "./auth-service";

@Injectable({
    providedIn: 'root',
})
export class UserService{
    private readonly httClient = inject(HttpClient);
    private readonly router = inject(Router);
    private readonly authService = inject(AuthService)

    getUsers(){
        return this.httClient.get<UserIdDTO[]>(`${environment.apiUrl}/Users`);
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

    saveVacancy(vacancyId : number|undefined, userId : number){
        return this.httClient.get<User>(`${environment.apiUrl}/users/${userId}/SaveVacancy/${vacancyId}`);
    }

    unsaveVacancy(vacancyId : number|undefined, userId : number){
        return this.httClient.get<boolean>(`${environment.apiUrl}/users/${userId}/DeleteVacancy/${vacancyId}`);
    }

    getSavedVacancies(userId : number){
        return this.httClient.get<Vacancy[]>(`${environment.apiUrl}/users/${userId}/savedVacancies`);
    }

    createUser(userDTO: CreateUserDTO){
        this.httClient.post<User>(`${environment.apiUrl}/users`, userDTO)
                            .subscribe((res) => {
                                this.authService.login(userDTO.login, userDTO.password)
                                this.router.navigate([`/`])
                            })
    }
    
    userManager(id: number){
        return this.httClient.get<User>(`${environment.apiUrl}/users/${id}/userManager`);
    }

    requestManagerRole(){
        let user = this.authService.getUserData()
        let id: number;
        if (user == null) 
            id = 0
        else
            id =  user.id
        return this.httClient.get<User>(`${environment.apiUrl}/users/${id}/requestManager`);
    }


}