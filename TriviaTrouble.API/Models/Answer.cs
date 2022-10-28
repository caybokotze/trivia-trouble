using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace TriviaTrouble.Models;

public class Answer
{
    [Key]
    public int Id { get; set; }
    
    [JsonIgnore]
    [ForeignKey(nameof(QuestionId))] 
    public virtual Question? Question { get; set; }
    public int QuestionId { get; set; }
    public string? Text { get; set; }
}