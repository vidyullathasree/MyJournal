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
using Windows.ApplicationModel.Background;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace MyJournal
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SettingsPage : Page
    {
        public SettingsPage()
        {
            this.InitializeComponent();
        }

        private void NavigateToAddSettingsPage(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(SettingsPage));
        }

        private void NavigateToJournalViewPage(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(JournalViewPage));
        }

        private async void StartNotifications_Click(object sender, RoutedEventArgs e)
        {
            var access = await BackgroundExecutionManager.RequestAccessAsync();
            switch (access)
            {
                case BackgroundAccessStatus.Unspecified:
                    break;
                case
           BackgroundAccessStatus.AllowedMayUseActiveRealTimeConnectivity:
                    break;
                case
           BackgroundAccessStatus.AllowedWithAlwaysOnRealTimeConnectivity:
                    break;
                case BackgroundAccessStatus.Denied:
                    break;
                default:
                    break;
            }
            //Adding background task
            var task = new BackgroundTaskBuilder
            {
                Name = "My Task",
                TaskEntryPoint = typeof(MyJournalRuntimeComponent.MyJournalRuntimeTask).ToString()
            };
            var trigger = new ApplicationTrigger();
            task.SetTrigger(trigger);
            var condition = new
            SystemCondition(SystemConditionType.InternetAvailable);
            task.Register();
            await trigger.RequestAsync();
        }
    }
}