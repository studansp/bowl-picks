using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BowlPicks.Api.Enum
{
    public enum TokenStatus
    {
        Valid=0,
        UserDoesNotExist=1,
        InvalidPassword=2
    }
}