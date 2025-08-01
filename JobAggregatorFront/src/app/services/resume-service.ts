import { HttpClient } from "@angular/common/http";
import { inject, Injectable } from "@angular/core";
import { Resume } from "../models/resume";
import { environment } from "../environments/environment";

@Injectable({
    providedIn: 'root',
})
export class ResumeService{
    private readonly httClient = inject(HttpClient);

    getResumes(){
        return this.httClient.get<Resume[]>(`${environment.apiUrl}/resumes`);
    }

    getResumeById(id: number){
        return this.httClient.get<Resume>(`${environment.apiUrl}/resumes/${id}`);
    }
}