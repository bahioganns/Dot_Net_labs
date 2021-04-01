[![Labs Build And Tests](https://github.com/bahioganns/Dot_Net_labs/actions/workflows/dotnet.yml/badge.svg?branch=cuamckuu_lab2)](https://github.com/bahioganns/Dot_Net_labs/actions/workflows/dotnet.yml)

# Лабораторные работы от 2 до 6

Выбрана тема: Приложение для заметок

- [X] Domain
- [X] DataAccess
- [X] BLL
- [X] BLL.Test
- [ ] DTO
- [ ] WebAPI
- [ ] Razor

# Заметки по dotnet CLI

```bash
# Создание проектов
mkdir labs
cd labs

dotnet new console -o Domain
dotnet new console -o DataAccess
dotnet new console -o BLL
dotnet new nunit -o BLL.Test
dotnet new classlib -o DTO
dotnet new webapi --no-https --auth None -o WebAPI
dotnet new # Список всех возможных типов проектов

# Создание решения и добавление проектов
dotnet new sln
dotnet sln labs.sln add Domain/Domain.csproject
dotnet sln labs.sln add BLL.Test/BLL.Test.csproject

# Использование одного проекта в другом
dotnet add ./DataAccess/ reference ./Domain/

# Cборка, тесты, запуск, см. больше в Makefile
dotnet build labs.sln
dotnet test labs.sln
dotnet run DataAccess

# Установка библиотек
dotnet add ./DataAccess/ package Microsoft.EntityFrameworkCore.Sqlite
dotnet add ./BLL.Test/ package Moq --version 4.16.1
```
