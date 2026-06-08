# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Commands

All `dotnet` commands must be run from the `./src` directory.

```bash
dotnet restore
dotnet build --no-restore -warnaserror
dotnet format --verify-no-changes             # check code style (CI enforces this)
dotnet format && csharpier format .           # auto-fix code style
dotnet pack --configuration Release -p:PackageVersion=<version> --output .
```

There are no test projects in this repository — the CI pipeline only builds and checks formatting.

## Architecture

This is an **interfaces-only NuGet library** — no implementations, no tests, no external dependencies beyond `Pure.Primitives.Abstractions`. Every file defines exactly one interface.

**Public API — six interfaces in the `Pure.RelationalSchema.RelationalModel.Abstractions` namespace:**

| Interface | Key properties |
|-----------|---------------|
| `ISchemaRelationalModel` | `Id: IGuid`, `Name: IString` |
| `ITableRelationalModel` | `Id: IGuid`, `SchemaId: IGuid`, `Name: IString` |
| `IColumnRelationalModel` | `Id: IGuid`, `TableId: IGuid`, `Name: IString`, `TypeId: IGuid` |
| `IColumnTypeRelationalModel` | `Id: IGuid`, `Name: IString` |
| `IIndexRelationalModel` | `Id: IGuid`, `TableId: IGuid`, `IsUnique: IBool` |
| `IForeignKeyRelationalModel` | `Id: IGuid`, `SchemaId: IGuid`, `ReferencingTableId: IGuid`, `ReferencedTableId: IGuid` |

Entities reference each other via `IGuid` identifiers — no direct object graph, no circular dependencies. All primitive types (`IGuid`, `IString`, `IBool`) come from [`Pure.Primitives.Abstractions`](https://github.com/kudima03/Pure.Primitives.Abstractions).

**Multi-targeting:** net7.0, net8.0, net9.0, net10.0. All interfaces must remain AOT-compatible (`IsAotCompatible = true`).

**Package validation:** `EnablePackageValidation = true` with `PackageValidationBaselineVersion = 0.1.0-preview.1.0.0`. Breaking changes to the public API surface fail the build.

**Publishing:** triggered by pushing a semver tag (e.g. `1.0.0`). The tag becomes the `PackageVersion`. Packages are published to both GitHub Packages and NuGet.org.

## Code Style

Enforced via `./src/.editorconfig` and checked in CI with `dotnet format --verify-no-changes` and `csharpier check .`:

- No `var` — always use explicit types (`csharp_style_var_*= false`)
- No expression-bodied methods or constructors — only properties, indexers, and accessors may use expression bodies
- File-scoped namespaces (`csharp_style_namespace_declarations = file_scoped`)
- `using` directives outside the namespace
- Max line length: 90 characters
- Private fields: `_camelCase` prefix; no non-private instance fields allowed
- Interfaces: `I`-prefixed PascalCase; generic type parameters: `T`-prefixed PascalCase
- Allman braces (`csharp_new_line_before_open_brace = all`)
- No implicit object creation when type is apparent (`new()` style disallowed)

## Commit Messages

Do not mention Claude or AI assistance in commit messages.
