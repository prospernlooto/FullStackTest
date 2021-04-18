using System;
using System.Configuration;

namespace DAL.GlobalCode
{
    public class GlobalSettings
    {
        public static string connection = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
    }
}
