namespace eShop.Contracts.Authentication
{
    public class AuthenticationResponse
    {
        public AuthenticationResponse(Guid id, string firstName, string lastName, string email, string token)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Token = token;
        }

        public Guid Id { get; set; }   
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }

    }
}
