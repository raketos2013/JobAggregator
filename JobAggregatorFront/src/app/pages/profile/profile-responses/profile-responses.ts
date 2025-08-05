import { Component, OnInit } from '@angular/core';
import { MatProgressSpinnerModule } from "@angular/material/progress-spinner";
import { MatExpansionModule } from "@angular/material/expansion";
import { MatCardModule } from "@angular/material/card";
import { MatIconModule } from "@angular/material/icon";
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { MatButtonModule } from '@angular/material/button';
import { UserApplication } from '../../../models/user-application';
import { ApplicationService } from '../../../services/application-service';
import { ApplicationStatus } from '../../../models/enums/application-status';

@Component({
  selector: 'app-profile-responses',
  imports: [MatProgressSpinnerModule, 
            MatExpansionModule, 
            MatCardModule, 
            MatIconModule,
            CommonModule,
            RouterModule,
            MatButtonModule],
  templateUrl: './profile-responses.html',
  styleUrl: './profile-responses.css'
})
export class ProfileResponses implements OnInit{
  applications: UserApplication[] = [];
  loading = true;

  constructor(private applicationService: ApplicationService) {}

  ngOnInit(): void {
    this.loadApplications();
  }

  loadApplications(): void {
    // this.applicationService.getUserApplications().subscribe({
    //   next: (apps) => {
    //     this.applications = apps;
    //     this.loading = false;
    //   },
    //   error: (err) => {
    //     console.error('Error loading applications', err);
    //     this.loading = false;
    //   }
    // });
  }

  getStatusText(status: ApplicationStatus){
    const statusMap: Record<ApplicationStatus, string> = {
          [ApplicationStatus.Sent]: 'Отправлена',
          [ApplicationStatus.Reviewed]: 'Рассмотрена',
          [ApplicationStatus.Confirmed]: 'Подтверждена',
          [ApplicationStatus.Rejected]: 'Отклонена'
        };
        return statusMap[status] || 'Не указан';
  }

  withdrawApplication(id: number): void {
    // this.applicationService.withdrawApplication(id).subscribe({
    //   next: () => {
    //     this.applications = this.applications.filter(a => a.id !== id);
    //   },
    //   error: (err) => console.error('Error withdrawing application', err)
    // });
  }
}
