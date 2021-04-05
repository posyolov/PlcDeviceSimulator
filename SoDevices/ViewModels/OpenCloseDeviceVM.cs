namespace SoDevices
{
    public class OpenCloseDeviceVM : NotifyViewModel
    {
        private readonly OpenCloseDevice openCloseDevice;
        private bool opened;
        private bool closed;
        private bool power;
        private bool failure;
        private bool localControl;
        private float position;

        public DelegateCommand<bool> SwitchModeCommand { get; }
        public DelegateCommand<bool> OpenCommand { get; }
        public DelegateCommand<bool> CloseCommand { get; }
        public DelegateCommand<bool> StopCommand { get; }

        public bool Opened
        {
            get => opened;
            set
            {
                opened = value;
                NotifyPropertyChanged();
            }
        }
        public bool Closed
        {
            get => closed;
            set
            {
                closed = value;
                NotifyPropertyChanged();
            }
        }
        public bool Power
        {
            get => power;
            set
            {
                power = value;
                NotifyPropertyChanged();
            }
        }
        public bool Failure
        {
            get => failure;
            set
            {
                failure = value;
                NotifyPropertyChanged();
            }
        }
        public bool Mode
        {
            get => localControl;
            set
            {
                localControl = value;
                NotifyPropertyChanged();
            }
        }
        public bool EStop { get; set; }

        public float Position
        {
            get => position;
            set
            {
                position = value;
                NotifyPropertyChanged();
            }
        }

        public OpenCloseDeviceVM(OpenCloseDevice openCloseDevice)
        {
            this.openCloseDevice = openCloseDevice;
            this.openCloseDevice.StateChanged += UpdateState;
            UpdateState();

            SwitchModeCommand = new DelegateCommand<bool>(
                canExecute: (obj) => true,
                execute: (obj) => Mode = !Mode);
            OpenCommand = new DelegateCommand<bool>(
                canExecute: (obj) => true,
                execute: (obj) => openCloseDevice.OnOpenButtonClick());
            CloseCommand = new DelegateCommand<bool>(
                canExecute: (obj) => true,
                execute: (obj) => openCloseDevice.OnCloseButtonClick());
            StopCommand = new DelegateCommand<bool>(
                canExecute: (obj) => true,
                execute: (obj) => openCloseDevice.OnStopButtonClick());
        }

        private void UpdateState()
        {
            Opened = openCloseDevice.Opened;
            Closed = openCloseDevice.Closed;
            Position = openCloseDevice.Position;
        }
    }
}
