using Demo.Models;

namespace Demo.Repository
{
    public class StudentMockREspotory: IStudentRepository
    {
        List<Student> students = new List<Student>();
        public StudentMockREspotory()
        {
            students.Add(new Student());
        }

        public Guid id { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void Delete(int id)
        {
            //students.Remove();
        }

        public void Edit(int id, Student item)
        {
            throw new NotImplementedException();
        }

        public List<Student> GetAll()
        {
            throw new NotImplementedException();
        }

        public List<Student> getallStudent()
        {
            return students;
        }

        public List<Student> GetAllStudentsWithDepartmentData()
        {
            throw new NotImplementedException();
        }

        public Student GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(Student item)
        {
            throw new NotImplementedException();
        }
    }
}
