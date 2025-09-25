using System.ComponentModel.DataAnnotations;

public class RedirectEntry
{
    [Key] // Primary Key
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string ShortUri { get; set; } = string.Empty; // e.g. "abc123"

    [Required]
    [MaxLength(2048)]
    public string LongUrl { get; set; } = string.Empty;  // e.g. "https://example.com/page"

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}

