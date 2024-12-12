
namespace PcStore.Web.ViewModels.Part
{
    public class PartQueryModel
    {
        public int CurrentPage { get; init; }

        public int PartsPerPage { get; init; }

        public int TotalParts { get; init; }

        public IEnumerable<AllPartModel> Parts { get; init; }
    }
}
