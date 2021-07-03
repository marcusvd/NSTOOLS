using System.Collections.Generic;
using System.DirectoryServices.AccountManagement;
using NsTools.Exceptions;

namespace NsTools.Os.Basic.Accounts
{
    public static class Group
    {
        public static PrincipalSearchResult<Principal> GetAll()
        {
            try
            {
                PrincipalContext LocalMachine = new PrincipalContext(ContextType.Machine);
                GroupPrincipal groupPrincipal = new GroupPrincipal(LocalMachine);
                PrincipalSearcher searcher = new PrincipalSearcher(groupPrincipal);
                return searcher.FindAll();
            }
            catch (System.Exception ex)
            {
                throw new GroupAccountException(ex.Message);
            }

        }

        public static bool ExistGroup(string group)
        {
            bool exists = false;

            PrincipalContext LocalMachine = new PrincipalContext(ContextType.Machine);
            GroupPrincipal gPrincipal = new GroupPrincipal(LocalMachine);
            PrincipalSearcher pSearch = new PrincipalSearcher(gPrincipal);

            foreach (var g in pSearch.FindAll())
            {
                if (g.Name.ToLower().Contains(group.ToLower()))
                {
                    exists = true;
                    return exists;
                }
                else
                {
                    exists = false;
                    return exists;
                }
            }
            return exists;

        }

        public static void getMembers(string group)
        {
            List<PrincipalSearchResult<Principal>> list = new List<PrincipalSearchResult<Principal>>();
            try
            {
                PrincipalContext LocalMachine = new PrincipalContext(ContextType.Machine);
                GroupPrincipal gPrincipal = GroupPrincipal.FindByIdentity(LocalMachine, IdentityType.Name, group);

                if (gPrincipal != null)
                {
                    foreach (var y in gPrincipal.GetMembers(true))
                    {
                        System.Console.WriteLine("Member: " + y);
                    }
                    gPrincipal.Dispose();
                }

                LocalMachine.Dispose();
            }
            catch (PrincipalOperationException ex)
            {
                System.Console.WriteLine("Error: " + ex.Message);
            }

        }

    }
}
