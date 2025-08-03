import { Component, OnInit } from '@angular/core';
import { MatCardModule } from "@angular/material/card";
import { MatProgressSpinnerModule } from "@angular/material/progress-spinner";
import { MatIconModule } from "@angular/material/icon";

@Component({
  selector: 'app-role-requests',
  imports: [MatCardModule, MatProgressSpinnerModule, MatIconModule],
  templateUrl: './role-requests.html',
  styleUrl: './role-requests.css'
})
export class RoleRequests implements OnInit{
  // requests: RoleRequest[] = [];
  // loading = true;

  // constructor(private roleRequestService: RoleRequestService) {}

  ngOnInit(): void {
    //this.loadRequests();
  }

  // loadRequests(): void {
  //   this.roleRequestService.getPendingRequests().subscribe({
  //     next: (reqs) => {
  //       this.requests = reqs;
  //       this.loading = false;
  //     },
  //     error: (err) => {
  //       console.error('Error loading requests', err);
  //       this.loading = false;
  //     }
  //   });
  // }

  // approveRequest(id: number): void {
  //   this.roleRequestService.approveRequest(id).subscribe({
  //     next: () => {
  //       this.requests = this.requests.filter(r => r.id !== id);
  //     },
  //     error: (err) => console.error('Error approving request', err)
  //   });
  // }

  // rejectRequest(id: number): void {
  //   this.roleRequestService.rejectRequest(id).subscribe({
  //     next: () => {
  //       this.requests = this.requests.filter(r => r.id !== id);
  //     },
  //     error: (err) => console.error('Error rejecting request', err)
  //   });
  // }
}
