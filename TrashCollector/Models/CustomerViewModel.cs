namespace TrashCollector.Models
{
    public class CustomerViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public int ZipCode { get; set; }
        public DayOfWeek PreferredDay { get; set; }
    }
}
