[![Build Status](https://github.com/bahioganns/Dot_Net_labs/workflows/.NET/badge.svg)](https://github.com/bahioganns/Dot_Net_labs/actions?query=branch%3Amaster)

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

dotenv new sln -o lab1
dotenv new console -o lab1
dotenv new nunit -o lab1.Test

dotenv sln lab1.sln add lab1/lab1.csproject
dotenv sln lab1.sln add lab1.Test/lab1.Test.csproject

dotenv build lab1.sln
dotenv test
dotenv run lab1
```
