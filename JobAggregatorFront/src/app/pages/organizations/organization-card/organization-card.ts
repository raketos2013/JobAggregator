import { CommonModule } from '@angular/common';
import { Component, Input } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { MatIconModule } from '@angular/material/icon';
import { RouterModule } from '@angular/router';
import { Organization } from '../../../models/organization';

@Component({
  selector: 'app-organization-card',
  imports: [CommonModule,
            MatCardModule,
            MatIconModule,
            MatButtonModule,
            RouterModule
  ],
  templateUrl: './organization-card.html',
  styleUrl: './organization-card.css'
})
export class OrganizationCard {
  @Input() organization!: Organization;
}
