using partnerBot;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Taikandi.Telebot;
using Taikandi.Telebot.Types;

namespace partnerBot
{
    public class Links
    {
        public const string connectionstring = "Data Source=(LocalDB)/v12.0;AttachDbFilename=C:/Users/Elfarus/Desktop/Курсова/LNUBot/partnerBot/partnerBot/BotDB.mdf;Integrated Security=True";
        

        private Links(string value) { Value = value; }

        public string Value { get; set; }
        

        public static string GetLink(string group)
        {
            if (group == "п'ятий") group = "пятий";
            string sqlquery = "SELECT link FROM Links WHERE keylink = N'"+group+"'";
            string value = "";
            string connectionstring = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Elfarus\\Desktop\\Курсова\\LNUBot\\partnerBot\\partnerBot\\BotDB.mdf;Integrated Security=True";
            SqlConnection connect = new SqlConnection(connectionstring);
            

            using (SqlConnection connection =
           new SqlConnection(connectionstring))
            {
                
                SqlCommand com = new SqlCommand(sqlquery, connect);
                connect.Open();
                SqlDataReader res = com.ExecuteReader();
                while (res.Read())
                {
                    value = res[0].ToString();
                }
            }

            return "https://drive.google.com/uc?export=download&id=" + value;
        }
    }
}
