using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SoDevices
{
    public class OpenCloseDevice : SoDevice<OpenCloseDeviceFromPlcTags, OpenCloseDeviceToPlcTags>
    {
        private const float DELTA = 1.0f;

        private float position;
        private float positionCloseLimit = 0.5f;
        private float positionOpenLimit = 99.5f;
        private bool openingFlag;
        private bool closingFlag;

        public event Action StateChanged;

        public float Position
        {
            get => position;
            private set 
            {
                if(value != position)
                {
                    position = value;
                    StateChanged?.Invoke();
                }
            }
        }

        public bool Opened
        {
            get => position >= positionOpenLimit;
        }

        public bool Closed
        {
            get => position <= positionCloseLimit;
        }

        public bool IsRemoteMode { get; set; }

        public OpenCloseDevice()
        {
            SoSimulation();
        }

        public void OnOpenButtonClick()
        {
            if (!IsRemoteMode)
            {
                openingFlag = true;
                closingFlag = false;
            }
        }

        public void OnCloseButtonClick()
        {
            if (!IsRemoteMode)
            {
                openingFlag = false;
                closingFlag = true;
            }
        }

        public void OnStopButtonClick()
        {
            if (!IsRemoteMode)
            {
                openingFlag = false;
                closingFlag = false;
            }
        }

        public void OnPlcTagsUpdated()
        {

        }

        private async void SoSimulation()
        {
            while (true)
            {
                if(IsRemoteMode)
                {

                }

                
                if (openingFlag && position < positionOpenLimit)
                    Position += DELTA;
                else
                    openingFlag = false;

                if (closingFlag && position > positionCloseLimit)
                    Position -= DELTA;
                else
                    closingFlag = false;

                await Task.Delay(100);
            }
        }

        //public void Dispose()
        //{
        //    Task.WaitAll();
        //}

        //~OpenCloseDevice()
        //{
        //    Task.WaitAll();
        //}

        //protected override void Finalize()
        //{
        //    try
        //    {
        //        Task.WaitAll();
        //    }
        //    finally
        //    {
        //        base.Finalize();
        //    }
        //}
    }
}
