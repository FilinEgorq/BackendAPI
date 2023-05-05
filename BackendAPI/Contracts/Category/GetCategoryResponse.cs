namespace BackendAPI.Contracts.Category
{
	public class GetCategoryResponse
	{
		public int Id { get; set; }

		public int? ParentId { get; set; }

		public string Name { get; set; } = null!;

		public string? Description { get; set; }

		public DateTime? IsDeleted { get; set; }
	}
}
