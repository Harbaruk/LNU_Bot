using partnerBot;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bot_Administrator.CRUD
{
    public static class TeachersCRUD
    {
        public static void Add(Teacher teacher)
        {
            string connectionstring = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=D:\\Studying\\Курсова\\LNUBot\\partnerBot\\partnerBot\\BotDB.mdf;Integrated Security=True";
            SqlConnection connect = new SqlConnection(connectionstring);

            SqlCommand cmd = new SqlCommand("INSERT INTO Teachers VALUES(N'" + teacher.Name + "',N'" + teacher.Surname
                + "',N'" + teacher.Depart + "',N'" + teacher.Descript + "',N'" + teacher.Position + "',N'" + teacher.Photo + "',N'" + teacher.Fathername +"');", connect);
            
            connect.Open();
            cmd.ExecuteNonQuery();
            connect.Close();
        }
    }
}
