using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Configuration;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace DL
{
    public class Conexion
    {
        public static String Cadena()
        {
            return ConfigurationManager.ConnectionStrings["UEstebanApesa"].ConnectionString.ToString();
        }
    }
}
