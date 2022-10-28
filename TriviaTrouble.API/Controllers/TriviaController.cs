using System.ComponentModel.DataAnnotations;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TriviaTrouble.Dto;
using TriviaTrouble.Models;

namespace TriviaTrouble.Controllers;

[ApiController]
[Route("/api/trivia")]
public class TriviaController : ControllerBase
{
    private readonly DataContext _dataContext;

    public TriviaController(DataContext dataContext)
    {
        _dataContext = dataContext;
    }
    
    [HttpGet]
    [Route("questions")]
    public List<Question>? GetQuestions()
    {
        var questions = _dataContext.Questions?.ToList() 
                        ?? throw new InvalidDataException("There are no questions available");

        var answers = _dataContext.Answers?.ToList() 
                      ?? throw new InvalidDataException("There are no answers available");
        
        foreach (var question in questions)
        {
            question.Answers = answers.Where(w => w.QuestionId == question.Id).ToList();
            question.CorrectAnswer = answers.First(f => f.Id == question.CorrectAnswerId);
        }

        return questions;
    }
    
    [HttpGet]
    [Route("question/{id:int}")]
    public Question GetQuestion(int id)
    {
        var question = _dataContext.Questions?.FirstOrDefault(f => f.Id == id);
        if (question is null)
        {
            throw new InvalidDataException("The question can not be found");
        }
        var questionAnswers = _dataContext.Answers?.Where(w => w.QuestionId == question.Id).ToList();

        question.Answers = questionAnswers;
        question.CorrectAnswer = questionAnswers?.FirstOrDefault(f => f.Id == question.CorrectAnswerId);
        return question;
    }

    [HttpPost]
    [Route("question")]
    public void PostQuestion(TriviaDto triviaDto)
    {
        _dataContext.Questions?.Add(triviaDto.Question ?? throw new InvalidDataException());
        _dataContext.SaveChanges();

        foreach (var answer in triviaDto.Answers ?? throw new InvalidDataException())
        {
            answer.QuestionId = triviaDto.Question?.Id??0;
            _dataContext?.Answers?.Add(answer);
            _dataContext?.SaveChanges();
        }
    }

    [HttpPut]
    [Route("question")]
    public void UpdateQuestion(QuestionDto question)
    {
        var dbQuestion = _dataContext.Questions?.FirstOrDefault(f => f.Id == question.Id);
        if (dbQuestion is null)
        {
            throw new ValidationException("The id provided is not valid");
        }

        if (dbQuestion is null)
        {
            throw new FileNotFoundException("Could not find the question stored in the database");
        }

        dbQuestion.CorrectAnswerId = question.CorrectAnswerId;
        _dataContext.Questions?.Update(dbQuestion);
        _dataContext.SaveChanges();
    }
}