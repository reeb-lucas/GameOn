using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

using Windows.UI.Xaml.Controls;
using GameOn;
using Windows.UI.Xaml.Media;

namespace GameOn.Views
{
    public sealed partial class New_TaskPage : Page, INotifyPropertyChanged
    {
        public New_TaskPage()
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

        private async void Save_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            if (TaskDate.Date == null || TaskTime.SelectedTime == null || TaskName.Text == "")
            {
                ContentDialog ErrorBox = new ContentDialog
                {
                    Title = "Error",
                    Content = "Please enter all the required data before saving",
                    CloseButtonText = "Ok",

                };
                await ErrorBox.ShowAsync();
                return;
            }
            DateTime dateTime = new DateTime(TaskDate.Date.Value.Year, TaskDate.Date.Value.Month, TaskDate.Date.Value.Day, TaskTime.SelectedTime.Value.Hours, TaskTime.SelectedTime.Value.Minutes, TaskTime.SelectedTime.Value.Seconds);
            int taskXP = 100;
            if (TypeComboBox.SelectedIndex == 0)
            {
                taskXP = 500;
            }
            else if (TypeComboBox.SelectedIndex == 1)
            {
                taskXP = 200;
            }
            PlayerTask newTask = new PlayerTask(dateTime, 10, taskXP, TaskName.Text, TaskNotes.Text, ColorButton.Background);

            PlayerData.playerTasks.Add(newTask);

            ContentDialog Completed = new ContentDialog
            {
                Title = "Complete!",
                Content = "Task has been saved",
                CloseButtonText = "Ok",

            };
            await Completed.ShowAsync();
            Frame.Navigate(this.GetType());
        }

        private void Button_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            ColorPicker.Visibility = 0;
            ColorDoneButton.Visibility = 0;    
        }

        private void ColorDoneButton_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            ColorPicker.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            ColorDoneButton.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            ColorButton.Background = new SolidColorBrush(ColorPicker.Color);
        }
    }
}
