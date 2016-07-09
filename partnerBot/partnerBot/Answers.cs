using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taikandi.Telebot.Types;
using Taikandi.Telebot;
using partnerBot;

namespace PartnerBot
{
    public static class Answers
    {
        public struct BotAnswers
        {
            public static List<string> MainMenu()
            {
                List<string> res = new List<string>();
                res.Add("Хочу дізнатись розклад пар");
                res.Add("Хочу дізнатись склад кафедр");
                res.Add("Хочу переглянути список заходів");
                res.Add("Хочу дати ідею самоврядуванню");
                res.Add("Просто поговорити");

                return res;
            }

            public static List<string> ChoiceTable()
            {
                List<string> res = new List<string>();
                res.Add("Групи");
                res.Add("Курсу");

                return res;
            }

            public static List<string> TypeOfTable()
            {
                List<string> res = new List<string>();
                res.Add("Вивести на екран");
                res.Add("Надіслати файлом");

                return res;
            }

            public static List<string> ChoiceCourse()
            {
                List<string> res = new List<string>();
                res.Add("Перший");
                res.Add("Другий");
                res.Add("Третій");
                res.Add("Четвертий");
                res.Add("П'ятий");

                return res;
            }

            #region Not important
            //    public const string A11_bReady = "Добавьте меня в контакты (@alive2059) и опишите в кратце, какие функции вы хотите поручить боту." +
            //        "\nЧтобы вернуться к началу нажмите /start";

            //    public const string A3_bCapabilities = "Боты могут брать любую доступную"+
            //        " инфрмацию (данные о товарах с сайта, ингридиентах блюд и т.д.) и обрабатывать их по заданной логике."+
            //        " А благодаря нашему искусственному интеллекту, общение бота с человеком происходит в максимально удобной форме.";
            //    public const string A3_bPrice = "Разработке бота сопоставима по ценам с разработкой веб-сайтов и"+
            //        " значительно дешевле разработки приложений под мобильные устройства.\n"+
            //        "Учитывая, новизну темы и туманные перспективы развития отрасли ботов, мы предлагаем формат подписки."+
            //        " То есть, мы делаем бота, а вы подписываетесь на его использование.\n"+
            //        "Такой формат позволит проверить пользу бота с небольшими вложениями.";
            //    public const string A3_bTime = "Разработка бота занимает в среднем около месяца.";

            //    public const string A10_0 = "У нас есть бот, который уже делает заказ еды";
            //    public const string A10_1 = "У нас есть бот, который уже делает заказ билетов";
            //    public const string A10_2 = "У нас есть бот, который помагает искать работу";
            //    public const string A10_3 = "У нас есть бот, который уже делает заказ такси";
            //    public const string A10_4 = "Список наших ботов:     \n\n";

            //    public const string A0_bus = "Мы готовы помочь с бизнесом. Что интересует?";

            //}
            public struct ClientAnswers
            {

                public const string L0_developer = "Хочу писать ботов";
                public const string L0_promote = "Хочу продвигать ботов";
                public const string L0_business = "Хочу бота для своего бизнеса";
                public const string L0_ideas = "У меня есть идеи";

                public const string L1_haveBots = "У меня уже есть бот(-ы)";
                public const string L1_haveSkills = "У меня есть необоходимые навыки, чтоб писать ботов";
                public const string L1_learn = "Хочу научиться писать ботов";

                public const string L3_bIs = "У меня есть бизнес";
                public const string L3_bCapabilities = "Я хочу узнать, что могут боты";
                public const string L3_bPrice = "Сколько стоит бот";
                public const string L3_bTime = "Сколько времени занмиает разработка";

                public const string L11_bReady = "Я готов. Что делать?";
                public const string L11_bBack = "Назад";
            }

            //public static List<string> Messenger()
            //{
            //    List<string> messenger = new List<string>();
            //    messenger.Add("Telegram");
            //    messenger.Add("Skype");
            //    messenger.Add("Slack");
            //    messenger.Add("Viber");
            //    return messenger;
            //}

            //public static List<string> Language()
            //{
            //    List<string> language = new List<string>();
            //    language.Add("C#");
            //    language.Add("Python");
            //    language.Add("Node");
            //    language.Add("Java");
            //    language.Add("C++");
            //    return language;
            //}

            //public static List<string> Occupation()
            //{
            //    List<string> occupation = new List<string>();
            //    occupation.Add("Заказ еды");
            //    occupation.Add("Заказ билетов");
            //    occupation.Add("Поиск работы");
            //    occupation.Add("Заказ такси");
            //    occupation.Add("Другое");
            //    return occupation;
            //}

            //public static List<string> Promoter()
            //{
            //    List<string> promoter = new List<string>();
            //    promoter.Add("Я - менеджер по продажам");
            //    promoter.Add("Я - маркетолог");
            //    promoter.Add("Я - сммщик");
            //    return promoter;
            //}
            #endregion

        }

