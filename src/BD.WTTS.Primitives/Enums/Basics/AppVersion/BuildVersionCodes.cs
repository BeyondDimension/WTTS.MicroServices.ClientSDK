// ReSharper disable once CheckNamespace
namespace BD.WTTS.Enums;

/// <summary>
/// <para>Enumeration of the currently known SDK version codes. These are the values that can be found in VERSION#SDK. Version numbers increment monotonically with each official platform release.</para>
/// <para>枚举当前已知的SDK版本代码。 这些是可以在 VERSION#SDK 中找到的值。 版本号随每个官方平台版本单调递增。</para>
/// <para>https://developer.android.google.cn/reference/android/os/Build.VERSION_CODES.html?hl=en</para>
/// <para>---------- Xamarin.Android ----------</para>
/// <para>程序集 Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065</para>
/// <para>C:\Program Files (x86)\Microsoft Visual Studio\2019\Enterprise\Common7\IDE\ReferenceAssemblies\Microsoft\Framework\MonoAndroid\v11.0\Mono.Android.dll</para>
/// <para>Android.OS.BuildVersionCodes</para>
/// <para>---------- Xamarin.Android ----------</para>
/// </summary>
public enum BuildVersionCodes
{
    /// <summary>
    /// October 2008: The original, first, version of Android
    /// <para>2008年10月：Android的原始版本</para>
    /// </summary>
    Base = 1,

    /// <summary>
    /// February 2009: First Android update, officially called 1.1
    /// <para>2009年2月：第一次Android更新，正式名为1.1</para>
    /// </summary>
    Base11 = 2,

    /// <summary>
    /// May 2009: Android 1.5
    /// <para>2009年5月：Android 1.5</para>
    /// </summary>
    Cupcake = 3,

    /// <summary>
    /// September 2009: Android 1.6
    /// <para>2009年9月：Android 1.6</para>
    /// </summary>
    Donut = 4,

    /// <summary>
    /// November 2009: Android 2.0
    /// <para>2009年11月：Android 2.0</para>
    /// </summary>
    Eclair = 5,

    /// <summary>
    /// December 2009: Android 2.0.1
    /// <para>2009年12月：Android 2.0.1</para>
    /// </summary>
    Eclair01 = 6,

    /// <summary>
    /// January 2010: Android 2.1
    /// <para>2010年1月：Android 2.1</para>
    /// </summary>
    EclairMr1 = 7,

    /// <summary>
    /// June 2010: Android 2.2
    /// <para>2010年6月：Android 2.2</para>
    /// </summary>
    Froyo = 8,

    /// <summary>
    /// November 2010: Android 2.3
    /// <para>2010年11月：Android 2.3</para>
    /// </summary>
    Gingerbread = 9,

    /// <summary>
    /// February 2011: Android 2.3.3
    /// <para>2011年2月：Android 2.3.3</para>
    /// </summary>
    GingerbreadMr1 = 10,

    /// <summary>
    /// February 2011: Android 3.0
    /// <para>2011年2月：Android 3.0</para>
    /// </summary>
    Honeycomb = 11,

    /// <summary>
    /// May 2011: Android 3.1
    /// <para>2011年5月：Android 3.1</para>
    /// </summary>
    HoneycombMr1 = 12,

    /// <summary>
    /// June 2011: Android 3.2
    /// <para>2011年6月：Android 3.2</para>
    /// </summary>
    HoneycombMr2 = 13,

    /// <summary>
    /// October 2011: Android 4.0
    /// <para>2011年10月：Android 4.0</para>
    /// </summary>
    IceCreamSandwich = 14,

    /// <summary>
    /// December 2011: Android 4.0.3
    /// <para>2011年12月：Android 4.0.3</para>
    /// </summary>
    IceCreamSandwichMr1 = 15,

    /// <summary>
    /// June 2012: Android 4.1
    /// <para>2012年6月：Android 4.1</para>
    /// </summary>
    JellyBean = 16,

    /// <summary>
    /// November 2012: Android 4.2, Moar jelly beans!
    /// <para>2012年11月：Android 4.2</para>
    /// </summary>
    JellyBeanMr1 = 17,

    /// <summary>
    /// July 2013: Android 4.3, the revenge of the beans.
    /// <para>2013年7月：Android 4.3</para>
    /// </summary>
    JellyBeanMr2 = 18,

    /// <summary>
    /// October 2013: Android 4.4, KitKat, another tasty treat.
    /// <para>2013年10月：Android 4.4</para>
    /// </summary>
    Kitkat = 19,

    /// <summary>
    /// June 2014: Android 4.4W
    /// <para>2014年6月：Android 4.4W</para>
    /// </summary>
    KitkatWatch = 20,

    /// <summary>
    /// November 2014: Lollipop.
    /// <para>2014年11月：棒棒糖</para>
    /// </summary>
    Lollipop = 21,

    /// <summary>
    /// March 2015: Lollipop with an extra sugar coating on the outside! For more information about this release, see the Android 5.1 APIs.
    /// <para>2015年3月：棒棒糖外面有额外的糖衣！ 有关此版本的更多信息，请参阅 Android 5.1 API。</para>
    /// </summary>
    LollipopMr1 = 22,

    /// <summary>
    /// M is for Marshmallow!
    /// <para>M 代表棉花糖！</para>
    /// </summary>
    M = 23,

    /// <summary>
    /// N is for Nougat.
    /// <para>N 代表牛轧糖。</para>
    /// </summary>
    N = 24,

    /// <summary>
    /// N MR1: Nougat++.
    /// </summary>
    NMr1 = 25,

    /// <summary>
    /// O.
    /// </summary>
    O = 26,

    /// <summary>
    /// O MR1.
    /// </summary>
    OMr1 = 27,

    /// <summary>
    /// P / Android 9
    /// </summary>
    P = 28,

    /// <summary>
    /// Q / Android 10
    /// </summary>
    Q = 29,

    /// <summary>
    /// P / Android 11
    /// </summary>
    R = 30,

    /// <summary>
    /// Android 12
    /// </summary>
    S = 31,

    /// <summary>
    /// Magic version number for a current development build, which has not yet turned into an official release.
    /// <para>当前开发版本的魔术版本号，尚未转变为官方版本。</para>
    /// </summary>
    CurDevelopment = 10000,
}