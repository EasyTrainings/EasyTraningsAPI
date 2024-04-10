using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyTraningsAPI.Tranning.Entities;

public class Tranning
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string Name { get; set; }
    
    //TO-DO FIX THIS! int -> existing entity
    //CREATE AgeCategory & TrainingType entities
    
    //public int AgeCategory { get; set; } // Foreign Key 
    //public int TrainingTypeId { get; set; } // Foreign Key
    
    
    public double Duration { get; set; } 
    public DateTime StartDate { get; set; } 
    public DateTime EndDate { get; set; } 
    public int LocationId { get; set; } 
}