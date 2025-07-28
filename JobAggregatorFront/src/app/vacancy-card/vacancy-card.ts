import {ChangeDetectionStrategy, Component, Input } from '@angular/core';
import {MatProgressBarModule} from '@angular/material/progress-bar';
import {MatCardModule} from '@angular/material/card';
import {MatChipsModule} from '@angular/material/chips';
import { Vacancy } from '../models/vacancy';
import { MatButtonModule } from '@angular/material/button';
import { MatDividerModule } from '@angular/material/divider';
import { MatIconModule } from '@angular/material/icon';
import { RouterModule } from '@angular/router';

@Component({
  selector: 'app-vacancy-card',
  imports: [MatCardModule, MatProgressBarModule, MatButtonModule, MatDividerModule, MatIconModule, RouterModule],
  templateUrl: './vacancy-card.html',
  styleUrl: './vacancy-card.css',
  changeDetection: ChangeDetectionStrategy.OnPush,
})

export class VacancyCard {
  longText = `The Chihuahua is a Mexican breed of toy dog. It is named for the
  Mexican state of Chihuahua and is among the smallest of all dog breeds. It is
  usually kept as a companion animal or for showing.`;
  @Input() vacancy!: Vacancy;
  //@Input() testString!: string; 
}
