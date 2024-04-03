using System.Net.NetworkInformation;

namespace BD.WTTS.Helpers;

public static class NetworkInterfaceHelper
{
    private const string _exceptVirtualDesc = "virtual";

    public static string? GetMACAddressStr(string separator = "-")
    {
        try
        {
            var physicalAddress = GetMACAddress();

            if (physicalAddress == null)
                return null;

            var addressStringParts = physicalAddress
                .GetAddressBytes()
                .Select(x => x.ToString("X2"));

            return string.Join(separator, addressStringParts);
        }
        catch
        {
            return null;
        }
    }

    public static PhysicalAddress? GetMACAddress()
    {
        NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();

        if (nics == null || nics.Length < 1)
            return null;

        var adapter = nics.FirstOrDefault(x =>
                    x.NetworkInterfaceType != NetworkInterfaceType.Loopback &&
                                x.OperationalStatus == OperationalStatus.Up &&
                                           !x.Description.Contains(_exceptVirtualDesc, StringComparison.OrdinalIgnoreCase)
                                                   );

        return adapter?.GetPhysicalAddress();
    }
}