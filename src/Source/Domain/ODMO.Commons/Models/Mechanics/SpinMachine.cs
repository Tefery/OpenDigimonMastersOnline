namespace ODMO.Commons.Models.Mechanics
{
    public class SpinMachine
    {
        public long SpinMachineId { get; set; }
        public int NormalItensRemaining { get; set; }
        public List<SpinMachineRareReward> RareRewards { get; set; }
    }
}
