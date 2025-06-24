using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

public record CourseRequestDto
(
    [Required(ErrorMessage = "Name is requierd")]
    [StringLength(100, MinimumLength = 3, ErrorMessage = "The length of the name is from 3 to 100 characters")]
    string Name,
    [Required(ErrorMessage = "Name is requierd")]
    [StringLength(1000, MinimumLength = 3, ErrorMessage = "The length of the name is from 3 to 1000 characters")]
    string Description
);