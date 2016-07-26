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


// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace MyJournal
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void button_JournalBase(object sender, RoutedEventArgs e)
        {
            txtblock.Text = "You have clicked Journal base!";
        }

        private async void button_ForcedLogging(object sender, RoutedEventArgs e)
        {
            var message = new Windows.UI.Popups.MessageDialog("Hello");
            await message.ShowAsync();
        }

        private void button_Settings(object sender, RoutedEventArgs e)
        {

            TimePicker t1 = new TimePicker();

            t1.Margin = new Thickness(50, 50, 0, 0);
            rightPanel.Children.Add(t1);
           
        }

        
    }
}
