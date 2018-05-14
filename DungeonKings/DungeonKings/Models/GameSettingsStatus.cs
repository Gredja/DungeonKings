namespace DungeonKings.Models
{
    public class GameSettingsStatus
    {
        public WorkStatus Status { get; set; } = WorkStatus.Iddle;
        public int ProcessingPercent { get; set; }
        public string Version { get; set; }
    }
}