
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messenger.Common
{
    public record LoginResponseDto(JsonWebTokenDto JsonWebToken, List<FriendDto> Friends, List<FriendRequestDto> FriendRequests);
}
