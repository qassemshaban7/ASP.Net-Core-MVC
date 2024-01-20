using Demo.Models;

namespace Demo.Repository
{
    public class DepartmentRepository: IDepartmentRepository
    {
        ITIEntity context;//= new ITIEntity();
        public DepartmentRepository(ITIEntity _context)
        {
            context = _context;
        }
        public List<Department> GetAll()
        {
            return context.Departments.ToList();
        }
        public Department GetById(int id)
        {
            return context.Departments.FirstOrDefault(x => x.Id == id);
        }
        public void Insert(Department item)
        {
            context.Departments.Add(item);
            context.SaveChanges();
        }
        public void Edit(int id, Department item)
        {
            Department oldDept = GetById(id);
            oldDept.Name = item.Name;
            oldDept.ManagerName = item.ManagerName;
            context.SaveChanges();
        }
        public void Delete(int id)
        {
            Department oldDept = GetById(id);
            context.Departments.Remove(oldDept);
            context.SaveChanges();
        }
    }
}
