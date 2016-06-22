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
            _ultraSonicSensor = new UltraSonicSensor();


            if (AnalyticsInfo.VersionInfo.DeviceFamily != "Windows.Desktop")
            {
                Task.Run(async () =>
                {
                    while (true)
                    {
                        await Task.Delay(1000);


                        await Windows.ApplicationModel.Core.CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(CoreDispatcherPriority.Normal,
                        () =>
                        {

                            double DistanceInMeters = _ultraSonicSensor.GetDistanceInMeters();
                            double Inches = DistanceInMeters * _INCHES_IN_A_METER;
                            DistanceInInches = Inches.ToString();
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

        /// <summary>
        /// Retrieve the distance to the object
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public void RetrieveDistance(object sender, RoutedEventArgs args)
        {
            _ultraSonicSensor.GetDistanceInMeters();

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
   