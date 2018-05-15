namespace DungeonKings.Models
{
    public class ProcessingStatus
    {
        public WorkStatus Status { get; set; } = WorkStatus.Idle;
        public int ProcessingPercent { get; set; }
        public string Version { get; set; }
    }
}