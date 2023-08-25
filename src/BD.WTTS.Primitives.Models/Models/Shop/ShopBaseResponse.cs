namespace BD.WTTS.Models;

public sealed class ShopBaseResponse<T>
{
    public bool Status { get; set; }

    public T? Data { get; set; }

    public string? Msg { get; set; }
}
