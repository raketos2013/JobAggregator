import { Component, inject, OnInit, signal } from '@angular/core';
import { Resume } from '../../../models/resume';
import { ResumeService } from '../../../services/resume-service';
import { Router } from '@angular/router';
import { ResumeFilter } from "../resume-filter/resume-filter";
import { MatPaginatorModule, PageEvent } from '@angular/material/paginator';
import { CommonModule } from '@angular/common';
import { MatCardModule } from '@angular/material/card';
import { ResumeCard } from '../resume-card/resume-card';
import { ResumeSidebar } from '../resume-sidebar/resume-sidebar';

@Component({
  selector: 'app-resumes',
  imports: [ResumeFilter,
    CommonModule,
    MatCardModule,
    MatPaginatorModule,
    ResumeFilter,
    ResumeCard,
    ResumeSidebar
  ],
  templateUrl: './resumes.html',
  styleUrl: './resumes.css'
})
export class Resumes implements OnInit{
  resumes = signal<Resume[]>([]);
  private readonly resumeService = inject(ResumeService);
  private readonly router = inject(Router);


  ngOnInit(): void {
    this.resumeService.getResumes().subscribe((res) => this.resumes.set(res));
  }

  viewResumeDetails(resumeId: number): void{
    this.router.navigate(['/resumes', resumeId]);
  }

  totalItems = 25;
  pageSize = 5;
  currentPage = 0;

  onPageChange(event: PageEvent): void {
    this.currentPage = event.pageIndex;
    this.pageSize = event.pageSize;
    // Здесь будет загрузка данных с API
  }

  onFiltersChange(filters: any): void {
    // Обработка изменения фильтров
    console.log('Applied filters:', filters);
  }

}
