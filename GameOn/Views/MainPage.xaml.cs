using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using GameOn;
using Windows.UI.Xaml.Controls;

namespace GameOn.Views
{
    public sealed partial class MainPage : Page, INotifyPropertyChanged
    {
        public MainPage()
        {
            InitializeComponent();
            int level = PlayerData.level;
            int totalXp = PlayerData.xp;
            int xpToNext = level * 1000;

            if (totalXp / xpToNext == 1)
            {
                PlayerData.level = level += 1;
                level += 1;
            }

            LevelText.Text = "Level: " + level;
            XpText.Text = totalXp + "/" + xpToNext;
            CurrentLevel.Text = "" + level;
            NextLevel.Text = "" + (level + 1);
            LevelRect.Width = totalXp / 3;

            CoinText.Text = "Coins: " + PlayerData.coins;
            UsernameText.Text = PlayerData.username;

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
            if(sender == TodayT1)
            {
                ContentDialog todayOneD = new ContentDialog
                {
                    Title = PlayerData.playerTasks[0]._name,
                    Content = PlayerData.playerTasks[0]._notes,
                    CloseButtonText = "OK!",
                    PrimaryButtonText = "Finished!"
                };
                ContentDialogResult result = await todayOneD.ShowAsync();
                if (result == ContentDialogResult.Primary)
                {
                    TodayT1.Visibility = (Windows.UI.Xaml.Visibility)1;
                    PlayerData.xp += PlayerData.playerTasks[0]._xp;
                    LevelRect.Width = PlayerData.xp / 3;
                }
            }
            if (sender == TodayT2)
            {
                ContentDialog todayOneD = new ContentDialog
                {
                    Title = PlayerData.playerTasks[1]._name,
                    Content = PlayerData.playerTasks[1]._notes,
                    CloseButtonText = "OK!",
                    PrimaryButtonText = "Finished!"
                };
                ContentDialogResult result = await todayOneD.ShowAsync();
                if (result == ContentDialogResult.Primary)
                {
                    TodayT2.Visibility = (Windows.UI.Xaml.Visibility)1;
                    PlayerData.xp += PlayerData.playerTasks[1]._xp;
                    LevelRect.Width = PlayerData.xp / 3;
                }
            }
            if (sender == TodayT3)
            {
                ContentDialog todayOneD = new ContentDialog
                {
                    Title = PlayerData.playerTasks[2]._name,
                    Content = PlayerData.playerTasks[2]._notes,
                    CloseButtonText = "OK!",
                    PrimaryButtonText = "Finished!"
                };
                ContentDialogResult result = await todayOneD.ShowAsync();
                if (result == ContentDialogResult.Primary)
                {
                    TodayT3.Visibility = (Windows.UI.Xaml.Visibility)1;
                    PlayerData.xp += PlayerData.playerTasks[2]._xp;
                    LevelRect.Width = PlayerData.xp / 3;
                }
            }
            if (sender == TodayT4)
            {
                ContentDialog todayOneD = new ContentDialog
                {
                    Title = PlayerData.playerTasks[3]._name,
                    Content = PlayerData.playerTasks[3]._notes,
                    CloseButtonText = "OK!",
                    PrimaryButtonText = "Finished!"
                };
                ContentDialogResult result = await todayOneD.ShowAsync();
                if (result == ContentDialogResult.Primary)
                {
                    TodayT4.Visibility = (Windows.UI.Xaml.Visibility)1;
                    PlayerData.xp += PlayerData.playerTasks[3]._xp;
                    LevelRect.Width = PlayerData.xp / 3;
                }
            }
        }
    }
}
