import { HttpClient } from "@angular/common/http";
import { inject, Injectable } from "@angular/core";
import { Organization } from "../models/organization";

@Injectable({
    providedIn: 'root',
})
export class OrganizationService{
    private readonly httClient = inject(HttpClient);

    getOrganizations(){
        //https://6vw5xwbz-7261.euw.devtunnels.ms
        return this.httClient.get<Organization[]>('https://6vw5xwbz-7261.euw.devtunnels.ms');
        // return this.httClient.get<Organization[]>('https://localhost:7261/api/organizations');
    }

    getOrganizationById(id: number){
        return this.httClient.get<Organization>(`https://6vw5xwbz-7261.euw.devtunnels.ms/${id}`);
        // return this.httClient.get<Organization>(`https://localhost:7261/api/organizations/${id}`);
    }
}