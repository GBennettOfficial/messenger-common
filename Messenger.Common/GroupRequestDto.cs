namespace Messenger.Common
{
    public record GroupRequestDto(string Name, string Description, GroupRole Role, string Username, string FirstName, string LastName, int UserCount);
    
}
