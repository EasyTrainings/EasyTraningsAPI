namespace EasyTraningsAPI.SeasonTicket.Entities;

public class SeasonTicket
{
    public int Id { get; set; } 
    public string Name { get; set; } 
    public double Price { get; set; } 
    public DateTime StartDate { get; set; } 
    public DateTime EndDate { get; set; } 
    public int TrainingTypeId { get; set; } // Foreign Key
    public int TrainingSessions { get; set; } 
    public int RemainingSessions { get; set; }
}