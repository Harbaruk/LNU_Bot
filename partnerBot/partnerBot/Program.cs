using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Newtonsoft.Json.Linq;
using Taikandi.Telebot;
using Taikandi.Telebot.Types;
using partnerBot;

namespace PartnerBot
{
    class Program
    {
        static void Main(string[] args)
        {
          Run().Wait();
        }


        static async Task Run()
        {
            const string token = "209885283:AAGVv082k-i-qWkz6NhJkkbbiXkvc6vIlLI"; // token
            var Bot = new Telebot(token);
            var me = await Bot.GetMeAsync(); // test access
            

            List<ResultReport> UserReport = new List<ResultReport>();
            ConversationStatus status = ConversationStatus.None;

            List<string> Answers = new List<string>();
            List<string> UnparsedAnswers = new List<string>();
            List<Teacher> AllTeachers = new List<Teacher>();
            

            int writeUnparsed;

            Console.WriteLine("Hello my name is {0}", me.Username);

            var offset = 0;


            while (true)
            {
                var updates = await Bot.GetUpdatesAsync(offset); // get updates starting from offset

                foreach (var update in updates)
                {
                    if (update.Message.Type == MessageType.Text)
                    {
                        Console.WriteLine(update.Message.Text);
                        writeUnparsed = 1;
                        await Bot.SendChatActionAsync(update.Message.Chat.Id, ChatAction.Typing);
                        await Task.Delay(100);

                        // /start
                        if (update.Message.Text.ToLower() == "/start")
                        {
                            status = ConversationStatus.MainMenu;
                            
                            if (!UserReport.Exists(x => x.ID == (int)update.Message.Chat.Id))
                            {
                                UserReport.Add(new ResultReport((int)update.Message.Chat.Id, status));
                                await Bot.SendMessageAsync(update.Message.Chat.Id, "Привіт! Чим я можу допомогти?",
                                   replyMarkup: PartnerBot.Answers.replyMarkups(status));
                            }
                            else
                            {
                                UserReport.Find(x => x.ID == (int)update.Message.Chat.Id).status = status;
                                await Bot.SendMessageAsync(update.Message.Chat.Id, "Що ще тебе цікавить?",
                                   replyMarkup: PartnerBot.Answers.replyMarkups(status));
                            }

                            Answers.Clear();
                            UnparsedAnswers.Clear();
                            writeUnparsed = 0;
                        }
                        else
                        {
                            if (!UserReport.Exists(x => x.ID == (int)update.Message.Chat.Id))
                            {
                                UserReport.Add(new ResultReport((int)update.Message.Chat.Id, status));
                            }


                            status = UserReport.Find(x => x.ID == (int)update.Message.Chat.Id).status;

                            switch (status)
                            {
                                case ConversationStatus.MainMenu:
                                    writeUnparsed = 0;
                                    if (update.Message.Text == PartnerBot.Answers.UserAnswers.Schedule)
                                    {
                                        status = ConversationStatus.Schedule;

                                        UserReport.Find(x => x.ID == (int)update.Message.Chat.Id).status = status;


                                        await Bot.SendMessageAsync(update.Message.Chat.Id,
                                                "Який саме розклад тобі потрібно?",
                                                replyMarkup: PartnerBot.Answers.replyMarkups(status));
                                    }
                                    else if (update.Message.Text == PartnerBot.Answers.UserAnswers.Department)
                                    {
                                        status = ConversationStatus.Department;

                                        UserReport.Find(x => x.ID == (int)update.Message.Chat.Id).status = status;

                                        await Bot.SendMessageAsync(update.Message.Chat.Id, "Якої саме кафедри?",
                                            replyMarkup: PartnerBot.Answers.replyMarkups(status));
                                    }

                                    else if (update.Message.Text == PartnerBot.Answers.UserAnswers.Activities)
                                    {
                                        status = ConversationStatus.Activities;
                                        
                                        UserReport.Find(x => x.ID == (int)update.Message.Chat.Id).status = status;

                                        await Bot.SendMessageAsync(update.Message.Chat.Id, "Зараз найду");
                                        Bot.SendChatActionAsync(update.Message.Chat.Id, ChatAction.FindLocation);
                                        await Bot.SendMessageAsync(update.Message.Chat.Id,
                                            "Ось список заходів на цей семестр \n Список може змінюватись",
                                            replyMarkup: PartnerBot.Answers.replyMarkups(status));
                                    }

                                    else if (update.Message.Text == PartnerBot.Answers.UserAnswers.Ideas)
                                    {
                                        status = ConversationStatus.Report;

                                        UserReport.Find(x => x.ID == (int)update.Message.Chat.Id).status = status;
                                        
                                        await Bot.SendMessageAsync(update.Message.Chat.Id,
                                            "Пишіть мені @hry_harbaruk, обговоримо деталі /start");
                                    }

                                    else if (update.Message.Text == PartnerBot.Answers.UserAnswers.Other)
                                    {
                                        Random rand = new Random();
                                        await Bot.SendMessageAsync(update.Message.Chat.Id, "Я ще не вмію говорити добре, але ось тобі єнотик");
                                        await Bot.SendPhotoFromFileAsync(update.Message.Chat.Id,
                                            "C:\\Users\\Elfarus\\Desktop\\Курсова\\LNUBot\\partnerBot\\Raccoon\\"
                                            + rand.Next(1, 8) + ".jpg", replyMarkup: PartnerBot.Answers.replyMarkups(ConversationStatus.MainMenu));


                                        // await Bot.SendMessageAsync(update.Message.Chat.Id, RealSpeech.Greeting[rand.Next(RealSpeech.Greeting.Count - 1)]);
                                    }
                                    else writeUnparsed = 1;
                                    break;

                                case ConversationStatus.Schedule:
                                    writeUnparsed = 0;

                                    if(update.Message.Text == PartnerBot.Answers.UserAnswers.Group)
                                    {
                                        status = ConversationStatus.Group;
                                        UserReport.Find(x => x.ID == (int)update.Message.Chat.Id).status = status;
                                        Bot.SendChatActionAsync((int)update.Message.Chat.Id, ChatAction.Typing);
                                        await Bot.SendMessageAsync(update.Message.Chat.Id, "Введіть назву групи (наприклад пмі-22)");
                                    }

                                    else if (update.Message.Text == PartnerBot.Answers.UserAnswers.Course)
                                    {
                                        status = ConversationStatus.Course;
                                        UserReport.Find(x => x.ID == (int)update.Message.Chat.Id).status = status;

                                        await Bot.SendMessageAsync(update.Message.Chat.Id, "Який ти курс?", replyMarkup:
                                            PartnerBot.Answers.replyMarkups(ConversationStatus.Course));
                                    }
                                    
                                break;

                                case ConversationStatus.Group:
                                    status = ConversationStatus.Report;
                                    UserReport.Find(x => x.ID == (int)update.Message.Chat.Id).status = status;
                                    Bot.SendChatActionAsync((int)update.Message.Chat.Id, ChatAction.UploadDocument);
                                   await Bot.SendMessageAsync((int)update.Message.Chat.Id, Links.GetLink(update.Message.Text)
                                       + "\n\n Для продовження натисніть /start",parseMode: ParseMode.Markdown);
                                    break;

                                case ConversationStatus.Course:
                                    status = ConversationStatus.Report;
                                    UserReport.Find(x => x.ID == (int)update.Message.Chat.Id).status = status;
                                    await Bot.SendMessageAsync((int)update.Message.Chat.Id, Links.GetLink(update.Message.Text.ToLower()));
                                    break;

                                case ConversationStatus.Department:
                                    status = ConversationStatus.Teachers;
                                    UserReport.Find(x => x.ID == (int)update.Message.Chat.Id).status = status;

                                    AllTeachers = Teacher.GetTeacher(update.Message.Text.ToLower());
                                    await Bot.SendMessageAsync((int)update.Message.Chat.Id, "Про якого викладача ви хочете знати більше?",
                                        replyMarkup: PartnerBot.Answers.replyMarkups(ConversationStatus.Teachers,update.Message.Text.ToLower()));
                                    break;

                                case ConversationStatus.Teachers:
                                    // = ConversationStatus.Report;
                                    UserReport.Find(x => x.ID == (int)update.Message.Chat.Id).status = status;
                                    string re = update.Message.Text;
                                    Teacher temp = AllTeachers.Find(x => x.Surname == update.Message.Text);
                                    if (temp.Photo != null)
                                    {
                                        await Bot.SendPhotoFromFileAsync(update.Message.Chat.Id, temp.Photo);
                                    }

                                    await Bot.SendMessageAsync(update.Message.Chat.Id,"*"+ temp.Name + " " + temp.Fathername + " " + temp.Surname +
                                        "*\n" + temp.Position + "\n" + temp.Descript,parseMode: ParseMode.Markdown);
                                    
                                    break;

                                case ConversationStatus.Activities:
                                    List<Activities> list = Activities.GetActivities();
                                    string name = update.Message.Text.ToLower();
                                    Activities current = list.Find(x => x.Name.ToLower() == name);
                                    await Bot.SendMessageAsync(update.Message.Chat.Id, "*" + current.Name + "*\n\n"
                                        + current.Description + "\n\n" + "*Час початку:* " + current.Start.Day + "."
                                        + current.Start.Month + " о " + current.Start.Hour +  " год\n"+"*Місце проведення:* " +
                                        current.Place,
                                        parseMode: ParseMode.Markdown);
                                    break;

                                case ConversationStatus.Report:
                                    status = ConversationStatus.None;
                                    UserReport.Find(x => x.ID == (int)update.Message.Chat.Id).status = status;
                                    break;
                            }
                            
                            if (writeUnparsed > 0)
                                    {
                                        UserReport.Find(x => x.ID == update.Message.Chat.Id).UnparsedAnswers.Add("<" +
                                            status.ToString() + "> " + update.Message.Text);
                                    }
                                    Console.WriteLine("- " + update.Message.From.FirstName + " " + update.Message.From.LastName +
                                        " (" + update.Message.From.Id + ") - " + update.Message.Date.Day + "."
                                        + update.Message.Date.Month + " (" + (update.Message.Date.Hour + 3)
                                        + ":" + update.Message.Date.Minute + ":" + update.Message.Date.Second + ") "
                                        + update.Message.Text);

                                    if ((int)status < -10)
                                    {
                                        ResultReport temp = UserReport.Find(x => x.ID == (int)update.Message.Chat.Id);

                                        string message = PartnerBot.Answers.GenerateReport(update, temp.Answers, temp.UnparsedAnswers, (int)status);
                                        await Bot.SendMessageAsync("215796607", message); //сюда вставить user id менеджера
                                                                                          //statusList.Remove((int)update.Message.From.Id);    
                                        UserReport.RemoveAll(x => x.ID == (int)update.Message.From.Id);
                                        UnparsedAnswers.Clear();
                                        writeUnparsed = 0;
                                    }
                            }

                            offset = (int)update.Id + 1;
                        }
                    }
                }
            }
        }
    }
