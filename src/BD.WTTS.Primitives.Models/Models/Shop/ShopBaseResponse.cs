namespace BD.WTTS.Models;

public class ShopBaseResponse<T> where T : class
{
    public bool Status { get; set; }

    public T? Data { get; set; }

    public string? Msg { get; set; }
}
