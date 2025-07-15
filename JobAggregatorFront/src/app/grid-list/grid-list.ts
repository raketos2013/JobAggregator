import { Component } from '@angular/core';
import {MatGridListModule} from '@angular/material/grid-list';
import { VacancyCard } from '../vacancy-card/vacancy-card';

export interface Tile {
  color: string;
  cols: number;
  rows: number;
  text: string;
}

@Component({
  selector: 'app-grid-list',
  imports: [MatGridListModule, VacancyCard],
  templateUrl: './grid-list.html',
  styleUrl: './grid-list.css'
})
export class GridList {
  tiles: Tile[] = [
    {text: 'One', cols: 2, rows: 1, color: 'lightblue'},
    {text: 'Two', cols: 3, rows: 1, color: 'lightgreen'},
    {text: 'Three', cols: 1, rows: 1, color: 'lightpink'}
  ];
}
