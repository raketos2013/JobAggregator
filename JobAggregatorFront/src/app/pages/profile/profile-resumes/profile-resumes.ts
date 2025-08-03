import { Component, OnInit } from '@angular/core';
import { MatIconModule } from "@angular/material/icon";
import { MatProgressSpinnerModule } from "@angular/material/progress-spinner";
import { MatExpansionModule } from "@angular/material/expansion";
import { RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';
import { MatButtonModule } from '@angular/material/button';
import { Resume } from '../../../models/resume';
import { ResumeService } from '../../../services/resume-service';

@Component({
  selector: 'app-profile-resumes',
  imports: [MatIconModule, 
            MatProgressSpinnerModule, 
            MatExpansionModule,
            RouterModule,
            CommonModule,
            MatButtonModule],
  templateUrl: './profile-resumes.html',
  styleUrl: './profile-resumes.css'
})
export class ProfileResumes implements OnInit{
  resumes: Resume[] = [];
  loading = true;

  constructor(private resumeService: ResumeService) {}

  ngOnInit(): void {
    this.loadResumes();
  }

  loadResumes(): void {
    this.resumeService.getUserResumes().subscribe({
      next: (resumes) => {
        this.resumes = resumes;
        this.loading = false;
      },
      error: (err) => {
        console.error('Error loading resumes', err);
        this.loading = false;
      }
    });
  }

  deleteResume(id: number): void {
    // this.resumeService.deleteResume(id).subscribe({
    //   next: () => {
    //     this.resumes = this.resumes.filter(r => r.id !== id);
    //   },
    //   error: (err) => console.error('Error deleting resume', err)
    // });
  }
}
