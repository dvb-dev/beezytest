using System.Threading.Tasks;

namespace BeezyTest.DomainServices
{
	public interface IBoxOfficeService
	{
		public Task<string> GetTopSeller(int cityId);
		public Task<string> GetTopSellerByGenre(int cityId, string genre);
	}
}
