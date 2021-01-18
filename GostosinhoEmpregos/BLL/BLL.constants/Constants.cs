using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;

namespace GostosinhoEmpregos.BLL.BLL.constants
{
    public static class Constants
    {
        public static string Conn_DB = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=master;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";//ConfigurationManager.ConnectionStrings["master"].ConnectionString;
    }
}
