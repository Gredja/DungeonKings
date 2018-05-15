using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace DungeonKings.Models
{
    public class ProcessingStatus
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public WorkStatus Status { get; set; } = WorkStatus.Idle;
        public int ProcessingPercent { get; set; }
        public string Version { get; set; }
    }
}