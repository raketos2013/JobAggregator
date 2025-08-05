import { Component, inject, OnInit } from '@angular/core';
import { MatProgressSpinnerModule } from "@angular/material/progress-spinner";
import { MatCardModule } from "@angular/material/card";
import { MatIconModule } from "@angular/material/icon";
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { MatButtonModule } from '@angular/material/button';
import { OrganizationService } from '../../../services/organization-service';
import { Organization } from '../../../models/organization';
import { OrganizationUsersDTO } from '../../../models/DTOs/organization-usersDTO';
import { AuthService } from '../../../services/auth-service';

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
  private readonly authService = inject(AuthService)
  organizations: OrganizationUsersDTO[] = [];
  loading = true;

  constructor(private organizationService: OrganizationService) {}

  ngOnInit(): void {
    this.loadOrganizations();
  }

  loadOrganizations(): void {
    let user = this.authService.getUserData()
    if (user == null) return
    this.organizationService.getUserOrganizations(user.id).subscribe({
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
