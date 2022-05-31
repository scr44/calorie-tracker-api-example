# Calorie Tracker

## Overview
A sample project that allows users to record types of food, food calories, and calories eaten per day. It demonstrates the following:

## Backend
- An [ASP.NET Web API](https://dotnet.microsoft.com/en-us/apps/aspnet/apis) with Swagger documentation
- Easy dependency injection with [AutoRegisterDi](https://github.com/JonPSmith/NetCore.AutoRegisterDi)
- Onion/Clean/Horizontal Slice architecture (Controller, Service, Repository, Domain)
- Domain-driven design (granted, it's just CRUD operations right now)
- [Entity Framework Core](https://docs.microsoft.com/en-us/ef/core/) backed by SQLite db for convenient local downloads. If you need a viewer, try [DB Browser for SQLite](https://sqlitebrowser.org/).
- Async data operations to avoid [ThreadPool starvation](https://medium.com/criteo-engineering/net-threadpool-starvation-and-how-queuing-makes-it-worse-512c8d570527)
- Unit testing with [NUnit](https://nunit.org/) and [Moq](https://github.com/moq/moq)
- COMING SOON: [OData](https://docs.microsoft.com/en-us/odata/overview) to feed a serverside-processed report grid
- COMING SOON: Demonstration of a [Vertical Slice](https://www.youtube.com/watch?v=SUiWfhAhgQw) architecture pattern using Jimmy Bogard's [MediatR](https://github.com/jbogard/MediatR) (a nice alternative to traditional onion)
- COMING SOON: Event logging for entity creation, deletion, or updating

## Frontend
- Scaffolded with [Vite](https://vitejs.dev/)
- Store using [Pinia](https://pinia.vuejs.org/)
- IN PROGRESS: [Vue 3](https://vuejs.org/) single-page application using the [Composition API](https://vuejs.org/guide/introduction.html#api-styles)
- IN PROGRESS: [Vue router](https://router.vuejs.org)
- COMING SOON: Grid/UI components from [SyncFusion](https://www.syncfusion.com/)
