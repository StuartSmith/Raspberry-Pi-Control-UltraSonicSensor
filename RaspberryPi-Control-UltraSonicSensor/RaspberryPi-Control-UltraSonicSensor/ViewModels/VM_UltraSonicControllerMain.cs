
using RaspberryPi_Control_UltraSonicSensor.UltraSonic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Windows.UI.Xaml;

namespace RaspberryPi_Control_UltraSonicSensor.ViewModels
{
    public class VM_UltraSonicControllerMain
    {

        private UltraSonicSensor _ultraSonicSensor; 


        public VM_UltraSonicControllerMain()
        {
            _ultraSonicSensor = new UltraSonicSensor();
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

    }
}
   