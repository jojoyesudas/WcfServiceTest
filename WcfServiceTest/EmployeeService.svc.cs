using DAL.Repository;
using DevTrends.WCFDataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Unity;
using Unity.Wcf;
using WCF.Contracts;
using WcfServiceTest.Mapper;


namespace WcfService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    [ValidateDataAnnotationsBehavior]
    public class EmployeeService : IEmployeeService
    {
        IEmployeeRepository _employeeRepository;
        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<EmployeeContract> AddAsync(EmployeeContract employeeContract)
        {
            return await Task.Factory.StartNew(() => DataMapper.ToContract(_employeeRepository.Add(DataMapper.ToDomain(employeeContract))));
        }

        public async Task<EmployeeContract> UpdateAsync(EmployeeContract employeeContract)
        {
            return await Task.Factory.StartNew(() => DataMapper.ToContract(_employeeRepository.Update(DataMapper.ToDomain(employeeContract))));
        }

        public async Task DeleteAsync(int employeeId)
        {
            await Task.Factory.StartNew(() => _employeeRepository.Delete(employeeId));
        }

        public async Task<EmployeeContract> GetAsync(int employeeId)
        {
            return await Task.Factory.StartNew(() => DataMapper.ToContract(_employeeRepository.Get(employeeId)));
        }

        public async Task<List<EmployeeContract>> GetAllAsync()
        {
            return await Task.Factory.StartNew(() =>DataMapper.ToContractList(_employeeRepository.GetAll()));
             
        }
    }

    
}
