using Pure.Primitives.Abstractions.Guid;
using Pure.Primitives.Abstractions.String;

namespace Pure.RelationalSchema.RelationalModel.Abstractions;

public interface IColumnRelationalModel
{
    public IGuid Id { get; }

    public IGuid TableId { get; }

    public IString Name { get; }

    public IGuid TypeId { get; }
}
