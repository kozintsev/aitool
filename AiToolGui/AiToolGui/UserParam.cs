using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AiToolGui
{
    public class UserParam
    {
        private static string userId;
        private static string username;
        private static string password;
        private static string fullname;
        private static short role;
        private static string rolename;
        private static string statustext;
        private static string localbdpath;

        public static string UserId
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
        public static short Role
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
