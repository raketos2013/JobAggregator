import { Component, inject, OnInit, signal } from '@angular/core';
import { OrganizationFilter } from '../organization-filter/organization-filter';
import { OrganizationCard } from '../organization-card/organization-card';
import { Organization } from '../../../models/organization';
import { MatIconModule } from "@angular/material/icon";
import { MatProgressSpinnerModule } from "@angular/material/progress-spinner";
import { OrganizationService } from '../../../services/organization-service';
import { Subscription } from 'rxjs/internal/Subscription';
import { AuthService } from '../../../services/auth-service';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-organizations',
  imports: [OrganizationFilter,
            OrganizationCard, 
            MatIconModule, 
            MatProgressSpinnerModule,
            CommonModule],
  templateUrl: './organizations.html',
  styleUrl: './organizations.css'
})
export class Organizations implements OnInit{
  public authService = inject(AuthService);
  organizations = signal<Organization[]>([]);
  private readonly organizationService = inject(OrganizationService);
  isLoading = false;
  private organizationsSub!: Subscription;

  ngOnInit(): void {
    this.loadCompanies();
    //this.organizationService.getOrganizations().subscribe((res) => this.organizations.set(res));
  }

  loadCompanies(): void {
    this.isLoading = true;
    this.organizationsSub = this.organizationService.getOrganizations().subscribe((res) => {this.organizations.set(res); 
                                                                                            this.isLoading = false;});
    this.isLoading = false;
      // .getCompanies(this.currentPage + 1, this.pageSize, this.filters)
      // .subscribe({
      //   next: (response) => {
      //     this.companies = response.data;
      //     this.totalItems = response.total;
      //     this.isLoading = false;
      //   },
      //   error: (error) => {
      //     console.error('Error loading companies', error);
      //     this.isLoading = false;
      //   }
      // });
  }

}
