using System;
using System.Linq;
using System.Threading.Tasks;
using AChat_Finaly_.Controllers;
using AChat_Finaly_.Models;
using HtmlAgilityPack;
using Microsoft.AspNet.SignalR;

namespace AChat_Finaly_.Hubs
{
    public class ChatHub : Hub
    {
        public void Send(string name, string message, int id, string pass)
        {
            name = Strip(name);
            message = Strip(message);
            pass = Strip(pass);
            id = int.Parse(Strip(id.ToString()));
            if (message.Length == 0)
                return;

            
            if (message.StartsWith("/"))
            {
                var userRole = IsCorrectUser(name, pass);
                #region Commands without DB use
                #region /info
                if (message.StartsWith("/info"))
                {
                    if (userRole == "admin")
                    {
                        Clients.Caller.showInfo(1);
                        return;
                    }
                    Clients.Caller.showInfo(0);
                    return;
                }
                #endregion
                #region  /w  - whisper
                if (message.StartsWith("/w ") || message.StartsWith("/W "))
                {
                    var taker = message.Split(' ')[1];
                    if(taker == name)
                    {
                        Clients.Caller.addLoggedMessageToPage("<li><i>Why did you whispering to yourself? Are you lonely?</i></li>");
                        return;
                    }
                    message = message.Substring(3 + taker.Length);
                    var message1 = "You whispered to <strong>" + taker + "</strong> that: <strong><i>" + message + "</i></strong>";
                    var message2 = "User <strong>" + name + "</strong> whispers you: <strong><i>" + message + "</i></strong>";
                    Clients.Caller.addWhisper(message1);
                    Clients.Group(taker.ToString()).addWhisper(message2);
                    return;
                }
                #endregion
                #endregion

                #region Commands  with DB use 
                #region /global
                if (message.StartsWith("/global ") && userRole=="admin")
                {
                    message = "*globally* "+message.Substring(7);
                    AddActualMessage(name, message, 0);
                    return;
                }
                #endregion
                #endregion

                #region Wrong command
                else
                {
                    Clients.Caller.addLoggedMessageToPage("<li><i>Wrong command. Send /info for more information about commands.</i></li>");
                    return;
                }
                #endregion
            }
            AddActualMessage(name, message, id);
        }
        public void Login(string name, string pass)
        {
            name = Strip(name);
            pass = Strip(pass);
            var userRole = IsCorrectUser(name, pass);
            if (userRole == "admin")
            {
                Clients.Caller.addCustomLineToAPage("AdminMenu", "<a class=\"common-button\" href=\"/StoryModels/Index?Name=" + name + "&Pass=" + pass + "\">Chats</a>");
                Clients.Caller.addCustomLineToAPage("AdminMenu", "<a class=\"common-button\" href=\"/UserModels/Index?Name=" + name + "&Pass=" + pass + "\">Users</a>");
                Clients.Caller.addCustomLineToAPage("AdminMenu", "<a class=\"common-button\" href=\"/Messages/Index?Name=" + name + "&Pass=" + pass + "\">Messages</a>");
            }
            else if(userRole == "ordinal")
            {
                Clients.Caller.addCustomLineToAPage("AdminMenu", "<a class=\"common-button\" href=\"/Messages/Index?Name=" + name + "&Pass=" + pass + "\">Messages</a>");
            }
            else if(userRole == "!exist")
            {
                if (name.Length <= 5 || pass.Length < 6)
                {
                    Clients.Caller.Reload();
                    return;
                }
                else
                {
                    Register(name, pass);
                }
            }
            else
            { 
            Clients.Caller.Reload();
            return;
            }
        }
        public void LoadStats(int id, string name)
        {
            name = Strip(name);
            Welcome(name, id.ToString());
            Help();
            id = int.Parse(Strip(id.ToString()));
            var words = 0;
            var symbols = 0;
            var bd = new DefaultContext();
            var bda = new UserModel();
            var bdb = new Message();
            foreach (var u in bd.UserModels)
            {
                foreach (var a in bd.Messages)
                {
                    if (id == a.StoryModel_Id && u.Name == a.Name)
                    {
                        words++;
                        symbols += a.Text.Length;
                    }
                }
                if(words > 0)
                    Clients.Caller.addStatsOfAToPage(u.Name, words, symbols);
                words = 0; symbols = 0;
            }
            Clients.Caller.addCustomLineToAPage("Stats", "<li><b>Chat stats </b> |  Chat #<i>" + id+"</i></li>");

        }
        public void LoadChat(int id)
        {
            
            id = int.Parse(Strip(id.ToString()));
            var bd = new DefaultContext();
            var bda = new Message();
            foreach (var a in bd.Messages)
            {
                if (id == a.StoryModel_Id || a.StoryModel_Id == 0)
                {
                    var text = "<li id=\""+a.Id+ "\"><button class=\"del\" name=\"" + a.Id + "\" >X</button><strong>" + a.Name + "</strong> <i>(at " + a.TimeStamp.ToShortDateString().Substring(0, 5) 
                        + a.TimeStamp.ToShortTimeString() + " ) said:</i><b> " + a.Text + "</b></li>";
                    Clients.Caller.addLoggedMessageToPage(text);
                }
            }
        }
        public void AccessChat(int chatid, string name, string pass)
        {
            name = Strip(name);
            pass = Strip(pass);
            chatid = int.Parse(Strip(chatid.ToString()));
            var id = chatid.ToString();
            var bd = new DefaultContext();
            var chats = bd.StoryModels.ToList();
            foreach(var a in chats)
            {
                if(a.ChatId == chatid)
                {
                    JoinRoom(id).Wait();
                    JoinRoom(name).Wait();
                    return;
                }
            }

            if (IsCorrectUser(name, pass) == "admin" && chatid > 0)
            {
                var stories = new StoryModelsController();
                stories.Create(new StoryModel() { ChatId = chatid });
                JoinRoom(id).Wait();
                JoinRoom(name).Wait();
                return;
            }
            Clients.Caller.Reload();
        }
        public void DeleteMessage(int id, string name, string pass)
        {
            name = Strip(name);
            pass = Strip(pass);
            var bd = new DefaultContext();
            var userRole = IsCorrectUser(name, pass);

                if(userRole=="admin"|| userRole=="ordinal")
                {
                    foreach(var a in bd.Messages)
                    {
                        if (a.Id != id)
                            continue;
                        if(a.Name == name || userRole == "admin")
                        {
                            var stories = new MessagesController();
                            stories.DeleteConfirmed(id);
                            Clients.All.deleteMessageS(id);
                            return;
                        }
                        else
                        {
                            Clients.Caller.deleteMessageS(id);
                            return;
                        }
                    }
                }                
            
        }


