using System.Web.Http;
using DungeonKings.Models;
using Timer = System.Timers.Timer;

namespace DungeonKings.Services
{

    public sealed class SettingsProcessor : ApiController
    {
        private static readonly Timer EnvironmentTimer = new Timer(60000);
        private static readonly Timer GameSettingsTimer = new Timer(60000);
        private static readonly Timer RoomSettingsTimer = new Timer(60000);
        private static readonly Timer SaleStoreTImer = new Timer(60000);
        private static readonly Timer CommonStoreTImer = new Timer(60000);

        private static SettingsProcessor _instance;

        public SettingsProcessor()
        {
            GameSettingsTimer.Elapsed += GameTimerElapsed;
            RoomSettingsTimer.Elapsed += RoomTimerElapsed;
            SaleStoreTImer.Elapsed += SaleStoreTimerElapsed;
            CommonStoreTImer.Elapsed += CommonStoreTImerElapsed;
            EnvironmentTimer.Elapsed += EnvironmentTimerElapsed;
        }

        public static SettingsProcessor Instance => _instance ?? (_instance = new SettingsProcessor());

        public ProcessingStatus GetGameProcessingStatus()
        {
            return GameSettingsTimer.Enabled ? GetProcessedStatus() : GetIddleStatus();
        }

        public ProcessingStatus GetEnvironmentProcessingStatus()
        {
            return EnvironmentTimer.Enabled ? GetProcessedStatus() : GetIddleStatus();
        }

        public ProcessingStatus GetRoomProcessingStatus()
        {
            return RoomSettingsTimer.Enabled ? GetProcessedStatus() : GetIddleStatus();
        }

        public ProcessingStatus GetCommonProcessingStatus()
        {
            return CommonStoreTImer.Enabled ? GetProcessedStatus() : GetIddleStatus();
        }

        public ProcessingStatus GetSaleProcessingStatus()
        {
            return SaleStoreTImer.Enabled ? GetProcessedStatus() : GetIddleStatus();
        }

        public void ProcessEnvironmentSettings()
        {
            EnvironmentTimer.Start();
        }

        public void ProcessGameSettings()
        {
            GameSettingsTimer.Start();
        }

        public void ProcessRoomSettings()
        {
            RoomSettingsTimer.Start();
        }

        public void ProcessCommonStore()
        {
            CommonStoreTImer.Start();
        }

        public void ProcessSaleStore()
        {
            SaleStoreTImer.Start();
        }

        private void GameTimerElapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            GameSettingsTimer.Stop();
        }

        private void RoomTimerElapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            RoomSettingsTimer.Stop();
        }

        private void CommonStoreTImerElapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            CommonStoreTImer.Stop();
        }

        private void SaleStoreTimerElapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            SaleStoreTImer.Stop();
        }

        private void EnvironmentTimerElapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            EnvironmentTimer.Stop();
        }

        private static ProcessingStatus GetProcessedStatus()
        {
            return new ProcessingStatus
            {
                Status = WorkStatus.Processed,
                ProcessingPercent = 80,
                Version = "1.0.1"
            };
        }

        private static ProcessingStatus GetIddleStatus()
        {
            return new ProcessingStatus
            {
                Status = WorkStatus.Idle,
                ProcessingPercent = 0,
                Version = "1.0.1"
            };
        }
    }
}