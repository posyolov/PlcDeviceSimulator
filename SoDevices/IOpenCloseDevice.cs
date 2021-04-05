using System;
using System.Collections.Generic;
using System.Text;

namespace SoDevices
{
    public interface IOpenCloseDevice
    {
        void Open();
        void Close();
        bool Opened { get; }
        bool Closed { get; }
        bool Power { get; }
        bool ControlMode { get; }
        bool Failure { get; }
        bool EStop { get; }
    }
}
