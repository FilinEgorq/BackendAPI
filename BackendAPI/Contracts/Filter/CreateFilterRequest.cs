namespace BackendAPI.Contracts.Filter
{
	public class CreateFilterRequest
	{
		public string Name { get; set; } = null!;

		public int CategoryId { get; set; }

		public DateTime? IsDeleted { get; set; }
	}
}
