using static BD.WTTS.MicroServices.Primitives.R.Strings;
using static BD.WTTS.R.Strings;
using ApiResponseCode = BD.WTTS.Enums.ApiRspCode;

// ReSharper disable once CheckNamespace
namespace BD.WTTS;

public static class ApiRspExtensions
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    static bool IsClientExceptionOrServerException(ApiResponseCode code) => code switch
    {
        ApiResponseCode.ClientException => true,
        _ => false,
    };

    public static string GetMessage(this ApiResponseCode code, string? errorAppendText = null, string? errorFormat = null)
    {
        if (code == ApiResponseCode.OK || code == ApiResponseCode.Canceled)
        {
            return string.Empty;
        }
        else if (code == ApiResponseCode.Unauthorized)
        {
            return ApiResponseCode_Unauthorized;
        }
        else if (code == ApiResponseCode.IsNotOfficialChannelPackage)
        {
            return IsNotOfficialChannelPackageWarning;
        }
        else if (code == ApiResponseCode.AppObsolete)
        {
            return ApiResponseCode_AppObsolete;
        }
        else if (code == ApiResponseCode.UserIsBan)
        {
            return UserIsBanErrorMessage;
        }
        else if (code == ApiResponseCode.CertificateNotYetValid)
        {
            return ApiResponseCode_CertificateNotYetValid;
        }
        else if (code == ApiResponseCode.NetworkConnectionInterruption)
        {
            return NetworkConnectionInterruption;
        }
        else if (code == ApiResponseCode.BadGateway)
        {
            return ApiResponseCode_BadGateway;
        }
        string message;
        var notErrorAppendText = string.IsNullOrWhiteSpace(errorAppendText);
        if (string.IsNullOrWhiteSpace(errorFormat))
        {
            if (notErrorAppendText)
            {
                errorFormat = IsClientExceptionOrServerException(code) ? ClientError_ : ServerError_;
            }
            else
            {
                errorFormat = IsClientExceptionOrServerException(code) ? ClientError__ : ServerError__;
            }
        }
        if (notErrorAppendText)
        {
            message = errorFormat.Format((int)code);
        }
        else
        {
            message = errorFormat.Format((int)code, errorAppendText);
        }
        return message;
    }

    internal static string GetMessage(this IApiRsp response, string? errorAppendText = null, string? errorFormat = null)
    {
        var message = response.InternalMessage;
        if (string.IsNullOrWhiteSpace(message))
        {
            if (response.Code == ApiResponseCode.ClientException && response is ApiRsp impl && impl.ClientException != null)
            {
                var exMsg = impl.ClientException.GetAllMessage();
                if (string.IsNullOrWhiteSpace(errorAppendText)) errorAppendText = exMsg;
                else errorAppendText = $"{errorAppendText}{Environment.NewLine}{exMsg}";
            }
            message = GetMessage(response.Code, errorAppendText, errorFormat);
        }
        return message;
    }
}
