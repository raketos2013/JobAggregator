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
import { Gender } from '../../../models/enums/gender';

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
  loading = true;
  @Input() resumeId?: number;
  resume = signal<Resume>({} as Resume);

  constructor(
    private route: ActivatedRoute,
    private resumeService: ResumeService
  ) {}

  ngOnInit(): void {
    if (!this.resumeId) {
        this.resumeId = +this.route.snapshot.paramMap.get('id')!;
      }
      this.loadResume();
  }

  loadResume(): void {
    if (this.resumeId) {
      this.resumeService.getResumeById(this.resumeId).subscribe((res) => {
        this.resume.set(res);
      });
    }
  }

  getGenderString(gender: Gender): string {
    const genderMap: Record<Gender, string> = {
      [Gender.Male]: 'Мужской',
      [Gender.Female]: 'Женский'
    };
    return genderMap[gender] || 'Не указан';
  }

  parseLinks(linksString: string | null): string[] {
    if(linksString == null) return [];
    try {
      return linksString.split('\n').filter(link => link.trim());
    } catch {
      return [];
    }
  }

  contactUser(): void {
    // Логика связи с пользователем
    console.log('Инициация контакта с пользователем', this.resume()?.userId);
  }

}
