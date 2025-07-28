import { Component, inject, signal } from '@angular/core';
import { Organization } from '../../models/organization';
import { ActivatedRoute } from '@angular/router';
import { OrganizationService } from '../../services/organization-service';

@Component({
  selector: 'app-organization-details',
  imports: [],
  templateUrl: './organization-details.html',
  styleUrl: './organization-details.css'
})
export class OrganizationDetails {
    private readonly organizationService = inject(OrganizationService)
    private readonly route = inject(ActivatedRoute);

    organization = signal<Organization>({} as Organization);

    ngOnInit(): void {
      const organizationId = Number(this.route.snapshot.paramMap.get('id'))
      this.organizationService.getOrganizationById(organizationId).subscribe((res) => {
        this.organization.set(res);
      });
    }
}
