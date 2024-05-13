using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyTraningsAPI.Models.Entities;

public class TrainningType
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public int Name { get; set; }
    public int PeopleQuintity { get; set; }
}