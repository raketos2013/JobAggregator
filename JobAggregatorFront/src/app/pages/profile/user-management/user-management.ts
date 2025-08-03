import { Component, OnInit, signal } from '@angular/core';
import { User } from '../../../models/user';
import { UserService } from '../../../services/user-service';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { MatButtonModule } from '@angular/material/button';
import { ReactiveFormsModule } from '@angular/forms';
import { MatIconModule } from "@angular/material/icon";
import { MatTableDataSource, MatTableModule } from '@angular/material/table';

@Component({
  selector: 'app-user-management',
  imports: [CommonModule,
    RouterModule,
    MatButtonModule,
    ReactiveFormsModule, 
    MatIconModule,
    MatTableModule],
  templateUrl: './user-management.html',
  styleUrl: './user-management.css'
})
export class UserManagement implements OnInit{
  users = signal<User[]>([]);
  displayedColumns: string[] = ['id', 'name', 'lastname', 'role', 'actions'];

  constructor(private userService: UserService) {}

  ngOnInit(): void {
    this.loadUsers();
  }

  loadUsers(): void {
    this.userService.getUsers().subscribe((res) => this.users.set(res));
    console.log(this.users())
  }

  grantRole(userId: number, role: string): void {
    // Логика выдачи роли
  }

  blockUser(userId: number): void {
    // Логика блокировки пользователя
  }
}
