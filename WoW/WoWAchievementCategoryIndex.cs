using System.Text.Json.Serialization;

namespace BNETAPI.WoW;

public record GuildCategory(
    [property: JsonPropertyName("key")] Key Key,
    [property: JsonPropertyName("name")] Name Name,
    [property: JsonPropertyName("id")] int Id
);

public record WoWAchievementCategoryIndexRoot(
    [property: JsonPropertyName("_links")] Links Links,
    [property: JsonPropertyName("categories")] IReadOnlyList<Category> Categories,
    [property: JsonPropertyName("root_categories")] IReadOnlyList<RootCategory> RootCategories,
    [property: JsonPropertyName("guild_categories")] IReadOnlyList<GuildCategory> GuildCategories
);

public record RootCategory(
    [property: JsonPropertyName("key")] Key Key,
    [property: JsonPropertyName("name")] Name Name,
    [property: JsonPropertyName("id")] int Id
);