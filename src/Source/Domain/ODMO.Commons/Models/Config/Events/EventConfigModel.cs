using ODMO.Commons.Enums.Events;

namespace ODMO.Commons.Models.Config.Events
{
    public sealed partial class EventConfigModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        
        public byte Rounds { get; set; }
        public bool IsEnabled { get; set; }
        public EventStartDayEnum StartDay { get; set; } = EventStartDayEnum.Everyday;
        public TimeSpan StartsAt { get; set; } = new(0, 0, 0);
        public List<EventMapsConfigModel> EventMaps { get; set; }

        public EventConfigModel(string name, string description,
            List<EventMapsConfigModel> eventMaps, bool isEnabled = true)
        {
            Name = name;
            Description = description;
            IsEnabled = isEnabled;
            EventMaps = eventMaps;
            Rounds = 1;
        }
    }
}