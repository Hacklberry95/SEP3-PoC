using System;
using System.Collections.Generic;

namespace ServerFramework.Authorization.AuthRoles
{
    public class Picker : Role
    {
        public static new List<string> auth;

        public Picker()
        {
            auth.Add("");
        }
    }
}
