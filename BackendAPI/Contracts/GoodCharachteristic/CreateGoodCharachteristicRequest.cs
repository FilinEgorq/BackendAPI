namespace BackendAPI.Contracts.GoodCharachteristic
{
    public class CreateGoodCharachteristicRequest
    {
        public int GoodId { get; set; }

        public int FilterId { get; set; }

        public object? Value { get; set; }
    }
}
