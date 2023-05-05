namespace BackendAPI.Contracts.Filter
{
	public class GetFilterResponse
	{
		public int Id { get; set; }

		public string Name { get; set; } = null!;

		public int CategoryId { get; set; }

		public DateTime? IsDeleted { get; set; }
	}
}
