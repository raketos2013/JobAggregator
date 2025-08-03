import { Component, OnInit } from '@angular/core';
import { User } from '../../../models/user';
import { AuthService } from '../../../services/auth-service';
import { MatTabsModule } from "@angular/material/tabs";
import { ProfileInfo } from '../profile-info/profile-info';
import { ProfileOrganizations } from '../profile-organizations/profile-organizations';
import { ProfileResponses } from '../profile-responses/profile-responses';
import { ProfileResumes } from '../profile-resumes/profile-resumes';
import { RoleRequests } from '../role-requests/role-requests';
import { SavedVacancies } from '../saved-vacancies/saved-vacancies';
import { UserManagement } from '../user-management/user-management';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-profile',
  imports: [MatTabsModule,
            ProfileInfo,
            ProfileOrganizations,
            ProfileResponses,
            ProfileResumes,
            RoleRequests,
            SavedVacancies,
            UserManagement,
            CommonModule
  ],
  templateUrl: './profile.html',
  styleUrl: './profile.css'
})

export class Profile implements OnInit{
  currentUser: User | null = null;
  activeTab: string = 'general';

  constructor(private authService: AuthService) {}

  ngOnInit(): void {
    this.loadUserData();
  }

  loadUserData(): void {
    this.currentUser = this.authService.getUserData();
  }

  changeTab(tab: string): void {
    this.activeTab = tab;
  }

  isAdmin(): boolean {
    return this.currentUser?.role === 'ADMIN';
  }

  isManager(): boolean {
    return this.currentUser?.role === 'MANAGER';
  }
}
