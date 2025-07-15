import { Component, Inject } from '@angular/core';
import {MatIconModule} from '@angular/material/icon';
import {MatDividerModule} from '@angular/material/divider';
import {MatButtonModule} from '@angular/material/button';
import {MatToolbarModule} from '@angular/material/toolbar';
import { Router, RouterModule } from '@angular/router';

@Component({
  selector: 'app-toolbar',
  imports: [RouterModule, MatToolbarModule, MatButtonModule, MatDividerModule, MatIconModule],
  templateUrl: './toolbar.html',
  styleUrl: './toolbar.css'
})

export class Toolbar {

}
