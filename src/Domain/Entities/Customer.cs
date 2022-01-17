using Domain.ValueObjects;

namespace Domain.Entities
{
    public class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string MobileNumber { get; set; } = string.Empty;
        public Address? Address { get; set; }

        // TODO: poor mans entity validation implementation
        public bool IsValid()
        {
            return
                !string.IsNullOrEmpty(FirstName) &&
                !string.IsNullOrEmpty(Email) &&
                Address != null;
        }
    }
}
