﻿namespace BackendAPI.Contracts.User
{
	public class CreateUserRequest
	{
		public string Name { get; set; } = null!;

		public string Surname { get; set; } = null!;

		public string Email { get; set; } = null!;

		public string Password { get; set; } = null!;

		public long PhoneNumber { get; set; }

		public double Balance { get; set; }

		public string Role { get; set; } = null!;

		public DateTime? BirthDay { get; set; }
	}
}