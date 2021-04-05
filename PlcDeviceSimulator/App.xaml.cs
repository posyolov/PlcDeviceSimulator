using Siemens.Simatic.Simulation.Runtime;
using SimaticPlcSim;
using SoDevices;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace PlcDeviceSimulator
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        PlcInstance plcInstance;

        Dictionary<string, SDataValue> tags = new Dictionary<string, SDataValue>();
        TagsViewModel tagsViewModel = new TagsViewModel();

        OpenCloseDevice openCloseDevice = new OpenCloseDevice();
        MainViewModel mainViewModel = new MainViewModel();

        private void OnStartup(object sender, StartupEventArgs e)
        {
            mainViewModel.WeigherGate1 = new OpenCloseDeviceVM(openCloseDevice);

            tags.Add("TestOut1", new SDataValue());
            tags.Add("TestIn1", new SDataValue());


            plcInstance = new PlcInstance("MyPlc");
            plcInstance.NewCycle += () =>
            {
                //plcInstance.GetPlcOutputs(ref tags);
                //tagsViewModel.Items = tags.Values.ToList();

                tagsViewModel.PlcOut1 = plcInstance.instance.ReadBool("TestOut1");
                plcInstance.instance.WriteBool("TestIn1", openCloseDevice.Opened);
                plcInstance.instance.WriteBool("TestIn2", openCloseDevice.Closed);
            };

            MainWindow mainWindow = new MainWindow();
            mainWindow.DataContext = mainViewModel;
            mainWindow.Show();
        }

        private void OnExit(object sender, ExitEventArgs e)
        {
            //plcInstance.instance?.UnregisterInstance();
            //plcInstance.instance?.
            //openCloseDevice.Dispose();
            Task.WaitAll();
        }
    }
}
