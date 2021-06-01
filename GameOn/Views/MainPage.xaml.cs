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
            //TODO: width of progress rectangle as fraction of setwidth/totwidth = totxp/xptonext

            CoinText.Text = "Coins: " + PlayerData.coins;
            UsernameText.Text = PlayerData.username;
                
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
            }
        }
    }
}
