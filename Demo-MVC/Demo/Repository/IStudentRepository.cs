using Demo.Models;

namespace Demo.Repository
{
    public interface IStudentRepository
    {
        Guid id { get; set; }
        List<Student> GetAll();
        List<Student> GetAllStudentsWithDepartmentData();
        Student GetById(int id);
        void Insert(Student item);
        void Edit(int id, Student item);
        void Delete(int id);

    }
}
