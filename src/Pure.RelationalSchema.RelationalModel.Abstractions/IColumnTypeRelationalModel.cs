using Pure.Primitives.Abstractions.Guid;
using Pure.Primitives.Abstractions.String;

namespace Pure.RelationalSchema.RelationalModel.Abstractions;

public interface IColumnTypeRelationalModel
{
    public IGuid Id { get; }

    public IString Name { get; }
}
