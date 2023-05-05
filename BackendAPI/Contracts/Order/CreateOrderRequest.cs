namespace BackendAPI.Contracts.Order
{
	public class CreateOrderRequest
	{
		public int UserId { get; set; }

		public decimal FullCost { get; set; }

		public string DeliveryMethod { get; set; } = null!;

		public string? Status { get; set; }

		public DateTime CreatedAt { get; set; } = DateTime.Now;
	}
}
