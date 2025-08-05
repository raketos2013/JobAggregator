import { HttpClient } from "@angular/common/http";
import { inject, Injectable, signal } from "@angular/core";
import { Organization } from "../models/organization";
import { environment } from "../environments/environment";
import { OrganizationDTO } from "../models/DTOs/organizationDTO";
import { Router } from "@angular/router";
import { CreateOrganizationDTO } from "../models/DTOs/create-organizationDTO";
import { OrganizationUsersDTO } from "../models/DTOs/organization-usersDTO";

@Injectable({
    providedIn: 'root',
})
export class OrganizationService{
    private readonly httClient = inject(HttpClient);
    private readonly router = inject(Router);
    organizationId = signal<number>(0);

    getOrganizations(){
        return this.httClient.get<Organization[]>(`${environment.apiUrl}/organizations`);
    }

    getOrganizationById(id: number){
        return this.httClient.get<OrganizationUsersDTO>(`${environment.apiUrl}/organizations/${id}`);
    }

    getUserOrganizations(id: number){
        return this.httClient.get<OrganizationUsersDTO[]>(`${environment.apiUrl}/organizations/user/${id}`);
    }

    createOrganization(organization: OrganizationDTO, userId: number){
        let createOrganizationDTO: CreateOrganizationDTO = {
            organization: organization,
            userId: userId
        }
        this.httClient.post<Organization>(`${environment.apiUrl}/organizations`, createOrganizationDTO)
            .subscribe((res) => {
                this.router.navigate([`/organizations/${res.id}`])
            })
    }
}