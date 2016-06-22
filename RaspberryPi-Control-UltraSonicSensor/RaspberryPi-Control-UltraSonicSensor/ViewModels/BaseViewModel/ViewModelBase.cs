using System.ComponentModel;
using System.Runtime.CompilerServices;


namespace RaspberryPi_Control_UltraSonicSensor.ViewModels.BaseViewModel
{
   public  class ViewModelBase: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = delegate { };


        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
