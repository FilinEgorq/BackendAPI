namespace BackendAPI.Contracts.Good
{
	public class GetGoodResponse
	{
		public int Id { get; set; }

		public string Name { get; set; } = null!;

		public string? Description { get; set; }

		public int Amount { get; set; }

		public decimal Price { get; set; }

		public byte[]? Preview { get; set; }

		public DateTime? IsDeleted { get; set; }
	}
}
