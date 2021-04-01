[![Labs Build And Tests](https://github.com/bahioganns/Dot_Net_labs/actions/workflows/dotnet.yml/badge.svg?branch=cuamckuu_lab2)](https://github.com/bahioganns/Dot_Net_labs/actions/workflows/dotnet.yml)

# Лабораторные работы от 2 до 6

Выбрана тема: Приложение для заметок

- [X] Domain
- [X] DataAccess
- [X] BLL
- [X] BLL.Test
- [ ] WebAPI
- [ ] Razor

# Заметки по C#

```bash
# Создание проектов
mkdir labs
cd labs

dotnet new console -o lab1
dotnet new nunit -o lab1.Test

# Создание решения и добавление проектов
dotnet new sln
dotnet sln labs.sln add lab1/lab1.csproject
dotnet sln labs.sln add lab1.Test/lab1.Test.csproject

# Использование одного проекта в другом
dotnet add ./DataAccess/ reference ./Domain/

# Cборка, тесты, запуск, см. больше в Makefile
dotnet build labs.sln
dotnet test labs.sln
dotnet run lab1

# Установка библиотек
dotnet add package Microsoft.EntityFrameworkCore.Sqlite
dotnet add package Moq --version 4.16.1
```
