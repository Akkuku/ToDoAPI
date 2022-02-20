# ToDo REST API

## About Project
RESTful API for simple ToDo list usage. 
Project utilizes .NET 6 and was created from webapi template.
API allows for simple CRUD operations to operate with the data stored in local PostgreSQL database. 
Database is created using Model First approach with Entity Framework Core migrations.

## Usage
Project is ready to test with swagger.
API is can be used in mobile or web client by accessing endpoints:

    https://localhost:7177/api/Assignment 
**POST** task or **GET** list of all tasks (Json),

    https://localhost:7177/api/Assignment/{id} 
**GET**, **PUT** or **DELETE** task of specific *id*,

    https://localhost:7177/api/Assignment/today
**GET** list of tasks assigned for today,

    https://localhost:7177/api/Assignment/unfinished
**GET** list of unfinished tasks,

    https://localhost:7177/api/Assignment/overdue
**GET** list of unfinished tasks which time has passed.