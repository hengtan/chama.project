namespace Chama.Domain.Models
{
    public class Lecturer : Person
    {
        public Lecturer(int courseId)
        {
            CourseId = courseId;
        }

        protected Lecturer() { }

        public int CourseId { get; private set; }
    }
}
