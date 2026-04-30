using Pure.Primitives.Abstractions.Guid;

namespace Pure.RelationalSchema.RelationalModel.Abstractions;

public interface IForeignKeyRelationalModel
{
    public IGuid Id { get; }

    public IGuid SchemaId { get; }

    public IGuid ReferencingTableId { get; }

    public IGuid ReferencedTableId { get; }
}
