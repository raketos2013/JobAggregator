import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { MatCardModule } from "@angular/material/card";
import { MatListModule } from "@angular/material/list";

@Component({
  selector: 'app-my-applications',
  imports: [MatCardModule, MatListModule, CommonModule],
  templateUrl: './my-applications.html',
  styleUrl: './my-applications.css'
})
export class MyApplications {

}
