# Att komma ig�ng

�ppna 'appsettings.development.json' och klistra in f�ljande connection string till databasen:
```
"ConnectionStrings": {
    "DefaultConnection": "Data Source=database.db"
  }
```

�ppna 'Packet Manager Console', v�lj 'Infrastructure' som default project och k�r f�ljande kommandon:
```
cd .\EDWebshop
Update-Database
```