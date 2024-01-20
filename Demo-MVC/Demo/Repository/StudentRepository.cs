using Demo.Models;
using Microsoft.EntityFrameworkCore;

namespace Demo.Repository
{
    public class StudentRepository: IStudentRepository
    {
        //CRUD
        //DI
        ITIEntity context;//= new ITIEntity();

        public Guid id { get; set; }
        public StudentRepository(ITIEntity _context)
        {
            id = Guid.NewGuid();
            context = _context;
        }

        public List<Student> GetAll()
        {
            return context.Students.ToList();
        }
        public List<Student> GetAllStudentsWithDepartmentData()
        {
            return context.Students.Include(s => s.Department).ToList();
        }
        public Student GetById(int id)
        {
            return context.Students.FirstOrDefault(x => x.Id == id);
        }
        public void Insert(Student item)
        {
            context.Students.Add(item);
            context.SaveChanges();
        }
        public void Edit(int id,Student item)
        {
            Student oldStudent= GetById(id);
            oldStudent.Name = item.Name;
            oldStudent.Dept_Id = item.Dept_Id;
            oldStudent.Age = item.Age;
            oldStudent.Image = item.Image;
            oldStudent.Address = item.Address;
        
            context.SaveChanges();
        }
        public void Delete(int id)
        {
            Student oldStudent = GetById(id);
            context.Students.Remove(oldStudent);
            context.SaveChanges();
        }
    }
}
