namespace Domain.ValueObjects
{
    public class Address
    {
        public string Street { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }
        public string Country { get; private set; }
        public string PostCode { get; private set; }

        public Address() { }

        public Address(string street, string city, string state, string country, string postCode)
        {
            Street = street;
            City = city;
            State = state;
            Country = country;
            PostCode = postCode;
        }

        protected IEnumerable<object> GetEqualityComponents()
        {
            // Using a yield return statement to return each element one at a time
            yield return Street;
            yield return City;
            yield return State;
            yield return Country;
            yield return PostCode;
        }
    }
}
