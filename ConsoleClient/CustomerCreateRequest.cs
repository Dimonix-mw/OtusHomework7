namespace ConsoleClient
{
    public class CustomerCreateRequest
    {
        /// <summary>
        /// ������ ������� �� �������� Customer ��� �������� � WebApi
        /// </summary>
        public CustomerCreateRequest()
        {
        }

        public CustomerCreateRequest(
            long customerId,
            string firstName,
            string lastName)
        {
            CustomerId = customerId;
            Firstname = firstName;
            Lastname = lastName;
        }
        public long CustomerId { get; init; }

        public string Firstname { get; init; }

        public string Lastname { get; init; }
    }
}