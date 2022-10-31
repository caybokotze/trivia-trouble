using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace TriviaTrouble.UI.Models;

public class Question
{
    public int Id { get; set; }
    
    public string? Text { get; set; }
    
    public virtual List<Answer>? Answers { get; set; }
    public Answer? CorrectAnswer { get; set; }
}