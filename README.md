# Projekt Currencies
*Autorzy: Kamil Świderski 51451, Karina Tylmanowska 51426, Julia Adamska 53376, Michał Chudzik 55251, Dawid Stępniewski 36320*

## O projekcie

Projekt ma na celu stworzenie wielowarstwowej aplikacji do wymiany walut online. Platforma oferuje podstawowe funkcje, takie jak możliwość wymiany walut, rejestracja nowych użytkowników, oraz logowanie do konta. Użytkownicy będą mieć również dostęp do przeglądania aktualnych oraz historycznych kursów walut, co pozwoli im śledzić zmiany i podejmować świadome decyzje w zakresie wymiany walut. W ramach projektu skupiamy się na zapewnieniu intuicyjnej obsługi oraz stabilności działania systemu, z myślą o zwiększeniu wygody korzystania z aplikacji przez naszych użytkowników.

Link do iteracji projektu w Trello: https://trello.com/b/DpjnqZnA/currencies

## Jak uruchomić program

#### Backend:
- pobierz repoyztorium na swój komputer 
- otwórz folder w Visual Studio
- uruchom `Currencies.Api`
- otworzy się strona Swagger

#### Frontend: 
- pobierz repozytorium na swój komputer
- otwórz folder `Client` w Visual Studio Code
- wykonaj komende `npm install` w celu zainstalowania paczek
- wykonaj komende `ng serve` w celu uruchomienia aplikacji
- aplikacja będzie dostępna pod `http://localhost:4200/`

#### Baza danych:
- zainstaluj SQL Server
- wejdź na Visual Studio 
- wejdź w `Tools -> NuGet Package Manager -> Package Manager Console`
- W konsoli wpisz: `Update-Database`
- wejdź w `Tools -> Connect with database`
- server: `localhost\SQLEXPRESS`, baza: `CurrenciesDB`
