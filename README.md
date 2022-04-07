# API

## Requirements

- .NET (v5.0.404)
  
- docker-compose (v1.29.2)

## SetUp

Firstly, we have to start our database container:

```console
$ docker-compose up
```

Then, if it is the first time running this container, we have to setup our database (create schemas etc) using Migrations.

Current migrations (located at [Migrations/](./Migrations) were generated with these commands:

```console
$ dotnet ef migrations add AddLookupTables
$ dotnet ef migrations add AddUniqueIndexesToLookupTables
```

Now we can apply it to our database:

```console
$ dotnet ef database update
```

## Usage

Then, all we have to do is run our api. :)

```console
$ dotnet run
```
