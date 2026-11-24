# NHibernateBaseRepository

A sample ASP.NET Core 2.1 Web API that uses NHibernate through a generic base session.

- `IMapperSession<T, TKey>` defines transactions, add, save, delete and querying.
- `MapperSessionBase` implements it; `BookMapperSession` and `StudentMapperSession` apply it to two entities.
- `CrudTestController` exposes book and student endpoints under `/api/CrudTest`.
- Swagger UI is enabled.

The database connection string is `NHibernateDb` in `appsettings.json`.

## Run

```bash
dotnet run --project NHibernateCore
```
