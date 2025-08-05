import { Component, EventEmitter, inject, Input, Output } from '@angular/core';
import { Resume } from '../../../models/resume';
import { CommonModule } from '@angular/common';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { MatChipsModule } from '@angular/material/chips';
import { MatIconModule } from '@angular/material/icon';
import { Router } from '@angular/router';

@Component({
  selector: 'app-resume-card',
  imports: [CommonModule,
            MatCardModule,
            MatButtonModule,
            MatIconModule,
            MatChipsModule],
  templateUrl: './resume-card.html',
  styleUrl: './resume-card.css'
})
export class ResumeCard {
  @Input() resume!: Resume;
  @Output() viewDetailsClicked = new EventEmitter<number>();

  private readonly router = inject(Router);

  viewDetailsResume(event: MouseEvent): void {
    event.stopPropagation();
    this.viewDetailsClicked.emit(this.resume.id);
    this.router.navigate(['/resumes', this.resume.id]);
  }


}
