using System;
using System.IO;
using System.Security;
using Microsoft.Win32;
using NsTools.Exceptions;

namespace NsTools.Useful.Reg
{
    public static class RegistryRegStatic
    {

        //Create a new property of any type or update existing value of a property returning a bool, but don't change name of the property existing.
        //RegistryRegStatic.CreateOrModify("CurrentUser", "SOFTWARE", "Teste", "1111111", RegistryValueKind.DWord);
        public static RegistryKey tBaseRegistry { get; set; }
        public static bool _Result { get; set; }
        public static bool CreateOrModifyProperty(string baseRegistry, string registryPath, string propertyName,
                                              string volumeName, RegistryValueKind registryValueKind)
        {
            _Result = false;

            try
            {
                if (baseRegistry.Contains("LocalMachine"))
                {
                    tBaseRegistry = Registry.LocalMachine.OpenSubKey(registryPath, RegistryKeyPermissionCheck.ReadWriteSubTree);
                }
                if (baseRegistry.Contains("CurrentUser"))
                {
                    tBaseRegistry = Registry.CurrentUser.OpenSubKey(registryPath, RegistryKeyPermissionCheck.ReadWriteSubTree);
                }

                tBaseRegistry.SetValue(propertyName, volumeName, registryValueKind);
                tBaseRegistry.Close();
                _Result = true;
            }
            catch (ArgumentNullException ex)
            {
                throw new RegistryException(ex.Message);
            }
            catch (ArgumentException ex)
            {
                throw new RegistryException(ex.Message);
            }
            catch (ObjectDisposedException ex)
            {
                throw new RegistryException(ex.Message);
            }
            catch (UnauthorizedAccessException ex)
            {
                throw new RegistryException(ex.Message);
            }
            catch (SecurityException ex)
            {
                throw new RegistryException(ex.Message);
            }
            catch (IOException ex)
            {
                throw new RegistryException(ex.Message);
            }

            return _Result;
        }
        public static bool DeleteProperty(string baseRegistry, string registryPath, string propertyName)
        {
            _Result = false;

            try
            {
                if (baseRegistry.Contains("LocalMachine"))
                {
                    tBaseRegistry = Registry.LocalMachine.OpenSubKey(registryPath, RegistryKeyPermissionCheck.ReadWriteSubTree);
                }
                if (baseRegistry.Contains("CurrentUser"))
                {
                    tBaseRegistry = Registry.CurrentUser.OpenSubKey(registryPath, RegistryKeyPermissionCheck.ReadWriteSubTree);
                }

                tBaseRegistry.DeleteValue(propertyName);
                tBaseRegistry.Close();
                _Result = true;
            }
            catch (ArgumentNullException ex)
            {
                throw new RegistryException(ex.Message);
            }
            catch (ArgumentException ex)
            {
                throw new RegistryException(ex.Message);
            }
            catch (ObjectDisposedException ex)
            {
                throw new RegistryException(ex.Message);
            }
            catch (UnauthorizedAccessException ex)
            {
                throw new RegistryException(ex.Message);
            }
            catch (SecurityException ex)
            {
                throw new RegistryException(ex.Message);
            }
            catch (IOException ex)
            {
                throw new RegistryException(ex.Message);
            }

            return _Result;
        }

    }






}
