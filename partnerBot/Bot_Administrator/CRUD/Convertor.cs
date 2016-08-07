using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bot_Administrator.CRUD
{
    public static class Convertor
    {
        public static string Convert(Dictionary<string,string> arr)
        {
            string res = "";
            foreach(var t in arr)
            {
                res += t.Key + "='" + t.Value + "',";
            }
            res = res.Remove(res.Length-1);
            res += ";";

            return res;
        }
    }
}
