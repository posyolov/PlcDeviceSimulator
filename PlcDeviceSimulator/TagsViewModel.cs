using Siemens.Simatic.Simulation.Runtime;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlcDeviceSimulator
{
    public class TagsViewModel : NotifyViewModel
    {
        IEnumerable<SDataValue> items;
        bool plcOut1 = true;
        bool plcIn1;

        public IEnumerable<SDataValue> Items
        {
            get => items;
            set
            {
                items = value;
                NotifyPropertyChanged();
            }
        }

        public bool PlcOut1
        {
            get => plcOut1;
            set
            {
                plcOut1 = value;
                NotifyPropertyChanged();
            }
        }

        public bool PlcIn1
        {
            get => plcIn1;
            set
            {
                plcIn1 = value;
                NotifyPropertyChanged();
            }
        }
    }
}
