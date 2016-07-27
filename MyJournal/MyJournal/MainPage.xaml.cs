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
using SQLite.Net.Attributes;


// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace MyJournal
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        string path;
        SQLite.Net.SQLiteConnection conn;
        public MainPage()
        {
            this.InitializeComponent();
            this.SqlConnection();
        }

        async public void SqlConnection()
        {
            path = System.IO.Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, "db.sqlite");
            conn = new SQLite.Net.SQLiteConnection(new
            SQLite.Net.Platform.WinRT.SQLitePlatformWinRT(), path);
            conn.CreateTable<WorkItem>();
            Add_WorkItem(new DateTime(2016, 7, 26));
            string text = Retrieve_WorkItem(new DateTime(2016, 7, 26));
            var str = new Windows.UI.Popups.MessageDialog(text);
            await str.ShowAsync();
        }

        public class WorkItem
        {
            [PrimaryKey, AutoIncrement]
            public DateTime TimeStamp { get; set; }
            public string logText { get; set; }
        }

        private void Add_WorkItem(DateTime dt)
        {
            var s = conn.Insert(new WorkItem()
            {
                TimeStamp = dt,
                logText = "text " + dt
            });
        }

        private string Retrieve_WorkItem(DateTime dt)
        {
            var query = conn.Table<WorkItem>();
            foreach (var message in query)
            {
                if (message.TimeStamp == dt)
                    return message.logText;
            }
            return string.Empty;
        }

        private void HamburgerButton_Click(object sender, RoutedEventArgs e)
        {
            MySplitView.IsPaneOpen = !MySplitView.IsPaneOpen;
        }

        private void IconsListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (AddNewItem.IsSelected) { conetentFrame.Navigate(typeof(AddItemPage)); }
            else if (ViewJournalBase.IsSelected) { conetentFrame.Navigate(typeof(JournalViewPage)); }
            else if (Settings.IsSelected) { conetentFrame.Navigate(typeof(SettingsPage)); }
        }


    }
}
          