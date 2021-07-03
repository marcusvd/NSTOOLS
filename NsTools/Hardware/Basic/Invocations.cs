using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace NsTools.Hardware.Basic
{
    class Invocations
    {
        private SystemEngine _engine { get; set; }

        public Invocations()
        {
            _engine = new SystemEngine();
        }
        public string AssMemoryCapacity()
        {
            return _engine.ActMemoryCapacity();
        }
        public string AssProcessorClock()
        {
            return _engine.ActProcessorClock();
        }
        public string AssDiskSystemCapacity()
        {
            return _engine.ActSystemDivre();
        }
        public string AssDiskSystemFreeSpace()
        {
            return _engine.ActSystemDivreFreeSpace();
        }

        public string AssDiskSystemModel()
        {
            return _engine.ActSystemDivreModel();
        }

    }
}
