using SR = BD.WTTS.R.Strings;

// ReSharper disable once CheckNamespace
namespace BD.WTTS.Enums;

public enum AppUpdateFailCode : byte
{
    /// <summary>
    /// <inheritdoc cref="SR.DownloadUpdateFail"/>
    /// </summary>
    DownloadUpdateFail,

    /// <summary>
    /// <inheritdoc cref="SR.UpdatePackVerificationFail"/>
    /// </summary>
    UpdatePackVerificationFail,

    /// <summary>
    /// <inheritdoc cref="SR.UpdatePackCacheHashInvalidDeleteFileFail_"/>
    /// </summary>
    UpdatePackCacheHashInvalidDeleteFileFail_,

    /// <summary>
    /// <inheritdoc cref="SR.UpdateEnumOutOfRange"/>
    /// </summary>
    UpdateEnumOutOfRange,

    /// <summary>
    /// <inheritdoc cref="SR.UpdateUnpackFail"/>
    /// </summary>
    UpdateUnpackFail,
}

public static partial class ApplicationUpdateFailCodeEnumExtensions
{
    public static string ToString2(this AppUpdateFailCode appUpdateFailCode, params string[] args) => appUpdateFailCode switch
    {
        AppUpdateFailCode.DownloadUpdateFail => SR.DownloadUpdateFail,
        AppUpdateFailCode.UpdatePackVerificationFail => SR.UpdatePackVerificationFail,
        AppUpdateFailCode.UpdatePackCacheHashInvalidDeleteFileFail_ => SR.UpdatePackCacheHashInvalidDeleteFileFail_.Format(args),
        AppUpdateFailCode.UpdateEnumOutOfRange => SR.UpdateEnumOutOfRange,
        AppUpdateFailCode.UpdateUnpackFail => SR.UpdateUnpackFail,
        _ => throw new ArgumentOutOfRangeException(nameof(appUpdateFailCode), appUpdateFailCode, null),
    };
}