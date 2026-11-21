namespace BD.WTTS.MicroServices.ClientSDK.UnitTest;

public sealed class ApiSerializationTest
{
    [Test]
    public async Task MessagePackReadsIndexedEnvelopesWithOrWithoutContent()
    {
        // Legacy raw MessagePack: [200, nil, true] and [400, "bad"].
        byte[] success = [0x93, 0xCC, 0xC8, 0xC0, 0xC3];
        byte[] error = [0x92, 0xCD, 0x01, 0x90, 0xA3, 0x62, 0x61, 0x64];
        Assert.That(ApiRspHelper.Deserialize<bool>(success).Content, Is.True);

        using var stream = new MemoryStream(error);
        var response = await ApiRspHelper.DeserializeAsync<List<AdvertisementDTO>>(stream);
        Assert.That((int)response.Code, Is.EqualTo(400));
        Assert.That(response.Content, Is.Null);
    }

    [Test]
    public async Task MessagePackReadsCompressedAdvertisementList()
    {
        var id = Guid.Parse("12345678-1234-4321-abcd-123456789abc");
        var name = new string('a', 256); // Cross the LZ4 compression threshold.
        var envelope = ApiRspHelper.Ok(new List<AdvertisementDTO> { new() { Id = id, Name = name } });
        var bytes = Serializable.SMP(envelope);
        using var stream = new MemoryStream(bytes);

        var response = await ApiRspHelper.DeserializeAsync<List<AdvertisementDTO>>(stream);
        Assert.That(response.Content?.Single().Id, Is.EqualTo(id));
        Assert.That(response.Content?.Single().Name, Is.EqualTo(name));
    }

    [Test]
    public async Task MemoryPackReadsIdentityProfileWithAnEnumDictionary()
    {
        const string avatar = "https://example.invalid/avatar";
        var envelope = ApiRspHelper.Ok(new IdentityUserInfoDTO
        {
            NickName = "fixture",
            AvatarUrl = new() { [ExternalLoginChannel.Microsoft] = avatar },
        });
        using var stream = new MemoryStream(MemoryPackSerializer.Serialize(envelope));

        var response = await ApiRspHelper.MemoryPackDeserializeAsync<IdentityUserInfoDTO>(stream);
        Assert.That(response.Content?.AvatarUrl?[ExternalLoginChannel.Microsoft], Is.EqualTo(avatar));
    }

    [Test]
    public void MessagePackWritesSteamRequestAsAnIndexedArray()
    {
        var request = new QuerySteamAppIdExistOwnedGamesRequest(76561198000000000, 570);
        var bytes = MessagePackSerializer.Serialize(request, ApiMessagePack.Options);
        var reader = new MessagePackReader(bytes);

        Assert.That(reader.ReadArrayHeader(), Is.EqualTo(2));
        Assert.That(reader.ReadInt64(), Is.EqualTo(request.SteamUserId64));
        Assert.That(reader.ReadInt32(), Is.EqualTo(request.AppId));
        Assert.That(reader.End, Is.True);
    }

    [Test]
    public void JsonContextContainsTelemetryAndVersionSubmissionRoots()
    {
        Assert.That(ApiJsonSerializerContext.Default.GetTypeInfo(typeof(ActiveUserRecordDTO)), Is.Not.Null);
        Assert.That(ApiJsonSerializerContext.Default.GetTypeInfo(typeof(AppVerSubmissionRequest)), Is.Not.Null);
    }
}
