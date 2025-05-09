namespace Messenger.Common;

public record RegisterDto(string Username, string FirstName, string LastName, string Email, string? Phone, string? Picture, string Password);
