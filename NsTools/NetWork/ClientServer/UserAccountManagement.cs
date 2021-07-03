using System;
using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;

namespace NsTools.NetWork.ClientServer
{
    public class UserAccountManagement
    {

        private string ADPath { get; set; }
        private string UserName { get; set; }
        private string Password { get; set; }

        private DirectoryEntry directoryEntry { get; set; }
        public UserAccountManagement(string aDPath, string userName, string pwd)
        {
            ADPath = aDPath;
            UserName = userName;
            directoryEntry = new DirectoryEntry(ADPath);
            directoryEntry.Username = UserName;
            directoryEntry.Password = pwd;
        }
        public UserAccountManagement(string aDPath)
        {
            ADPath = aDPath;
            directoryEntry = new DirectoryEntry(ADPath);
        }

        public void GetAllAd()
        {
            foreach (DirectoryEntry users in directoryEntry.Children)
            {
                System.Console.WriteLine(users.InvokeGet("description"));
            }

        }





    }







}
