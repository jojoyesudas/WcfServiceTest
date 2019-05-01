using DAL.DataModel;
using DAL.Repository;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using WCF.Contracts;
using WcfServiceTest.Mapper;


namespace WcfService.Test
{     
    public class EmployeeServiceTest
    {

        [TestCase]
        public void IsAnyRecords_AlreadyExists_inDB()
        {
            //Arrange
            List<Employee> lst = new List<Employee>
            {
                new Employee{Id=1,FName="Test1",LName="User1",Gender="M",Addresses=new List<Address>{
                    new Address{
                        Id=1,EmployeeId=1,Line1="Address11",Line2="Address12",POBox="POBox",City="City",Country="Country",Email="abcdefg1@test.com",Phone="+11-1111-111-111"
                    }}},
                     new Employee{Id=2,FName="Test2",LName="User2",Gender="M",Addresses=new List<Address>{
                    new Address{
                        Id=2,EmployeeId=2,Line1="Address21",Line2="Address22",POBox="POBox",City="City",Country="Country",Email="abcdefg2@test.com",Phone="+22-2222-222-222"
                    }}},
                     new Employee{Id=3,FName="Test3",LName="User3",Gender="M",Addresses=new List<Address>{
                    new Address{
                        Id=3,EmployeeId=3,Line1="Address31",Line2="Address32",POBox="POBox",City="City",Country="Country",Email="abcdefg3@test.com",Phone="+33-3333-333-333"
                    }}}
            };           
            Mock<IEmployeeRepository> employeeRepository = new Mock<IEmployeeRepository>();
            employeeRepository.Setup(x => x.GetAll()).Returns(lst);            
            EmployeeService service = new EmployeeService(employeeRepository.Object);
            ////ACT            
            Task<List<EmployeeContract>> result = service.GetAllAsync();
            result.Wait();
            //Assert
            Assert.Greater(result.Result.Count, 0);
        }

        [TestCase(1)]
        [TestCase(2)]
        public void IsEmployee_WithSpecificIDExists_inDB(int  empID)
        {
            //Arrange    
            Employee emp = new Employee
            {
                Id = empID,
                FName = "Test1",
                LName = "User1",
                Gender = "M",
                Addresses = new List<Address>{
                    new Address{
                        Id=empID,EmployeeId=empID,Line1="Address11",Line2="Address12",POBox="POBox",City="City",Country="Country",Email="abcdefg1@test.com",Phone="+11-1111-111-111"
                    }}
            };                    
            Mock<IEmployeeRepository> employeeRepository = new Mock<IEmployeeRepository>();
            employeeRepository.Setup(x => x.Get(empID)).Returns(emp);
            EmployeeService service = new EmployeeService(employeeRepository.Object);
            ////ACT            
            Task<EmployeeContract> result = service.GetAsync(empID);
            result.Wait();
            //Assert
            Assert.AreEqual(result.Result.ID, empID);
        }

        [TestCase]
        public void Add_NewEmployeeContract_inDB()
        {
            //Arrange            
            EmployeeContract employeeContract = new EmployeeContract
            {
                FName = "Test1",
                LName = "User1",
                Gender = "M",
                Address = new AddressContract {
                Line1="Address11",
                Line2 = "Address12",
                POBox = "POBox",
                City = "City",
                Country = "Country",
                Email = "abcdefg1@test.com",
                Phone = "+11-1111-111-111"
                }
            };
            Employee emp = new Employee
            {
                Id = 1,
                FName = "Test1",
                LName = "User1",
                Gender = "M",
                Addresses = new List<Address>{
                    new Address{
                        Id=1,EmployeeId=1,Line1="Address11",Line2="Address12",POBox="POBox",City="City",Country="Country",Email="abcdefg1@test.com",Phone="+11-1111-111-111"
                    }}
            };
            Mock<IEmployeeRepository> employeeRepository = new Mock<IEmployeeRepository>();
            employeeRepository.Setup(x => x.Add(It.IsAny<Employee>())).Returns(emp);
            EmployeeService service = new EmployeeService(employeeRepository.Object);
            ////ACT            
            Task<EmployeeContract> result = service.AddAsync(employeeContract);
            result.Wait();
            //Assert
            Assert.NotNull(result.Result);
        }       

        [TestCase]
        public void Update_ExistingEmployeeContract_inDB()
        {
            //Arrange            
            EmployeeContract employeeContract = new EmployeeContract
            {
                ID=2,
                FName = "Test2",
                LName = "User2",
                Gender = "M",
                Address = new AddressContract
                {
                    Id = 2,
                    EmployeeContractId = 2,
                    Line1 = "Address211",
                    Line2 = "Address212",
                    POBox = "POBox",
                    City = "City",
                    Country = "Country",
                    Email = "abcdefg1@test.com",
                    Phone = "+22-2222-222-222"
                }
            };            
            List<Employee> lst = new List<Employee>
            {
                new Employee{Id=1,FName="Test1",LName="User1",Gender="M",Addresses=new List<Address>{
                    new Address{
                        Id=1,EmployeeId=1,Line1="Address11",Line2="Address12",POBox="POBox",City="City",Country="Country",Email="abcdefg1@test.com",Phone="+11-1111-111-111"
                    }}},
                     new Employee{Id=2,FName="Test2",LName="User2",Gender="M",Addresses=new List<Address>{
                    new Address{
                        Id=2,EmployeeId=2,Line1="Address21",Line2="Address22",POBox="POBox",City="City",Country="Country",Email="abcdefg2@test.com",Phone="+22-2222-222-222"
                    }}},
                     new Employee{Id=3,FName="Test3",LName="User3",Gender="M",Addresses=new List<Address>{
                    new Address{
                        Id=3,EmployeeId=3,Line1="Address31",Line2="Address32",POBox="POBox",City="City",Country="Country",Email="abcdefg3@test.com",Phone="+33-3333-333-333"
                    }}}
            };
            //Arrange
            Mock<IEmployeeRepository> employeeRepository = new Mock<IEmployeeRepository>();
            employeeRepository.Setup(x => x.GetAll()).Returns(lst);            
            EmployeeService service = new EmployeeService(employeeRepository.Object);
            ////ACT            
            Task<EmployeeContract> result = service.UpdateAsync(employeeContract);
            result.Wait();
            //Assert
            Assert.Null(result.Result);
        }        
    }
   
}
