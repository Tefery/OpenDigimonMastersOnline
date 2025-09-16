using ODMO.Commons.Enums.Events;

namespace ODMO.Commons.Models.Config.Events
{
    public sealed partial class EventConfigModel
    {
        public void SetStartsAt(TimeSpan startsAt) => StartsAt = startsAt;

        public void SetStartDay(EventStartDayEnum startDay) => StartDay = startDay;
    }
}