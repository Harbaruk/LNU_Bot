using partnerBot;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bot_Administrator.CRUD
{
    public static class CRUD_Activities
    {
        static string connectionstring = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=D:\\Studying\\Курсова\\LNUBot\\partnerBot\\partnerBot\\BotDB.mdf;Integrated Security=True";
        static SqlConnection connect = new SqlConnection(connectionstring);

        public static void Add(Activities active)
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO Activities VALUES(N'" + active.Name + "',N'" + active.Faculty
                + "',N'" + active.Description + "',N'" + active.Start + "',N'" + active.Place + "');", connect);

            connect.Open();
            cmd.ExecuteNonQuery();
            connect.Close();
        }

        public static void Delete (string active)
        {
            SqlCommand cmd = new SqlCommand("DELETE FROM Activities WHERE Name = N'@name';", connect);
            cmd.Parameters.Add(new SqlParameter("@name", active));

            connect.Open();
            cmd.ExecuteNonQuery();
            connect.Close();
        }
    }
}
