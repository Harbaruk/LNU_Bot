using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace partnerBot
{
    public enum ConversationStatus
    {
        None = -1, MainMenu, Schedule, Group, GroupChoiced, Course, Faculty, Show, Send,
        Department, Teachers, Activities, Report, Other
    }
}
