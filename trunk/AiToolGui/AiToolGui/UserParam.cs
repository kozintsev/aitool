using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AiToolGui
{
    public class UserParam
    {
        private static string username;
        private static string password;
        private static string fullname;

        public static string Username
        {
            get { return username; }
            set { username = value; }
        }
        public static string Password
        {
            get { return password; }
            set { password = value; }
        }
        public static string Fullname
        {
            get { return fullname; }
            set { fullname = value; }
        }
    }
}
