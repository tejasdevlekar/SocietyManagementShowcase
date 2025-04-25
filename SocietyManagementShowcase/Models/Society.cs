namespace SocietyManagementShowcase.Models
{
    public class Society
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<WingType> Wing { get; set; }
        public int NoOfWings { get; set; }
        public List<Person> SecurityStaff { get; set; }
        public List<Person> HouseKeepingStaff { get; set; }
        public Person Manager { get; set; }

    }
}
