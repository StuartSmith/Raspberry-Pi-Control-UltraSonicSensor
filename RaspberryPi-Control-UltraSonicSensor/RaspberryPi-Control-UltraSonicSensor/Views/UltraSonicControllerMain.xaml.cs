using RaspberryPi_Control_UltraSonicSensor.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace RaspberryPi_Control_UltraSonicSensor.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class UltraSonicControllerMain : Page
    {
        private VM_UltraSonicControllerMain viewModel;

        public UltraSonicControllerMain()
        {
            this.InitializeComponent();
            viewModel = new VM_UltraSonicControllerMain();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
