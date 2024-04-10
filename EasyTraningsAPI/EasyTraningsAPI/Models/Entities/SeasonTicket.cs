using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyTraningsAPI.SeasonTicket.Entities;

public class SeasonTicket
{ 
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; } 
    public string Name { get; set; } 
    public double Price { get; set; } 
    public DateTime StartDate { get; set; } 
    public DateTime EndDate { get; set; } 
    
    //TO-DO FIX THIS! int -> existing entity
    //CREATE TrainingType entities
    
    // public int TrainingTypeId { get; set; } // Foreign Key
    
    public int TrainingSessions { get; set; } 
    public int RemainingSessions { get; set; }
}