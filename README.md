# Pure.RelationalSchema.RelationalModel.Abstractions

Relational model interfaces for representing database schema structures in the **Pure** ecosystem — immutable, composable abstractions over schemas, tables, columns, indexes, and foreign keys.

[![.NET build & test](https://github.com/kudima03/Pure.RelationalSchema.RelationalModel.Abstractions/actions/workflows/build-and-test.yml/badge.svg?branch=main)](https://github.com/kudima03/Pure.RelationalSchema.RelationalModel.Abstractions/actions/workflows/build-and-test.yml)
[![Build and Deploy](https://github.com/kudima03/Pure.RelationalSchema.RelationalModel.Abstractions/actions/workflows/publish-nuget.yml/badge.svg?branch=main)](https://github.com/kudima03/Pure.RelationalSchema.RelationalModel.Abstractions/actions/workflows/publish-nuget.yml)
[![NuGet](https://img.shields.io/nuget/v/Pure.RelationalSchema.RelationalModel.Abstractions)](https://www.nuget.org/packages/Pure.RelationalSchema.RelationalModel.Abstractions)
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](LICENSE)

## Overview

`Pure.RelationalSchema.RelationalModel.Abstractions` defines read-only interfaces that describe the structural elements of a relational database schema. Each interface models one entity — schema, table, column, column type, index, or foreign key — using typed primitives from `Pure.Primitives.Abstractions`. All identities are expressed as `IGuid`, names as `IString`, and flags as `IBool`.

## Interfaces

| Interface | Namespace | Description |
|-----------|-----------|-------------|
| `ISchemaRelationalModel` | `Pure.RelationalSchema.RelationalModel.Abstractions` | A database schema identified by a GUID and named with an `IString` |
| `ITableRelationalModel` | `Pure.RelationalSchema.RelationalModel.Abstractions` | A table within a schema; references its parent schema via `SchemaId` |
| `IColumnRelationalModel` | `Pure.RelationalSchema.RelationalModel.Abstractions` | A column in a table; carries a reference to its column type via `TypeId` |
| `IColumnTypeRelationalModel` | `Pure.RelationalSchema.RelationalModel.Abstractions` | A named column type (e.g. `integer`, `varchar`) identified by a GUID |
| `IIndexRelationalModel` | `Pure.RelationalSchema.RelationalModel.Abstractions` | An index on a table; exposes `IsUnique` as `IBool` |
| `IForeignKeyRelationalModel` | `Pure.RelationalSchema.RelationalModel.Abstractions` | A foreign key constraint linking two tables within a schema |

## Design Principles

- **Immutable** — all interfaces expose only `get` properties; no setters, no mutating methods.
- **Composable** — entities reference each other via `IGuid` identifiers rather than direct object graphs, keeping interfaces flat and dependency-free.
- **AOT-compatible** — the library is fully compatible with Native AOT compilation.

## Dependencies

- [`Pure.Primitives.Abstractions`](https://github.com/kudima03/Pure.Primitives.Abstractions/tree/4.3.0) — base interfaces for immutable, composable abstractions over .NET primitive types (`IBool`, `IString`, `IGuid`, `INumber<T>`, etc.)

## Target Frameworks

- .NET 7
- .NET 8
- .NET 9
- .NET 10

## Installation

```shell
dotnet add package Pure.RelationalSchema.RelationalModel.Abstractions
```

## Usage

Implement the interfaces to model your relational schema entities:

```csharp
using Pure.RelationalSchema.RelationalModel.Abstractions;
using Pure.Primitives.Abstractions.Guid;
using Pure.Primitives.Abstractions.String;

public sealed class SchemaRelationalModel : ISchemaRelationalModel
{
    public SchemaRelationalModel(IGuid id, IString name)
    {
        Id = id;
        Name = name;
    }

    public IGuid Id { get; }
    public IString Name { get; }
}
```
