namespace Application.Models.Entities
{
    public class Contract
    {
        public int Id { get; set; }
        public int LegalPersonId { get; set; }
        public LegalPerson? LegalPerson { get; set; }
        public int PhysicalPersonId { get; set; }
        public PhysicalPerson? PhysicalPerson { get; set; }
        public double ContracAtmount { get; set; }
        public string Status { get; set; }
        public DateTime SingingDate { get; set; }
    }
}
