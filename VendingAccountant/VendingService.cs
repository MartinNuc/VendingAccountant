using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using VendingAccountant.VendingServerService;

namespace VendingAccountant
{
    class VendingService
    {
        public static storageCycleServiceClient getService()
        {
            var serviceClient = new VendingServerService.storageCycleServiceClient();
            serviceClient.Endpoint.Address = new EndpointAddress(@"http://" + getServerIp() + @"/storagecycle/api/StorageCycleRemoteFacade?wsdl");
            return serviceClient;
        }

        public static string getServerIp()
        {
            //return "192.168.1.2";
            Microsoft.Win32.RegistryKey registry = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("Software", true).CreateSubKey("Vending");
            var value = registry.GetValue("ServerIp");
            if (value == null)
            {
                return null;
            }
            return value.ToString();
        }
    }
}
