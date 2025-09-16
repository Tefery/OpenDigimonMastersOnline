using ODMO.Commons.DTOs.Character;

namespace ODMO.Commons.DTOs.Events
{
    public sealed partial class AttendanceRewardDTO
    {
        /// <summary>
        /// Unique sequential identifier.
        /// </summary>
        public long Id { get;  set; }

        /// <summary>
        /// The current log-in streak.
        /// </summary>
        public byte TotalDays { get;  set; }

        /// <summary>
        /// The date when the last reward was claimed.
        /// </summary>
        public DateTime LastRewardDate { get;  set; }

        /// <summary>
        /// Reference to the owner.
        /// </summary>
        public long CharacterId { get; private set; }
        public CharacterDTO Character { get; private set; }
    }
}