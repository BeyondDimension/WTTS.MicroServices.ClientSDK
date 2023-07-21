namespace BD.WTTS.Models;

public class ArticleCategoryDTO
{
    public Guid Id { get; set; }

    public string Name { get; set; } = string.Empty;
}

public class ArticleCategoryTreeDTO : ArticleCategoryDTO
{
    public ArticleCategoryTreeDTO[]? Child { get; set; }
}