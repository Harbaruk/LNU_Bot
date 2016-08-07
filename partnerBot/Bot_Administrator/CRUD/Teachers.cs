using partnerBot;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bot_Administrator.CRUD
{
    /// <summary>
    /// CRUD for Teachers
    /// </summary>
    public static class CRUD_Teacher
    {
        /// <summary>
        /// Paste your connection string here
        /// </summary>
        static string connectionstring = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=D:\\Studying\\Курсова\\LNUBot\\partnerBot\\partnerBot\\BotDB.mdf;Integrated Security=True";
        static SqlConnection connect = new SqlConnection(connectionstring);

        /// <summary>
        /// Add new teacher to DB
        /// </summary>
        /// <param name="teacher">Teacher you add</param>
        public static void Add(Teacher teacher)
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO Teachers VALUES(N'" + teacher.Name + "',N'" + teacher.Surname
                + "',N'" + teacher.Depart + "',N'" + teacher.Descript + "',N'" + teacher.Position + "',N'" + teacher.Photo + "',N'" + teacher.Fathername +"');", connect);
            
            connect.Open();
            cmd.ExecuteNonQuery();
            connect.Close();
        }

        /// <summary>
        /// Remove teacher from DB
        /// </summary>
        /// <param name="teacher"></param>
        public static void Delete(string teacher)
        {
            SqlCommand cmd = new SqlCommand("DELETE FROM Teachers WHERE Name = N'@name';", connect);
            cmd.Parameters.Add(new SqlParameter("@name", teacher));

            connect.Open();
            cmd.ExecuteNonQuery();
            connect.Close();
        }

        public static void Update(Dictionary<string,string> changes, Dictionary<string,string> search)
        {
            SqlCommand cmd = new SqlCommand("UPDATE Teachers Set @changes WHERE @condition", connect);
            cmd.Parameters.Add(new SqlParameter("@changes", Convertor.Convert(changes)));
            cmd.Parameters.Add(new SqlParameter("@condition", Convertor.Convert(search)));

            connect.Open();
            cmd.ExecuteNonQuery();
            connect.Close();
        }
        
    }
}
