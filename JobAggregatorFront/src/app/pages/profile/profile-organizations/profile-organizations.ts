import { Component, OnInit } from '@angular/core';
import { MatProgressSpinnerModule } from "@angular/material/progress-spinner";
import { MatCardModule } from "@angular/material/card";
import { MatIconModule } from "@angular/material/icon";
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { MatButtonModule } from '@angular/material/button';
import { OrganizationService } from '../../../services/organization-service';
import { Organization } from '../../../models/organization';

@Component({
  selector: 'app-profile-organizations',
  imports: [MatProgressSpinnerModule,
            MatCardModule, 
            MatIconModule,
            CommonModule,
            RouterModule,
            MatButtonModule],
  templateUrl: './profile-organizations.html',
  styleUrl: './profile-organizations.css'
})
export class ProfileOrganizations implements OnInit{
  organizations: Organization[] = [];
  loading = true;

  constructor(private organizationService: OrganizationService) {}

  ngOnInit(): void {
    this.loadOrganizations();
  }

  loadOrganizations(): void {
    this.organizationService.getUserOrganizations().subscribe({
      next: (orgs) => {
        this.organizations = orgs;
        this.loading = false;
      },
      error: (err) => {
        console.error('Error loading organizations', err);
        this.loading = false;
      }
    });
  }
}
