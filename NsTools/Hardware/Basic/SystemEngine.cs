using NsTools.Useful.Generics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Management;
using System.Text;

namespace NsTools.Hardware.Basic
{
    class SystemEngine
    {
        private ManagementObjectSearcher _objSearch { get; set; }
        private UInt64 _listReturnOne { get; set; }
        private List<string> _listReturn { get; set; }
        private Converters _converter { get; set; }
        private string _oneReturn { get; set; }
        private DriveInfo _drvInfo { get; set; }
        private long _drvInfoSize { get; set; }
        private long _drvInfoSizeFreeSpace { get; set; }

        public SystemEngine()
        {
            //_listReturn = new List<UInt64>();
            _converter = new Converters();
            _drvInfo = new DriveInfo(Path.GetPathRoot(Environment.SystemDirectory));
        }
        public UInt64 OperatorMObjReturnsOneUint64(string strWmi, string property)
        {
            _objSearch = new ManagementObjectSearcher(new ObjectQuery(strWmi));
            ManagementObjectCollection queryCollection = _objSearch.Get();
            foreach (var qwe in queryCollection)
            {
                PropertyData data1 = qwe.Properties[property];
                UInt64 T = (UInt64)data1.Value;
                _listReturnOne = T;
                break;
            }
            return _listReturnOne;
        }
        public string OperatorMObjReturnsOne(string strWmi, string property)
        {
            _objSearch = new ManagementObjectSearcher(new ObjectQuery(strWmi));
            ManagementObjectCollection queryCollection = _objSearch.Get();
            foreach (var qwe in queryCollection)
            {
                PropertyData data1 = qwe.Properties[property];
                string T = (string)data1.Value;

                _oneReturn = T;

                break;
            }
            return _oneReturn;
        }
        public List<string> OperatorMObjReturnsMany(string strWmi, string property)
        {
            _objSearch = new ManagementObjectSearcher(new ObjectQuery(strWmi));
            ManagementObjectCollection queryCollection = _objSearch.Get();
            foreach (var qwe in queryCollection)
            {
                PropertyData data1 = qwe.Properties[property];
                string[] T = (string[])data1.Value;
                foreach (string i in T)
                {
                    _listReturn.Add(i);
                }
                
                break;
            }
            return _listReturn;
        }
        public string ActMemoryCapacity()
        {
            return _converter.ConvertSize(OperatorMObjReturnsOneUint64("SELECT * FROM Win32_ComputerSystem", "TotalPhysicalMemory"));
        }
        public string ActProcessorClock()
        {
            return OperatorMObjReturnsOne("SELECT * FROM Win32_Processor", "Name");
        }
        public string ActSystemDivre()
        {
            _drvInfoSize = _drvInfo.TotalSize;
             return _converter.ConvertSize(_drvInfoSize);
        }
        public string ActSystemDivreFreeSpace()
        {
            _drvInfoSizeFreeSpace = _drvInfo.TotalFreeSpace;
            return _converter.ConvertSize(_drvInfoSizeFreeSpace);
        }

        //Fix
        public string ActSystemDivreModel()
        {
            return OperatorMObjReturnsOne("SELECT * FROM Win32_DiskDrive", "MediaType");
        }

    }
}
