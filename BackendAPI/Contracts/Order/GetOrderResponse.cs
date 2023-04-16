using System.Security.Cryptography.X509Certificates;

namespace BackendAPI.Contracts.Order
{
    public class GetOrderResponse
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public decimal FullCost { get; set; }

        public string DeliveryMethod { get; set; } = null!;

        public string? Status { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? IsDeleted { get; set; }
    }
}
