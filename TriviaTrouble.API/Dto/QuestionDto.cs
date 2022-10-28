using TriviaTrouble.Models;

namespace TriviaTrouble.Dto;

public class QuestionDto : IQuestion
{
    public int Id { get; set; }
    public string? Text { get; set; }
    public int CorrectAnswerId { get; set; }
}