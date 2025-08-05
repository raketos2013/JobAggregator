# JobAggregator 🚀

Веб-приложение для агрегации вакансий, соединяющее соискателей и работодателей на одной платформе.

## ✨ Основные возможности

### Для соискателей:
- 🔍 Поиск и фильтрация вакансий по различным критериям
- 📝 Создание и управление профессиональным резюме
- 💾 Сохранение интересных вакансий в избранное
- ✉️ Прямой отклик на вакансии

### Для работодателей:
- 🏢 Создание профиля компании
- 📢 Публикация и управление вакансиями
- 👀 Поиск кандидатов по базе резюме
- 💌 Отправка персональных предложений кандидатам

## 🛠 Технологический стек

### Backend (Web API)
| Технология | Описание |
|------------|----------|
| ![ASP.NET](https://img.shields.io/badge/ASP.NET-9.0+-512BD4?logo=.net) | Основной фреймворк |
| ![EF Core](https://img.shields.io/badge/EF_Core-8.0-blue) | ORM для работы с БД |
| ![PostgreSQL](https://img.shields.io/badge/PostgreSQL-16.0-336791?logo=postgresql) | Система управления базами данных |
| ![Swagger](https://img.shields.io/badge/Swagger-3.0-85EA2D?logo=swagger) | Документация API |
| ![JWT](https://img.shields.io/badge/JWT-Auth-black) | Аутентификация |

### Frontend
| Технология | Описание |
|------------|----------|
| ![Angular](https://img.shields.io/badge/Angular-20.0-DD0031?logo=angular) | Основной фреймворк |
| ![Angular Material](https://img.shields.io/badge/Angular_Material-20.0-1976D2) | UI компоненты |
| ![Node.js](https://img.shields.io/badge/Node.js-22.0-339933?logo=node.js) | Среда выполнения |

## 🚀 Установка и запуск

### Предварительные требования
- [.NET 9.0+](https://dotnet.microsoft.com/download)
- [Node.js 22.x](https://nodejs.org/)
- [PostgreSQL 16+](https://www.postgresql.org/download/)

### Backend
```bash
# Клонирование репозитория
git clone https://github.com/raketos2013/JobAggregator
cd JobAggregator

# Восстановление зависимостей
dotnet restore

# Настройка базы данных (укажите свои параметры в appsettings.json)
dotnet ef database update

# Запуск приложения
dotnet run
```


## 🖥 Frontend

### Основные технологии:
- <img src="https://angular.io/assets/images/logos/angular/angular.svg" width="16" height="16"> [Angular 20.0+](https://angular.io/) - Основной фреймворк
- <img src="https://material.angular.io/assets/img/angular-material-logo.svg" width="16" height="16"> [Angular Material](https://material.angular.io/) - UI компоненты
- <img src="https://nodejs.org/static/images/logo.svg" width="16" height="16"> [Node.js 22+](https://nodejs.org/) - Среда выполнения

## 🗺 Roadmap

### ✅ Версия 1.0 (Текущая)
- [x] Базовый функционал вакансий и резюме
- [x] Поиск и фильтрация
- [x] Авторизация и ролевой доступ
- [x] Базовые уведомления

### 🔄 Версия 1.1 (Q4 2025)
- [ ] Полноценная система уведомлений (email + web push)
- [ ] Чат между пользователями
- [ ] Аналитика просмотров

### 🚀 Версия 2.0 (Q2 2026)
- [ ] Блог-платформа
- [ ] Система рекомендаций
- [ ] Мобильное приложение

#### Прогресс разработки:
```mermaid
gantt
    title График релизов
    dateFormat  YYYY-MM-DD
    section 1.1
    Уведомления   :active, 2025-09-01, 30d
    Чат           :2025-10-01, 45d
    section 2.0
    Блог          :2026-04-01, 60d
```

## 📬 Контакты

### 📩 Связь с разработчиком
- **Email**: [daniilgol123498@gmail.com](mailto:daniilgol123498@gmail.com)
- **LinkedIn**: [Daniil Golubovich](https://www.linkedin.com/in/daniil-golubovich-708641359/)
