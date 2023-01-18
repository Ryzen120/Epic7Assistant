
namespace Epic7Assistant
{
    partial class Epic7AssistantGUI
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Epic7AssistantGUI));
            this.m_PanelTitleBar = new System.Windows.Forms.Panel();
            this.m_ButtonCloseApp = new System.Windows.Forms.Button();
            this.m_ButtonMinimize = new System.Windows.Forms.Button();
            this.m_LabelTitle = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.m_ButtonLogs = new System.Windows.Forms.Button();
            this.m_ButtonAuto = new System.Windows.Forms.Button();
            this.m_PanelLogs = new System.Windows.Forms.Panel();
            this.m_LabelLoggingOutput = new System.Windows.Forms.Label();
            this.m_RichTextBoxLoggingOutput = new System.Windows.Forms.RichTextBox();
            this.m_PanelAuto = new System.Windows.Forms.Panel();
            this.m_LabelStepFour = new System.Windows.Forms.Label();
            this.m_LabelStepThree = new System.Windows.Forms.Label();
            this.m_LabelStepTwo = new System.Windows.Forms.Label();
            this.m_LabelStepOne = new System.Windows.Forms.Label();
            this.m_ButtonCancel = new System.Windows.Forms.Button();
            this.m_CheckBoxExped = new System.Windows.Forms.CheckBox();
            this.m_CheckBoxEvent = new System.Windows.Forms.CheckBox();
            this.m_CheckBoxAP = new System.Windows.Forms.CheckBox();
            this.m_CheckBoxHunt = new System.Windows.Forms.CheckBox();
            this.m_CheckBox4k = new System.Windows.Forms.CheckBox();
            this.m_CheckBox1440 = new System.Windows.Forms.CheckBox();
            this.m_CheckBox1080 = new System.Windows.Forms.CheckBox();
            this.m_ButtonRun = new System.Windows.Forms.Button();
            this.m_PictureBox = new System.Windows.Forms.PictureBox();
            this.m_PanelTitleBar.SuspendLayout();
            this.panel1.SuspendLayout();
            this.m_PanelLogs.SuspendLayout();
            this.m_PanelAuto.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_PictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // m_PanelTitleBar
            // 
            this.m_PanelTitleBar.BackColor = System.Drawing.Color.Black;
            this.m_PanelTitleBar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_PanelTitleBar.Controls.Add(this.m_PictureBox);
            this.m_PanelTitleBar.Controls.Add(this.m_ButtonCloseApp);
            this.m_PanelTitleBar.Controls.Add(this.m_ButtonMinimize);
            this.m_PanelTitleBar.Controls.Add(this.m_LabelTitle);
            this.m_PanelTitleBar.Location = new System.Drawing.Point(-2, -2);
            this.m_PanelTitleBar.Name = "m_PanelTitleBar";
            this.m_PanelTitleBar.Size = new System.Drawing.Size(1319, 72);
            this.m_PanelTitleBar.TabIndex = 1;
            this.m_PanelTitleBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.m_PanelTitleBar_MouseDown);
            this.m_PanelTitleBar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.m_PanelTitleBar_MouseMove);
            this.m_PanelTitleBar.MouseUp += new System.Windows.Forms.MouseEventHandler(this.m_PanelTitleBar_MouseUp);
            // 
            // m_ButtonCloseApp
            // 
            this.m_ButtonCloseApp.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_ButtonCloseApp.ForeColor = System.Drawing.Color.Black;
            this.m_ButtonCloseApp.Location = new System.Drawing.Point(1260, 19);
            this.m_ButtonCloseApp.Name = "m_ButtonCloseApp";
            this.m_ButtonCloseApp.Size = new System.Drawing.Size(34, 30);
            this.m_ButtonCloseApp.TabIndex = 5;
            this.m_ButtonCloseApp.Text = "X";
            this.m_ButtonCloseApp.UseVisualStyleBackColor = true;
            this.m_ButtonCloseApp.Click += new System.EventHandler(this.m_ButtonCloseApp_Click);
            // 
            // m_ButtonMinimize
            // 
            this.m_ButtonMinimize.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_ButtonMinimize.ForeColor = System.Drawing.Color.Black;
            this.m_ButtonMinimize.Location = new System.Drawing.Point(1220, 19);
            this.m_ButtonMinimize.Name = "m_ButtonMinimize";
            this.m_ButtonMinimize.Size = new System.Drawing.Size(34, 30);
            this.m_ButtonMinimize.TabIndex = 4;
            this.m_ButtonMinimize.Text = "-";
            this.m_ButtonMinimize.UseVisualStyleBackColor = true;
            this.m_ButtonMinimize.Click += new System.EventHandler(this.m_ButtonMinimize_Click);
            // 
            // m_LabelTitle
            // 
            this.m_LabelTitle.AutoSize = true;
            this.m_LabelTitle.Font = new System.Drawing.Font("Century Gothic", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_LabelTitle.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.m_LabelTitle.Location = new System.Drawing.Point(548, 19);
            this.m_LabelTitle.Name = "m_LabelTitle";
            this.m_LabelTitle.Size = new System.Drawing.Size(213, 33);
            this.m_LabelTitle.TabIndex = 0;
            this.m_LabelTitle.Text = "Epic 7 Assistant";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.Controls.Add(this.m_ButtonLogs);
            this.panel1.Controls.Add(this.m_ButtonAuto);
            this.panel1.Location = new System.Drawing.Point(0, 69);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(98, 683);
            this.panel1.TabIndex = 35;
            // 
            // m_ButtonLogs
            // 
            this.m_ButtonLogs.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.m_ButtonLogs.Font = new System.Drawing.Font("Comic Sans MS", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_ButtonLogs.ForeColor = System.Drawing.SystemColors.Control;
            this.m_ButtonLogs.Location = new System.Drawing.Point(3, 69);
            this.m_ButtonLogs.Name = "m_ButtonLogs";
            this.m_ButtonLogs.Size = new System.Drawing.Size(92, 49);
            this.m_ButtonLogs.TabIndex = 3;
            this.m_ButtonLogs.Text = "Logs";
            this.m_ButtonLogs.UseVisualStyleBackColor = true;
            this.m_ButtonLogs.Click += new System.EventHandler(this.m_ButtonLogs_Click);
            // 
            // m_ButtonAuto
            // 
            this.m_ButtonAuto.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.m_ButtonAuto.Font = new System.Drawing.Font("Comic Sans MS", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_ButtonAuto.ForeColor = System.Drawing.SystemColors.Control;
            this.m_ButtonAuto.Location = new System.Drawing.Point(3, 14);
            this.m_ButtonAuto.Name = "m_ButtonAuto";
            this.m_ButtonAuto.Size = new System.Drawing.Size(92, 49);
            this.m_ButtonAuto.TabIndex = 0;
            this.m_ButtonAuto.Text = "Auto";
            this.m_ButtonAuto.UseVisualStyleBackColor = true;
            this.m_ButtonAuto.Click += new System.EventHandler(this.m_ButtonAuto_Click);
            // 
            // m_PanelLogs
            // 
            this.m_PanelLogs.BackColor = System.Drawing.Color.Silver;
            this.m_PanelLogs.Controls.Add(this.m_LabelLoggingOutput);
            this.m_PanelLogs.Controls.Add(this.m_RichTextBoxLoggingOutput);
            this.m_PanelLogs.Location = new System.Drawing.Point(98, 69);
            this.m_PanelLogs.Name = "m_PanelLogs";
            this.m_PanelLogs.Size = new System.Drawing.Size(1218, 683);
            this.m_PanelLogs.TabIndex = 44;
            // 
            // m_LabelLoggingOutput
            // 
            this.m_LabelLoggingOutput.AutoSize = true;
            this.m_LabelLoggingOutput.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_LabelLoggingOutput.Location = new System.Drawing.Point(24, 10);
            this.m_LabelLoggingOutput.Name = "m_LabelLoggingOutput";
            this.m_LabelLoggingOutput.Size = new System.Drawing.Size(129, 19);
            this.m_LabelLoggingOutput.TabIndex = 22;
            this.m_LabelLoggingOutput.Text = "Logging Output";
            // 
            // m_RichTextBoxLoggingOutput
            // 
            this.m_RichTextBoxLoggingOutput.BackColor = System.Drawing.Color.Black;
            this.m_RichTextBoxLoggingOutput.ForeColor = System.Drawing.Color.DodgerBlue;
            this.m_RichTextBoxLoggingOutput.Location = new System.Drawing.Point(28, 32);
            this.m_RichTextBoxLoggingOutput.Name = "m_RichTextBoxLoggingOutput";
            this.m_RichTextBoxLoggingOutput.ReadOnly = true;
            this.m_RichTextBoxLoggingOutput.Size = new System.Drawing.Size(1169, 598);
            this.m_RichTextBoxLoggingOutput.TabIndex = 21;
            this.m_RichTextBoxLoggingOutput.Text = "";
            // 
            // m_PanelAuto
            // 
            this.m_PanelAuto.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.m_PanelAuto.BackColor = System.Drawing.Color.Silver;
            this.m_PanelAuto.Controls.Add(this.m_LabelStepFour);
            this.m_PanelAuto.Controls.Add(this.m_LabelStepThree);
            this.m_PanelAuto.Controls.Add(this.m_LabelStepTwo);
            this.m_PanelAuto.Controls.Add(this.m_LabelStepOne);
            this.m_PanelAuto.Controls.Add(this.m_ButtonCancel);
            this.m_PanelAuto.Controls.Add(this.m_CheckBoxExped);
            this.m_PanelAuto.Controls.Add(this.m_CheckBoxEvent);
            this.m_PanelAuto.Controls.Add(this.m_CheckBoxAP);
            this.m_PanelAuto.Controls.Add(this.m_CheckBoxHunt);
            this.m_PanelAuto.Controls.Add(this.m_CheckBox4k);
            this.m_PanelAuto.Controls.Add(this.m_CheckBox1440);
            this.m_PanelAuto.Controls.Add(this.m_CheckBox1080);
            this.m_PanelAuto.Controls.Add(this.m_ButtonRun);
            this.m_PanelAuto.Location = new System.Drawing.Point(97, 69);
            this.m_PanelAuto.Name = "m_PanelAuto";
            this.m_PanelAuto.Size = new System.Drawing.Size(1219, 683);
            this.m_PanelAuto.TabIndex = 44;
            // 
            // m_LabelStepFour
            // 
            this.m_LabelStepFour.AutoSize = true;
            this.m_LabelStepFour.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_LabelStepFour.Location = new System.Drawing.Point(26, 214);
            this.m_LabelStepFour.Name = "m_LabelStepFour";
            this.m_LabelStepFour.Size = new System.Drawing.Size(333, 16);
            this.m_LabelStepFour.TabIndex = 41;
            this.m_LabelStepFour.Text = "4. Select your assistant of choice then click run.";
            // 
            // m_LabelStepThree
            // 
            this.m_LabelStepThree.AutoSize = true;
            this.m_LabelStepThree.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_LabelStepThree.Location = new System.Drawing.Point(26, 105);
            this.m_LabelStepThree.Name = "m_LabelStepThree";
            this.m_LabelStepThree.Size = new System.Drawing.Size(253, 16);
            this.m_LabelStepThree.TabIndex = 40;
            this.m_LabelStepThree.Text = "3. Select resolution of main display.";
            // 
            // m_LabelStepTwo
            // 
            this.m_LabelStepTwo.AutoSize = true;
            this.m_LabelStepTwo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_LabelStepTwo.Location = new System.Drawing.Point(26, 69);
            this.m_LabelStepTwo.Name = "m_LabelStepTwo";
            this.m_LabelStepTwo.Size = new System.Drawing.Size(508, 16);
            this.m_LabelStepTwo.TabIndex = 39;
            this.m_LabelStepTwo.Text = "2. Move BlueStacks to main display and set BlueStacks to be full screen.";
            // 
            // m_LabelStepOne
            // 
            this.m_LabelStepOne.AutoSize = true;
            this.m_LabelStepOne.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_LabelStepOne.Location = new System.Drawing.Point(26, 33);
            this.m_LabelStepOne.Name = "m_LabelStepOne";
            this.m_LabelStepOne.Size = new System.Drawing.Size(653, 16);
            this.m_LabelStepOne.TabIndex = 38;
            this.m_LabelStepOne.Text = "1. Go to Windows settings -> Display -> Set monitor where BlueStacks will run to " +
    "main display. ";
            // 
            // m_ButtonCancel
            // 
            this.m_ButtonCancel.Location = new System.Drawing.Point(626, 585);
            this.m_ButtonCancel.Name = "m_ButtonCancel";
            this.m_ButtonCancel.Size = new System.Drawing.Size(104, 30);
            this.m_ButtonCancel.TabIndex = 37;
            this.m_ButtonCancel.Text = "Cancel";
            this.m_ButtonCancel.UseVisualStyleBackColor = true;
            this.m_ButtonCancel.Click += new System.EventHandler(this.m_ButtonCancel_Click);
            // 
            // m_CheckBoxExped
            // 
            this.m_CheckBoxExped.AutoSize = true;
            this.m_CheckBoxExped.Location = new System.Drawing.Point(48, 314);
            this.m_CheckBoxExped.Name = "m_CheckBoxExped";
            this.m_CheckBoxExped.Size = new System.Drawing.Size(80, 17);
            this.m_CheckBoxExped.TabIndex = 36;
            this.m_CheckBoxExped.Text = "Expeditions";
            this.m_CheckBoxExped.UseVisualStyleBackColor = true;
            this.m_CheckBoxExped.CheckedChanged += new System.EventHandler(this.m_CheckBoxExped_CheckedChanged);
            // 
            // m_CheckBoxEvent
            // 
            this.m_CheckBoxEvent.AutoSize = true;
            this.m_CheckBoxEvent.Location = new System.Drawing.Point(48, 291);
            this.m_CheckBoxEvent.Name = "m_CheckBoxEvent";
            this.m_CheckBoxEvent.Size = new System.Drawing.Size(54, 17);
            this.m_CheckBoxEvent.TabIndex = 34;
            this.m_CheckBoxEvent.Text = "Event";
            this.m_CheckBoxEvent.UseVisualStyleBackColor = true;
            this.m_CheckBoxEvent.CheckedChanged += new System.EventHandler(this.m_CheckBoxEvent_CheckedChanged);
            // 
            // m_CheckBoxAP
            // 
            this.m_CheckBoxAP.AutoSize = true;
            this.m_CheckBoxAP.Location = new System.Drawing.Point(48, 267);
            this.m_CheckBoxAP.Name = "m_CheckBoxAP";
            this.m_CheckBoxAP.Size = new System.Drawing.Size(40, 17);
            this.m_CheckBoxAP.TabIndex = 33;
            this.m_CheckBoxAP.Text = "AP";
            this.m_CheckBoxAP.UseVisualStyleBackColor = true;
            this.m_CheckBoxAP.CheckedChanged += new System.EventHandler(this.m_CheckBoxAP_CheckedChanged);
            // 
            // m_CheckBoxHunt
            // 
            this.m_CheckBoxHunt.AutoSize = true;
            this.m_CheckBoxHunt.Location = new System.Drawing.Point(48, 243);
            this.m_CheckBoxHunt.Name = "m_CheckBoxHunt";
            this.m_CheckBoxHunt.Size = new System.Drawing.Size(49, 17);
            this.m_CheckBoxHunt.TabIndex = 32;
            this.m_CheckBoxHunt.Text = "Hunt";
            this.m_CheckBoxHunt.UseVisualStyleBackColor = true;
            this.m_CheckBoxHunt.CheckedChanged += new System.EventHandler(this.m_CheckBoxHunt_CheckedChanged);
            // 
            // m_CheckBox4k
            // 
            this.m_CheckBox4k.AutoSize = true;
            this.m_CheckBox4k.Location = new System.Drawing.Point(48, 182);
            this.m_CheckBox4k.Name = "m_CheckBox4k";
            this.m_CheckBox4k.Size = new System.Drawing.Size(39, 17);
            this.m_CheckBox4k.TabIndex = 30;
            this.m_CheckBox4k.Text = "4K";
            this.m_CheckBox4k.UseVisualStyleBackColor = true;
            this.m_CheckBox4k.CheckedChanged += new System.EventHandler(this.m_CheckBox4k_CheckedChanged);
            // 
            // m_CheckBox1440
            // 
            this.m_CheckBox1440.AutoSize = true;
            this.m_CheckBox1440.Location = new System.Drawing.Point(48, 158);
            this.m_CheckBox1440.Name = "m_CheckBox1440";
            this.m_CheckBox1440.Size = new System.Drawing.Size(56, 17);
            this.m_CheckBox1440.TabIndex = 29;
            this.m_CheckBox1440.Text = "1440p";
            this.m_CheckBox1440.UseVisualStyleBackColor = true;
            this.m_CheckBox1440.CheckedChanged += new System.EventHandler(this.m_CheckBox1440_CheckedChanged);
            // 
            // m_CheckBox1080
            // 
            this.m_CheckBox1080.AutoSize = true;
            this.m_CheckBox1080.Location = new System.Drawing.Point(48, 134);
            this.m_CheckBox1080.Name = "m_CheckBox1080";
            this.m_CheckBox1080.Size = new System.Drawing.Size(56, 17);
            this.m_CheckBox1080.TabIndex = 28;
            this.m_CheckBox1080.Text = "1080p";
            this.m_CheckBox1080.UseVisualStyleBackColor = true;
            this.m_CheckBox1080.CheckedChanged += new System.EventHandler(this.m_CheckBox1080_CheckedChanged);
            // 
            // m_ButtonRun
            // 
            this.m_ButtonRun.Location = new System.Drawing.Point(489, 585);
            this.m_ButtonRun.Name = "m_ButtonRun";
            this.m_ButtonRun.Size = new System.Drawing.Size(104, 30);
            this.m_ButtonRun.TabIndex = 0;
            this.m_ButtonRun.Text = "Run";
            this.m_ButtonRun.UseVisualStyleBackColor = true;
            this.m_ButtonRun.Click += new System.EventHandler(this.m_ButtonRun_Click);
            // 
            // m_PictureBox
            // 
            this.m_PictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.m_PictureBox.Image = ((System.Drawing.Image)(resources.GetObject("m_PictureBox.Image")));
            this.m_PictureBox.Location = new System.Drawing.Point(-3, 1);
            this.m_PictureBox.Name = "m_PictureBox";
            this.m_PictureBox.Size = new System.Drawing.Size(102, 70);
            this.m_PictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.m_PictureBox.TabIndex = 6;
            this.m_PictureBox.TabStop = false;
            // 
            // Epic7AssistantGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.BurlyWood;
            this.ClientSize = new System.Drawing.Size(1316, 752);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.m_PanelTitleBar);
            this.Controls.Add(this.m_PanelAuto);
            this.Controls.Add(this.m_PanelLogs);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Epic7AssistantGUI";
            this.Text = "Form1";
            this.m_PanelTitleBar.ResumeLayout(false);
            this.m_PanelTitleBar.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.m_PanelLogs.ResumeLayout(false);
            this.m_PanelLogs.PerformLayout();
            this.m_PanelAuto.ResumeLayout(false);
            this.m_PanelAuto.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_PictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel m_PanelTitleBar;
        private System.Windows.Forms.PictureBox m_PictureBox;
        private System.Windows.Forms.Button m_ButtonCloseApp;
        private System.Windows.Forms.Button m_ButtonMinimize;
        private System.Windows.Forms.Label m_LabelTitle;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button m_ButtonLogs;
        private System.Windows.Forms.Button m_ButtonAuto;
        private System.Windows.Forms.Panel m_PanelLogs;
        private System.Windows.Forms.Panel m_PanelAuto;
        private System.Windows.Forms.Button m_ButtonRun;
        private System.Windows.Forms.Label m_LabelLoggingOutput;
        private System.Windows.Forms.RichTextBox m_RichTextBoxLoggingOutput;
        private System.Windows.Forms.CheckBox m_CheckBox4k;
        private System.Windows.Forms.CheckBox m_CheckBox1440;
        private System.Windows.Forms.CheckBox m_CheckBox1080;
        private System.Windows.Forms.CheckBox m_CheckBoxEvent;
        private System.Windows.Forms.CheckBox m_CheckBoxAP;
        private System.Windows.Forms.CheckBox m_CheckBoxHunt;
        private System.Windows.Forms.CheckBox m_CheckBoxExped;
        private System.Windows.Forms.Button m_ButtonCancel;
        private System.Windows.Forms.Label m_LabelStepFour;
        private System.Windows.Forms.Label m_LabelStepThree;
        private System.Windows.Forms.Label m_LabelStepTwo;
        private System.Windows.Forms.Label m_LabelStepOne;
    }
}

