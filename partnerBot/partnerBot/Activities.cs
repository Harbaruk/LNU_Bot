using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace partnerBot
{
    public class Activities
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Start { get; set; }
        public string Place { get; set; }

        public Activities(string aName, string aDes, string aStart, string aPlace)
        {
            Name = aName;
            Description = aDes;
            Start = DateTime.Parse(aStart);
            Place = aPlace;
        }

        public static List<Activities> GetActivities()
        {
            List<Activities> res = new List<Activities>();
            string sqlquery = "SELECT * FROM Activities";
            string connectionstring = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Elfarus\\Desktop\\Курсова\\LNUBot\\partnerBot\\partnerBot\\BotDB.mdf;Integrated Security=True";
            SqlConnection connect = new SqlConnection(connectionstring);


            using (SqlConnection connection =
           new SqlConnection(connectionstring))
            {
                SqlCommand com = new SqlCommand(sqlquery, connect);
                connect.Open();
                SqlDataReader read = com.ExecuteReader();

                while (read.Read())
                {
                    res.Add(new Activities(read[1].ToString(), read[2].ToString(), read[3].ToString(),read[4].ToString()));
                }
            }

            return res;
        }

        public static List<string> GetActivitiesName(List<Activities> a)
        {
            List<string> res = new List<string>();
            foreach(var t in a)
            {
                res.Add(t.Name);
            }

            return res;
        }
    }
}
