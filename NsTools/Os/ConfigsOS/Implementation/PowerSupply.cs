using System;
using NsTools.Os.ConfigsOS.Helpers;
using NsTools.Os.ConfigsOS.Interfaces;

namespace NsTools.Os.ConfigsOS.Implementation
{
    public class PowerSupply : IPowerSupply
    {
        public bool SetHighPerformace()
        {
            // bool result = false;
            try
            {
                HelpersConfigsOS Helpers = new HelpersConfigsOS();
                Helpers.Run("calc", "setactive 381b4222-f694-41f0-9685-ff5bb260df2e");
                return true;
            }
            catch (Exception)
            {
                return false;
            }


        }
    }
}