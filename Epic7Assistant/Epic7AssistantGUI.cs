using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Epic7Assistant.Properties;
using System.IO;

namespace Epic7Assistant
{
    public partial class Epic7AssistantGUI : Form
    {

        private Point gStartLocation;

        private bool gDragging;

        private int[] gStartPoint;

        private string gLogFile;

        bool g1080p;
        bool g1440p;
        bool g4k;

        bool gHunt;
        bool gAP;
        bool gEvent;
        bool gExped;

        public Epic7AssistantGUI()
        {
            InitializeComponent();

            gStartPoint = new int[2];
            gLogFile = Environment.GetEnvironmentVariable("USERPROFILE") + "\\Epic7AssistantLogs_Logs.txt";
        }

        private void m_CheckBox1080_CheckedChanged(object sender, EventArgs e)
        {
       
             g1080p = true;
             g1440p = false;
             g4k = false;
             m_CheckBox1440.Checked = false;
             m_CheckBox4k.Checked = false;
             CheckAllFields();
          
            
        }

        private void m_CheckBox1440_CheckedChanged(object sender, EventArgs e)
        {
            g1080p = false;
            g1440p = true;
            g4k = false;
            m_CheckBox1080.Checked = false;
            m_CheckBox4k.Checked = false;
            CheckAllFields();
        }

        private void m_CheckBox4k_CheckedChanged(object sender, EventArgs e)
        {
            g1080p = false;
            g1440p = false;
            g4k = true;
            m_CheckBox1080.Checked = false;
            m_CheckBox1440.Checked = false;
            CheckAllFields();
        }

        private void m_ButtonCloseApp_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void m_ButtonMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        public void CreateLogFile()
        {
            if (File.Exists(gLogFile))
            {
                File.Delete(gLogFile);
            }

            File.Create(gLogFile).Dispose();
        }

        public void UpdateLogs(string message)
        {
            if (InvokeRequired)
            {
                Invoke((MethodInvoker)delegate { UpdateLogs(message); });
            }
            else
            {
                File.AppendAllText(gLogFile, DateTime.Now + ": " + message + Environment.NewLine);

                m_RichTextBoxLoggingOutput.Text += DateTime.Now + ":" + message + Environment.NewLine;
            }
        }

        private void m_PanelTitleBar_MouseMove(object sender, MouseEventArgs e)
        {
            if (gDragging)
            {
                Point p = PointToScreen(new Point(m_PanelTitleBar.Location.X + e.Location.X, m_PanelTitleBar.Location.Y + e.Location.Y));

                Location = new Point(gStartPoint[0] + p.X - gStartLocation.X, gStartPoint[1] + p.Y - gStartLocation.Y);
            }
        }

        private void m_PanelTitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
            {
                float ratio = (float)(e.Location.X) / (float)(m_PanelTitleBar.Width);
                this.WindowState = FormWindowState.Normal;
                Point p = PointToScreen(new Point(m_PanelTitleBar.Location.X + e.Location.X,
                                                    m_PanelTitleBar.Location.Y + e.Location.Y));

                gStartLocation = p;
                gStartPoint[0] = Location.X;
                gStartPoint[1] = Location.Y;

            }
            else
            {
                gStartLocation = PointToScreen(new Point(m_PanelTitleBar.Location.X + e.Location.X,
                                                            m_PanelTitleBar.Location.Y + e.Location.Y));

                gStartPoint[0] = Location.X;
                gStartPoint[1] = Location.Y;
            }
            gDragging = true;
        }

        private void m_PanelTitleBar_MouseUp(object sender, MouseEventArgs e)
        {
            gDragging = false;

            Point p = PointToScreen(e.Location);
            if (p.Y < 2)
            {
                this.WindowState = FormWindowState.Maximized;
            }
        }

        async private void m_ButtonRun_Click(object sender, EventArgs e)
        {
            Globals.Cancelled = false;

            Task task1 = Task.Factory.StartNew(() => new Automations(this, gHunt, gAP, gEvent, gExped, g1080p, g1440p, g4k));

        }

        private void m_CheckBoxHunt_CheckedChanged(object sender, EventArgs e)
        {
            gHunt = true;
            gAP = false;
            gEvent = false;
            gExped = false;
            m_CheckBoxAP.Checked = false;
            m_CheckBoxEvent.Checked = false;
            m_CheckBoxExped.Checked = false;
            CheckAllFields();
        }

        private void m_CheckBoxAP_CheckedChanged(object sender, EventArgs e)
        {
            gHunt = false;
            gAP = true;
            gEvent = false;
            gExped = false;
            m_CheckBoxHunt.Checked = false;
            m_CheckBoxEvent.Checked = false;
            m_CheckBoxExped.Checked = false;
            CheckAllFields();
        }

        private void m_CheckBoxEvent_CheckedChanged(object sender, EventArgs e)
        {
            gHunt = false;
            gAP = false;
            gEvent = true;
            gExped = false;
            m_CheckBoxHunt.Checked = false;
            m_CheckBoxAP.Checked = false;
            m_CheckBoxExped.Checked = false;
            CheckAllFields();
        }

        private void m_CheckBoxExped_CheckedChanged(object sender, EventArgs e)
        {
            gHunt = false;
            gAP = false;
            gEvent = false;
            gExped = true;
            m_CheckBoxHunt.Checked = false;
            m_CheckBoxAP.Checked = false;
            m_CheckBoxEvent.Checked = false;
            CheckAllFields();
        }

        private void m_ButtonCancel_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Cancelling...");
            Globals.Cancelled = true;
        }

        private void m_ButtonLogs_Click(object sender, EventArgs e)
        {
            m_PanelLogs.BringToFront();
        }

        private void m_ButtonAuto_Click(object sender, EventArgs e)
        {
            m_PanelAuto.BringToFront();
        }

        private void CheckAllFields()
        {
            if((m_CheckBox1080.Checked == true || m_CheckBox1440.Checked == true || m_CheckBox4k.Checked == true) && (m_CheckBoxHunt.Checked == true || m_CheckBoxAP.Checked == true || m_CheckBoxEvent.Checked == true || m_CheckBoxExped.Checked == true))
            {
                m_ButtonRun.Enabled = true;
            }
            else
            {
                m_ButtonRun.Enabled = false;
            }
        }

    }
}
