using System;
using System.Threading;
using System.IO;
using System.Net;

using System.Runtime.InteropServices;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            var filename = "Image.jpg";
            //Download image from internet
            new WebClient().DownloadFile("https://img3.thuthuatphanmem.vn/uploads/2019/06/13/anh-nen-may-tinh-dep_095242594.jpg", filename);
            //get the directory from where the current file was saved
            string path = AppDomain.CurrentDomain.BaseDirectory;
            ChangeWallpaper(path + filename); //call func ChangeWallpaper
            Thread.Sleep(1000);
            File.Delete(path + filename);//Delete file image which just have downloaded
        }
        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool SystemParametersInfo(uint uiAction, uint uiParam, String pvParam, uint fWinIni);
        private const uint SPI_SETDESKWALLPAPER = 0x14; //Defines action for setting the wallpaper
        private const uint SPIF_UPDATEINIFILE = 0x1;//Update the user's information
        private const uint SPIF_SENDWININICHANGE = 0x2; //Tell other applications about the change in status.
        private static void ChangeWallpaper(string file_name)
        {
            uint flag = 0;
            SystemParametersInfo(SPI_SETDESKWALLPAPER, 0, file_name, flag);
        }
    }
}