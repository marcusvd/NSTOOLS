using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Win32;

namespace NsTools.Useful.Reg
{
    class RegistryReg
    {
        private string _propertName { get; set; }
        private string _volumeName { get; set; }
        private string _baseRegistry { get; set; }
        private string _registryPath { get; set; }
        private RegistryValueKind _regVKind { get; set; }
        private RegistryKey _tBaseRegistry { get; set; }

        public RegistryReg(string baseRegistry, string registryPath, string propertyName, string volumeName, RegistryValueKind registryValueKind)
        {
            _baseRegistry = baseRegistry;
            _propertName = propertyName;
            _volumeName = volumeName;
            _registryPath = registryPath;
            _regVKind = registryValueKind;


            if (_baseRegistry.Contains("LocalMachine"))
            {
                _tBaseRegistry = Registry.LocalMachine.OpenSubKey(registryPath, RegistryKeyPermissionCheck.ReadWriteSubTree);
            }
            if (_baseRegistry.Contains("CurrentUser"))
            {
                _tBaseRegistry = Registry.CurrentUser.OpenSubKey(registryPath, true);
            }
        }

        public void Create()
        {

            _tBaseRegistry.SetValue(_propertName, _volumeName, _regVKind);
            _tBaseRegistry.Close();


        }










        /*
         
         
        










         public List<string> test(string name)
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

