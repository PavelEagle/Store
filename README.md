MVC Project WebStore

- Трехслойная структура (API, Repository, DB);
- Для внедрения в проеток Dependency Injection используется Autofac;
- Маппинг моделей осуществляется с помощью Automapper;
- Для мапинга данных из SQL запросов с моделями данных в C# используется Dapper; 
- 2 конфигурации: Development и Production;
- 2 контроллера: ReportController - для отчетов по интернет - магазину, ProductController - CRUD по товарам;
- На View-слой добавлены все отчеты из ReportController и CRUD из ProductController;
- Реализовано полученией курса валют из API ЦБ https://www.cbr-xml-daily.ru/daily_json.js и конвертация в местную валюту при получении данных о заказе.

Ссылка на базу данных - https://drive.google.com/open?id=1SQvPfAadkUthwdNdPkhbGonxoWgArIgk
