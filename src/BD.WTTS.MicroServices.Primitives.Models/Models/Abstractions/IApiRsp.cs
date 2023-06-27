using ApiRspEx = BD.WTTS.ApiRspExtensions;

namespace BD.WTTS.Models.Abstractions;

/// <summary>
/// 微服务接口响应接口
/// </summary>
public interface IApiRsp /*: IApiResponse*/
{
    /// <summary>
    /// 响应码
    /// </summary>
    ApiRspCode Code { get; set; }

    /// <summary>
    /// 显示消息
    /// </summary>
    string Message => ApiRspEx.GetMessage(this);

    /// <summary>
    /// 获取显示消息并在末尾追加文本
    /// </summary>
    /// <param name="errorAppendText"></param>
    /// <returns></returns>
    string GetMessageByAppendText(string? errorAppendText)
        => ApiRspEx.GetMessage(this, errorAppendText);

    /// <summary>
    /// 通过自定义格式化文本获取显示消息
    /// </summary>
    /// <param name="errorFormat"></param>
    /// <param name="errorAppendText"></param>
    /// <returns></returns>
    string GetMessageByFormat(string errorFormat, string? errorAppendText = null)
        => ApiRspEx.GetMessage(this, errorAppendText, errorFormat);

    /// <summary>
    /// 内部显示消息
    /// </summary>
    internal string? InternalMessage { get; set; }

    /// <summary>
    /// 是否成功
    /// </summary>
    /// <returns></returns>
    /*new*/
    bool IsSuccess { get; }

    //bool IApiResponse.IsSuccess
    //{
    //    get => IsSuccess;
    //    set
    //    {
    //        if (this is object apiRsp)
    //        {
    //            return;
    //        }
    //        throw new NotSupportedException();
    //    }
    //}

    //string[] IApiResponse.Messages
    //{
    //    get => new[] { Message };
    //    set
    //    {
    //        if (value != null)
    //        {
    //            InternalMessage = value.Length switch
    //            {
    //                0 => string.Empty,
    //                1 => value[0],
    //                _ => string.Join(Environment.NewLine, value),
    //            };
    //        }
    //        else
    //        {
    //            InternalMessage = null;
    //        }
    //    }
    //}
}

/// <inheritdoc cref="IApiRsp"/>
public interface IApiRsp<out T> : IApiRsp/*, IApiResponse<T>*/
{
    /// <summary>
    /// 附加内容
    /// </summary>
    T? Content { get; }

    //T? IApiResponse<T>.Data => Content;
}