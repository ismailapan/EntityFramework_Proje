using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace EntityProjeDb
{
    internal class Class1
    {
        public SqlConnection Connection()
        {
            SqlConnection baglan = new SqlConnection("Data Source=LAPTOP-9IICM93V\\SQLEXPRESS;Initial Catalog=DbEntityUrun;Integrated Security=True");
            baglan.Open();
            return baglan;
        }
    }
}
