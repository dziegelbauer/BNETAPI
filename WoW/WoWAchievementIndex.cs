using System.Text.Json.Serialization;

namespace BNETAPI.WoW;

public record WoWAchievementIndexRoot(
    [property: JsonPropertyName("_links")] Links Links,
    [property: JsonPropertyName("achievements")] IReadOnlyList<Achievement> Achievements
);