using Demo.Models;

namespace Demo.Repository
{
    public interface IDepartmentRepository
    {
        List<Department> GetAll();
        Department GetById(int id);
        void Insert(Department item);
        void Edit(int id, Department item);
        void Delete(int id);
    }
}