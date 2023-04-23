namespace Application.Models.Entities
{
    public class LegalPerson
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string INN { get; set; }
        public string OGRN { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public List<Contract> Contracts { get; set; }
    }
}
