using System.Collections.Generic;

namespace ClientFramework.Authorization.AuthRoles
{
    public class PickingManager : Role
    {
        public static new List<string> auth;

        public PickingManager()
        {
            auth.Add("");
        }
    }
}