import { Component, inject, OnInit, signal } from '@angular/core';
import { MatIconModule } from "@angular/material/icon";
import { MatProgressSpinnerModule } from "@angular/material/progress-spinner";
import { MatExpansionModule } from "@angular/material/expansion";
import { RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';
import { MatButtonModule } from '@angular/material/button';
import { Resume } from '../../../models/resume';
import { ResumeService } from '../../../services/resume-service';
import { AuthService } from '../../../services/auth-service';

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
  resumes = signal<Resume[]>([]);
  loading = true;

  private readonly resumeService = inject(ResumeService)
  private readonly authService = inject(AuthService)

  ngOnInit(): void {
    this.loadResumes();
  }

  loadResumes(): void {
    let user = this.authService.getUserData();
    if(user == null){
      this.loading = false;
      return;
    }
    
    this.resumeService.getUserResumes(user.id).subscribe({
      next: (resumes) => {
        this.resumes.set(resumes);
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
