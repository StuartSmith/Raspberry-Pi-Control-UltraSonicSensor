using System;
using System.Diagnostics;
using System.Threading;
using Windows.Devices.Gpio;

namespace RaspberryPi_Control_UltraSonicSensor.UltraSonic
{
    class UltraSonicSensor
    {
        private GpioController _gpioController;
        private GpioPin _echoPin;
        private GpioPin _triggerPin;


        /// <summary>
        /// Sound travels at 343 meters a second, but since this is echo location
        /// we need to divide this number in two, 171.5 meters per second.
        /// The below number is how long does it take for sound to travel to an object
        /// and bounce back that is  1 meter away...
        /// 0.0058309037900875 seconds
        /// </summary>
        private const double _amountOfTimeForSoundToTravelOneMeter = 0.0058309037900875;

        private const double _secondsToWaitForReturnFromSensor = 5;

        public RaspberryPiGPI0Pin RaspberryGPIOpinEcho { get; }
        public RaspberryPiGPI0Pin RaspberryGPIOpinTrigger { get; }

        public bool GpioInitialized
        {
            get;
            private set;
        }

        public UltraSonicSensor()
        {
            RaspberryGPIOpinEcho = RaspberryPiGPI0Pin.GPIO20;
            RaspberryGPIOpinTrigger = RaspberryPiGPI0Pin.GPIO21;

            GpioInit();
        }


        /// <summary>
        /// Initialize the Two GPIO pins one for input and one for output
        /// </summary>
        private void GpioInit()
        {
            try
            {
                GpioInitialized = false;
                _gpioController = GpioController.GetDefault();

                _echoPin = _gpioController.OpenPin(Convert.ToInt32(RaspberryGPIOpinEcho));
                _triggerPin = _gpioController.OpenPin(Convert.ToInt32(RaspberryGPIOpinTrigger));

                _echoPin.SetDriveMode(GpioPinDriveMode.Input);
                _triggerPin.SetDriveMode(GpioPinDriveMode.Output);

                GpioInitialized = true;

            }
            catch (Exception ex)
            {
                Debug.WriteLine("ERROR: GpioInit failed - " + ex.ToString());
            }
        }


        public double GetDistanceInMeters()
        {
            //Send a pulse to the Sonic sensor to the 
            // trigger pin for  one millisecond this lets the ultra sonic
            //sensor know we are waiting for a return value
            var mre = new ManualResetEventSlim(false); 
            _triggerPin.Write(GpioPinValue.High);
            mre.Wait(TimeSpan.FromMilliseconds(0.01));
            _triggerPin.Write(GpioPinValue.Low);

           double AmountOfTimeForpulse  = WaitForReturnPulse(_echoPin);


            return 0;
        }

        /// <summary>
        /// The Speed of sound is 343 meters per second.
        /// Since we are pointing sound at an object and bouncing it back we need to divide
        /// the amount of time by 2 for the sensor. For echo location sound travels 171 meters per second. If an
        /// object is 343 meters away the time to get to the object and return again is 2 seconds.  
        /// </summary>
        /// <param name="pin"></param>
        /// <param name="value"></param>
        /// <returns>If the sensor waits longer than 5 seconds for the sound to return this function returns -1</returns>
        private double WaitForReturnPulse(GpioPin pin)
        {
            var sw = new Stopwatch();
            
            // Wait for pulse            
            while (pin.Read() != GpioPinValue.High && sw.Elapsed.TotalSeconds > _secondsToWaitForReturnFromSensor)
            {
            }
            sw.Start();

            // Wait for pulse end          
            while (pin.Read() == GpioPinValue.High && sw.Elapsed.TotalSeconds > _secondsToWaitForReturnFromSensor)
            {
            }
            sw.Stop();
     

            if (sw.Elapsed.TotalSeconds > _secondsToWaitForReturnFromSensor)
            {
                return -1;
            }

            return sw.Elapsed.TotalSeconds;
        }



    }
}
