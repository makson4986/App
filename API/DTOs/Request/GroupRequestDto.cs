using System.ComponentModel.DataAnnotations;

public record GroupRequestDto
(   
    [Required(ErrorMessage = "Name is requierd")]
    [StringLength(100, MinimumLength = 3, ErrorMessage = "The length of the name is from 3 to 100 characters")]
    string Name
);