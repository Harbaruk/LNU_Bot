using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace partnerBot
{
   public class ResultReport
    {
        public int ID;
        public ConversationStatus status;
        public List<string> Answers;
        public List<string> UnparsedAnswers;

        public ResultReport()
        {
            ID = 0;
            status = ConversationStatus.MainMenu;
            Answers = new List<string>();
            UnparsedAnswers = new List<string>();
        }

        public ResultReport(int _id, ConversationStatus _status)
        {
            ID = _id;
            status = _status;
            Answers = new List<string>();
            UnparsedAnswers = new List<string>();
        }
    }
}
