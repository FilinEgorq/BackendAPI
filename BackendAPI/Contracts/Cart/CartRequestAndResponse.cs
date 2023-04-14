namespace BackendAPI.Contracts.Cart
{
    public class CartRequestAndResponse
    {
        public int UserId { get; set; }

        public int GoodId { get; set; }

        public int Count { get; set; }
    }
}
