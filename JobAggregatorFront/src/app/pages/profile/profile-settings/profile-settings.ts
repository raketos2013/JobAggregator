import { Component } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from "@angular/material/card";
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatDividerModule } from "@angular/material/divider";

@Component({
  selector: 'app-profile-settings',
  imports: [MatCardModule, 
            MatDividerModule, 
            MatCheckboxModule, 
            MatButtonModule],
  templateUrl: './profile-settings.html',
  styleUrl: './profile-settings.css'
})
export class ProfileSettings {

}