        public struct UserAnswers
        {
            public const string Schedule = "Хочу дізнатись розклад пар";
            public const string Department = "Хочу дізнатись склад кафедр";
            public const string Activities = "Хочу переглянути список заходів";
            public const string Ideas = "Хочу дати ідею самоврядуванню";
            public const string Other = "Просто поговорити";

            public const string Group = "Групи";
            public const string Course = "Курсу";

            public const string Send = "Надіслати файлом";
            public const string Show = "Вивести на екран";
            
        }

        public static KeyboardButton[][] ListToMatrixVertical(List<string> input)
        {
            KeyboardButton[][] result;

            List<KeyboardButton[]> tabRows = new List<KeyboardButton[]>();
            foreach (string item in input)
            { tabRows.Add(new KeyboardButton[] { new KeyboardButton(item) }); }
            result = tabRows.ToArray();

            return result;
        }

        public static KeyboardButton[][] ListToMatrixHorizontal(List<string> input)
        {
            KeyboardButton[][] result;
            KeyboardButton[] temp = new KeyboardButton[input.Count];
            for (int i = 0; i < temp.Length; i++)
            {
                temp[i] = new KeyboardButton(input[i]);
            }
            
            result = new KeyboardButton[][]
            {
                    temp
            };

            return result;
        }

        // формирование сообщения отчётов

        public static string GenerateReport(Update update, List<string> Answers, List<string> UnparsedAnswers, int status)
        {
            string result = update.Message.Date.Year + "/" + update.Message.Date.Month + "/" + update.Message.Date.Day + "  " + update.Message.Date.Hour + ":" + update.Message.Date.Minute + "\n";
            result += update.Message.From.FirstName + " " + update.Message.From.LastName + " (" + update.Message.From.Id + ") \n";


            if (update.Message.Contact != null)
            {
                result += "Номер :" + update.Message.Contact;
            }

            if (update.Message.From.Username != null && update.Message.From.Username.Length > 0)
                result += "@" + update.Message.From.Username + "\n";
            switch (status)
            {
                case -10:
                    result += "має цікаві ідеї\n";
                    break;

                case -11:
                    result += "Есть готовые боты\n";
                    break;

                case -12:
                    result += "Есть навыки\n";
                    break;

                case -13:
                    result += "Хочет учиться\n";
                    break;

                case -14:
                    result += "Хочет продвигать\n";
                    break;

                case -15:
                    result += "Хочет бота для бизнеса\n";
                    break;
            }

            if (Answers.Count > 0)
            {
                foreach (var item in Answers)
                {
                    result += item + "\n";
                }
            }

            if (UnparsedAnswers.Count > 0)
            {
                result += "---- Кроме того, он сообщил, что: \n";
                foreach (var item in UnparsedAnswers)
                {
                    result += "- " + item + "\n";
                }
            }


            return result;
        }

        public static ReplyKeyboardMarkup replyMarkups(ConversationStatus status, string dep = "")
        {
            ReplyKeyboardMarkup replyMarkup = new ReplyKeyboardMarkup(false);
            switch (status)
            {
                case ConversationStatus.MainMenu:
                    replyMarkup = new ReplyKeyboardMarkup
                    {
                        Keyboard = ListToMatrixVertical(BotAnswers.MainMenu()),
                        OneTimeKeyboard = true,
                        ResizeKeyboard = true
                    };
                    break;

                case ConversationStatus.Schedule:
                    replyMarkup = new ReplyKeyboardMarkup
                    {
                        Keyboard = ListToMatrixHorizontal(BotAnswers.ChoiceTable()),
                        OneTimeKeyboard = true,
                        ResizeKeyboard = true
                    };
                    break;

                case ConversationStatus.Department:
                    
                    replyMarkup = new ReplyKeyboardMarkup
                    {
                        Keyboard = ListToMatrixVertical(Department.AllDepartments()),
                        OneTimeKeyboard = true,
                        ResizeKeyboard = true
                    };
                    break;

                case ConversationStatus.Teachers:
                    List<string> res = new List<string>();
                   List<Teacher> temp = Teacher.GetTeacher(dep);
                    foreach( var t in temp)
                    {
                        res.Add(t.Surname);
                    }
                    replyMarkup = new ReplyKeyboardMarkup
                    {
                        Keyboard = ListToMatrixVertical(res),
                        OneTimeKeyboard = true,
                        ResizeKeyboard = true
                    };

                    break;
                case ConversationStatus.Course:
                    replyMarkup = new ReplyKeyboardMarkup
                    {
                        Keyboard = ListToMatrixHorizontal(BotAnswers.ChoiceCourse()),
                        OneTimeKeyboard = true,
                        ResizeKeyboard = true
                    };
                    break;

                case ConversationStatus.Activities:
                    replyMarkup = new ReplyKeyboardMarkup
                    {
                        Keyboard = ListToMatrixVertical(Activities.GetActivitiesName(Activities.GetActivities())),
                        OneTimeKeyboard = true,
                        ResizeKeyboard = true
                    };
                    break;

            }
            if (replyMarkup.Keyboard != null)
            {
                return replyMarkup;
            }
            else return null;
        }

    }
}
