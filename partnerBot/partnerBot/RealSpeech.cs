using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace partnerBot
{
  
    public static class RealSpeech
    {
        public static List<string> Greeting = new List<string>()
        {
            "привіт", "прівєт", "алоха", "ку", "хай", "здоров", "здоровенькі були" 
        };

        public static List<string> Deals = new List<string>()
        {
            "як справи?", "як поживаєш?", "як ти?", "як життя молоде?"
        };


        
        
        public static string GetAnswer(string message)
        {
            string res = "";
            
            return res;
        }
    }
}
