# BackendAPI

## Создание интернет-магазина в рамках учебной практики!

Проект выполнен в Visual Studio с использованием HTML, CSS, Blazor и др.

Проект состоит из следующих компонентов:

+ BackendAPI - Контроллеры для проверки работоспособности API, а также контракты для удобного добавления и получения данных;
+ BusinessLogic - Непосредственно реализация API для получения доступа к данным;
+ BusinessLogic.Tests - Тесты для проверки API (BusinessLogic);
+ DataAccess - слой доступа к данным;
+ Domain - слой абстракций: Интерфейсы и модели данных;
+ WebServer - графический интерфейс сайта с использованием фреймворка Blazor.

Также используются github actions с использованием workflow-файлов для проверки форматирования, отрабатывания тестов и компиляции решения.
Используется github pages для развёртывания сайта
