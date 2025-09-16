

using ODMO.Commons.Models.Base;

namespace ODMO.Commons.Models.Config
{
    public sealed class KillSpawnTargetMobConfigModel :ICloneable
    {
        public long Id { get; set; }

        public int TargetMobType { get; set; }

        public byte TargetMobAmount { get; set; }

        public object Clone()
        {
            
                return (KillSpawnTargetMobConfigModel)MemberwiseClone();        
        }
    }
}