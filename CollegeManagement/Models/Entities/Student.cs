namespace CollegeManagement.Models.Entities
{
    public class Student
    {
        public Guid Id { get; set; }
        public int reg_no { get; set; }
        public string name { get; set; }

        public int age { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string city { get; set; }
        public string country { get; set; }

    }
}
