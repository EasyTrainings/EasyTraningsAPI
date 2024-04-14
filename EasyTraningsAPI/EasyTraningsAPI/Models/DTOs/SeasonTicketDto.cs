namespace EasyTraningsAPI.Models.DTOs;

public record SeasonTicketDto()
{
    public int Id { get; init; }
    public string? Name { get; init; }
    public double Price { get; init; }
    public DateTime StartDate { get; init; }
    public DateTime EndDate { get; init; }
    public int TrainingType { get; init; }
    public int TrainingSessions { get; init; }
    public int RemainingSessions { get; init; }
}