using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace WindowsFormsApp2
{
    class Baza
    {
        public static SqlConnection conn()
        {
            return new SqlConnection(@"Data Source=DESKTOP-E8MTTAK;Initial Catalog=Projekt;Integrated Security=True");
        }
    }
}
