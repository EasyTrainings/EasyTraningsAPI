using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EasyTraningsAPI.User.Enum;

namespace EasyTraningsAPI.User.Entities;

public class User
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string Login { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public string Username { get; set; }
    public UserRole Role { get; set; } 
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime BirthDate { get; set; }
    public int? SeasonTicketId { get; set; }
    public SeasonTicket.Entities.SeasonTicket? SeasonTicket { get; set; } //foreign key
    public UserAccountStatus AccountStatus { get; set; }
}
   