using Sanford.Multimedia.Midi;

namespace SequencerDemo
{
    partial class Form1
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
            if(disposing && (components != null))
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
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.connectAPCmini = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button6 = new System.Windows.Forms.Button();
            this.channelListBox = new System.Windows.Forms.ListBox();
            this.sysCommonListBox = new System.Windows.Forms.ListBox();
            this.sysExGroupBox = new System.Windows.Forms.GroupBox();
            this.sysExRichTextBox = new System.Windows.Forms.RichTextBox();
            this.sysRealtimeListBox = new System.Windows.Forms.ListBox();
            this.connectFLstudio = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.panel1.SuspendLayout();
            this.sysExGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.Enabled = false;
            this.button2.Location = new System.Drawing.Point(149, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(154, 23);
            this.button2.TabIndex = 0;
            this.button2.Text = "All lights on Defualt Color";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // button3
            // 
            this.button3.Enabled = false;
            this.button3.Location = new System.Drawing.Point(12, 12);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(131, 23);
            this.button3.TabIndex = 1;
            this.button3.Text = "ALL LIGHTS OFF Off";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.Button3_Click);
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.Location = new System.Drawing.Point(3, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Pattern 1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // button4
            // 
            this.button4.Enabled = false;
            this.button4.Location = new System.Drawing.Point(84, 3);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 3;
            this.button4.Text = "Pattern 2";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.Button4_Click);
            // 
            // connectAPCmini
            // 
            this.connectAPCmini.Location = new System.Drawing.Point(503, 16);
            this.connectAPCmini.Name = "connectAPCmini";
            this.connectAPCmini.Size = new System.Drawing.Size(173, 42);
            this.connectAPCmini.TabIndex = 4;
            this.connectAPCmini.Text = "Connect MIDI I/O (APC mini)";
            this.connectAPCmini.UseVisualStyleBackColor = true;
            this.connectAPCmini.Click += new System.EventHandler(this.Button5_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button6);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.button4);
            this.panel1.Location = new System.Drawing.Point(12, 41);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(291, 30);
            this.panel1.TabIndex = 6;
            // 
            // button6
            // 
            this.button6.Enabled = false;
            this.button6.Location = new System.Drawing.Point(165, 3);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(75, 23);
            this.button6.TabIndex = 4;
            this.button6.Text = "mix one";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.Button6_Click);
            // 
            // channelListBox
            // 
            this.channelListBox.FormattingEnabled = true;
            this.channelListBox.Location = new System.Drawing.Point(12, 77);
            this.channelListBox.Name = "channelListBox";
            this.channelListBox.Size = new System.Drawing.Size(291, 420);
            this.channelListBox.TabIndex = 7;
            // 
            // sysCommonListBox
            // 
            this.sysCommonListBox.FormattingEnabled = true;
            this.sysCommonListBox.Location = new System.Drawing.Point(309, 77);
            this.sysCommonListBox.Name = "sysCommonListBox";
            this.sysCommonListBox.Size = new System.Drawing.Size(440, 69);
            this.sysCommonListBox.TabIndex = 8;
            // 
            // sysExGroupBox
            // 
            this.sysExGroupBox.Controls.Add(this.sysExRichTextBox);
            this.sysExGroupBox.Location = new System.Drawing.Point(309, 250);
            this.sysExGroupBox.Name = "sysExGroupBox";
            this.sysExGroupBox.Size = new System.Drawing.Size(440, 247);
            this.sysExGroupBox.TabIndex = 9;
            this.sysExGroupBox.TabStop = false;
            this.sysExGroupBox.Text = "SysEx Messages";
            // 
            // sysExRichTextBox
            // 
            this.sysExRichTextBox.Location = new System.Drawing.Point(6, 19);
            this.sysExRichTextBox.Name = "sysExRichTextBox";
            this.sysExRichTextBox.Size = new System.Drawing.Size(423, 222);
            this.sysExRichTextBox.TabIndex = 7;
            this.sysExRichTextBox.Text = "";
            // 
            // sysRealtimeListBox
            // 
            this.sysRealtimeListBox.FormattingEnabled = true;
            this.sysRealtimeListBox.Location = new System.Drawing.Point(309, 152);
            this.sysRealtimeListBox.Name = "sysRealtimeListBox";
            this.sysRealtimeListBox.Size = new System.Drawing.Size(440, 69);
            this.sysRealtimeListBox.TabIndex = 10;
            // 
            // connectFLstudio
            // 
            this.connectFLstudio.Location = new System.Drawing.Point(839, 16);
            this.connectFLstudio.Name = "connectFLstudio";
            this.connectFLstudio.Size = new System.Drawing.Size(167, 42);
            this.connectFLstudio.TabIndex = 11;
            this.connectFLstudio.Text = "Connect MIDI I/O (FL Studio)";
            this.connectFLstudio.UseVisualStyleBackColor = true;
            this.connectFLstudio.Click += new System.EventHandler(this.Button7_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(781, 64);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(269, 199);
            this.listBox1.TabIndex = 16;
            // 
            // listBox2
            // 
            this.listBox2.FormattingEnabled = true;
            this.listBox2.Location = new System.Drawing.Point(781, 272);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(269, 225);
            this.listBox2.TabIndex = 17;
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(1062, 509);
            this.Controls.Add(this.listBox2);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.connectFLstudio);
            this.Controls.Add(this.sysRealtimeListBox);
            this.Controls.Add(this.sysExGroupBox);
            this.Controls.Add(this.sysCommonListBox);
            this.Controls.Add(this.channelListBox);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.connectAPCmini);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Name = "Form1";
            this.panel1.ResumeLayout(false);
            this.sysExGroupBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion


        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button connectAPCmini;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.ListBox channelListBox;
        private System.Windows.Forms.ListBox sysCommonListBox;
        private System.Windows.Forms.GroupBox sysExGroupBox;
        private System.Windows.Forms.RichTextBox sysExRichTextBox;
        private System.Windows.Forms.ListBox sysRealtimeListBox;
        private System.Windows.Forms.Button connectFLstudio;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.ListBox listBox2;
    }
}

