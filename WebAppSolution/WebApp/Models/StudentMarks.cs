namespace WebApp.Models
{
    public class StudentMarks
    {
        public string FirstName { get; set; }
        public string LastName { get;set; }
        public int Assessment { get;set; }
        public int AssessmentVersion { get; set; }
        public double Mark { get;set; }

        public StudentMarks() { }

        public StudentMarks(string firstname, string lastName, 
                            int assessment, int assessmentversion, double mark = 0.0)
        {
            FirstName = firstname;
            LastName = lastName;
            Assessment = assessment;
            AssessmentVersion = assessmentversion;
            Mark = mark;
        }

        public override string ToString()
        {
            return $"{FirstName},{LastName},{Assessment},{AssessmentVersion},{Mark}";
        }
        public static StudentMarks Parse(string text)
        {
            string[] items = text.Split(",");
            if (items.Length != 5 )
            {
                throw new FormatException($"Invalid record format: {text}");
            }
            return new StudentMarks(items[0], items[1], int.Parse(items[2]),
                int.Parse(items[3]), double.Parse(items[4]));
        }
    }
}
