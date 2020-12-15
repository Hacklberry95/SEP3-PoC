using System.Collections.Generic;

namespace ClientFramework.Authorization.AuthRoles
{
    public class Troubleshooter:Role
    {
        public static new List<string> auth;

        public Troubleshooter()
        {
            auth.Add("");
        }
    }
}