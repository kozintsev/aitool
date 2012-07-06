using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AiToolGui
{
    public class UserParam
    {
        private static int userId;
        private static string username;
        private static string password;
        private static string fullname;
        private static int role;
        private static string rolename;
        private static string statustext;
        private static string localbdpath;
        private static string language;
        public static string Language
        {
            get { return language; }
            set { language = value;}
        }

        public static int UserId
        {
            get { return userId; }
            set { userId = value; }
        }

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
        public static int Role
        {
            get { return role; }
            set { role = value; }
        }
        public static string Rolename
        {
            get { return rolename; }
            set { rolename = value; }
        }
        
        public static string StatusText
        {
            get { return statustext; }
            set { statustext = value; }
        }

        public static string LocalBDPath
        {
            get { return localbdpath; }
            set { localbdpath = value; }
        }
        
    }
}
