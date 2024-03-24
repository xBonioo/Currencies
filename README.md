# Projekt Currencies
*Autorzy: Kamil Swiderski, Karina Tylmanowska, Julia Adamska, Michal Chudzik, Dawid Stepniewski*

## O projekcie

Projekt ma na celu stworzenie wielowarstowowej aplikacji do wymiany walut online. Platforma oferuje podstawowe funkcje, takie jak możliwość wymiany walut, rejestracja nowych użytkowników, oraz logowanie do konta. Użytkownicy będą mieć również dostęp do przeglądania aktualnych oraz historycznych kursów walut, co pozwoli im śledzić zmiany i podejmować świadome decyzje w zakresie wymiany walut. W ramach projektu skupiamy się na zapewnieniu intuicyjnej obsługi oraz stabilności działania systemu, z myślą o zwiększeniu wygody korzystania z niego przez naszych użytkowników.

## Jak uruchomić program

#### Backend:
- pobierz repoyztorium na swój komputer 
- otwórz folder w Visual Studio
- uruchom `Currencies.Api`
- otworzy się strona Swagger

#### Frontend: 
- ...

#### Baza danych:
- zainstaluj SQL Server
- wejdź na Visual Studio 
- wejdź w `Tools -> NuGet Package Manager -> Package Manager Console`
- W konsoli wpisz: `Update-Database`
- wejdź w `Tools -> Connect with database`
- server: `localhost\SQLEXPRESS`, baza: `CurrenciesDB`

##  Strona internetowa

Tutaj będzie opis strony...

## Baza danych 

W tej sekcji przedstawiamy strukturę oraz funkcje bazy danych, która będzie wspierać działanie naszej platformy do wymiany walut. Baza danych będzie oparta na relacyjnym modelu danych i zapewni niezbędną funkcjonalność do przechowywania informacji o użytkownikach, transakcjach oraz kursach walut.

#### Model bazy danych 

![Model bazy danych](Documentation/Images/database_model.png)