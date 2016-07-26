using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Windows.Devices.Gpio;

namespace RaspberryPi_Control_UltraSonicSensor.UltraSonic
{
    class UltraSonicSensor
    {
        private GpioPin triggerPin { get; set; }
        private GpioPin echoPin { get; set; }
        private Stopwatch timeWatcher;


        public UltraSonicSensor(int triggerPin, int echoPin)
        {
            GpioController controller = GpioController.GetDefault();
            timeWatcher = new Stopwatch();
            //initialize trigger pin.
            this.triggerPin = controller.OpenPin(triggerPin);
            this.triggerPin.SetDriveMode(GpioPinDriveMode.Output);
            this.triggerPin.Write(GpioPinValue.Low);
            //initialize echo pin.
            this.echoPin = controller.OpenPin(echoPin);
            this.echoPin.SetDriveMode(GpioPinDriveMode.Input);
        }

        private double GetDistance()
        {
            ManualResetEvent mre = new ManualResetEvent(false);
            mre.WaitOne(100);
            Stopwatch pulseLength = new Stopwatch();
            Stopwatch TotalTime = new Stopwatch();


            TotalTime.Start();

            //Send pulse
            this.triggerPin.Write(GpioPinValue.High);
            mre.WaitOne(TimeSpan.FromMilliseconds(0.01));
            this.triggerPin.Write(GpioPinValue.Low);

            //Recieve pusle
            while (this.echoPin.Read() == GpioPinValue.Low && TotalTime.ElapsedMilliseconds < 5000)
            {
            }
            pulseLength.Start();

            while (this.echoPin.Read() == GpioPinValue.High && TotalTime.ElapsedMilliseconds < 5000)
            {
            }
            pulseLength.Stop();

            if (TotalTime.ElapsedMilliseconds >= 5000)
                return -1;


            //Calculating distance
            TimeSpan timeBetween = pulseLength.Elapsed;
            //Debug.WriteLine(timeBetween.ToString());
           
            return timeBetween.TotalSeconds;
        }

        public double GetDistanceInCentimeters => GetDistance() * 17000;

        public double GetDistanceInInches => GetDistance() * 17000 / 2.5;



       

        private double PulseIn(GpioPin echoPin, GpioPinValue value)
        {
            var t = Task.Run(() =>
            {
                //Recieve pusle
                while (this.echoPin.Read() != value)
                {
                }
                timeWatcher.Start();

                while (this.echoPin.Read() == value)
                {
                }
                timeWatcher.Stop();
                //Calculating distance
                double distance = timeWatcher.Elapsed.TotalSeconds * 17000;
                return distance;
            });
            bool didComplete = t.Wait(5000);
            if (didComplete)
            {
                return t.Result;
            }
            else
            {
                return 0.0;
            }
        }




    }
}
