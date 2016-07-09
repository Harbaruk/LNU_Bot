using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace partnerBot
{

    public class Department
    {
        private Department(string value) { Value = value; }

        public string Value { get; set; }

        public static Department DiscreteAnalisys { get { return new Department("Дискретного аналізу та інтелектуальних систем"); } }
        public static Department InformationSystems { get { return new Department("Інформаційних систем"); } }
        public static Department MathModels { get { return new Department("Математичного моделювання соціально - економічних процесів"); } }
        public static Department ComputMathematics { get { return new Department("Обчислювальної математики"); } }
        public static Department ApliedMath { get { return new Department("Прикладної математики"); } }
        public static Department Programming { get { return new Department("Програмування"); } }
        public static Department OptimalTheoryProcesses { get { return new Department("Теорії оптимальних процесів"); }}

        public static List<string> AllDepartments()
        {
            List<string> res = new List<string>();
            res.Add(DiscreteAnalisys.Value);
            res.Add(InformationSystems.Value);
            res.Add(MathModels.Value);
            res.Add(ComputMathematics.Value);
            res.Add(ApliedMath.Value);
            res.Add(Programming.Value);
            res.Add(OptimalTheoryProcesses.Value);

            return res;
        }
    }



    public class Teacher
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Depart { get; set; }
        public string Descript { get; set; }
        public string Position { get; set; }
        public string Photo { get; set; }
        public string Fathername { get; set; }

        public Teacher (string aName, string aSurname, string aDep, string aDes, string aPos, string aPhoto, string aFather)
        {
            Name = aName;
            Surname = aSurname;
            Depart = aDep;
            Descript = aDes;
            Position = aPos;
            Photo = aPhoto;
            Fathername = aFather;
        }

        public Teacher()
        {
            Name = string.Empty;
            Surname = string.Empty;
            Depart = string.Empty;
            Descript = string.Empty;
            Position = string.Empty;
            Photo = string.Empty;
            Fathername = string.Empty;
        }

        public static List<Teacher> GetTeacher (string depart)
        {
            List<Teacher> res = new List<Teacher>();
            string sqlquery = "SELECT * FROM Teachers Where department = N'"+depart.ToLower()+"'";
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
                   res.Add(new Teacher(read[1].ToString(),read[2].ToString(), read[3].ToString(), read[4].ToString(), 
                       read[5].ToString(),
                       "C:\\Users\\Elfarus\\Desktop\\Курсова\\LNUBot\\partnerBot\\Teacher\\"
                       +Transliter.GetTranslit((read[6].ToString().ToLower())),
                       read[7].ToString()));

                    if (read[6] == null || read[6].ToString() == "") res.Last().Photo = null;
                    
                }
            }

            return res;
        }
    }


}
