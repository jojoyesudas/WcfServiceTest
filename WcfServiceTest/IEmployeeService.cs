
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;
using WCF.Contracts;

namespace WcfService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IEmployeeService
    {       
        [OperationContract]
        [FaultContract(typeof(FaultException))]
        Task<EmployeeContract> AddAsync(EmployeeContract employeeContract);

        [OperationContract]
        [FaultContract(typeof(FaultException))]
        Task<EmployeeContract> UpdateAsync(EmployeeContract employeeContract);

        [OperationContract]
        Task DeleteAsync(int employeeId);

        [OperationContract]
        Task<EmployeeContract> GetAsync(int employeeId); 

        [OperationContract]
        Task<List<EmployeeContract>> GetAllAsync();        
    }
}
