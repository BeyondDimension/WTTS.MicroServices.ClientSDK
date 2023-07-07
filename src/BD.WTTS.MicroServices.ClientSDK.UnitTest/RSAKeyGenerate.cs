using System.Runtime.Serialization.Formatters;

namespace BD.WTTS.MicroServices.ClientSDK.UnitTest;

public sealed class RSAKeyGenerate
{
    [Test]
    public void Generate()
    {
        //var cfg = "debug";
        //using var rsa = RSA.Create(4096);
        //var privateKey = rsa.ToJsonString(true);
        //Console.WriteLine(privateKey); // RSA 私钥，Json 格式，存储在服务端数据库中
        //MemoryPackFormatterProvider.Register<MemoryPackFormatters>();
        //var keyPath = Path.Combine(ProjectUtils.ProjPath, $"rsa-public-key-{cfg}.bin");
        //var bytes = Serializable.SMP2(rsa.ExportParameters(false));
        //File.WriteAllBytes(keyPath, bytes);

        //var key = """

        //    """;
        //using var rsa = RSA.Create();
        //RSAUtils.FromJsonString(rsa, key);
        //var publicKey = rsa.ToJsonString(false);
        //Console.WriteLine(publicKey);
    }
}
