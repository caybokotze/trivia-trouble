using TriviaTrouble.Models;

namespace TriviaTrouble.Dto;

public class TriviaDto
{
    public Question? Question { get; set; }
    public List<Answer>? Answers { get; set; }
}