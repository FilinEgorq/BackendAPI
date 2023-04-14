namespace BackendAPI.Contracts.User
{
    public class UpdateUserRequest
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string Surname { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string Password { get; set; } = null!;

        public long? PhoneNumber { get; set; }

        public decimal Balance { get; set; }

        public string Role { get; set; } = null!;

        public DateTime? Birthday { get; set; }

        public DateTime? IsDeleted { get; set; }
    }
}
