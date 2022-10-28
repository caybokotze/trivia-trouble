using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace TriviaTrouble.Models;

public interface IQuestion
{
    int Id { get; set; }
    string? Text { get; set; }
    int CorrectAnswerId { get; set; }
}

public class Question : IQuestion
{
    public Question()
    {
    }
    
    [Key]
    public int Id { get; set; }
    
    [Required]
    public string? Text { get; set; }
    public virtual List<Answer>? Answers { get; set; }
    
    [JsonIgnore]
    public int CorrectAnswerId { get; set; }
    
    [NotMapped]
    public Answer? CorrectAnswer { get; set; }
}