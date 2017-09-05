using MotionRec.NancyApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MotionRec.NancyApp.App_Code
{
    public class Utils
    {
        public string MessageToUser { get; set; }
        public bool CommandSucceeded { get; set; }
        public IUser User { get; set; }

        public Utils(IUser user)
        {
            CommandSucceeded = true;
            MessageToUser = "";
            this.User = user;
        }
        public void AddMessage(string Msg)
        {
            this.MessageToUser += Msg;
        }
        public bool emailIsValid(string email)
        {
           return Regex.IsMatch(email,
               @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
               @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$",
               RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
        }

    }
}
