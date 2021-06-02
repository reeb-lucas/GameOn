using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

using GameOn.Helpers;
using GameOn.Services;
using Microsoft.Toolkit.Uwp.UI;
using Windows.ApplicationModel;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace GameOn.Views
{
    // TODO WTS: Add other settings as necessary. For help see https://github.com/Microsoft/WindowsTemplateStudio/blob/release/docs/UWP/pages/settings-codebehind.md
    // TODO WTS: Change the URL for your privacy policy in the Resource File, currently set to https://YourPrivacyUrlGoesHere
    public sealed partial class SettingsPage : Page, INotifyPropertyChanged
    {
        private ElementTheme _elementTheme = ThemeSelectorService.Theme;

        public ElementTheme ElementTheme
        {
            get { return _elementTheme; }

            set { Set(ref _elementTheme, value); }
        }

        private string _versionDescription;

        public string VersionDescription
        {
            get { return _versionDescription; }

            set { Set(ref _versionDescription, value); }
        }

        public SettingsPage()
        {
            InitializeComponent();
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            await InitializeAsync();
        }

        private async Task InitializeAsync()
        {
            VersionDescription = GetVersionDescription();
            await Task.CompletedTask;
        }

        private string GetVersionDescription()
        {
            var appName = "AppDisplayName".GetLocalized();
            var package = Package.Current;
            var packageId = package.Id;
            var version = packageId.Version;

            return $"{appName} - {version.Major}.{version.Minor}.{version.Build}.{version.Revision}";
        }

        private async void ThemeChanged_CheckedAsync(object sender, RoutedEventArgs e)
        {
            ThemeContentDialog chooseTheme = new ThemeContentDialog();

            await chooseTheme.ShowAsync();

            if (chooseTheme.Theme == 2)
            { 
                await ThemeSelectorService.SetThemeAsync(ElementTheme.Dark);
            }
            else if (chooseTheme.Theme == 1)
            {
                await ThemeSelectorService.SetThemeAsync(ElementTheme.Light);
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

        private async void AccountDetails_Button_Click(object sender, RoutedEventArgs e)
        {
            ContentDialog details = new ContentDialog()
            {
                Title = "Account Details",
                Content = "Username: " + PlayerData.username + "\n" + "Coins: " + PlayerData.coins + "\n" + "Level: " + PlayerData.level + "\n" + "XP: " + PlayerData.xp + "\n" + "Needed XP: " + PlayerData.level * 1000,
                CloseButtonText = "Done"
            };

            await details.ShowAsync();
        }

        private async void Sure_Button_Click(object sender, RoutedEventArgs e)
        {
            ContentDialog confirmation = new ContentDialog()
            {
                Title = "Confirm",
                Content = "Are You Sure?",
                PrimaryButtonText = "Cancel",
                SecondaryButtonText = "Confirm"
            };

            await confirmation.ShowAsync();
        }

        private async void About_Button_Click(object sender, RoutedEventArgs e)
        {
            ContentDialog about = new ContentDialog()
            {
                Title = "About",
                Content = "Version 0.0.1\n\n" + "Creators:\n" + "   Kohlton Kuczler\n   Tyler Lucas\n   Jacob Pressley\n   Devin Wolford",
                CloseButtonText = "Done"
            };

            await about.ShowAsync();
        }

        private async void Reset_Button_Click(object sender, RoutedEventArgs e)
        {
            SureCheckContentDialog check = new SureCheckContentDialog();

            await check.ShowAsync();
        }
    }
}
