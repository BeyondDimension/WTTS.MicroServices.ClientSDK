namespace BD.WTTS.Models;

/// <summary>
/// 文章
/// </summary>

[MPObj, MP2Obj(SerializeLayout.Explicit)]
public class ArticleItemDTO
{
    [MPKey(0), MP2Key(0)]
    public Guid Id { get; set; }

    /// <summary>
    /// 标题
    /// </summary>
    [MPKey(1), MP2Key(1)]
    public string Title { get; set; } = string.Empty;

    /// <summary>
    /// 作者名
    /// </summary>
    [MPKey(2), MP2Key(2)]
    public string AuthorName { get; set; } = string.Empty;

    /// <summary>
    /// 封面图
    /// </summary>
    [MPKey(3), MP2Key(3)]
    public string CoverUrl { get; set; } = string.Empty;

    /// <summary>
    /// 简介
    /// </summary>
    [MPKey(4), MP2Key(4)]
    public string Introduction { get; set; } = string.Empty;

    /// <summary>
    /// 浏览量
    /// </summary>
    [MPKey(5), MP2Key(5)]
    public long ViewCount { get; set; }

    /// <summary>
    /// 文章创建时间
    /// </summary>
    [MPKey(6), MP2Key(6)]
    public DateTimeOffset CreationTime { get; set; }

    /// <summary>
    /// 文章标签
    /// </summary>
    [MPKey(7), MP2Key(7)]
    public IEnumerable<ArticleTagDTO>? Tags { get; set; }

    /// <summary>
    /// 文章分类
    /// </summary>
    [MPKey(8), MP2Key(8)]
    public ArticleCategoryDTO? Category { get; set; }

}
