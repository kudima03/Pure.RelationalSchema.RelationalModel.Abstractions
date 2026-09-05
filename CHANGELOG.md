# Changelog

All notable changes to Pure.RelationalSchema.RelationalModel.Abstractions are documented here.

Format follows [Keep a Changelog](https://keepachangelog.com/en/1.1.0/).

---

## [0.1.0-preview.1.0.0] — 2026-04-30

### Changed

- Package dependency switched from `Pure.RelationalSchema.Abstractions` to a
  direct reference on `Pure.Primitives.Abstractions` 4.3.0, removing the
  redundant transitive dependency.

## [0.1.0-preview.0.1.0] — 2026-04-30

### Added

- **`ISchemaRelationalModel`** — `Id` (`IGuid`), `Name` (`IString`).
- **`ITableRelationalModel`** — `Id` (`IGuid`), `SchemaId` (`IGuid`),
  `Name` (`IString`).
- **`IColumnRelationalModel`** — `Id` (`IGuid`), `TableId` (`IGuid`),
  `Name` (`IString`), `TypeId` (`IGuid`).
- **`IColumnTypeRelationalModel`** — `Id` (`IGuid`), `Name` (`IString`).
- **`IIndexRelationalModel`** — `Id` (`IGuid`), `TableId` (`IGuid`),
  `IsUnique` (`IBool`).
- **`IForeignKeyRelationalModel`** — `Id` (`IGuid`), `SchemaId` (`IGuid`),
  `ReferencingTableId` (`IGuid`), `ReferencedTableId` (`IGuid`).
