namespace BD.WTTS.Models;

public class ShopBaseRequest<T> where T : class
{
    public int Id { get; set; }

    public T? Data { get; set; }
}

public class ShopBaseRequest
{
    public int Id { get; set; }

    public object? Data { get; set; }
}
