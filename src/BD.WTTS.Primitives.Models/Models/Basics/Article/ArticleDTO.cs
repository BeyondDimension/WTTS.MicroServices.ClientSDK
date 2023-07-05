namespace BD.WTTS.Models;
public class ArticleDTO
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
    /// 文章内容
    /// </summary>
    public string Content { get; set; } = string.Empty;

    /// <summary>
    /// 分类
    /// </summary>
    public ArticleCategoryDTO? Category { get; set; }

    /// <summary>
    /// 标签列表
    /// </summary>
    public ArticleTagDTO[]? Tags { get; set; }

    /// <summary>
    /// 文章创建时间
    /// </summary>
    public DateTimeOffset CreationTime { get; set; }
}
