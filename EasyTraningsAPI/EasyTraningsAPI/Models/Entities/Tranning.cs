namespace EasyTraningsAPI.Tranning.Entities;

public class Tranning
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int AgeCategoryId { get; set; } // Foreign Key
    public int TrainingTypeId { get; set; } // Foreign Key
    public double Duration { get; set; } 
    public DateTime StartDate { get; set; } 
    public DateTime EndDate { get; set; } 
    public int LocationId { get; set; } 
}