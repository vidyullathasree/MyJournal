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

namespace MyJournal
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class JournalViewPage : Page
    {
        LinkedList<WorkItem> workItems = new LinkedList<WorkItem>();
        public JournalViewPage()
        {
            this.InitializeComponent();
            workItems.AddLast(new WorkItem { Time=new DateTime(), workItem="Santhi adds Text" });
            workItems.AddLast(new WorkItem { Time=new DateTime(), workItem="Vidyu adds Text" });
            ListViewDisplay.ItemsSource = workItems;
        }

        private void NavigateToJournalViewPage(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(JournalViewPage));
        }
    }
}
