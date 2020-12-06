using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerFramework.Authorization.AuthRoles
{
    public class Loader : Role
    {
        public static new List<string> auth;

        public Loader()
        {
            auth.Add("");
        }
    }
}
