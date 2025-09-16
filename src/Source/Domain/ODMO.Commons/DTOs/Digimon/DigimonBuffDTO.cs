using ODMO.Commons.DTOs.Base;

namespace ODMO.Commons.DTOs.Digimon
{
    public class DigimonBuffDTO : BuffDTO
    {
        /// <summary>
        /// Unique sequential identifier.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Reference to the owner.
        /// </summary>
        public long BuffListId { get; set; }
        public DigimonBuffListDTO BuffList { get; set; }
    }
}