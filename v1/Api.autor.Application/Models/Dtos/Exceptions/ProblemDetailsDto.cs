namespace Api.autor.Application.Models.Dtos.Exceptions
{
    public record struct ProblemDetailsDto(
         int Status,
        string Type,
        string Title,
        string Detail,
        Dictionary<string, List<string>> InvalidParams);
  
}
