import { Component } from '@angular/core';
import { MatCardModule } from "@angular/material/card";
import { MatListModule } from "@angular/material/list";
import { MatIconModule } from "@angular/material/icon";
import { CommonModule } from '@angular/common';
import { MatButtonModule } from '@angular/material/button';

interface NewsItem {
  title: string;
  date: string;
  excerpt: string;
  category: string;
}


@Component({
  selector: 'app-organization-sidebar',
  imports: [MatCardModule, MatListModule, MatIconModule, CommonModule, MatButtonModule],
  templateUrl: './organization-sidebar.html',
  styleUrl: './organization-sidebar.css'
})
export class OrganizationSidebar {
    newsItems: NewsItem[] = [
    {
      title: 'Рынок труда в 2024: основные тренды',
      date: '15 января 2024',
      excerpt: 'Какие специалисты будут наиболее востребованы в этом году',
      category: 'Аналитика'
    },
    {
      title: 'Новые требования к IT-специалистам',
      date: '10 января 2024',
      excerpt: 'Какие навыки стали обязательными для разработчиков',
      category: 'IT'
    },
    {
      title: 'Как компании привлекают лучших сотрудников',
      date: '5 января 2024',
      excerpt: 'Обзор самых эффективных методов рекрутинга',
      category: 'HR'
    },
    {
      title: 'Изменения в трудовом законодательстве',
      date: '28 декабря 2023',
      excerpt: 'Что нужно знать работодателям и соискателям',
      category: 'Законодательство'
    },
    {
      title: 'Рейтинг лучших работодателей года',
      date: '20 декабря 2023',
      excerpt: 'Топ-50 компаний по версии HeadHunter',
      category: 'Рейтинги'
    }
  ];

  getIcon(category: string): string {
    switch(category) {
      case 'Аналитика': return 'analytics';
      case 'IT': return 'code';
      case 'HR': return 'groups';
      case 'Законодательство': return 'gavel';
      case 'Рейтинги': return 'star';
      default: return 'article';
    }
  }

}
