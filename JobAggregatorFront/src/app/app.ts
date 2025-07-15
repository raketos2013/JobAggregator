import { Component, signal } from '@angular/core';
import { Toolbar } from "./toolbar/toolbar";
import { RouterOutlet } from '@angular/router';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, Toolbar],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
  protected title = 'Jobber';
}
