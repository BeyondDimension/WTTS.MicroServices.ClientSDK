namespace BD.WTTS.Models;
public class ArticleCategoryDTO1
{

    public Guid Id { get; set; }

    public string Name { get; set; } = string.Empty;
}

public class ArticleCategoryTreeDTO : ArticleCategoryDTO1
{
    public ArticleCategoryDTO1[]? Child { get; set; }
}