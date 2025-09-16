
namespace ODMO.Commons.Models.Asset
{

    public class ExtraEvolutionInformationAssetModel
    {
        public long Id { get; set; }

        public int IndexId { get; set; }

        public List<ExtraEvolutionAssetModel> ExtraEvolution { get; set; }

    }
}
