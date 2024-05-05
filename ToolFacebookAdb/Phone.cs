using KAutoHelper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using xNet;

namespace ToolFacebookAdb
{
    public class Phone
    {
        public string FACEBOOK = "com.facebook.katana";
        private ContextDataBitMap context;
        private HttpRequest http;
        public Account account { get; set; }
        public List<TASKFACEBOOK> tasks { get; set; }

        public string deviceID;
        public Phone(string deviceID,ContextDataBitMap context) {
            this.deviceID = deviceID;
            this.context = context;
            http = new HttpRequest();
        }
        public Phone(ContextDataBitMap context)
        {
            this.context = context;
            http = new HttpRequest();
        }
        public void OpenApp()
        {
            KAutoHelper.ADBHelper.ExecuteCMD($"adb -s {deviceID} shell am start -n com.facebook.katana/com.facebook.katana.LoginActivity");
        }
        public void ClearData(string appname)
        {
            KAutoHelper.ADBHelper.ExecuteCMD($"adb -s {deviceID} shell pm clear {appname}");
        }
        public void FakeVPN()
        {

        }
        public void Tapimg(Bitmap ImgFind)
        {

                Bitmap bm = (Bitmap)ImgFind.Clone();
                var screen = ADBHelper.ScreenShoot(deviceID);
                var Point = ImageScanOpenCV.FindOutPoint(screen, bm);

                if (Point != null)
                {

                    ADBHelper.Tap(deviceID, Point.Value.X + 14, Point.Value.Y + 3);

                    return;
                }
        }
        public bool IshaveImg(Bitmap ImgFind)
        {
            try
            {
                Bitmap bm = (Bitmap)ImgFind.Clone();
                var screen = ADBHelper.ScreenShoot(deviceID);
                var Point = ImageScanOpenCV.FindOutPoint(screen, bm);
                return Point != null;
            }
            catch
            {
                return false;
            }

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
                    Tapimg(Img);
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
        public bool ImgForTime(Bitmap Img, int time)
        {
            bool isHaveImgage = false;
            int timecount = 0;
            while (timecount < time)
            {
                if (IshaveImg(Img))
                {
                    isHaveImgage = true;
                    break;
                }
                else
                {
                    timecount++;
                    Thread.Sleep(1000);
                }
            }
            return isHaveImgage;
        }
        public void Login(Account account )
        {
            KAutoHelper.ADBHelper.TapByPercent(deviceID, 32.5, 40.2);
            Thread.Sleep(400);
            KAutoHelper.ADBHelper.InputText(deviceID, account.username);
            Thread.Sleep(400);
            KAutoHelper.ADBHelper.TapByPercent(deviceID, 14.7, 50.8);
            Thread.Sleep(400);
             sendTen(account.password);
            Thread.Sleep(400);
            Tapimg(context.iconDangNhap);
            //   KAutoHelper.ADBHelper.TapByPercent(deviceID, 47.6, 60.9); //click dang nhap ( ddang looix)
            Thread.Sleep(10000); // chờ xoay login
            //check dungs sai
            if (IshaveImg(context.iconThuCachKhac))
            {
                string key2fa = Get2FA(account.key2fa);

                KAutoHelper.ADBHelper.TapByPercent(deviceID, 13.2, 68.1); // click mã 
                Thread.Sleep(500);
                KAutoHelper.ADBHelper.InputText(deviceID, key2fa);
                Thread.Sleep(500);
                KAutoHelper.ADBHelper.TapByPercent(deviceID, 48.8, 87.3); // click tiep tuc
                // theem may buoc bo qua 
            }
            else
            {
                Console.WriteLine("SAi TAi Khoan MK");
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
            KAutoHelper.ADBHelper.ExecuteCMD("adb -s " + deviceID + " shell ime set com.android.adbkeyboard/.AdbIME");
            Thread.Sleep(1000);
            KAutoHelper.ADBHelper.ExecuteCMD("adb -s " + deviceID + " shell am broadcast -a ADB_INPUT_B64 --es msg " + str);
        }
        public void Createpage(string PageName)
        {
            Tapimg(context.iconCaNhan);
            Thread.Sleep(200);
            KAutoHelper.ADBHelper.TapByPercent(deviceID, 91.3, 14.0);

            Thread.Sleep(2000);
            Thread.Sleep(1000);
            while (!IshaveImg(context.iconPage))
            {
                if (IshaveImg(context.iconPage))
                {
                    Tapimg(context.iconPage);
                    break;
                }
                KAutoHelper.ADBHelper.SwipeByPercent(deviceID, 49.8, 67.4, 62, 15.1, 800);
                Thread.Sleep(500);
                KAutoHelper.ADBHelper.SwipeByPercent(deviceID, 49.8, 67.4, 62, 15.1, 800);
                Thread.Sleep(200);
                if (IshaveImg(context.iconPage))
                {
                    Tapimg(context.iconPage);
                    break;
                }
            }
           
          
            Tapimg(context.iconXemthem);
            if (IshaveImg(context.iconPage))
            {
                Tapimg(context.iconPage);
            }

            Thread.Sleep(1000);
            ClickImgForTime(context.iconTao, 5);
            Thread.Sleep(1000);
            ClickImgForTime(context.iconBatDau, 10);
            Thread.Sleep(3000);
            KAutoHelper.ADBHelper.TapByPercent(deviceID, 16.1, 34.4); //ten trang
            Thread.Sleep(200);
            sendTen(PageName);
            Thread.Sleep(200);
            ClickImgForTime(context.iconTiep, 10);

            ClickImgForTime(context.imgBanNhac, 10);
            ClickImgForTime(context.imgSucKhoe, 10);
            ClickImgForTime(context.imgCuaHang, 10);

            Thread.Sleep(1000);
            KAutoHelper.ADBHelper.TapByPercent(deviceID, 49.5, 93.2);
            Thread.Sleep(1000);
            ClickImgForTime(context.iconTiep, 5);
            //chọn ảnh
            while (IshaveImg(context.iconTiep))
            {
                ClickImgForTime(context.iconTiep, 5);
            }

            Thread.Sleep(1000);
            ClickImgForTime(context.imgXong, 5);
            //setup page nếu cần
        }
        public void Reels(int timeWatch)
        {
            
            Tapimg(context.iconCaNhan);
            Thread.Sleep(200);
            KAutoHelper.ADBHelper.TapByPercent(deviceID, 91.3, 14.0);
            Thread.Sleep(3000);
            bool isHaveIconReels = false;
            while (!isHaveIconReels)
            {
                if (IshaveImg(context.iconReels))
                {
                    Tapimg(context.iconReels);
                    break;
                }
                KAutoHelper.ADBHelper.SwipeByPercent(deviceID, 49.8, 67.4, 62, 15.1, 800);
                Thread.Sleep(500);
                KAutoHelper.ADBHelper.SwipeByPercent(deviceID, 49.8, 67.4, 62, 15.1, 800);
                Thread.Sleep(200);
                if (IshaveImg(context.iconXemthem))
                {
                    Tapimg(context.iconXemthem);
                }
            }
            // watch reel
            int currentReel = 0;
            while (currentReel < timeWatch)
            {
                int watchingTime = 18;
                Thread.Sleep(watchingTime * 1000);
                Thread.Sleep(500);
                KAutoHelper.ADBHelper.SwipeByPercent(deviceID, 41.6, 50, 41.6, 5, 1000);
                Thread.Sleep(500);
                currentReel+=18;

            }

        }
    }
    public enum TASKFACEBOOK { 
    LOGIN,
    TAOPAGE,
    REELS,
    UPREELS
    }


}
