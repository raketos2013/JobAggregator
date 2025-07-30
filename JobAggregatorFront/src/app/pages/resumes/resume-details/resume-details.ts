import { Component, inject, Input, OnInit, signal } from '@angular/core';
import { Resume } from '../../../models/resume';
import { ActivatedRoute } from '@angular/router';
import { ResumeService } from '../../../services/resume-service';
import { CommonModule } from '@angular/common';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { MatChipsModule } from '@angular/material/chips';
import { MatDividerModule } from '@angular/material/divider';
import { MatIconModule } from '@angular/material/icon';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';

@Component({
  selector: 'app-resume-details',
  imports: [CommonModule,
            MatCardModule,
            MatButtonModule,
            MatIconModule,
            MatDividerModule,
            MatChipsModule,
            MatProgressSpinnerModule],
  templateUrl: './resume-details.html',
  styleUrl: './resume-details.css'
})
export class ResumeDetails implements OnInit {
  ngOnInit(): void {
    throw new Error('Method not implemented.');
  }
private readonly resumeService = inject(ResumeService)
    private readonly route = inject(ActivatedRoute);
    @Input() resumeId?: number;
    resume = signal<Resume>({} as Resume);
    isLoading = false;
}
