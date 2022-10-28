using AutoMapper;
using TriviaTrouble.Dto;
using TriviaTrouble.Models;

namespace TriviaTrouble;

public static class MapTo<TSource, TDestination>
{
    public static TDestination FromSource(TSource source)
    {
        var config = new MapperConfiguration(c =>
        {
            c.CreateMap<Question, QuestionDto>();
            c.CreateMap<QuestionDto, Question>();
        });
        
        var mapper = new Mapper(config);
        return mapper.Map<TSource, TDestination>(source);
    }
}