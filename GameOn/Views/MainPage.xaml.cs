using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

using Windows.UI.Xaml.Controls;

namespace GameOn.Views
{
    public sealed partial class MainPage : Page, INotifyPropertyChanged
    {
        public MainPage()
        {
            InitializeComponent();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void Set<T>(ref T storage, T value, [CallerMemberName]string propertyName = null)
        {
            if (Equals(storage, value))
            {
                return;
            }

            storage = value;
            OnPropertyChanged(propertyName);
        }

        private void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        private async void Task_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            //If sender == TodayTOne then open TodayTOne dialog with info on task
            if(sender == TodayTOne)
            {
                ContentDialog todayOneD = new ContentDialog
                {
                    Title = "Task 1 - get dynamic string somehow",
                    Content = "set string as task description",
                    CloseButtonText = "OK!"
                };
                ContentDialogResult result = await todayOneD.ShowAsync();
            }
        }
    }
}
