using System.Collections.Generic;

namespace ServerFramework.Authorization.AuthRoles
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