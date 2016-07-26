using System;
using RaspberryPi_Control_UltraSonicSensor.UltraSonic;
using RaspberryPi_Control_UltraSonicSensor.ViewModels.BaseViewModel;
using System.Threading.Tasks;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.System.Profile;

namespace RaspberryPi_Control_UltraSonicSensor.ViewModels
{
    public class VM_UltraSonicControllerMain:ViewModelBase
    {

        private UltraSonicSensor _ultraSonicSensor;
        private const double _INCHES_IN_A_METER = 39.3700787;

        public VM_UltraSonicControllerMain()
        {

            //Create an ultra sonic sensor using GPIO Pin 20 for trigger and 21 for echo
            _ultraSonicSensor = new UltraSonicSensor((int)RaspberryPiGPI0Pin.GPIO20, (int)RaspberryPiGPI0Pin.GPIO21);

            if (AnalyticsInfo.VersionInfo.DeviceFamily != "Windows.Desktop")
            {
                Task.Run(async () =>
                {
                    while (true)
                    {
                        await Task.Delay(50);
                        await Windows.ApplicationModel.Core.CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(CoreDispatcherPriority.Normal,
                        () =>
                        {
                            DistanceInInches = ((int)_ultraSonicSensor.GetDistanceInInches).ToString();
                        });

                    }
                }

                );
            }
            else
            {
                DistanceInInches = "54321";
            }


        }

       


        private string _distanceInInches;
        public string DistanceInInches
        {
            get { return _distanceInInches; }
            set
            {
                _distanceInInches = value;
                OnPropertyChanged();
            }
        }


    }
}
   