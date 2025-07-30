import { Component, signal } from '@angular/core';
import { OrganizationFilter } from '../organization-filter/organization-filter';
import { OrganizationCard } from '../organization-card/organization-card';
import { Organization } from '../../../models/organization';

@Component({
  selector: 'app-organizations',
  imports: [OrganizationFilter,
            OrganizationCard
  ],
  templateUrl: './organizations.html',
  styleUrl: './organizations.css'
})
export class Organizations {
  organizations = signal<Organization[]>([]);
}
