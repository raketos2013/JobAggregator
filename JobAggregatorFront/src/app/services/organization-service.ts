import { HttpClient } from "@angular/common/http";
import { inject, Injectable } from "@angular/core";
import { Organization } from "../models/organization";
import { environment } from "../environments/environment";
import { OrganizationDTO } from "../models/DTOs/organizationDTO";
import { Router } from "@angular/router";
import { CreateOrganizationDTO } from "../models/DTOs/create-organizationDTO";

@Injectable({
    providedIn: 'root',
})
export class OrganizationService{
    private readonly httClient = inject(HttpClient);
    private readonly router = inject(Router);

    getOrganizations(){
        //https://6vw5xwbz-7261.euw.devtunnels.ms
        return this.httClient.get<Organization[]>(`${environment.apiUrl}/organizations`);
    }

    getOrganizationById(id: number){
        return this.httClient.get<Organization>(`${environment.apiUrl}/organizations/${id}`);
    }

    getUserOrganizations(){
        return this.httClient.get<Organization[]>(`${environment.apiUrl}/organizations`);
    }

    createOrganization(organization: OrganizationDTO, userId: number){
        let createOrganizationDTO: CreateOrganizationDTO = {
            organization: organization,
            userId: userId
        }
        console.log('@@@@@@@@@@@@@@@@')
        console.log(createOrganizationDTO)
        this.httClient.post<Organization>(`${environment.apiUrl}/organizations`, createOrganizationDTO)
            .subscribe((res) => {
                this.router.navigate([`/organizations/${res.id}`])
            })
    }
}