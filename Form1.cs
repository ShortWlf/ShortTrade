using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CefSharp.MinimalExample.WinForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            // set this.FormBorderStyle to None here if needed
            // if set to none, make sure you have a way to close the form!
        }
        private const int WM_NCHITTEST = 0x84;
        private const int HTCLIENT = 0x1;
        private const int HTCAPTION = 0x2;

        ///
        /// Handling the window messages
        ///
        protected override void WndProc(ref Message message)
        {
            base.WndProc(ref message);

            if (message.Msg == WM_NCHITTEST && (int)message.Result == HTCLIENT)
                message.Result = (IntPtr)HTCAPTION;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
        }

        [DllImport("user32.dll")]
        internal static extern IntPtr SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32.dll")]
        internal static extern bool ShowWindow(IntPtr hWnd, int nCmdShow); //ShowWindow needs an IntPtr

        private static void FocusProcess()
        {
            IntPtr hWnd; //change this to IntPtr
            Process[] processRunning = Process.GetProcesses();
            foreach (Process pr in processRunning)
            {
                if (pr.ProcessName == "PathOfExileSteam")
                {
                    hWnd = pr.MainWindowHandle; //use it as IntPtr not int
                    ShowWindow(hWnd, 3);
                    SetForegroundWindow(hWnd); //set to topmost
                }
            }
        }


        private void Form1_DragDrop(object sender, DragEventArgs e)
        {

        }

        private void Form1_DoubleClick(object sender, EventArgs e)
        {
            //           BrowserForm BrowserForm = new BrowserForm();
            //           BrowserForm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BrowserForm BrowserForm = new BrowserForm();
            BrowserForm.Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            FocusProcess();
            SendKeys.Send("{ENTER}");
            SendKeys.Send("/");
            SendKeys.Send("h");
            SendKeys.Send("i");
            SendKeys.Send("d");
            SendKeys.Send("e");
            SendKeys.Send("o");
            SendKeys.Send("u");
            SendKeys.Send("t");
            SendKeys.Send("{ENTER}");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            BrowserForm BrowserForm = new BrowserForm();
            BrowserForm.Show();
        }
    }
}
