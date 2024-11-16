namespace Studentportal.Model
{
    public class AddStudentDto
    {

        public int Id { get; set; }
        public string StudentName { get; set; }
        public int courseID { get; set; }
        public string password { get; set; }
    }
}
