using Pure.Primitives.Abstractions.Guid;
using Pure.Primitives.Abstractions.String;

namespace Pure.RelationalSchema.RelationalModel.Abstractions;

public interface ITableRelationalModel
{
    public IGuid Id { get; }

    public IGuid SchemaId { get; }

    public IString Name { get; }
}
