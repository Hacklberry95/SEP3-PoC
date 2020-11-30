using System;
using System.Collections.Generic;

namespace ClientFramework.Authorization.AuthRoles
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
