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
            if (PlayerData.playerTasks.Count > 0)
            {
                for (int i = 0; i < PlayerData.playerTasks.Count; i++)
                {
                    if (i == 0)
                    {
                        TodayT1.Visibility = 0;
                        TodayT1.Content = "" + PlayerData.playerTasks[i]._name + "     " + PlayerData.playerTasks[i]._xp + " XP " + PlayerData.playerTasks[i]._coins + " Coins";
                        TodayT1.Background = PlayerData.playerTasks[i]._color;
                    }

                    if (i == 1)
                    {
                        TodayT2.Visibility = 0;
                        TodayT2.Content = "" + PlayerData.playerTasks[i]._name + "     " + PlayerData.playerTasks[i]._xp + " XP " + PlayerData.playerTasks[i]._coins + " Coins";
                        TodayT1.Background = PlayerData.playerTasks[i]._color;
                    }
                    if (i == 2)
                    {
                        TodayT3.Visibility = 0;
                        TodayT3.Content = "" + PlayerData.playerTasks[i]._name + "     " + PlayerData.playerTasks[i]._xp + " XP " + PlayerData.playerTasks[i]._coins + " Coins";
                        TodayT1.Background = PlayerData.playerTasks[i]._color;
                    }
                    if (i == 3)
                    {
                        TodayT4.Visibility = 0;
                        TodayT4.Content = "" + PlayerData.playerTasks[i]._name + "     " + PlayerData.playerTasks[i]._xp + " XP " + PlayerData.playerTasks[i]._coins + " Coins";
                        TodayT1.Background = PlayerData.playerTasks[i]._color;
                    }

                }
            }
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
            
        }

        private async void Task_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            if (sender == TodayT1)
            {
                ContentDialog todayOneC = new ContentDialog
                {
                    Title = PlayerData.playerTasks[0]._name,
                    Content = PlayerData.playerTasks[0]._notes,
                    CloseButtonText = "OK!",
                    PrimaryButtonText = "Finished!"
                };
                ContentDialogResult result = await todayOneC.ShowAsync();
                if (result == ContentDialogResult.Primary)
                {
                    TodayT1.Visibility = (Windows.UI.Xaml.Visibility)1;
                    PlayerData.xp += PlayerData.playerTasks[0]._xp;
                }
            }
            if (sender == TodayT2)
            {
                ContentDialog todayOneC = new ContentDialog
                {
                    Title = PlayerData.playerTasks[1]._name,
                    Content = PlayerData.playerTasks[1]._notes,
                    CloseButtonText = "OK!",
                    PrimaryButtonText = "Finished!"
                };
                ContentDialogResult result = await todayOneC.ShowAsync();
                if (result == ContentDialogResult.Primary)
                {
                    TodayT2.Visibility = (Windows.UI.Xaml.Visibility)1;
                    PlayerData.xp += PlayerData.playerTasks[1]._xp;
                }
            }
            if (sender == TodayT3)
            {
                ContentDialog todayOneC = new ContentDialog
                {
                    Title = PlayerData.playerTasks[2]._name,
                    Content = PlayerData.playerTasks[2]._notes,
                    CloseButtonText = "OK!",
                    PrimaryButtonText = "Finished!"
                };
                ContentDialogResult result = await todayOneC.ShowAsync();
                if (result == ContentDialogResult.Primary)
                {
                    TodayT3.Visibility = (Windows.UI.Xaml.Visibility)1;
                    PlayerData.xp += PlayerData.playerTasks[2]._xp;
                }
            }
            if (sender == TodayT4)
            {
                ContentDialog todayOneC = new ContentDialog
                {
                    Title = PlayerData.playerTasks[3]._name,
                    Content = PlayerData.playerTasks[3]._notes,
                    CloseButtonText = "OK!",
                    PrimaryButtonText = "Finished!"
                };
                ContentDialogResult result = await todayOneC.ShowAsync();
                if (result == ContentDialogResult.Primary)
                {
                    TodayT4.Visibility = (Windows.UI.Xaml.Visibility)1;
                    PlayerData.xp += PlayerData.playerTasks[3]._xp;
                }
            }
        }
    }
}
