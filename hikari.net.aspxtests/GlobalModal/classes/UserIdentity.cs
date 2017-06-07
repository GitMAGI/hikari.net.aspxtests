using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace GlobalModal.classes
{
    public class UserIdentity : IIdentity
    {
        public UserIdentity(string Name, bool IsAuthenticated, string AuthenticationType = null)
        {
            this.AuthenticationType = AuthenticationType;
            this.Name = Name;
            this.IsAuthenticated = true;
        }

        public string AuthenticationType { get; }

        public bool IsAuthenticated { get; }

        public string Name { get; }
    }
}