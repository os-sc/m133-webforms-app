using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpielGutWebInterface.Domain
{
    public static class Helpers
    {
        public static int GetUnixTime()
        {
            // Only supports times up to Tue, 19 Jan 2038 03:14:07 GMT
            return (int)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
        }
    }
}