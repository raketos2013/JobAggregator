import { Component } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatDialog } from '@angular/material/dialog';
import { MatIconModule } from '@angular/material/icon';
import { MatMenuModule } from '@angular/material/menu';
import { MatToolbarModule } from '@angular/material/toolbar';

@Component({
  selector: 'app-navbar',
  imports: [MatToolbarModule, MatButtonModule,
    MatIconModule,
    MatMenuModule],
  templateUrl: './navbar.html',
  styleUrl: './navbar.css'
})
export class Navbar {
  constructor(private dialog: MatDialog) {}

  // openLoginDialog(): void {
  //   this.dialog.open(LoginDialogComponent, {
  //     width: '400px'
  //   });
  // }

  // openRegisterDialog(): void {
  //   this.dialog.open(RegisterDialogComponent, {
  //     width: '450px'
  //   });
  // }
}
