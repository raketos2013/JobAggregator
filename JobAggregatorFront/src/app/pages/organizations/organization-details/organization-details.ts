import { CommonModule } from '@angular/common';
import { Component, inject, Input, OnInit, signal } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { MatIconModule } from '@angular/material/icon';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import {MatTabsModule} from '@angular/material/tabs';
import { OrganizationService } from '../../../services/organization-service';
import { ActivatedRoute, Router, RouterModule } from '@angular/router';
import { AuthService } from '../../../services/auth-service';
import { OrganizationUsersDTO } from '../../../models/DTOs/organization-usersDTO';

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
  private readonly authService = inject(AuthService)
  public readonly route = inject(ActivatedRoute);

  @Input() organizationId?: number;
  organization = signal<OrganizationUsersDTO>({} as OrganizationUsersDTO);

  isLoading = false;
  error: string | null = null;

  constructor(
    private router: Router
  ) {}

  ngOnInit(): void {
    if(!this.organizationId){
      this.organizationId = +this.route.snapshot.paramMap.get('id')!;
    }
    this.organizationService.organizationId.set(this.organizationId)
    this.loadOrganization();
  }

  loadOrganization(): void{
    if(this.organizationId){
      this.organizationService.getOrganizationById(this.organizationId).subscribe((res) => {
        this.organization.set(res);
        console.log(this.organization().idUsers)
      })
    }
  }

  isUserOrganization(): boolean{
    console.log(this.organization())
    const userFind: number | undefined = this.organization().idUsers
                                          .find(item => item == this.authService.getUserData()?.id);
    if(userFind){
      return true
    } else{
      return false
    }
  }

}
