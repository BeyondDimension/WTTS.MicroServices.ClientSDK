// ReSharper disable once CheckNamespace
namespace BD.WTTS.Models.Abstractions;

public interface IUserDTO
{
    const int MaxLength_NickName = Constants.Lengths.Max_CUserNickName;

    Guid Id { get; set; }

    /// <summary>
    /// 昵称
    /// </summary>
    string NickName { get; set; }

    /// <summary>
    /// 头像
    /// </summary>
    Guid Avatar { get; set; }

    protected static string GetDebuggerDisplay(IUserDTO user) => $"{user.NickName}: {user.Id}";
}