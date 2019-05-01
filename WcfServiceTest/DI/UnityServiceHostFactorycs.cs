using DAL.Repository;
using System;
using System.ServiceModel;
using System.ServiceModel.Activation;
using Unity;
using Unity.Wcf;
using WcfService;



namespace WcfServiceTest.DI
{
    public class UnityServiceHostFactory : ServiceHostFactory
    {
        protected override ServiceHost CreateServiceHost(
                                          Type serviceType, Uri[] baseAddresses)
        {
            UnityContainer unity = new UnityContainer();
            UnityServiceHost host = new UnityServiceHost(unity, serviceType, baseAddresses);

            //configure container
            unity.RegisterType<IEmployeeRepository, EmployeeRepository>();
            unity.RegisterType<IEmployeeService, EmployeeService>();

            return host;
        }
    }
}