using ODMO.Commons.Enums;
using ODMO.Commons.DTOs.Character;

namespace ODMO.Commons.DTOs.Events
{
    public class TimeRewardDTO
    {
        /// <summary>
        /// Unique sequential identifier.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// The reward current index and duration.
        /// </summary>
        public TimeRewardIndexEnum RewardIndex { get; set; }

        /// <summary>
        /// The current index start time.
        /// </summary>
        public DateTime StartTime { get; set; }

        /// <summary>
        /// Reference to the owner.
        /// </summary>
        public long CharacterId { get; set; }
        public CharacterDTO Character { get; set; }

        /// <summary>
        /// The current time.
        /// </summary>
        public int AtualTime { get; set; }
    }
}
