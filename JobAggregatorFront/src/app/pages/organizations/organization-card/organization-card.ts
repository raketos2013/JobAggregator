import { CommonModule } from '@angular/common';
import { Component, EventEmitter, Input, Output } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { MatIconModule } from '@angular/material/icon';
import { Router, RouterModule } from '@angular/router';
import { Organization } from '../../../models/organization';
import { MatDividerModule } from "@angular/material/divider";

@Component({
  selector: 'app-organization-card',
  imports: [CommonModule,
    MatCardModule,
    MatIconModule,
    MatButtonModule,
    RouterModule, MatDividerModule],
  templateUrl: './organization-card.html',
  styleUrl: './organization-card.css'
})
export class OrganizationCard {
  @Input() organization!: Organization;
  @Output() viewDetailsClicked = new EventEmitter<number>();

  constructor(
    private router: Router 
  ) {}

  viewDetails(event: MouseEvent): void {
    event.stopPropagation();
    this.viewDetailsClicked.emit(this.organization.id);
    this.router.navigate(['/organizations', this.organization.id]);
  }
}
