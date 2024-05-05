using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolFacebookAdb
{
    public class ListConfigDataInfo
    {
        public LDPhone ldphone;
        public Account account;
        public string Page;
        public string Folder;
        public ProxyKey proxy;
        public ListConfigDataInfo()
        {

        }
        public ListConfigDataInfo(LDPhone ldphone, Account account, string Page, string Folder, ProxyKey proxy)
        {
            this.ldphone = ldphone;
            this.account = account; 
            this.Page = Page;
            this.Folder = Folder;
            this.proxy = proxy;
        }
    }
}
