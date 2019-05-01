using System;
namespace DAL.Repository
{
    public interface IEmployeeRepository
    {
        DAL.DataModel.Employee Add(DAL.DataModel.Employee employee);
        void Delete(int employeeID);
        DAL.DataModel.Employee Get(int employeeID);
        System.Collections.Generic.List<DAL.DataModel.Employee> GetAll();
        DAL.DataModel.Employee Update(DAL.DataModel.Employee employee);
    }
}
