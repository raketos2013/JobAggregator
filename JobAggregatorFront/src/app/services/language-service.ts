import { HttpClient } from "@angular/common/http";
import { inject, Injectable } from "@angular/core";
import { Language } from "../models/language";
import { environment } from "../environments/environment";
import { Router } from "@angular/router";

@Injectable({
    providedIn: 'root',
})
export class LanguageService{
    private readonly httClient = inject(HttpClient);
    private readonly router = inject(Router);

    getLanguages(){
        return this.httClient.get<Language[]>(`${environment.apiUrl}/languages`);
    }
    
    getLanguageById(id: number){
        return this.httClient.get<Language>(`${environment.apiUrl}/languages/${id}`);
    }
}