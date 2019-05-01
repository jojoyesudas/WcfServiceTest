using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WCF.Contracts;

namespace WcfServiceTest.Mapper
{
    public class DataMapper
    {
        public static DAL.DataModel.Employee ToDomain(EmployeeContract employeeContract)
        {
            if (employeeContract != null)
            {
                DAL.DataModel.Employee employee = new DAL.DataModel.Employee
                {
                    Id = employeeContract.ID,
                    FName = employeeContract.FName,
                    LName = employeeContract.LName,
                    Gender = employeeContract.Gender,
                    Addresses = new DAL.DataModel.Address[]
                {
                    new DAL.DataModel.Address
                    {
                        Id=employeeContract.Address.Id,
                        EmployeeId=employeeContract.Address.EmployeeContractId,
                        Line1=employeeContract.Address.Line1,
                        Line2=employeeContract.Address.Line2,
                        POBox=employeeContract.Address.POBox,
                        City=employeeContract.Address.City,
                        Country=employeeContract.Address.Country,
                        Email=employeeContract.Address.Email,
                        Phone=employeeContract.Address.Phone,
                    }
                }
                };
                return employee;
            }
            return null;
        }

        public static List<DAL.DataModel.Employee> ToDomainList(List<EmployeeContract> employeeContracts)
        {
            List<DAL.DataModel.Employee> lst = new List<DAL.DataModel.Employee>();
            foreach (EmployeeContract item in employeeContracts)
            {
                lst.Add(ToDomain(item));
            }
            return lst;
        }

        public static EmployeeContract ToContract(DAL.DataModel.Employee employee)
        {
            if (employee != null)
            {
                EmployeeContract employeeContract = new EmployeeContract
                {
                    ID = employee.Id,
                    FName = employee.FName,
                    LName = employee.LName,
                    Gender = employee.Gender,
                    Address = new AddressContract
                    {
                        Id = employee.Addresses.FirstOrDefault().Id,
                        EmployeeContractId=employee.Addresses.FirstOrDefault().EmployeeId,
                        Line1 = employee.Addresses.FirstOrDefault().Line1,
                        Line2 = employee.Addresses.FirstOrDefault().Line2,
                        POBox = employee.Addresses.FirstOrDefault().POBox,
                        City = employee.Addresses.FirstOrDefault().City,
                        Country = employee.Addresses.FirstOrDefault().Country,
                        Email = employee.Addresses.FirstOrDefault().Email,
                        Phone = employee.Addresses.FirstOrDefault().Phone,

                    }
                };
                return employeeContract;
            }
            return null;
        }

        public static List<EmployeeContract> ToContractList(List<DAL.DataModel.Employee> employees)
        {
            List<EmployeeContract> lst = new List<EmployeeContract>();
            foreach (DAL.DataModel.Employee item in employees)
            {
                lst.Add(ToContract(item));
            }
            return lst;
        }
    }
}