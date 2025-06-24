using System.Text.Json.Serialization;

public record UserProfileDto
(
    string Email,
    [property: JsonConverter(typeof(JsonStringEnumConverter))]
    Role Role
);