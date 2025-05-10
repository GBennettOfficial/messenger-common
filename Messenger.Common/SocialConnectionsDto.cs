namespace Messenger.Common
{
    public record SocialConnectionsDto(List<FriendDto> Friends, List<FriendRequestDto> FriendRequests, List<GroupDto> Groups, List<GroupRequestDto> GroupRequests);

}
