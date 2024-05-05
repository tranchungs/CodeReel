
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xNet;
using System.Text.RegularExpressions;
using KAutoHelper;

namespace ToolFacebookAdb
{
    public class LDPhone
    {

        public string FACEBOOK = "com.facebook.katana";
        public string EXPRESSVPN = "com.expressvpn.vpn";
        public ContextDataBitMap context;
        private HttpRequest http;
        private bool state;
        public string index;
        public int indexSheet;

        public LDPhone(string index)
        {
            this.index = "LDPlayer-"+index;
            this.indexSheet = Int16.Parse(index)+1;
            state = false;
            context = new ContextDataBitMap();
            http = new HttpRequest();
        }
        public void SetContextDataBitMap(ContextDataBitMap context)
        {
            this.context = context;
            state = false;
        }
        public LDPhone(string index, ContextDataBitMap context)
        {
            this.index = index;
            this.context = context;
            http = new HttpRequest();
            state = false;
        }
        public void Start()
        {
            LDPlayer.Open(LDType.Name, index);
           
        }
        public void Close()
        {
            LDPlayer.Close(LDType.Name, index);

        }
        public bool GetState()
        {
            state = LDPlayer.IsDeviceRunning(LDType.Name, index);
            return state;
        }
        public void OpenAppLogin()
        {
            int count = 0;
            LDPlayer.OpenApp(LDType.Name, index, FACEBOOK);
            while (count<10)
            {
                if (IshaveImg(context.iconFacebook))
                {
                   
                    break;
                }
                else
                {
                    count++;
                    Thread.Sleep(1000);
                }
            }

        }
        public void OpenApp()
        {
            LDPlayer.OpenApp(LDType.Name, index, FACEBOOK);
           

        }
        public void FakeIP(ProxyKey proxy,object obj)
        {
            LDPlayer.OpenApp(LDType.Name, index, EXPRESSVPN);
            Thread.Sleep(20000);
            if (IshaveImg(context.iconSignIn))
            {
                LDPlayer.TapImg(LDType.Name, index, context.iconSignIn);
                Thread.Sleep(2000);
                LDPlayer.InputText(LDType.Name, index, proxy.account);  
                Thread.Sleep(400);
                LDPlayer.TapByPercent(LDType.Name, index, 49, 40.9);
                Thread.Sleep(400);
                LDPlayer.InputText(LDType.Name, index, proxy.password);
                Thread.Sleep(400);
                LDPlayer.TapByPercent(LDType.Name, index, 50.2, 57.7);
                Thread.Sleep(10000);
                ClickImgForTime(context.iconOK, 10);
                Thread.Sleep(1000);
                LDPlayer.TapByPercent(LDType.Name, index, 80.3, 72.9);
                Thread.Sleep(1000);
                ClickImgForTime(context.iconNoThank, 5);
                Thread.Sleep(1000);
                LDPlayer.TapByPercent(LDType.Name, index, 49.5, 81.1);
                Thread.Sleep(3000);
            }
            // Ngăn các luồng khác bắt đầu FakeIP
            int count = 0;
            while (count < 10)
            {
                if(IshaveImg(context.iconVPN)|| IshaveImg(context.iconVPN2))
                {
                    LDPlayer.TapByPercent(LDType.Name, index, 12.7, 95.9);
                    break;
                }
                Thread.Sleep(1000);
                count++;
            }
            Thread.Sleep(2000);
            LDPlayer.TapByPercent(LDType.Name, index, 36.3, 54.0);
            Thread.Sleep(2000);
            LDPlayer.TapImg(LDType.Name, index, context.iconKinhLup);
            Thread.Sleep(2000);
            LDPlayer.InputText(LDType.Name, index, "US");
            Thread.Sleep(1000);
            LDPlayer.TapImg(LDType.Name, index, context.iconHoaKy);
            Random r = new Random(indexSheet);
           Thread.Sleep(r.Next(500, 700));
            lock(obj)
            {
                AnothorAdb();
            }
            Thread.Sleep(6000);
            if (IshaveImg(context.imgMaybeLater))
            {
                LDPlayer.TapImg(LDType.Name, index, context.imgMaybeLater);
            }
           // LDPlayer.TapByPercent(LDType.Name, index, 48.6, 92.1);

        }
        public void Login(Account account)
        {
        CheckLai:
            List<Bitmap> listOpenSceen = new List<Bitmap>();
            listOpenSceen.Add(context.iconFacebook);
            listOpenSceen.Add(context.iconFacebook2);
            InfoImage infoScreenOpen = CheckListBitMap(listOpenSceen);
            if (infoScreenOpen.isHave)
            {
                //mở app thành công
                switch(infoScreenOpen.index) {
                    case 0: //iconMeta là chưa đăng nhập
                        LDPlayer.TapByPercent(LDType.Name, index, 32.5, 40.2);
                        Thread.Sleep(400);
                        LDPlayer.TapByPercent(LDType.Name, index, 13.5, 40.2);
                        Thread.Sleep(400);
                        LDPlayer.InputText(LDType.Name, index, account.username);
                        Thread.Sleep(400);
                        LDPlayer.TapByPercent(LDType.Name, index, 14.7, 50.8);
                        Thread.Sleep(400);
                        LDPlayer.InputText(LDType.Name, index, account.password);
                        Thread.Sleep(400);
                        listOpenSceen.Clear();
                        listOpenSceen.Add(context.iconDangNhap);
                        listOpenSceen.Add(context.iconDangNhap2);
                        InfoImage ScreenAppLogin = CheckListBitMap(listOpenSceen);
                        if(ScreenAppLogin.isHave)
                        {
                            LDPlayer.Tap(LDType.Name, index, ScreenAppLogin.point.X, ScreenAppLogin.point.Y);
                        }
                        Thread.Sleep(15000);

                        listOpenSceen.Clear();
                        listOpenSceen.Add(context.iconThuCachKhac);
                        listOpenSceen.Add(context.iconThuCachKhac2);
                        InfoImage Screen_ResultLogin = CheckListBitMap(listOpenSceen);
                        if (Screen_ResultLogin.isHave)
                        {
                            LDPlayer.Tap(LDType.Name, index, Screen_ResultLogin.point.X, Screen_ResultLogin.point.Y);
                            Thread.Sleep(1000);
                            LDPlayer.TapByPercent(LDType.Name, index, 31.3, 52.5);
                            Thread.Sleep(1000);
                            LDPlayer.TapByPercent(LDType.Name, index, 48.1, 94.7);//tiếp tục 
                            Thread.Sleep(1000);
                            LDPlayer.TapByPercent(LDType.Name, index, 13.2, 68.1); // click mã 
                            Thread.Sleep(1000);
                            string key2fa = "";
                            while (key2fa.Length == 0)
                            {
                                key2fa = Get2FA(account.key2fa);
                                LDPlayer.InputText(LDType.Name, index, key2fa);
                                Thread.Sleep(1000);
                            }
                            LDPlayer.TapByPercent(LDType.Name, index, 48.8, 87.3); // click tiep tuc
                            Thread.Sleep(15000);
                            listOpenSceen.Clear();
                            listOpenSceen.Add(context.iconThuLai);
                            listOpenSceen.Add(context.iconLucKhac);
                            listOpenSceen.Add(context.iconLucKhac2);
                            InfoImage Screen_ResultAfterLogin = CheckListBitMap(listOpenSceen);
                            if (Screen_ResultAfterLogin.isHave)
                            {
                                LDPlayer.Tap(LDType.Name, index, ScreenAppLogin.point.X, ScreenAppLogin.point.Y);
                            }
                            Thread.Sleep(5000);
                            LDPlayer.KillApp(LDType.Name, index, FACEBOOK);
                            Thread.Sleep(1000);
                            LDPlayer.OpenApp(LDType.Name, index, FACEBOOK);
                            Thread.Sleep(5000);
                            if (IshaveImg(context.iconChoPhep))
                            {
                                LDPlayer.TapImg(LDType.Name, index, context.iconChoPhep);
                                Thread.Sleep(1000);
                                if (IshaveImg(context.iconChoPhep2))
                                {
                                    LDPlayer.TapImg(LDType.Name, index, context.iconChoPhep2);
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("SAi TAi Khoan MK");
                        }
                        

                        break;
                    case 1: // đã đăng nhập

                        break;
                
                }
            }
            else
            {
                LDPlayer.KillApp(LDType.Name, index, FACEBOOK);
                Thread.Sleep(1000);
                LDPlayer.OpenApp(LDType.Name, index, FACEBOOK);
                Thread.Sleep(5000);
                goto CheckLai;

            }
            #region OLD
            //if (IshaveImg(context.iconFacebook2))
            //{
            //    // ko can dang nhap
            //}
            //else
            //{



            //    LDPlayer.TapImg(LDType.Name, index, context.iconDangNhap);

            //    Thread.Sleep(15000);
            //    //check dungs sai
            //    if (IshaveImg(context.iconThuCachKhac))
            //    {

            //        LDPlayer.TapImg(LDType.Name, index, context.iconThuCachKhac);
            //        Thread.Sleep(1000);
            //        LDPlayer.TapByPercent(LDType.Name, index, 31.3, 52.5);
            //        Thread.Sleep(500);
            //        LDPlayer.TapByPercent(LDType.Name, index, 48.1, 94.7);//tiếp tục 
            //        Thread.Sleep(1000);
            //        LDPlayer.TapByPercent(LDType.Name, index, 13.2, 68.1); // click mã 
            //        Thread.Sleep(1000);
            //        string key2fa = Get2FA(account.key2fa);
            //        LDPlayer.InputText(LDType.Name, index, key2fa);
            //        Thread.Sleep(1000);
            //        LDPlayer.TapByPercent(LDType.Name, index, 48.8, 87.3); // click tiep tuc
            //        Thread.Sleep(15000);
            //        LDPlayer.TapByPercent(LDType.Name, index, 48.8, 87.3); // thử lại 
            //        Thread.Sleep(7000);

            //        LDPlayer.TapByPercent(LDType.Name, index, 48.8, 87.3); // thử lại 

            //        Thread.Sleep(5000);
            //        LDPlayer.TapByPercent(LDType.Name, index, 49.3, 92.8);
            //        Thread.Sleep(5000);
            //        while (IshaveImg(context.iconboqua2))
            //        {
            //            LDPlayer.TapImg(LDType.Name, index, context.iconboqua2);
            //            Thread.Sleep(1000);
            //        }
            //        Thread.Sleep(1000);
            //        LDPlayer.TapByPercent(LDType.Name, index, 46.9, 95.8);

            //        LDPlayer.TapByPercent(LDType.Name, index, 49.8, 93.1);
            //        Thread.Sleep(3000);
            //        LDPlayer.KillApp(LDType.Name, index, FACEBOOK);
            //        Thread.Sleep(1000);
            //        LDPlayer.OpenApp(LDType.Name, index, FACEBOOK);
            //        Thread.Sleep(5000);
            //        if (IshaveImg(context.iconChoPhep))
            //        {
            //            LDPlayer.TapImg(LDType.Name, index, context.iconChoPhep);
            //            Thread.Sleep(1000);
            //            if (IshaveImg(context.iconChoPhep2))
            //            {
            //                LDPlayer.TapImg(LDType.Name, index, context.iconChoPhep2);
            //            }
            //        }
            //        Thread.Sleep(5000);

            //    }
            //    else
            //    {
            //        Console.WriteLine("SAi TAi Khoan MK");
            //    }
            //}
            #endregion

        }
        public bool IshaveImg(Bitmap ImgFind)
        {
            try
            {
                Bitmap bm = (Bitmap)ImgFind.Clone();
                var screen = LDPlayer.ScreenShoot(LDType.Name, index);
                var Point =  KAutoHelper.ImageScanOpenCV.FindOutPoint(screen, bm);
                return Point != null;
            }
            catch
            {
                return false;
            }

        }
        public InfoImage CheckListBitMap(List<Bitmap> ImgFind)
        {
            InfoImage infoImage = new InfoImage();
            try
            {
               
                var screen = LDPlayer.ScreenShoot(LDType.Name, index);
                for (int i = 0; i < ImgFind.Count; i++)
                {
                    Bitmap bm = (Bitmap)ImgFind[i].Clone();
                    var Point = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen, bm);
                    if(Point != null)
                    {
                        infoImage.isHave = true;
                        infoImage.point = (Point)Point;
                        infoImage.index = i;
                        break;
                    }
                }
                return infoImage;


            }
            catch
            {
                return infoImage;
            }

        }
        public string Get2FA(string code)
        {

            string html = http.Get($"https://2fa.live/tok/{code}").ToString();
            string pattern = @"\b\d{6}\b";
            Regex regex = new Regex(pattern);
            Match matches = regex.Match(html);
            return matches.Value;
        }
        public void sendTen(string name)
        {
            string str = Convert.ToBase64String(Encoding.UTF8.GetBytes(name));
            LDPlayer.Adb(LDType.Name, index, " shell ime set com.android.adbkeyboard/.AdbIME");
            Thread.Sleep(1000);
            LDPlayer.Adb(LDType.Name, index, $" shell am broadcast -a ADB_INPUT_B64 --es msg {str}");
          //  KAutoHelper.ADBHelper.ExecuteCMD("adb -s " + LDPlayer.GetDevices()[int.Parse(this.index)] + " shell am broadcast -a ADB_INPUT_B64 --es msg " + str);
        }
        public void Createpage(string PageName, Account account)
        {
            if (!account.isCreate)
            {
                LDPlayer.TapImg(LDType.Name, index, context.iconCaNhan);
                Thread.Sleep(500);
                if (!IshaveImg(context.iconMenu))
                {
                    LDPlayer.TapByPercent(LDType.Name, index, 91.3, 14.0);
                }

                Thread.Sleep(3000);
                while (!IshaveImg(context.iconPage))
                {
                    if (IshaveImg(context.iconPage))
                    {
                        LDPlayer.TapImg(LDType.Name, index, context.iconPage);
                        break;
                    }
                    LDPlayer.SwipeByPercent(LDType.Name, index, 49.8, 67.4, 62, 15.1);
                    Thread.Sleep(500);
                    if (IshaveImg(context.iconXemthem))
                    {
                        LDPlayer.TapImg(LDType.Name, index, context.iconXemthem);
                    }
                }

                if (IshaveImg(context.iconPage))
                {
                    LDPlayer.TapImg(LDType.Name, index, context.iconPage);
                }

                Thread.Sleep(1000);
                ClickImgForTime(context.iconTao, 5);
                Thread.Sleep(1000);
                ClickImgForTime(context.iconBatDau, 10);
                Thread.Sleep(3000);
                LDPlayer.TapByPercent(LDType.Name, index, 16.1, 34.4); //ten trang
                Thread.Sleep(200);
                LDPlayer.InputText(LDType.Name, index, PageName);              // sendTen(PageName);
                Thread.Sleep(200);
                ClickImgForTime(context.iconTiep, 10);
                Thread.Sleep(5000);
                LDPlayer.TapByPercent(LDType.Name, index, 20.4, 52.8);
                Thread.Sleep(600);
                LDPlayer.TapByPercent(LDType.Name, index, 21.2, 68.1);
                Thread.Sleep(600);
                LDPlayer.TapByPercent(LDType.Name, index, 21.2, 68.1);
                Thread.Sleep(600);
                LDPlayer.TapByPercent(LDType.Name, index, 20.7, 82.0);
                Thread.Sleep(600);
                LDPlayer.TapByPercent(LDType.Name, index, 20.7, 82.0);
                Thread.Sleep(1000);
                LDPlayer.TapByPercent(LDType.Name, index, 50.5, 93.1); // click tao
                Thread.Sleep(10000);
                LDPlayer.TapByPercent(LDType.Name, index, 41.8, 80.2);
                Thread.Sleep(600);
                LDPlayer.TapByPercent(LDType.Name, index, 49.3, 94.2);
                Thread.Sleep(600);
                ClickImgForTime(context.iconTiep, 5);
                Thread.Sleep(7000);
                //chọn ảnh
                LDPlayer.TapByPercent(LDType.Name, index, 50.0, 56.3); // click chonj anh
                Thread.Sleep(1000);
                if (IshaveImg(context.iconChoPhepTruyCap))
                {
                    LDPlayer.TapImg(LDType.Name, index, context.iconChoPhepTruyCap);
                    Thread.Sleep(400);
                    LDPlayer.TapByPercent(LDType.Name, index, 77.9, 63.2);
                    Thread.Sleep(400);
                    LDPlayer.TapByPercent(LDType.Name, index, 72.1, 61.0);
                }
                Thread.Sleep(1000);
                Random random = new Random();
                double minValueX = 5.3; // Giá trị tối thiểu
                double maxValueX = 91.8; // Giá trị tối đa

                double rangeX = maxValueX - minValueX;
                double randomNumberInRangeX = random.NextDouble() * rangeX + minValueX;

                double minValueY = 11.6; // Giá trị tối thiểu
                double maxValueY = 95; // Giá trị tối đa
                double rangeY = maxValueY - minValueY;
                double randomNumberInRangeY = random.NextDouble() * rangeY + minValueY;
                LDPlayer.TapByPercent(LDType.Name, index, randomNumberInRangeX, randomNumberInRangeY);

                Thread.Sleep(5000);

                ClickImgForTime(context.iconTiep, 10);
                Thread.Sleep(1000);
                ClickImgForTime(context.iconTiep, 10);

                Thread.Sleep(1000);
                ClickImgForTime(context.imgXong, 10);
                Thread.Sleep(20000);
                LDPlayer.TapByPercent(LDType.Name, index, 47.6, 94.7);
                Thread.Sleep(2000);
                LDPlayer.TapByPercent(LDType.Name, index, 6.7, 7.4);
                Thread.Sleep(5000);
                LDPlayer.TapByPercent(LDType.Name, index, 6.7, 7.4);
                Thread.Sleep(2000);
                LDPlayer.KillApp(LDType.Name, index, FACEBOOK);
                Thread.Sleep(1000);
                LDPlayer.OpenApp(LDType.Name, index, FACEBOOK);
                Thread.Sleep(5000);
                GoogleSheetService service = new GoogleSheetService();
                service.UpdateValuePage(indexSheet, "1");

            }
            
            //setup page nếu cần
            // push len la da tao page
        }
        public bool ClickImgForTime(Bitmap Img, int time)
        {
            bool isClicked = false;
            int timecount = 0;
            while (timecount < time)
            {
                if (IshaveImg(Img))
                {
                    isClicked = true;
                    LDPlayer.TapImg(LDType.Name, index, Img);
                    break;
                }
                else
                {
                    timecount++;
                    Thread.Sleep(1000);
                }
            }
            return isClicked;
        }
        public void Reels(int timewatch)
        {
          LDPlayer.Adb(LDType.Name, index, " shell am start -n com.facebook.katana/com.facebook.katana.IntentUriHandler -d \"https://www.facebook.com/reel/1102071784422020\"");
            Thread.Sleep(5000);
            // watch reel
            int currentReel = 0;
            while (currentReel < timewatch)
            {
                Thread.Sleep(10 * 1000);
                LDPlayer.TapByPercent(LDType.Name, index, 48.6, 24.3);
                LDPlayer.TapByPercent(LDType.Name, index, 48.6, 24.3);
                Thread.Sleep(5 * 1000);
                Thread.Sleep(500);
                LDPlayer.SwipeByPercent(LDType.Name,index, 41.6, 75, 41.6,5 ,200);
                Thread.Sleep(500);
                currentReel += 18;

            }
        }
        public void Add()
        {

        }
        public void UpReels(int amont)
        {
            LDPlayer.Adb(LDType.Name, index, " shell am start -n com.facebook.katana/com.facebook.katana.IntentUriHandler -d \"https://www.facebook.com/reelscomposer\"");
            Thread.Sleep(5000);
            LDPlayer.TapByPercent(LDType.Name, index, 13.2, 27.0);
            Thread.Sleep(2000);
            LDPlayer.TapByPercent(LDType.Name, index, 16.4, 43.9); //click video
            Thread.Sleep(10000);

            Random random = new Random(indexSheet);
            int swipe = random.Next(3, 12);
            for(int i = 0;i< swipe; i++)
            {
                LDPlayer.SwipeByPercent(LDType.Name, index, 41.6, 75, 41.6, 200);
            }
            double minValueX = 5.3; // Giá trị tối thiểu
            double maxValueX = 91.8; // Giá trị tối đa

            double rangeX = maxValueX - minValueX;
            double randomNumberInRangeX = random.NextDouble() * rangeX + minValueX;

            double minValueY = 11.6; // Giá trị tối thiểu
            double maxValueY = 95; // Giá trị tối đa
            double rangeY = maxValueY - minValueY;
            double randomNumberInRangeY = random.NextDouble() * rangeY + minValueY;
            LDPlayer.TapByPercent(LDType.Name, index, randomNumberInRangeX, randomNumberInRangeY);
            Thread.Sleep(10000);
            //chon ngau nhien video
            LDPlayer.TapByPercent(LDType.Name, index, 18.8, 46.0);
            Thread.Sleep(2000);
            LDPlayer.TapByPercent(LDType.Name, index, 83.2, 94.2);
            Thread.Sleep(2000);
            LDPlayer.TapByPercent(LDType.Name, index, 54.6, 95.1);
            //qua xem reels
            Thread.Sleep(10000);

        }
        public void AnothorAdb()
        {
            LDPlayer.KillAdb();
            Thread.Sleep(1000);
            LDPlayer.StartServerAdb();
            Thread.Sleep(1000);
            LDPlayer.GetPingAdb();
            Thread.Sleep(2000);
        }
    }
}
public class InfoImage
{
    public int index;
    public bool isHave;
    public Point point;
    public InfoImage(int index,bool ishave,Point point)
    {
        this.index = index;
        this.isHave = ishave;
        this.point = point;
    }
    public InfoImage(bool ishave)
    {
        this.isHave = ishave;
    }
    public InfoImage()
    {
        this.isHave = false;
    }
}