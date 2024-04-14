namespace EasyTraningsAPI.Models.DTOs;

public record TranningDto()
{
    public int Id { get; init; }
    public string? Name { get; init; }
    public int AgeCategoryId { get; init; }
    public int TranningTypeId { get; init; }
    public double Duration { get; init; }
    public DateTime StartDate { get; init; }
    public DateTime EndDate { get; init; }
    public int LocationId { get; init; }
}