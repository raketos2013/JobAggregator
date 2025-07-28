import { HttpClient } from "@angular/common/http";
import { inject, Injectable } from "@angular/core";
import { Organization } from "../models/organization";

@Injectable({
    providedIn: 'root',
})
export class OrganizationService{
    private readonly httClient = inject(HttpClient);

    getOrganizations(){
        return this.httClient.get<Organization[]>('https://localhost:7261/api/organizations');
    }

    getOrganizationById(id: number){
        return this.httClient.get<Organization>(`https://localhost:7261/api/organizations/${id}`);
    }
}