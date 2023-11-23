# Att komma igång

Öppna 'appsettings.development.json' och klistra in följande connection string till databasen:
```
"ConnectionStrings": {
    "DefaultConnection": "Data Source=database.db"
  }
```

Öppna 'Packet Manager Console', välj 'Infrastructure' som default project och kör följande kommandon:
```
cd .\EDWebshop
Update-Database
```