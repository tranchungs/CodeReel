using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Xml.Linq;
using Newtonsoft.Json.Linq;

namespace ToolFacebookAdb
{
    public class UtilityHelper
    {

        public static void ReadConfig()
        {
            string filePath = "Environment.config";
            try
            {
                // Đọc file JSON
                string jsonContent = File.ReadAllText(filePath);
                JObject jsonObject = JObject.Parse(jsonContent);

                // Cập nhật thuộc tính
                ConfigEnv.FolderConfig = jsonObject["LDFolderConfig"].ToString();
                ConfigEnv.FolderLD = jsonObject["LDFolder"].ToString();
                // Lưu lại vào file
                File.WriteAllText(filePath, jsonObject.ToString());

                Console.WriteLine("File has been updated successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error occurred: " + ex.Message);
            }
        }
        public static string ReadLDClone()
        {
            string filePath = "Environment.config";
            try
            {
                // Đọc file JSON
                string jsonContent = File.ReadAllText(filePath);
                JObject jsonObject = JObject.Parse(jsonContent);

                // Cập nhật thuộc tính
                string main = jsonObject["LDMain"].ToString();
                return main;
            }
            catch (Exception ex)
            {
                return "";
            }
        }
        public static List<Account> LoadAccountsFromFile(string path)
        {
            List<Account> accounts = new List<Account>();
            try
            {
                
            }
            catch (Exception ex)
            {

            }

            return accounts;
        }
        public static List<ProxyKey> LoadKeyFromFile(string path)
        {
            List<ProxyKey> proxyKeys = new List<ProxyKey>();
            try
            {
                using (StreamReader reader = new StreamReader(path))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        proxyKeys.Add(new ProxyKey(line,line));
                    }
                }
            }
            catch (Exception ex)
            {

            }

            return proxyKeys;
        }
        public static void SetSharedFolder(string  name,string newPath,List<LDevice> listLDCurrent)
        {
            if (newPath.Length == 0) return;
            int index = 0;
            foreach (LDevice device in listLDCurrent)
            {
                if (name == device.Name)
                {
                    index = device.Index;
                    break;
                }

            }
            string filePath = ConfigEnv.FolderConfig +$"\\leidian{index}.config";
            try
            {
                // Đọc file JSON
                string jsonContent = File.ReadAllText(filePath);
                JObject jsonObject = JObject.Parse(jsonContent);

                // Cập nhật thuộc tính
                jsonObject["statusSettings.sharedPictures"] = newPath;

                // Lưu lại vào file
                File.WriteAllText(filePath, jsonObject.ToString());

            }
            catch (Exception ex)
            {
            }
        }
        public static Account GetAccountByUsername(string account,List<Account> listAcc)
        {
            Account accresult = new Account("","","",true);
            foreach(Account acc in listAcc)
            {
                if(acc.username == account)
                {
                    accresult = acc;
                    break;
                }
            }
            return accresult;
        }
        public static ListConfigDataInfo GetConfigDataInfo(string index,List<ListConfigDataInfo> listData)
        {
            ListConfigDataInfo result = new ListConfigDataInfo();
            foreach (ListConfigDataInfo info in listData)
            {
                if(info.ldphone.index == index)
                {
                    result = info;
                    break;
                    
                }
            }
            return result;
        }
    }
}
