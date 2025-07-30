import { HttpClient } from "@angular/common/http";
import { inject, Injectable } from "@angular/core";
import { Resume } from "../models/resume";

@Injectable({
    providedIn: 'root',
})
export class ResumeService{
    private readonly httClient = inject(HttpClient);

    getResumes(){
        return this.httClient.get<Resume[]>('https://localhost:7261/api/resumes');
    }

    getResumeById(id: number){
        return this.httClient.get<Resume>(`https://localhost:7261/api/resumes/${id}`);
    }
}