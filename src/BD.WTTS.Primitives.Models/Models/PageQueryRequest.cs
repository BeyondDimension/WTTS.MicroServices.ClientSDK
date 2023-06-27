// ReSharper disable once CheckNamespace
namespace BD.WTTS.Models;

/// <summary>
/// 分页查询请求
/// </summary>
/// <typeparam name="T"></typeparam>
[MPObj, MP2Obj(SerializeLayout.Explicit)]
public sealed partial class PageQueryRequest<T> : IPageQueryRequest, IPageQueryRequest<T>
{
    [MPKey(0), MP2Key(0)]
    public int Current { get; set; }

    [MPKey(1), MP2Key(1)]
    public int PageSize { get; set; } = 15;

    [MPKey(2), MP2Key(2)]
    public T? Params { get; set; }
}