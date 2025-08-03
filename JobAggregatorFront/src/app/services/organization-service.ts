import { HttpClient } from "@angular/common/http";
import { inject, Injectable } from "@angular/core";
import { Organization } from "../models/organization";
import { environment } from "../environments/environment";

@Injectable({
    providedIn: 'root',
})
export class OrganizationService{
    private readonly httClient = inject(HttpClient);

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
}