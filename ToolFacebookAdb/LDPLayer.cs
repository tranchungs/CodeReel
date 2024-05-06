using KAutoHelper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolFacebookAdb
{
    public static class EnumExtensions
    {
        public static T GetAttribute<T>(this Enum value) where T : Attribute
        {
            object[] customAttributes = value.GetType().GetMember(value.ToString())[0].GetCustomAttributes(typeof(T), inherit: false);
            if (customAttributes.Length == 0)
            {
                return null;
            }

            return (T)customAttributes[0];
        }

        public static string ToName(this Enum value)
        {
            DescriptionAttribute attribute = value.GetAttribute<DescriptionAttribute>();
            if (attribute != null)
            {
                return attribute.Description;
            }

            return value.ToString();
        }
    }
    public enum LDType
    {
        [Description("name")]
        Name,
        [Description("index")]
        Id
    }
    public class LDPlayer
    {
        public static string PathLD = "C:\\LDPlayer\\LDPlayer4.0\\ldconsole.exe";

        public static void Open(LDType ldType, string nameOrId)
        {
            ExecuteLD("launch --" + ldType.ToName() + " " + nameOrId);
        }

        public static void OpenApp(LDType ldType, string nameOrId, string packageName)
        {
            ExecuteLD("launchex --" + ldType.ToName() + " " + nameOrId + " --packagename " + packageName);
        }

        public static void Close(LDType ldType, string nameOrId)
        {
            ExecuteLD("quit --" + ldType.ToName() + " " + nameOrId);
        }

        public static void CloseAll()
        {
            ExecuteLD("quitall");
        }

        public static void ReBoot(LDType ldType, string nameOrId)
        {
            ExecuteLD("reboot --" + ldType.ToName() + " " + nameOrId);
        }

        public static void Create(string name)
        {
            ExecuteLD("add --name " + name);
        }

        public static void Copy(string name, string fromNameOrId)
        {
            ExecuteLD("copy --name " + name + " --from " + fromNameOrId);
        }

        public static void Delete(LDType ldType, string nameOrId)
        {
            ExecuteLD("remove --" + ldType.ToName() + " " + nameOrId);
        }

        public static void Rename(LDType ldType, string nameOrId, string titleNew)
        {
            ExecuteLD("rename --" + ldType.ToName() + " " + nameOrId + " --title " + titleNew);
        }

        public static void InstallAppFile(LDType ldType, string nameOrId, string fileName)
        {
            ExecuteLD("installapp --" + ldType.ToName() + " " + nameOrId + " --filename \"" + fileName + "\"");
        }

        public static void InstallAppPackage(LDType ldType, string nameOrId, string packageName)
        {
            ExecuteLD("installapp --" + ldType.ToName() + " " + nameOrId + " --packagename " + packageName);
        }

        public static void UninstallApp(LDType ldType, string nameOrId, string packageName)
        {
            ExecuteLD("uninstallapp --" + ldType.ToName() + " " + nameOrId + " --packagename " + packageName);
        }

        public static void RunApp(LDType ldType, string nameOrId, string packageName)
        {
            ExecuteLD("runapp --" + ldType.ToName() + " " + nameOrId + " --packagename " + packageName);
        }

        public static void KillApp(LDType ldType, string nameOrId, string packageName)
        {
            ExecuteLD("killapp --" + ldType.ToName() + " " + nameOrId + " --packagename " + packageName);
        }

        public static void Locate(LDType ldType, string nameOrId, string lng, string lat)
        {
            ExecuteLD("locate --" + ldType.ToName() + " " + nameOrId + " --LLI " + lng + "," + lat);
        }

        public static void ChangeProperty(LDType ldType, string nameOrId, string cmd)
        {
            ExecuteLD("modify --" + ldType.ToName() + " " + nameOrId + " " + cmd);
        }

        public static void SetProp(LDType ldType, string nameOrId, string key, string value)
        {
            ExecuteLD("setprop --" + ldType.ToName() + " " + nameOrId + " --key " + key + " --value " + value);
        }

        public static string GetProp(LDType ldType, string nameOrId, string key)
        {
            return ExecuteLDForResult("getprop --" + ldType.ToName() + " " + nameOrId + " --key " + key);
        }

        public static string Adb(LDType ldType, string nameOrId, string cmd, int timeout = 10000, int retry = 1)
        {
            return ExecuteLDForResult("adb --" + ldType.ToName() + " \"" + nameOrId + "\" --command \"" + cmd + "\"", timeout, retry);
        }

        public static void DownCpu(LDType ldType, string nameOrId, string rate)
        {
            ExecuteLD("downcpu --" + ldType.ToName() + " " + nameOrId + " --rate " + rate);
        }

        public static void Backup(LDType ldType, string nameOrId, string filePath)
        {
            ExecuteLD("backup --" + ldType.ToName() + " " + nameOrId + " --file \"" + filePath + "\"");
        }

        public static void Restore(LDType ldType, string nameOrId, string filePath)
        {
            ExecuteLD("restore --" + ldType.ToName() + " " + nameOrId + " --file \"" + filePath + "\"");
        }

        public static void Action(LDType ldType, string nameOrId, string key, string value)
        {
            ExecuteLD("action --" + ldType.ToName() + " " + nameOrId + " --key " + key + " --value " + value);
        }

        public static void Scan(LDType ldType, string nameOrId, string filePath)
        {
            ExecuteLD("scan --" + ldType.ToName() + " " + nameOrId + " --file " + filePath);
        }

        public static void SortWnd()
        {
            ExecuteLD("sortWnd");
        }

        public static void ZoomIn(LDType ldType, string nameOrId)
        {
            ExecuteLD("zoomIn --" + ldType.ToName() + " " + nameOrId);
        }

        public static void ZoomOut(LDType ldType, string nameOrId)
        {
            ExecuteLD("zoomOut --" + ldType.ToName() + " " + nameOrId);
        }

        public static void Pull(LDType ldType, string nameOrId, string remoteFilePath, string localFilePath)
        {
            ExecuteLD("pull --" + ldType.ToName() + " " + nameOrId + " --remote \"" + remoteFilePath + "\" --local \"" + localFilePath + "\"");
        }

        public static void Push(LDType ldType, string nameOrId, string remoteFilePath, string localFilePath)
        {
            ExecuteLD("push --" + ldType.ToName() + " " + nameOrId + " --remote \"" + remoteFilePath + "\" --local \"" + localFilePath + "\"");
        }

        public static void BackupApp(LDType ldType, string nameOrId, string packageName, string filePath)
        {
            ExecuteLD("backupapp --" + ldType.ToName() + " " + nameOrId + " --packagename " + packageName + " --file \"" + filePath + "\"");
        }

        public static void RestoreApp(LDType ldType, string nameOrId, string packageName, string filePath)
        {
            ExecuteLD("restoreapp --" + ldType.ToName() + " " + nameOrId + " --packagename " + packageName + " --file \"" + filePath + "\"");
        }

        public static void GlobalConfig(LDType ldType, string nameOrId, string fps, string audio, string fastPlay, string cleanMode)
        {
            ExecuteLD("globalsetting --" + ldType.ToName() + " " + nameOrId + " --audio " + audio + " --fastplay " + fastPlay + " --cleanmode " + cleanMode);
        }

        public static List<string> GetDevices()
        {
            string[] array = ExecuteLDForResult("list").Trim().Split(new char[1] { '\n' });
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == "")
                {
                    return new List<string>();
                }

                array[i] = array[i].Trim();
            }

            return array.ToList();
        }

        public static List<string> GetDevicesRunning()
        {
            string[] array = ExecuteLDForResult("runninglist").Trim().Split(new char[1] { '\n' });
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == "")
                {
                    return new List<string>();
                }

                array[i] = array[i].Trim();
            }
            return array.ToList();
        }

        public static bool IsDeviceRunning(LDType ldType, string nameOrId)
        {
            return ExecuteLDForResult("isrunning --" + ldType.ToName() + " " + nameOrId).Trim() == "running";
        }

        public static List<LDevice> GetDevices2()
        {
            try
            {
                List<LDevice> list = new List<LDevice>();
                string[] array = ExecuteLDForResult("list2").Trim().Split(new char[1] { '\n' });
                foreach (string obj in array)
                {
                    LDevice lDevice = new LDevice();
                    string[] array2 = obj.Trim().Split(new char[1] { ',' });
                    lDevice.index = int.Parse(array2[0]);
                    lDevice.name = array2[1];
                    lDevice.topHandle = new IntPtr(Convert.ToInt32(array2[2], 16));
                    lDevice.bindHandle = new IntPtr(Convert.ToInt32(array2[3], 16));
                    lDevice.androidState = int.Parse(array2[4]);
                    lDevice.dnplayerPID = int.Parse(array2[5]);
                    lDevice.vboxPID = int.Parse(array2[6]);
                    list.Add(lDevice);
                }

                return list;
            }
            catch
            {
                return null;
            }
        }

        public static List<LDevice> GetDevices2Running()
        {
            try
            {
                List<LDevice> list = new List<LDevice>();
                List<string> devicesRunning = GetDevicesRunning();
                string[] array = ExecuteLDForResult("list2").Trim().Split(new char[1] { '\n' });
                foreach (string obj in array)
                {
                    LDevice lDevice = new LDevice();
                    string[] array2 = obj.Trim().Split(new char[1] { ',' });
                    lDevice.index = int.Parse(array2[0]);
                    lDevice.name = array2[1];
                    lDevice.topHandle = new IntPtr(Convert.ToInt32(array2[2], 16));
                    lDevice.bindHandle = new IntPtr(Convert.ToInt32(array2[3], 16));
                    lDevice.androidState = int.Parse(array2[4]);
                    lDevice.dnplayerPID = int.Parse(array2[5]);
                    lDevice.vboxPID = int.Parse(array2[6]);
                    if (devicesRunning.Contains(lDevice.name))
                    {
                        list.Add(lDevice);
                    }
                }

                return list;
            }
            catch
            {
                return null;
            }
        }

        public static void ExecuteLD(string cmd)
        {
            Process process = new Process();
            process.StartInfo.FileName = PathLD;
            process.StartInfo.Arguments = cmd;
            process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.CreateNoWindow = true;
            process.EnableRaisingEvents = true;
            process.Start();
            process.WaitForExit();
            process.Close();
        }
        public static void KillAdb()
        {
            ExecuteLD("adb kill-server");
        }
        public static void StartServerAdb()
        {
            ExecuteLD("adb start-server");
        }
        public static void GetPingAdb()
        {
            ExecuteLD("adb devices");
        }
        public static string ExecuteLDForResult(string cmdCommand, int timeout = 10000, int retry = 2)
        {
            try
            {
                Process process = new Process();
                process.StartInfo = new ProcessStartInfo
                {
                    FileName = PathLD,
                    Arguments = cmdCommand,
                    CreateNoWindow = true,
                    UseShellExecute = false,
                    WindowStyle = ProcessWindowStyle.Hidden,
                    RedirectStandardInput = true,
                    RedirectStandardOutput = true
                };
                process.Start();
                process.WaitForExit(timeout);
                process.Kill();
                return process.StandardOutput.ReadToEnd();
            }
            catch
            {
                return null;
            }
        }

        public static Point GetScreenResolution(LDType ldType, string nameOrId)
        {
            string text = Adb(ldType, nameOrId, "shell dumpsys display | grep \"mCurrentDisplayRect\"");
            string text2 = text.Substring(text.IndexOf("- ", StringComparison.Ordinal));
            string[] array = text2.Substring(text2.IndexOf(' '), text2.IndexOf(')') - text2.IndexOf(' ')).Split(new char[1] { ',' });
            return new Point(Convert.ToInt32(array[0].Trim()), Convert.ToInt32(array[1].Trim()));
        }

        public static void TapByPercent(LDType ldType, string nameOrId, double x, double y, int count = 1)
        {
            Point screenResolution = GetScreenResolution(ldType, nameOrId);
            int x2 = (int)(x * ((double)screenResolution.X * 1.0 / 100.0));
            int y2 = (int)(y * ((double)screenResolution.Y * 1.0 / 100.0));
            Tap(ldType, nameOrId, x2, y2, count);
        }

        public static void Tap(LDType ldType, string nameOrId, int x, int y, int count = 1)
        {
            string text = $"shell input tap {x} {y}";
            for (int i = 1; i < count; i++)
            {
                text = text + " && " + text;
            }
            Adb(ldType, nameOrId, text, 200);
        }

        public static void PressKey(LDType ldType, string nameOrId, LDKeyEvent key)
        {
            Adb(ldType, nameOrId, $"shell input keyevent {key}", 200);
        }

        public static void SwipeByPercent(LDType ldType, string nameOrId, double x1, double y1, double x2, double y2, int duration = 100)
        {
            Point screenResolution = GetScreenResolution(ldType, nameOrId);
            int x3 = (int)(x1 * ((double)screenResolution.X * 1.0 / 100.0));
            int y3 = (int)(y1 * ((double)screenResolution.Y * 1.0 / 100.0));
            int x4 = (int)(x2 * ((double)screenResolution.X * 1.0 / 100.0));
            int y4 = (int)(y2 * ((double)screenResolution.Y * 1.0 / 100.0));
            Swipe(ldType, nameOrId, x3, y3, x4, y4, duration);
        }

        public static void Swipe(LDType ldType, string nameOrId, int x1, int y1, int x2, int y2, int duration = 100)
        {
            Adb(ldType, nameOrId, $"shell input swipe {x1} {y1} {x2} {y2} {duration}", 200);
        }

        public static void InputText(LDType ldType, string nameOrId, string text)
        {
            Adb(ldType, nameOrId, "shell input text \"" + text.Replace(" ", "%s").Replace("&", "\\&").Replace("<", "\\<")
                .Replace(">", "\\>")
                .Replace("?", "\\?")
                .Replace(":", "\\:")
                .Replace("{", "\\{")
                .Replace("}", "\\}")
                .Replace("[", "\\[")
                .Replace("]", "\\]")
            .Replace("|", "\\|") + "\"");
        }

        public static void LongPress(LDType ldType, string nameOrId, int x, int y, int duration = 100)
        {
            Swipe(ldType, nameOrId, x, y, x, y, duration);
        }

        public static Bitmap ScreenShoot(LDType ldType, string nameOrId, bool isDeleteImageAfterCapture = true, string fileName = "screenShoot.png")
        {
            string text = ldType.ToString() + "_" + nameOrId;
            string text2 = Path.GetFileNameWithoutExtension(fileName) + text + Path.GetExtension(fileName);
            if (File.Exists(text2))
            {
                try
                {
                    File.Delete(text2);
                }
                catch (Exception)
                {
                }
            }

            string filename = Directory.GetCurrentDirectory() + "\\" + text2;
            string text3 = "\"" + Directory.GetCurrentDirectory().Replace("\\\\", "\\") + "\"";
            string cmd = "shell screencap -p \"/sdcard/" + text2 + "\"";
            string cmd2 = "pull /sdcard/" + text2 + " " + text3;
            Adb(ldType, nameOrId, cmd);
            Adb(ldType, nameOrId, cmd2);
            Bitmap result = null;
            try
            {
                using Bitmap original = new Bitmap(filename);
                result = new Bitmap(original);
            }
            catch
            {
            }

            if (!isDeleteImageAfterCapture)
            {
                return result;
            }

            try
            {
                File.Delete(text2);
            }
            catch
            {
            }

            try
            {
                Adb(ldType, nameOrId, "shell \"rm /sdcard/" + text2 + "\"");
                return result;
            }
            catch
            {
                return result;
            }
        }

        public static void PlanModeOn(LDType ldType, string nameOrId, CancellationToken cancellationToken)
        {
            if (!cancellationToken.IsCancellationRequested)
            {
                Adb(ldType, nameOrId, " settings put global airplane_mode_on 1");
                Adb(ldType, nameOrId, "am broadcast -a android.intent.action.AIRPLANE_MODE");
            }
        }

        public static void PlanModeOff(LDType ldType, string nameOrId, CancellationToken cancellationToken)
        {
            if (!cancellationToken.IsCancellationRequested)
            {
                Adb(ldType, nameOrId, " settings put global airplane_mode_on 1");
                Adb(ldType, nameOrId, "am broadcast -a android.intent.action.AIRPLANE_MODE");
            }
        }

        public static void Delay(double delayTime)
        {
            for (double num = 0.0; num < delayTime; num += 100.0)
            {
                Thread.Sleep(TimeSpan.FromMilliseconds(100.0));
            }
        }

        public static Point? FindImage(LDType ldType, string nameOrId, string imagePath, int count = 5)
        {
            FileInfo[] files = new DirectoryInfo(imagePath).GetFiles();
            do
            {
                Bitmap bitmap = null;
                int num = 3;
                do
                {
                    try
                    {
                        bitmap = ScreenShoot(ldType, nameOrId);
                    }
                    catch (Exception)
                    {
                        num--;
                        Delay(1000.0);
                        continue;
                    }

                    break;
                }
                while (num > 0);
                if (bitmap == null)
                {
                    return null;
                }

                Point? result = null;
                FileInfo[] array = files;
                for (int i = 0; i < array.Length; i++)
                {
                    Bitmap subBitmap = (Bitmap)Image.FromFile(array[i].FullName);
                    result = ImageScanOpenCV.FindOutPoint(bitmap, subBitmap);
                    if (result.HasValue)
                    {
                        break;
                    }
                }

                if (result.HasValue)
                {
                    return result;
                }

                Delay(2000.0);
                count--;
            }
            while (count > 0);
            return null;
        }

        public static bool FindImageAndClick(LDType ldType, string nameOrId, string imagePath, int count = 5)
        {
            Point? point = FindImage(ldType, nameOrId, imagePath, count);
            if (!point.HasValue)
            {
                return false;
            }

            Tap(ldType, nameOrId, point.Value.X, point.Value.Y);
            return true;
        }

        public static void Back(LDType ldType, string nameOrId)
        {
            PressKey(ldType, nameOrId, LDKeyEvent.KEYCODE_BACK);
        }

        public static void Home(LDType ldType, string nameOrId)
        {
            PressKey(ldType, nameOrId, LDKeyEvent.KEYCODE_HOME);
        }

        public static void Menu(LDType ldType, string nameOrId)
        {
            PressKey(ldType, nameOrId, LDKeyEvent.KEYCODE_APP_SWITCH);
        }

        public static bool TapImg(LDType ldType, string nameOrId, Bitmap imgFind)
        {
            Bitmap subBitmap = (Bitmap)imgFind.Clone();
            Point? point = ImageScanOpenCV.FindOutPoint(ScreenShoot(ldType, nameOrId), subBitmap);
            if (!point.HasValue)
            {
                return false;
            }

            Tap(ldType, nameOrId, point.Value.X, point.Value.Y);
            return true;
        }

        public static void ChangeProxy(LDType ldType, string nameOrId, string ipProxy, string portProxy)
        {
            Adb(ldType, nameOrId, "shell settings put global http_proxy " + ipProxy + ":" + portProxy);
        }

        public static void RemoveProxy(LDType ldType, string nameOrId)
        {
            Adb(ldType, nameOrId, "shell settings put global http_proxy :0");
        }
    }
    public class LDevice
    {
        public int index;

        public string name;

        public IntPtr topHandle;

        public IntPtr bindHandle;

        public int androidState;

        public int dnplayerPID;

        public int vboxPID;

        public int Index
        {
            get
            {
                return index;
            }
            set
            {
                index = value;
            }
        }

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        public IntPtr TopHandle
        {
            get
            {
                return topHandle;
            }
            set
            {
                topHandle = value;
            }
        }

        public IntPtr BindHandle
        {
            get
            {
                return bindHandle;
            }
            set
            {
                bindHandle = value;
            }
        }

        public int AndroidState
        {
            get
            {
                return androidState;
            }
            set
            {
                androidState = value;
            }
        }

        public int DnplayerPid
        {
            get
            {
                return dnplayerPID;
            }
            set
            {
                dnplayerPID = value;
            }
        }

        public int VboxPid
        {
            get
            {
                return vboxPID;
            }
            set
            {
                vboxPID = value;
            }
        }
    }
    public enum LDKeyEvent
    {
        KEYCODE_0 = 0,
        KEYCODE_SOFT_LEFT = 1,
        KEYCODE_SOFT_RIGHT = 2,
        KEYCODE_HOME = 3,
        KEYCODE_BACK = 4,
        KEYCODE_CALL = 5,
        KEYCODE_ENDCALL = 6,
        KEYCODE_0_ = 7,
        KEYCODE_1 = 8,
        KEYCODE_2 = 9,
        KEYCODE_3 = 10,
        KEYCODE_4 = 11,
        KEYCODE_5 = 12,
        KEYCODE_6 = 13,
        KEYCODE_7 = 14,
        KEYCODE_8 = 0xF,
        KEYCODE_9 = 0x10,
        KEYCODE_STAR = 17,
        KEYCODE_POUND = 18,
        KEYCODE_DPAD_UP = 19,
        KEYCODE_DPAD_DOWN = 20,
        KEYCODE_DPAD_LEFT = 21,
        KEYCODE_DPAD_RIGHT = 22,
        KEYCODE_DPAD_CENTER = 23,
        KEYCODE_VOLUME_UP = 24,
        KEYCODE_VOLUME_DOWN = 25,
        KEYCODE_POWER = 26,
        KEYCODE_CAMERA = 27,
        KEYCODE_CLEAR = 28,
        KEYCODE_A = 29,
        KEYCODE_B = 30,
        KEYCODE_C = 0x1F,
        KEYCODE_D = 0x20,
        KEYCODE_E = 33,
        KEYCODE_F = 34,
        KEYCODE_G = 35,
        KEYCODE_H = 36,
        KEYCODE_I = 37,
        KEYCODE_J = 38,
        KEYCODE_K = 39,
        KEYCODE_L = 40,
        KEYCODE_M = 41,
        KEYCODE_N = 42,
        KEYCODE_O = 43,
        KEYCODE_P = 44,
        KEYCODE_Q = 45,
        KEYCODE_R = 46,
        KEYCODE_S = 47,
        KEYCODE_T = 48,
        KEYCODE_U = 49,
        KEYCODE_V = 50,
        KEYCODE_W = 51,
        KEYCODE_X = 52,
        KEYCODE_Y = 53,
        KEYCODE_Z = 54,
        KEYCODE_COMMA = 55,
        KEYCODE_PERIOD = 56,
        KEYCODE_ALT_LEFT = 57,
        KEYCODE_ALT_RIGHT = 58,
        KEYCODE_SHIFT_LEFT = 59,
        KEYCODE_SHIFT_RIGHT = 60,
        KEYCODE_TAB = 61,
        KEYCODE_SPACE = 62,
        KEYCODE_SYM = 0x3F,
        KEYCODE_EXPLORER = 0x40,
        KEYCODE_ENVELOPE = 65,
        KEYCODE_ENTER = 66,
        KEYCODE_DEL = 67,
        KEYCODE_GRAVE = 68,
        KEYCODE_MINUS = 69,
        KEYCODE_EQUALS = 70,
        KEYCODE_LEFT_BRACKET = 71,
        KEYCODE_RIGHT_BRACKET = 72,
        KEYCODE_BACKSLASH = 73,
        KEYCODE_SEMICOLON = 74,
        KEYCODE_APOSTROPHE = 75,
        KEYCODE_SLASH = 76,
        KEYCODE_AT = 77,
        KEYCODE_NUM = 78,
        KEYCODE_HEADSETHOOK = 79,
        KEYCODE_FOCUS = 80,
        KEYCODE_PLUS = 81,
        KEYCODE_MENU = 82,
        KEYCODE_NOTIFICATION = 83,
        KEYCODE_APP_SWITCH = 187
    }
}
