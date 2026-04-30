using Pure.Primitives.Abstractions.Bool;
using Pure.Primitives.Abstractions.Guid;

namespace Pure.RelationalSchema.RelationalModel.Abstractions;

public interface IIndexRelationalModel
{
    public IGuid Id { get; }

    public IGuid TableId { get; }

    public IBool IsUnique { get; }
}
