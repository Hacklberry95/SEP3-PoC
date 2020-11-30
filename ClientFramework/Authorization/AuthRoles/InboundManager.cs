using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientFramework.Authorization.AuthRoles
{
    public class InboundManager : Role
    {
        public static new List<string> auth;

        public InboundManager()
        {
            auth.Add("");
        }
    }
}
