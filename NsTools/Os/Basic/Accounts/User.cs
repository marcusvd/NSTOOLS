using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;
using NsTools.Exceptions;

namespace NsTools.Os.Basic.Accounts
{
    public static class User
    {

        public static bool ExistUser(int identityType, string toSearch)
        {
            try
            {
                bool existing = false;
                IdentityType type = IdentityType.SamAccountName;
                switch (identityType)
                {
                    case 0:
                        type = IdentityType.SamAccountName;
                        break;
                    case 1:
                        type = IdentityType.Name;
                        break;
                    case 2:
                        type = IdentityType.UserPrincipalName;
                        break;
                    case 3:
                        type = IdentityType.DistinguishedName;
                        break;
                    case 4:
                        type = IdentityType.Sid;
                        break;
                    case 5:
                        type = IdentityType.Guid;
                        break;
                }

                using (PrincipalContext LocalMachine = new PrincipalContext(ContextType.Machine))
                {
                    UserPrincipal check = UserPrincipal.FindByIdentity(LocalMachine, type, toSearch);
                    existing = (check != null);
                }
                return existing;
            }
            catch (MultipleMatchesException ex)
            {
                throw new UserAccountException(ex.Message);
            }
            catch (InvalidEnumArgumentException ex)
            {
                throw new UserAccountException(ex.Message);
            }
        }

        public static bool NewUserAccount(int type, string name, string pwd)
        {
            if (!ExistUser(type, name))
            {
                DirectoryEntry ConnectionMachine = new DirectoryEntry("WinNT://" + Environment.MachineName + ",computer");

                DirectoryEntry UserAccountGeneralSettings = ConnectionMachine.Children.Add(name, "user");

                UserAccountGeneralSettings.Invoke("SetPassword", new string[] { pwd });
                UserAccountGeneralSettings.CommitChanges();
                return true;
            }

            return false;

        }

        public static bool? IsEnabled(string userName)
        {
            bool? exists = false;
            try
            {
                using (PrincipalContext LocalMachine = new PrincipalContext(ContextType.Machine))
                {
                    UserPrincipal user = UserPrincipal.FindByIdentity(LocalMachine, userName);
                    exists = user.Enabled;
                }
            }
            catch (MultipleMatchesException ex)
            {
                throw new UserAccountException(ex.Message);
            }
            catch (InvalidEnumArgumentException ex)
            {
                throw new UserAccountException(ex.Message);
            }
            return exists;
        }

        public static void EnabledOrDisabled(bool onOff, string username)
        {

            try
            {
                using (PrincipalContext LocalMachine = new PrincipalContext(ContextType.Machine))
                {
                    UserPrincipal user = UserPrincipal.FindByIdentity(LocalMachine, username);
                    user.Enabled = onOff;
                    user.Save();

                }
            }
            catch (Exception ex)
            {
                throw new UserAccountException(ex.Message);
            }

        }
        //foreach needed
        public static PrincipalSearchResult<Principal> GetAll()
        {
            try
            {
                PrincipalContext LocalMachine = new PrincipalContext(ContextType.Machine);
                UserPrincipal user = new UserPrincipal(LocalMachine);
                PrincipalSearcher searcher = new PrincipalSearcher(user);
                return searcher.FindAll();
            }
            catch (System.Exception ex)
            {
                throw new GroupAccountException(ex.Message);
            }
        }
    }
}
