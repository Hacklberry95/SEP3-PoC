using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerFramework.Authorization
{
    /// <summary>
    /// General class for authorization roles. Classes extending this one are stored in the AuthRoles namespace.
    /// </summary>
    public abstract class Role
    {
        public static List<string> auth;
    }
}
