using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace server
{
    public class ChatRoom
    {
        List<User> users;
        List<String> messages;
        public ChatRoom(User u) {
            users = new List<User>();
            users.Add(u);
            messages = new List<string>();
        }

        public void addUser(User u) {
            users.Add(u);
        }

        public void newMessage(String s) {
            messages.Add(s);
        }

        public bool isInHere(int ID) {

            foreach (User u in users) {
                if (u.getServerNumber() == ID) {
                    return true;
                }
            }

            return false;
        }



        public String getMessages()
        {
            if (messages.Count > 0)
            {
                return messages.Last();
            }
            else
            {
                return null;
            }
        }

        internal void removeUser(int ThisUser)
        {
            foreach (User u in users)
            {
                if (u.getServerNumber() == ThisUser)
                {
                    users.Remove(u);
                    break;
                }
            }
        }

        internal bool update()
        {
            if (users.Count == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}



/*
 * 
 * this.Disposed(this, EventArgs.Empty);
 * 
 */
