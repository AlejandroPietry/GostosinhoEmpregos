using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace Test
{
    public static class Constants
    {
        public static string Conn_DB = ConfigurationManager.ConnectionStrings["master"].ConnectionString;
    }
}
