[![Build Status](https://github.com/bahioganns/Dot_Net_labs/workflows/.NET/badge.svg?branch=cuamckuu_lab1)](https://github.com/bahioganns/Dot_Net_labs/actions?query=branch%3Acuamckuu_lab1)

# Лабораторная работа 1

Реализовать:
  1. Связанный список с операциями: вставка, удаление, разворот
  2. Бинарное дерево с операциями: вставка, поиск, удаление
  3. Сортировку вставками

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
