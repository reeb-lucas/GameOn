using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

using Windows.UI.Xaml.Controls;
using GameOn;

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

        private void Save_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            DateTime dateTime = new DateTime(TaskDate.Date.Value.Year, TaskDate.Date.Value.Month, TaskDate.Date.Value.Day, TaskTime.SelectedTime.Value.Hours, TaskTime.SelectedTime.Value.Minutes, TaskTime.SelectedTime.Value.Seconds);

            PlayerTask newTask = new PlayerTask(dateTime, 10, 100, TaskName.Text, TaskNotes.Text);

            PlayerData.playerTasks.Add(newTask);
        }
    }
}
