using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Data.SqlTypes;
using EN;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DAL
{
    public static class DBComon
    {
        private static string Conm = @"Data Source=EDWIN-PC\SQLEXPRESS;Initial Catalog=ProyectoFinal;Integrated Security=True;Encrypt=False";
        public static IDbConnection Conexion()
        {
            return new SqlConnection (Conm);
        }
        public static IDbCommand ObtenerComando(string pComando, IDbConnection pCnm)
        {
            return new SqlCommand(pComando, pCnm as SqlConnection);
        }
    }
}

