# Blombruket webshop
## Ett gruppprojekt inom kursen "Test, Verifiering och certifiering"

av **Emelie Baker** och **Dennis Hankvist**.
December 2023.

## Beskrivning

Detta är vår backend för en webshop som säljer blommor. 
Det är en klon av [Blombruket](https://www.blombruket.se).

### Tekniker
- ASP.NET Core WebAPI för att skapa ett RESTful API.
- SQLite databas för att lagra information om produkter.
- Entity Framework Core för att kommunicera med databasen.
- MSTest för enhetstester.
- MOQ.EntityFramework för att mocka databasen i enhetstesterna.
- AutoMapper för att mappa mellan modeller och DTOs.
- Ett "Error Handling Middleware" för att begränsa känslig kod som kan tänkas skickas ut till klienten vid interna fel.

### Projektindelning (SoC)
- `EDWebshop.Api` - WebAPI
- `EDWebshop.Api.Tests` - Enhetstester för WebAPI
- `EDWebshop.Contracts` - Gemensamma modeller och DTOs
- `EDWebshop.Data` - Databas och repositories
- `EDWebshop.Data.Tests` - Enhetstester för databas och repositories

## Till opponenter

Ni kör enklast projektet i Visual Studio Community 2019.

Vi har inkluderat `appsettings.development.json` i repot, så ni kan **köra projektet direkt** (denna fil har varit utesluten från repot fram till inlämningen).
En databas kallad `database.db` kommer att skapas i roten av projektet när vi kör projektet för första gången.
Ett stort antal produkter kommer automatiskt att "seedas" direkt i databasen.
Vår frontend pratar endast med `Get()` och `GetAll()`. Övriga metoder är tänka att användas av ett admin-gränssnitt som vi inte skrivit.
Vi har arbetat enligt Gitflow, men har inför inlämningen mergat in development i master.

Vi har 23 tester som täcker den största delen av all logik i projektet. Vi tester inte modeller och DTOer, då dessa inte innehåller någon logik.
För att köra våra tester, tryck på `Ctrl + R, A` i Visual Studio (eller navigera till `Test > Run all tests` i menyn).
För att visa resultaten av testerna, tryck på `Ctrl + E, T` (eller navigera till `Test > Test Explorer` i menyn).
