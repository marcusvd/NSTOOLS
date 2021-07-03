using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Management;
using Microsoft.Win32;

namespace NsTools.Os.ConfigsOS.Helpers
{
    public class HelpersConfigsOS : IHelpersConfigsOS
    {
        #region Properties Registry
        string _propertName { get; set; }
        string _volumeName { get; set; }
        string _baseRegistry { get; set; }
        string _registryPath { get; set; }
        RegistryValueKind _regVKind { get; set; }
        RegistryKey _tBaseRegistry { get; set; }
        public HelpersConfigsOS(string baseRegistry, string registryPath, string propertyName, string volumeName, RegistryValueKind registryValueKind)
        {
            _baseRegistry = baseRegistry;
            _propertName = propertyName;
            _volumeName = volumeName;
            _registryPath = registryPath;
            _regVKind = registryValueKind;

            if (_baseRegistry.Contains("LocalMachine"))
            {
                _tBaseRegistry = Registry.LocalMachine.OpenSubKey(registryPath, RegistryKeyPermissionCheck.ReadWriteSubTree);
                Console.WriteLine(registryPath);
            }
            if (_baseRegistry.Contains("CurrentUser"))
            {
                _tBaseRegistry = Registry.CurrentUser.OpenSubKey(registryPath, true);
                Console.WriteLine(registryPath);
            }
        }
        public HelpersConfigsOS(string baseRegistry, string registryPath, string propertyName, string volumeName, RegistryValueKind registryValueKind, string dword="love")
        {
            _baseRegistry = baseRegistry;
            _propertName = propertyName;
            _volumeName = volumeName;
            _registryPath = registryPath;
            _regVKind = registryValueKind;

            if (_baseRegistry.Contains("LocalMachine"))
            {
                _tBaseRegistry = Registry.LocalMachine.OpenSubKey(registryPath, RegistryKeyPermissionCheck.ReadWriteSubTree);
                Console.WriteLine(registryPath);
            }
            if (_baseRegistry.Contains("CurrentUser"))
            {
                _tBaseRegistry = Registry.CurrentUser.OpenSubKey(registryPath, true);
                Console.WriteLine(registryPath);
            }
        }
      
        #endregion
        #region HardWare Query
        private ManagementObjectSearcher _objSearch { get; set; }
        private string _OneReturn { get; set; }
        private bool _OneReturnBool { get; set; }
        private List<string> _listReturn { get; set; }
        #endregion
        public HelpersConfigsOS()
        {

        }
        public bool Run(string name, string args)
        {
            ProcessStartInfo _Process = new ProcessStartInfo(name);
            try
            {
                _Process.Arguments = args;
                Process.Start(_Process);
                return true;
            }
            catch (Exception)
            {
                return true;
            }
        }
        public bool WriteReg()
        {
            //string baseRegistry, string registryPath, string propertyName, string volumeName, RegistryValueKind registryValueKind
            try
            {
                _tBaseRegistry.SetValue(_propertName, _volumeName, _regVKind);
                _tBaseRegistry.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        //Write DWord
        public bool WriteReg(string DWord)
        {
            //string baseRegistry, string registryPath, string propertyName, string volumeName, RegistryValueKind registryValueKind
            try
            {
                _tBaseRegistry.SetValue(_propertName, _volumeName, _regVKind);
                _tBaseRegistry.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public List<string> HardwareQueryMany(string strWmi, string property)
        {
            _listReturn = new List<string>();

            _objSearch = new ManagementObjectSearcher(new ObjectQuery(strWmi));
            ManagementObjectCollection queryCollection = _objSearch.Get();

            foreach (var qwe in queryCollection)
            {
                PropertyData data1 = qwe.Properties[property];
                string[] T = (string[])data1.Value;
                foreach (string item in T)
                {
                    _listReturn.Add(item);
                }
                break;
            }
            return _listReturn;
        }
        public string HardwareQuerySingle(string strWmi, string property)
        {
            _objSearch = new ManagementObjectSearcher(new ObjectQuery(strWmi));
            ManagementObjectCollection queryCollection = _objSearch.Get();
            foreach (var qwe in queryCollection)
            {
                PropertyData data1 = qwe.Properties[property];
                string T = (string)data1.Value;

                _OneReturn = T;

                break;
            }
            return _OneReturn;
        }

    }
}