JobAggregator

     Проект представляет собой веб-приложение для агрегации вакансий, позволяющее соискателям искать работу, а работодателям – размещать вакансии.
     
     
Функциональность
    
    Для соискателей:
* Поиск и просмотр вакансий
* Создание и управление резюме
* Сохранение понравившихся вакансий
* Отклик на вакансии

    Для работодателей:
* Создание компании/организации
* Публикация и управление вакансиями
* Поиск кандидатов по резюме
* Отправка предложений кандидатам

Технологии
    
    Backend (Web API)
* ASP.NET 9.0+
* Entity Framework Core
* PostgreSQL
* Swagger
* JWT аутентификация

    Frontend
* Angular 20.0+
* Angular Material
* Node 22+

Установка

1. Клонировать репозиторий:
git clone https://github.com/raketos2013/JobAggregator
2. Настроить backend:
     cd JobAggregator
     dotnet restore
Настроить строку подключения к базе данных в appsettings.json
Применить миграции 
     dotnet ef database update
Запустить
     dotnet run
3. Настроить frontend
cd JobAggregatorFront
npm install
Настроить API endpoints в environment.ts
Запустить
     ng serve
     
     Приложение будет доступно по адресу http://localhost:4200
     API документация (Swagger): https://localhost:7261/swagger/index.html
     
     
Roadmap
     Версия 1.0 (Текущая)
* Базовый функционал вакансий и резюме
* Поиск и фильтрация
* Авторизация и профили с ролевым доступом
* Некоторые уведомления
     Версия 1.1 (Q4 2025)
* Полноценная система уведомлений (email, web push)
* Чат между соискателем и работодателем
* Аналитика просмотра вакансий/резюме
     Версия 2.0 (Q2 2026)
* Возможность вести блог
     
Контакты
     Email: daniilgol123498@gmail.com
     LinkedIn: https://www.linkedin.com/in/daniil-golubovich-708641359/
     
