using Microsoft.Win32;
using System;
using System.Collections.Generic;


namespace NsTools.Useful.Has
{
    public class Installed
    {
        /// <summary>
        /// Search path must be a folder before
        /// </summary>
        /// //Tests

        private List<string> lstInstalled { get; set; }
        private string strUninstall { get; set; }
        private string PropertName { get; set; }
        private string KeyToSearch { get; set; }
        private string BaseRegistry { get; set; }
        private RegistryKey TBaseRegistry { get; set; }

        public Installed(string baseRegistry, string keyToSearch, string propertyName)
        {   //Disabled
            lstInstalled = new List<string>();
            BaseRegistry = baseRegistry;
            PropertName = propertyName;
            KeyToSearch = keyToSearch;

            if (BaseRegistry.Contains("LocalMachine"))
            {
                TBaseRegistry = Registry.LocalMachine.OpenSubKey(KeyToSearch);
            }
            if (BaseRegistry.Contains("CurrentUser"))
            {
                TBaseRegistry = Registry.CurrentUser.OpenSubKey(KeyToSearch);
            }
        }
        public string SearchUninstallStringExe(string name)
        {
            using (RegistryKey rk = TBaseRegistry)
            {
                foreach (string skName in rk.GetSubKeyNames())
                {
                    if (skName.Contains(name))
                    {
                        using (RegistryKey sk = rk.OpenSubKey(skName))
                        {
                            try
                            {
                                return sk.GetValue(PropertName).ToString();
                            }
                            catch (Exception)
                            { }

                        }
                    }
                }
            }

            return strUninstall;
        }

        public string SearchUninstallStringExeMsi(string name)
        {
            using (RegistryKey rk = TBaseRegistry)
            {
                foreach (string skName in rk.GetSubKeyNames())
                {
                    using (RegistryKey sk = rk.OpenSubKey(skName))
                    {
                        try
                        {
                            if (sk.GetValue(PropertName).ToString().Contains(name))
                            {
                                return sk.GetValue("UninstallString").ToString();
                            }
                        }
                        catch (Exception)
                        { }
                    }
                }
            }
            return strUninstall;
        }










        /*public List<string> test(string name)
        {
            using (RegistryKey rk = TBaseRegistry)
            {
                foreach (string skName in rk.GetSubKeyNames())
                {
                    if (skName.Contains(name))
                    {
                        using (RegistryKey sk = rk.OpenSubKey(skName))
                        {
                            try
                            {
                                lstInstalled.Add(sk.GetValue(PropertName).ToString());
                            }
                            catch (Exception)
                            { }
                        }
                    }
                }
            }



            return lstInstalled;
        }*/


    }



}
