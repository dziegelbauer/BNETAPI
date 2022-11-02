using System.Text.Json.Serialization;

namespace BNETAPI.WoW;

public record Asset(
    [property: JsonPropertyName("key")] string Key,
    [property: JsonPropertyName("value")] string Value,
    [property: JsonPropertyName("file_data_id")] int FileDataId
);

public record WoWAchievementMediaRoot(
    [property: JsonPropertyName("_links")] Links Links,
    [property: JsonPropertyName("assets")] IReadOnlyList<Asset> Assets,
    [property: JsonPropertyName("id")] int Id
);