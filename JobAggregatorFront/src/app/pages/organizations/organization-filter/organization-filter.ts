import { Component } from '@angular/core';
import { MatCardModule } from "@angular/material/card";
import { MatInputModule } from "@angular/material/input";
import { MatExpansionModule } from "@angular/material/expansion";
import { MatListModule } from "@angular/material/list";
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-organization-filter',
  imports: [MatCardModule, MatInputModule, MatExpansionModule, MatListModule,CommonModule],
  templateUrl: './organization-filter.html',
  styleUrl: './organization-filter.css'
})
export class OrganizationFilter {

}
