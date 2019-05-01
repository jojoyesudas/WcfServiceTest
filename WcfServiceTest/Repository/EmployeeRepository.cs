//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;


//namespace WcfService.Repository
//{
//    public class EmployeeRepository : IEmployeeRepository
//    {
//        public string Save(Employee ee)
//        {            
//            return "saved";
//        }

//        public string Update(Employee ee)
//        {
//            return "Updated";
//        }

//        public List<Employee> GetAll()
//        {
//            return new List<Employee>
//            {
//                new Employee{ID=1,FName="Dummy",LName="User1",Gender="M"},
//                new Employee{ID=2,FName="Dummy",LName="User2",Gender="M"},
//                new Employee{ID=3,FName="Dummy",LName="User3",Gender="M"},
//            };
//        }

//        public Employee Get(int employeeId)
//        {            
//            return new Employee { ID = 1, FName = "Jojo", LName = "X", Gender = "M" };
//        }

//        public string Delete(int employeeId)
//        {
//            return "Deleted"; ;
//        }
//    }

//    public interface IEmployeeRepository
//    {
//        string Save(Employee ee);
//        string Update(Employee ee);
//        List<Employee> GetAll();
//        Employee Get(int employeeId);
//        string Delete(int employeeId);
//    }
//}