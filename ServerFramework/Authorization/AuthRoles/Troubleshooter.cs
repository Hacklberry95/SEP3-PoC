using System.Collections.Generic;

namespace ServerFramework.Authorization.AuthRoles
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