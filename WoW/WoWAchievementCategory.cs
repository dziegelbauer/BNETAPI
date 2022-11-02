using System.Text.Json.Serialization;

namespace BNETAPI.WoW;

public record AggregatesByFaction(
    [property: JsonPropertyName("alliance")] Alliance Alliance,
    [property: JsonPropertyName("horde")] Horde Horde
);

public record Alliance(
    [property: JsonPropertyName("quantity")] int Quantity,
    [property: JsonPropertyName("points")] int Points
);

public record Horde(
    [property: JsonPropertyName("quantity")] int Quantity,
    [property: JsonPropertyName("points")] int Points
);

public record ParentCategory(
    [property: JsonPropertyName("key")] Key Key,
    [property: JsonPropertyName("name")] Name Name,
    [property: JsonPropertyName("id")] int Id
);

public record WoWAchievementCategoryRoot(
    [property: JsonPropertyName("_links")] Links Links,
    [property: JsonPropertyName("id")] int Id,
    [property: JsonPropertyName("name")] Name Name,
    [property: JsonPropertyName("achievements")] IReadOnlyList<Achievement> Achievements,
    [property: JsonPropertyName("parent_category")] ParentCategory ParentCategory,
    [property: JsonPropertyName("is_guild_category")] bool IsGuildCategory,
    [property: JsonPropertyName("aggregates_by_faction")] AggregatesByFaction AggregatesByFaction,
    [property: JsonPropertyName("display_order")] int DisplayOrder
);
