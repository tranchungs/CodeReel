using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace ToolFacebookAdb
{
    public class Account
    {
        public string username { get; private set; }
        public string password { get; private set; }
        public string key2fa { get; private set; }
        public bool isCreate { get; private set; }

        public Account(string username,string password,string key2fa,bool isCreate)
        {
            this.username = username;
            this.password = password;
            this.key2fa = key2fa;
            this.isCreate = isCreate;
        }
        public string ToString()
        {
            return $"{username}|{password}|{key2fa}";
        }
    }
    public class ProxyKey
    {
        public string account { get; private set; }
        public string password { get; private set; }
        public ProxyKey(string account, string password)
        {
            this.account = account;
            this.password = password;
        }
        public string ToString()
        {
            return $"{account}|{password}";
        }
   
    }

    public class ConfigEnv
    {
        public static string FolderConfig;
        public static string FolderLD;
        public static string LDMain;
    }
}

