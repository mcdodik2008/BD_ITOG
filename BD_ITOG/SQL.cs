using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BD_ITOG
{
    public static class SQL
    {
        public static List<List<string>> ReadSql(string sqlExpression)
        {
            string connectionString = @"Data Source=KOMPYTER-ALEKSE\SQLEXPRESS;Initial Catalog=InSy;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            var command = new SqlCommand(sqlExpression, connection);
            var reader = command.ExecuteReader();
            
            var table = new List<List<string>>();
            var row = new List<string>();
            int nRows = reader.FieldCount;

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    for (int i = 0; i < nRows; i++)
                    {
                        row.Add(reader.GetValue(i).ToString());
                    }
                    table.Add(row);
                    row = new List<string>();
                }
            }
            reader.Close();
            connection.Close();
            return table;
        }
    }
}
