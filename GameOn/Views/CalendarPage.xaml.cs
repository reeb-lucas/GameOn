using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

using GameOn.Core.Models;
using GameOn.Core.Services;

using Microsoft.Toolkit.Uwp.UI.Controls;

using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;

namespace GameOn.Views
{
    public sealed partial class CalendarPage : Page, INotifyPropertyChanged
    {
        private SampleOrder _selected;

        public SampleOrder Selected
        {
            get { return _selected; }
            set { Set(ref _selected, value); }
        }

        public ObservableCollection<SampleOrder> SampleItems { get; private set; } = new ObservableCollection<SampleOrder>();

        public CalendarPage()
        {
            InitializeComponent();
            Loaded += CalendarPage_Loaded;
        }

        private async void CalendarPage_Loaded(object sender, RoutedEventArgs e)
        {
            SampleItems.Clear();

            var data = await SampleDataService.GetListDetailDataAsync();

            foreach (var item in data)
            {
                SampleItems.Add(item);
            }
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

        private void Calender_DateChange(CalendarView sender, CalendarViewSelectedDatesChangedEventArgs args)
        {
            if((string)Button1.Content == "Task 1           ## XP # Coins")
            {
                Button1.Content = "Task A           ## XP # Coins";
                Button2.Content = "Task B           ## XP # Coins";
                Button3.Content = "Task C           ## XP # Coins";
                Button4.Content = "Task D           ## XP # Coins";
            }
            else
            {
                Button1.Content = "Task 1           ## XP # Coins";
                Button2.Content = "Task 2           ## XP # Coins";
                Button3.Content = "Task 3           ## XP # Coins";
                Button4.Content = "Task 4           ## XP # Coins";
            }
        }

        private void Task_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
