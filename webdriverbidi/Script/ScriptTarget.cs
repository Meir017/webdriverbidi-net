namespace WebDriverBidi.Script;

using Newtonsoft.Json;
using JsonConverters;

[JsonObject(MemberSerialization.OptIn)]
[JsonConverter(typeof(ScriptTargetJsonConverter))]
public abstract class ScriptTarget
{
}