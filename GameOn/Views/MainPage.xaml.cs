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
            int level = 1;
            int totalXp = PlayerData.xp;
            int xpToNext = level * 1000;

            if (totalXp / xpToNext == 1)
                level += 1;

            LevelText.Text = "Level: " + level;
            XpText.Text = totalXp + "/" + xpToNext;
            CurrentLevel.Text = "" + level;
            NextLevel.Text = "" + (level + 1);
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
