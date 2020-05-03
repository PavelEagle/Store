MVC Project WebStore

- Трехслойная структура (API, Repository, DB);
- Для внедрения в проеток Dependency Injection используется Autofac;
- Маппинг моделей осуществляется с помощью Automapper;
- Для мапинга данных из SQL запросов с моделями данных в C# используется Dapper; 
- 2 конфигурации: Development и Production;
- 2 контроллера: ReportController - для отчетов по интернет - магазину, ProductController - CRUD по товарам;
- На View-слой добавлены все отчеты из ReportController и CRUD из ProductController

Ссылка на базу данных - https://drive.google.com/open?id=1g-ggnpZSpQAKPNje-cy33bC_leGktHf3
