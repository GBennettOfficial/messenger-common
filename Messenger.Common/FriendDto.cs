﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messenger.Common
{
    public record FriendDto(string Username, string UserCode, string FirstName, string LastName);
}
