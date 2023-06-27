// ReSharper disable once CheckNamespace
namespace BD.WTTS.Models.Abstractions;

public abstract class BasePageQueryRequest : IPageQueryRequest
{
    public int Current { get; set; }

    public int PageSize { get; set; } = 15;
}
