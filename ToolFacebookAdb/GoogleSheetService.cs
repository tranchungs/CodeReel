using Google.Apis.Auth.OAuth2;
using Google.Apis.Sheets.v4.Data;
using Google.Apis.Sheets.v4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ToolFacebookAdb
{
    public class GoogleSheetService
    {
        SheetsService service;

        // Đường dẫn đến file JSON chứa thông tin Credential
        string credentialFilePath = "credentials.json";

        // ID của Google Sheet bạn muốn đọc
        string spreadsheetId = "1hgJSOjH7porwW2bNeHF0lxahOPW_lklJ1PdKINRoeyI";

        // Tên của phạm vi (range) bạn muốn đọc, ví dụ: "Sheet1!A1:B10"
        string range = "1!A2:O1000";

        public GoogleSheetService()
        {
            InitGoogleSheet();
        }

        private void InitGoogleSheet()
        {
            // Khởi tạo credential từ file JSON
            GoogleCredential credential;
            using (var stream = new FileStream(credentialFilePath, FileMode.Open, FileAccess.ReadWrite))
            {
                credential = GoogleCredential.FromStream(stream)
                    .CreateScoped(SheetsService.Scope.Spreadsheets);
            }

            // Khởi tạo dịch vụ Google Sheets
            service = new SheetsService(new Google.Apis.Services.BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = "Google Sheets API GPM",
            });
        }

        public void UpdateValuePage(int rownumber, string value)
        {

            string rangenew = $"1!F{rownumber}:F5";
            var valueRange = new ValueRange();
            var oblist = new List<object>() { value };
            valueRange.Values = new List<IList<object>> { oblist };

            var updateRequest = service.Spreadsheets.Values.Update(valueRange, spreadsheetId, rangenew);

            updateRequest.ValueInputOption = SpreadsheetsResource.ValuesResource.UpdateRequest.ValueInputOptionEnum.USERENTERED;
            var response = updateRequest.Execute();
        }
        public List<ListConfigDataInfo> ReadAllRows()
        {
            List<ListConfigDataInfo> listConfig = new List<ListConfigDataInfo>();
            // Thực hiện request để lấy dữ liệu từ Google Sheet
            SpreadsheetsResource.ValuesResource.GetRequest request = service.Spreadsheets.Values.Get(spreadsheetId, range);

            ValueRange response = request.Execute();
            IList<IList<Object>> values = response.Values;

            if (values != null && values.Count > 0)
            {
                foreach (var row in values)
                {
                    LDPhone ldPhone = new LDPhone(row[0].ToString());
                    string[] Acc = row[1].ToString().Split('|');

               
                    string page = row[2].ToString();
                    string folder = row[3].ToString();
                    string[] AccProxy = row[4].ToString().Split('|');
                    ProxyKey proxy = new ProxyKey(AccProxy[0], AccProxy[1]);
                    
                    string isCreate = row[5].ToString();
                    Account account;
                    if (isCreate == "0")
                    {
                        account = new Account(Acc[0], Acc[1], Acc[2],false);
                    }
                    else
                    {
                        account = new Account(Acc[0], Acc[1], Acc[2], true);
                    }
                    listConfig.Add(new ListConfigDataInfo(ldPhone, account, page, folder, proxy));
                }
            }
            return listConfig;
        }
    }
}
