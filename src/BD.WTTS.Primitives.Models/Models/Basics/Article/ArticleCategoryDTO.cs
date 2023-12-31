namespace BD.WTTS.Models;

[MPObj, MP2Obj(SerializeLayout.Explicit)]
public partial class ArticleCategoryDTO
{
    [MPKey(0), MP2Key(0)]
    public Guid Id { get; set; }

    [MPKey(1), MP2Key(1)]
    public string Name { get; set; } = string.Empty;
}

public class ArticleCategoryTreeDTO : ArticleCategoryDTO
{
    public ArticleCategoryTreeDTO[]? Child { get; set; }
}