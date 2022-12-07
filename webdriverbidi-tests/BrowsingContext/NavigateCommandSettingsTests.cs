namespace WebDriverBidi.BrowsingContext;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

[TestFixture]
public class NavigateCommandSettingsTests
{
    [Test]
    public void TestCanSerializeSettings()
    {
        var properties = new NavigateCommandSettings("myContextId", "http://example.com");
        string json = JsonConvert.SerializeObject(properties);
        JObject serialized = JObject.Parse(json);
        Assert.That(serialized.Count, Is.EqualTo(2));
        Assert.That(serialized.ContainsKey("context"));
        Assert.That(serialized["context"]!.Type, Is.EqualTo(JTokenType.String));
        Assert.That(serialized["context"]!.Value<string>(), Is.EqualTo("myContextId"));
        Assert.That(serialized.ContainsKey("url"));
        Assert.That(serialized["url"]!.Type, Is.EqualTo(JTokenType.String));
        Assert.That(serialized["url"]!.Value<string>(), Is.EqualTo("http://example.com"));
    }

    [Test]
    public void TestCanSerializeSettingsWithAcceptWaitNone()
    {
        var properties = new NavigateCommandSettings("myContextId", "http://example.com");
        properties.Wait = ReadinessState.None;
        string json = JsonConvert.SerializeObject(properties);
        JObject serialized = JObject.Parse(json);
        Assert.That(serialized.Count, Is.EqualTo(3));
        Assert.That(serialized.ContainsKey("context"));
        Assert.That(serialized["context"]!.Type, Is.EqualTo(JTokenType.String));
        Assert.That(serialized["context"]!.Value<string>(), Is.EqualTo("myContextId"));
        Assert.That(serialized.ContainsKey("url"));
        Assert.That(serialized["url"]!.Type, Is.EqualTo(JTokenType.String));
        Assert.That(serialized["url"]!.Value<string>(), Is.EqualTo("http://example.com"));
        Assert.That(serialized.ContainsKey("wait"));
        Assert.That(serialized["wait"]!.Type, Is.EqualTo(JTokenType.String));
        Assert.That(serialized["wait"]!.Value<string>(), Is.EqualTo("none"));
    }

    [Test]
    public void TestCanSerializeSettingsWithAcceptWaitInteractive()
    {
        var properties = new NavigateCommandSettings("myContextId", "http://example.com");
        properties.Wait = ReadinessState.Interactive;
        string json = JsonConvert.SerializeObject(properties);
        JObject serialized = JObject.Parse(json);
        Assert.That(serialized.Count, Is.EqualTo(3));
        Assert.That(serialized.ContainsKey("context"));
        Assert.That(serialized["context"]!.Type, Is.EqualTo(JTokenType.String));
        Assert.That(serialized["context"]!.Value<string>(), Is.EqualTo("myContextId"));
        Assert.That(serialized.ContainsKey("url"));
        Assert.That(serialized["url"]!.Type, Is.EqualTo(JTokenType.String));
        Assert.That(serialized["url"]!.Value<string>(), Is.EqualTo("http://example.com"));
        Assert.That(serialized.ContainsKey("wait"));
        Assert.That(serialized["wait"]!.Type, Is.EqualTo(JTokenType.String));
        Assert.That(serialized["wait"]!.Value<string>(), Is.EqualTo("interactive"));
    }

    [Test]
    public void TestCanSerializeSettingsWithAcceptWaitComplete()
    {
        var properties = new NavigateCommandSettings("myContextId", "http://example.com");
        properties.Wait = ReadinessState.Complete;
        string json = JsonConvert.SerializeObject(properties);
        JObject serialized = JObject.Parse(json);
        Assert.That(serialized.Count, Is.EqualTo(3));
        Assert.That(serialized.ContainsKey("context"));
        Assert.That(serialized["context"]!.Type, Is.EqualTo(JTokenType.String));
        Assert.That(serialized["context"]!.Value<string>(), Is.EqualTo("myContextId"));
        Assert.That(serialized.ContainsKey("url"));
        Assert.That(serialized["url"]!.Type, Is.EqualTo(JTokenType.String));
        Assert.That(serialized["url"]!.Value<string>(), Is.EqualTo("http://example.com"));
        Assert.That(serialized.ContainsKey("wait"));
        Assert.That(serialized["wait"]!.Type, Is.EqualTo(JTokenType.String));
        Assert.That(serialized["wait"]!.Value<string>(), Is.EqualTo("complete"));
    }
}