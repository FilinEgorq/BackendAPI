namespace BackendAPI.Contracts.Category
{
    public class CreateCategoryRequest
    {
        public int? ParentId { get; set; }

        public string Name { get; set; } = null!;

        public string? Description { get; set; }
    }
}