        private void AddActualMessage(string name, string message, int id)
        {
            var baseD = new MessagesController();
            var m = new Message() { Name = name, Text = message, TimeStamp = DateTime.UtcNow, StoryModel_Id = id };
            baseD.Create(m);
            var mId = new DefaultContext().Messages.ToList().Last();

            if (id == 0)
                Clients.All.addNewMessageToPage(name, message, mId.Id);
            
            else
                Clients.Group(id.ToString()).addNewMessageToPage(name, message, mId.Id);
        }
        private void Welcome(string n, string id) => Clients.Group(id).addLoggedMessageToPage("<li>User - <b>" + n + "</b></i> is joined a chat!</li>");
        private void Help() => Clients.Caller.addLoggedMessageToPage("<li>/info - to see list of available commands</li>");
        private Task JoinRoom(string roomName)
        {
            return Groups.Add(Context.ConnectionId, roomName);
        }
        private Task LeaveRoom(string roomName)
        {
            return Groups.Remove(Context.ConnectionId, roomName);
        }
        private void Register(string name, string pass) => 
            new UserModelsController().Create(new UserModel() { Name = name, Pass = pass });                
        private string Strip(string s)
        {
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(s);
            return doc.DocumentNode.InnerText;
        }
        private string IsCorrectUser(string name, string pass)
        {
            var bd = new DefaultContext();
            var users = bd.UserModels.ToList();
            foreach (var a in users)
            {
                if (a.Name == name && a.Pass == pass && a.UserVIP)
                {
                    return "admin";
                }
                if(a.Name == name && a.Pass == pass)
                {
                    return "ordinal";
                }
            }
            return "!exist";
        }
    }
}