$migrationName = Read-Host "Migration name: "

Add-Migration $migrationName -Project CalorieTracker.Infrastructure

Update-Database