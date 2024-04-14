namespace EasyTraningsAPI.Models.DTOs;

public record UserDto()
{
    public int Id { get; init; }
    public string? Login { get; init; }
    public string? Password { get; init; }
    public string? Email { get; init; }
    public string? Username { get; init; }
    public string? RegistrationDate { get; init; }
    public string? Role { get; init; }
    // public RoleEnum Role { get; init; }
    public string? FirstName { get; init; }
    public string? LastName { get; init; }
    public DateTime CreatedAt { get; init; }
    public DateTime UpdatedAt { get; init; }
    public bool IsDeleted { get; init; }  //????
    public DateTime BirthDate { get; init; }
    public int SeasonTicketUid { get; init; }
    public string? AccountStatus { get; init; }
    // public AccountStatusEnum AccountStatus { get; init; }
}