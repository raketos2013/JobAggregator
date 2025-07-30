import { Component, Input } from '@angular/core';
import { Resume } from '../../../models/resume';
import { CommonModule } from '@angular/common';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { MatChipsModule } from '@angular/material/chips';
import { MatIconModule } from '@angular/material/icon';

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
}
