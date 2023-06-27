// ReSharper disable once CheckNamespace
namespace BD.WTTS.Models.Abstractions;

public interface IPageQueryRequest
{
    /// <summary>
    /// 当前页码或当前偏移量
    /// </summary>
    int Current { get; set; }

    int PageSize { get; set; }
}

public interface IPageQueryRequest<T> : IPageQueryRequest
{
    T? Params { get; set; }
}