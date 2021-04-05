using System;
using System.Collections.Generic;
using System.Text;

namespace SoDevices
{
    public class OpenCloseDeviceToPlcTags
    {
        public bool Opened { get; }
        public bool Closed { get; }
        public bool Power { get; }
        public bool ControlMode { get; }
        public bool Failure { get; }
        public bool EStop { get; }
    }
}
