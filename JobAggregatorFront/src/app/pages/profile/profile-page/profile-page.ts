import { Component } from '@angular/core';
import { MatCardModule } from "@angular/material/card";
import { MatTabsModule } from "@angular/material/tabs";
import { MyResumes } from "../my-resumes/my-resumes";
import { ProfileInfo } from "../profile-info/profile-info";
import { MatButtonModule } from '@angular/material/button';
import { ProfileSettings } from "../profile-settings/profile-settings";
import { MyApplications } from "../my-applications/my-applications";

@Component({
  selector: 'app-profile-page',
  imports: [MatCardModule, MatTabsModule, MyResumes, ProfileInfo, MatButtonModule, ProfileSettings, MyApplications],
  templateUrl: './profile-page.html',
  styleUrl: './profile-page.css'
})
export class ProfilePage {
  activeTabIndex = 0;
}
