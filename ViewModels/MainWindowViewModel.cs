using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace AdbDeviceTool.ViewModels
{
    public class MainWindowViewModel : ViewModelBase, INotifyPropertyChanged
    {
        public new event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private string ConnectCommand => $"adb connect {DeviceIP}";

        private string DisconnectCommand => $"adb disconnect {DeviceIP}";

        private string InstallCommand => $"adb install {InstallPath}";

        private string UninstallCommand => $"adb -s {DeviceIP} uninstall {RoomsAppName}";

        private string LaunchRoomsCommand => $"adb -s {DeviceIP} shell am start {RoomsAppName}/{RoomsSplashActivityName}";

        private string ForceStopRoomsCommand => $"adb -s {DeviceIP} shell am force-stop {RoomsAppName}";

        private string LaunchSettingsCommand => $"adb -s {DeviceIP} shell am start {SettingsAppName}/{SettingsSplashActivityName}";

        private string ForceStopSettingsCommand => $"adb -s {DeviceIP} shell am force-stop {RoomsAppName}";

        public string DeviceIP
        {
            get;
            set;
        }

        public string InstallPath
        {
            get;
            set;
        }

        public string RoomsAppName
        {
            get;
            set;
        }

        public string RoomsSplashActivityName
        {
            get;
            set;
        }

        public string SettingsAppName
        {
            get;
            set;
        }

        public string SettingsSplashActivityName
        {
            get;
            set;
        }

        private StringBuilder commandOutputBuilder = new StringBuilder();
        public string CommandOutput
        {
            get => commandOutputBuilder.ToString();
            private set
            {
                commandOutputBuilder.AppendLine(value);
                OnPropertyChanged(nameof(CommandOutput));
            }
        }

        public MainWindowViewModel()
        {
            RoomsAppName = "com.ringcentral.com";
            RoomsSplashActivityName = "com.ringcentral.com.RoomsSplashActivity";
            SettingsAppName = "com.android.settings";
            SettingsSplashActivityName = ".Settings$ApnEditorActivity";
        }

        public void OnConnectClick()
        {
            CommandOutput = ConnectCommand.Bash();
        }

        public void OnDisconnectClick()
        {
            CommandOutput = DisconnectCommand.Bash();
        }

        public void OnInstallClick()
        {
            CommandOutput = InstallCommand.Bash();
        }

        public void OnUninstallClick()
        {
            CommandOutput = UninstallCommand.Bash();
        }

        public void OnLaunchRoomsClick()
        {
            CommandOutput = LaunchRoomsCommand.Bash();
        }

        public void OnForceStopRoomsClick()
        {
            CommandOutput = ForceStopRoomsCommand.Bash();
        }

        public void OnLaunchSettingsClick()
        {
            CommandOutput = LaunchSettingsCommand.Bash();
        }

        public void OnForceStopSettingsClick()
        {
            CommandOutput = ForceStopSettingsCommand.Bash();
        }
    }
}
