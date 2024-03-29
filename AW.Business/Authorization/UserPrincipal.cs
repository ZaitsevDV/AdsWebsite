﻿using AW.Common.Models;
using System.Security.Principal;

namespace AW.Business.Authorization
{
    public class UserPrincipal : IPrincipal
    {
        public UserPrincipal(string userName)
        {
            Identity = new GenericIdentity(userName);
        }

        public string UserName { get; set; }
        public Role Role { get; set; }
        public IIdentity Identity { get; }

        public bool IsInRole(string role)
        {
            return Role.RoleName.Contains(role);
        }
    }
}