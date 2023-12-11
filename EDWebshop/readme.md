# Blombruket webshop
## Ett gruppprojekt inom kursen "Test, Verifiering och certifiering"

av **Emelie Baker** och **Dennis Hankvist**.
December 2023.

## Beskrivning

Detta �r v�r backend f�r en webshop som s�ljer blommor. 
Det �r en klon av [Blombruket](https://www.blombruket.se).

### Tekniker
- ASP.NET Core WebAPI f�r att skapa ett RESTful API.
- SQLite databas f�r att lagra information om produkter.
- Entity Framework Core f�r att kommunicera med databasen.
- MSTest f�r enhetstester.
- MOQ.EntityFramework f�r att mocka databasen i enhetstesterna.
- AutoMapper f�r att mappa mellan modeller och DTOs.
- Ett "Error Handling Middleware" f�r att begr�nsa k�nslig kod som kan t�nkas skickas ut till klienten vid interna fel.

### Projektindelning (SoC)
- `EDWebshop.Api` - WebAPI
- `EDWebshop.Api.Tests` - Enhetstester f�r WebAPI
- `EDWebshop.Contracts` - Gemensamma modeller och DTOs
- `EDWebshop.Data` - Databas och repositories
- `EDWebshop.Data.Tests` - Enhetstester f�r databas och repositories

## Till opponenter

Ni k�r enklast projektet i Visual Studio Community 2019.

Vi har inkluderat `appsettings.development.json` i repot, s� ni kan **k�ra projektet direkt** (denna fil har varit utesluten fr�n repot fram till inl�mningen).
En databas kallad `database.db` kommer att skapas i roten av projektet n�r vi k�r projektet f�r f�rsta g�ngen.
Ett stort antal produkter kommer automatiskt att "seedas" direkt i databasen.
V�r frontend pratar endast med `Get()` och `GetAll()`. �vriga metoder �r t�nka att anv�ndas av ett admin-gr�nssnitt som vi inte skrivit.
Vi har arbetat enligt Gitflow, men har inf�r inl�mningen mergat in development i master.

Vi har 23 tester som t�cker den st�rsta delen av all logik i projektet. Vi tester inte modeller och DTOer, d� dessa inte inneh�ller n�gon logik.
F�r att k�ra v�ra tester, tryck p� `Ctrl + R, A` i Visual Studio (eller navigera till `Test > Run all tests` i menyn).
F�r att visa resultaten av testerna, tryck p� `Ctrl + E, T` (eller navigera till `Test > Test Explorer` i menyn).