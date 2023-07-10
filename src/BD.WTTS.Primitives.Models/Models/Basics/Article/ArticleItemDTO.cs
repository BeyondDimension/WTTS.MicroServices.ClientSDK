namespace BD.WTTS.Models;

public class ArticleItemDTO
{
    public Guid Id { get; set; }

    /// <summary>
    /// 标题
    /// </summary>
    public string Title { get; set; } = string.Empty;

    /// <summary>
    /// 作者名
    /// </summary>
    public string AuthorName { get; set; } = string.Empty;

    /// <summary>
    /// 封面图
    /// </summary>
    public string CoverUrl { get; set; } = string.Empty;

    /// <summary>
    /// 简介
    /// </summary>
    public string Introduction { get; set; } = string.Empty;

    /// <summary>
    /// 文章创建时间
    /// </summary>
    public DateTimeOffset CreationTime { get; set; }

    /// <summary>
    /// 文章标签
    /// </summary>
    public IEnumerable<ArticleTagDTO>? Tags { get; set; }

    /// <summary>
    /// 文章分类
    /// </summary>
    public ArticleCategoryDTO? Category { get; set; }

}
