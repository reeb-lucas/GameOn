using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using GameOn;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;


namespace GameOn.Views
{
    public sealed partial class MainPage : Page, INotifyPropertyChanged
    {
        static bool started = false;

        public MainPage()
        {
            InitializeComponent();

            if (!started)
            {
                PlayerTask newTask = new PlayerTask(DateTime.Now, 10, 100, "Welcome", "Wave to let us know you found this note!", new SolidColorBrush());

                PlayerData.playerTasks.Add(newTask);
                started = true;
            }


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
                        TodayT2.Background = PlayerData.playerTasks[i]._color;
                    }
                    if (i == 2)
                    {
                        TodayT3.Visibility = 0;
                        TodayT3.Content = "" + PlayerData.playerTasks[i]._name + "     " + PlayerData.playerTasks[i]._xp + " XP " + PlayerData.playerTasks[i]._coins + " Coins";
                        TodayT3.Background = PlayerData.playerTasks[i]._color;
                    }
                    if (i == 3)
                    {
                        TodayT4.Visibility = 0;
                        TodayT4.Content = "" + PlayerData.playerTasks[i]._name + "     " + PlayerData.playerTasks[i]._xp + " XP " + PlayerData.playerTasks[i]._coins + " Coins";
                        TodayT4.Background = PlayerData.playerTasks[i]._color;
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
            int taskIndex = -1;
            if (sender == TodayT1) taskIndex = 0;
            else if (sender == TodayT2) taskIndex = 1;
            else if (sender == TodayT3) taskIndex = 2;
            else if (sender == TodayT4) taskIndex = 3;

            if (taskIndex >= 0)
            {

                ContentDialog todayOneD = new ContentDialog
                {
                    Title = PlayerData.playerTasks[taskIndex]._name,
                    Content = PlayerData.playerTasks[taskIndex]._notes,
                    CloseButtonText = "OK!",
                    PrimaryButtonText = "Finished!"
                };
                ContentDialogResult result = await todayOneD.ShowAsync();
                if (result == ContentDialogResult.Primary)
                {
                    ((Button)sender).Visibility = (Windows.UI.Xaml.Visibility)1;
                    PlayerData.xp += PlayerData.playerTasks[taskIndex]._xp;
                    LevelRect.Width = PlayerData.xp / 3;

                    PlayerData.playerTasks.RemoveAt(taskIndex );


                    //Update xp and level text
                    int level = PlayerData.level;
                    int totalXp = PlayerData.xp;
                    int xpToNext = level * 1000;

                    LevelText.Text = "Level: " + level;
                    XpText.Text = totalXp + "/" + xpToNext;
                    CurrentLevel.Text = "" + level;
                    NextLevel.Text = "" + (level + 1);
                    LevelRect.Width = totalXp / 3;
                    Frame.Navigate(this.GetType());
                }
            }
        }
    }
}
