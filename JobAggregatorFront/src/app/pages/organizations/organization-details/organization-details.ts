import { CommonModule } from '@angular/common';
import { Component, inject, Input, OnInit, signal } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { MatIconModule } from '@angular/material/icon';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import {MatTabsModule} from '@angular/material/tabs';
import { OrganizationService } from '../../../services/organization-service';
import { ActivatedRoute, RouterModule } from '@angular/router';
import { Organization } from '../../../models/organization';

@Component({
  selector: 'app-organization-details',
  imports: [  CommonModule,
              MatCardModule,
              MatTabsModule,
              MatIconModule,
              MatButtonModule,
              MatProgressSpinnerModule,
              RouterModule],
  templateUrl: './organization-details.html',
  styleUrl: './organization-details.css'
})
export class OrganizationDetails implements OnInit{
[x: string]: any;

  private readonly organizationService = inject(OrganizationService);
  public readonly route = inject(ActivatedRoute);
  @Input() organizationId?: number;
  organization = signal<Organization>({} as Organization);

  isLoading = false;
  error: string | null = null;

  ngOnInit(): void {
    if(!this.organizationId){
      this.organizationId = +this.route.snapshot.paramMap.get('id')!;
    }
    this.loadOrganization();
  }

  loadOrganization(): void{
    if(this.organizationId){
      this.organizationService.getOrganizationById(this.organizationId).subscribe((res) => {
        this.organization.set(res);
      })
    }
  }

}
