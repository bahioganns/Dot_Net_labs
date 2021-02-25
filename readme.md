[![Build Status](https://github.com/bahioganns/Dot_Net_labs/workflows/.NET/badge.svg?branch=cuamckuu_lab2)](https://github.com/bahioganns/Dot_Net_labs/actions?query=branch%3Acuamckuu_lab2)

# Лабораторная работа 2

## Задание
- Выбрать тему для проекта – прототипа системы на трехзвенной архитектуре
- Используем DotNet Core 3.x
- Своя тема, подразумевающая наличие: БД, сервер с API (WebAPI), клиент на ASP.NET MVC (веб-приложение)
- Начать реализацию проекта – создать новый Solution, продумать и сделать доменную модель

# Заметки по C#

```bash
# Создание решения с проектами
mkdir someSolution
cd someSolution

dotnet new sln
dotnet new console -o lab1
dotnet new nunit -o lab1.Test

dotnet sln labs.sln add lab1/lab1.csproject
dotnet sln labs.sln add lab1.Test/lab1.Test.csproject

dotnet build labs.sln
dotnet test labs.sln
dotnet run lab1
```
