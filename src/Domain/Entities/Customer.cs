using Domain.ValueObjects;

namespace Domain.Entities
{
    public class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string MobileNumber { get; set; }
        public Address? Address { get; set; }

        public bool IsValid()
        {
            return
                FirstName != null &&
                Email != null;// &&
                //Address != null;
        }
    }
}
