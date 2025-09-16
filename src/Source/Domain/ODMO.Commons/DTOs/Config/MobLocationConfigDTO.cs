using ODMO.Commons.DTOs.Base;

namespace ODMO.Commons.DTOs.Config
{
    public class MobLocationConfigDTO : LocationDTO
    {
        /// <summary>
        /// Sequencial unique identifier.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Reference to the owner.
        /// </summary>
        public long MobConfigId { get; set; }
        public MobConfigDTO MobConfig { get; set; }
    }
}
