using DAL.DataModel;
using DAL.Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        DataModel.EmployeeDBEntities context;
        IDataLogger _logger;

        public EmployeeRepository(IDataLogger logger)
        {
            _logger = logger;
            context = new DataModel.EmployeeDBEntities();
        }

        public EmployeeRepository(DataModel.EmployeeDBEntities ctxt, IDataLogger logger)
        {
            _logger = logger;
            context = ctxt;
        }

        public Employee Add(Employee employee)
        {
            Employee employeeModified = null;
            if (employee == null)
            {
                _logger.WriteLog("Invalid Record");
                throw new Exception("Invalid Record");
            }
            if (context.Employees.Count() == 0)
                employeeModified = context.Employees.Add(employee);
            else
            {
                var isExisting = context.Employees.FirstOrDefault(x => x.FName.ToUpper() == employee.FName.ToUpper() && x.LName.ToUpper() == employee.LName.ToUpper());

                if (employee.Addresses != null)
                {
                    string phoneNumber=employee.Addresses.FirstOrDefault().Phone.ToUpper();
                    var isPhoneExists = context.Addresses.FirstOrDefault(x => x.Phone.ToUpper() == phoneNumber);
                    if (isExisting == null && isPhoneExists == null)
                    {
                        employeeModified = context.Employees.Add(employee);
                    }
                    else
                    {
                        if (isExisting != null)
                        {
                            _logger.WriteException("Exception Occured :",new FaultException("Duplicate Entry Found"));
                            throw new FaultException("Duplicate Entry Found");
                        }
                        if (isPhoneExists != null)
                        {
                            _logger.WriteException("Exception Occured :", new FaultException("Duplicate Phone Number Found"));
                            throw new FaultException("Duplicate Phone Number Found");
                        }
                    }
                }
            }
            context.SaveChanges();
            return employeeModified;
        }

        public Employee Update(Employee employee)
        {
            if (employee == null)
            {
                throw new FaultException("Invalid Record");
            }
            string phoneNumber = employee.Addresses.FirstOrDefault().Phone.ToUpper();
            var isPhoneExists = context.Addresses.FirstOrDefault(x => x.Phone.ToUpper() == phoneNumber && x.EmployeeId != employee.Id);
            if (isPhoneExists == null)
            {
                context.Entry(employee).State = System.Data.EntityState.Modified;
                context.Employees.Attach(employee);
                context.SaveChanges();
                return context.Employees.FirstOrDefault(X => X.Id == employee.Id);
            }
            else
            {
                _logger.WriteException("Exception Occured :", new FaultException("Duplicate Phone Number Found"));
                throw new FaultException("Duplicate Phone Number Found");
            }                     
        }

        public Employee Get(int  employeeID)
        {
            return context.Employees.FirstOrDefault(x => x.Id == employeeID);
        }

        public List<Employee> GetAll()
        {
            return context.Employees.ToList<Employee>(); ;
        }

        public void  Delete(int employeeID)
        {
            if (context.Employees.FirstOrDefault(x => x.Id == employeeID)!=null)
            {
                context.Employees.Remove(context.Employees.FirstOrDefault(x => x.Id == employeeID));                
                context.SaveChanges();
            }
            else                
            {
                _logger.WriteException("Exception Occured :", new FaultException("No Records Found"));
                throw new FaultException("No Records Found");
            } 
        }
    }
}
