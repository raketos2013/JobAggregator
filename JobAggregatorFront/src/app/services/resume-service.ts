import { HttpClient } from "@angular/common/http";
import { inject, Injectable } from "@angular/core";
import { Resume } from "../models/resume";
import { environment } from "../environments/environment";
import { ResumeDTO } from "../models/DTOs/resumeDTO";
import { Router } from "@angular/router";

@Injectable({
    providedIn: 'root',
})
export class ResumeService{
    private readonly httClient = inject(HttpClient);
    private readonly router = inject(Router);

    getResumes(){
        return this.httClient.get<Resume[]>(`${environment.apiUrl}/resumes`);
    }

    getResumeById(id: number){
        return this.httClient.get<Resume>(`${environment.apiUrl}/resumes/${id}`);
    }

    createResume(resume: ResumeDTO){
        this.httClient.post<Resume>(`${environment.apiUrl}/resumes`, resume)
                        .subscribe((res) => {
                            this.router.navigate([`/resumes/${res.id}`]);
                            });
    }

    getUserResumes(userId : number){
        return this.httClient.get<Resume[]>(`${environment.apiUrl}/users/${userId}/resumes`);
    }
}