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
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.listBox3 = new System.Windows.Forms.ListBox();
            this.listBox4 = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.sysExGroupBox.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.Enabled = false;
            this.button2.Location = new System.Drawing.Point(155, 3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(148, 23);
            this.button2.TabIndex = 0;
            this.button2.Text = "All lights on Defualt Color";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // button3
            // 
            this.button3.Enabled = false;
            this.button3.Location = new System.Drawing.Point(3, 3);
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
            this.button1.Location = new System.Drawing.Point(3, 32);
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
            this.button4.Location = new System.Drawing.Point(105, 32);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 3;
            this.button4.Text = "Pattern 2";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.Button4_Click);
            // 
            // connectAPCmini
            // 
            this.connectAPCmini.Location = new System.Drawing.Point(12, 230);
            this.connectAPCmini.Name = "connectAPCmini";
            this.connectAPCmini.Size = new System.Drawing.Size(279, 38);
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
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Location = new System.Drawing.Point(347, 324);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(306, 62);
            this.panel1.TabIndex = 6;
            // 
            // button6
            // 
            this.button6.Enabled = false;
            this.button6.Location = new System.Drawing.Point(213, 32);
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
            this.channelListBox.Location = new System.Drawing.Point(12, 12);
            this.channelListBox.Name = "channelListBox";
            this.channelListBox.Size = new System.Drawing.Size(291, 82);
            this.channelListBox.TabIndex = 7;
            // 
            // sysCommonListBox
            // 
            this.sysCommonListBox.FormattingEnabled = true;
            this.sysCommonListBox.Location = new System.Drawing.Point(12, 100);
            this.sysCommonListBox.Name = "sysCommonListBox";
            this.sysCommonListBox.Size = new System.Drawing.Size(291, 69);
            this.sysCommonListBox.TabIndex = 8;
            // 
            // sysExGroupBox
            // 
            this.sysExGroupBox.Controls.Add(this.sysExRichTextBox);
            this.sysExGroupBox.Location = new System.Drawing.Point(12, 250);
            this.sysExGroupBox.Name = "sysExGroupBox";
            this.sysExGroupBox.Size = new System.Drawing.Size(291, 247);
            this.sysExGroupBox.TabIndex = 9;
            this.sysExGroupBox.TabStop = false;
            this.sysExGroupBox.Text = "SysEx Messages";
            // 
            // sysExRichTextBox
            // 
            this.sysExRichTextBox.Location = new System.Drawing.Point(6, 19);
            this.sysExRichTextBox.Name = "sysExRichTextBox";
            this.sysExRichTextBox.Size = new System.Drawing.Size(279, 222);
            this.sysExRichTextBox.TabIndex = 7;
            this.sysExRichTextBox.Text = "";
            // 
            // sysRealtimeListBox
            // 
            this.sysRealtimeListBox.FormattingEnabled = true;
            this.sysRealtimeListBox.Location = new System.Drawing.Point(12, 175);
            this.sysRealtimeListBox.Name = "sysRealtimeListBox";
            this.sysRealtimeListBox.Size = new System.Drawing.Size(291, 69);
            this.sysRealtimeListBox.TabIndex = 10;
            // 
            // connectFLstudio
            // 
            this.connectFLstudio.Location = new System.Drawing.Point(748, 259);
            this.connectFLstudio.Name = "connectFLstudio";
            this.connectFLstudio.Size = new System.Drawing.Size(264, 42);
            this.connectFLstudio.TabIndex = 11;
            this.connectFLstudio.Text = "Connect MIDI I/O (FL Studio)";
            this.connectFLstudio.UseVisualStyleBackColor = true;
            this.connectFLstudio.Click += new System.EventHandler(this.Button7_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(748, 133);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(264, 69);
            this.listBox1.TabIndex = 16;
            // 
            // listBox2
            // 
            this.listBox2.FormattingEnabled = true;
            this.listBox2.Location = new System.Drawing.Point(748, 45);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(264, 69);
            this.listBox2.TabIndex = 17;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.listBox4);
            this.panel2.Controls.Add(this.listBox3);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.connectAPCmini);
            this.panel2.Location = new System.Drawing.Point(347, 19);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(306, 272);
            this.panel2.TabIndex = 18;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(243, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Step 1. Pick the \"APC mini\" from both  device lists";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // listBox3
            // 
            this.listBox3.FormattingEnabled = true;
            this.listBox3.Location = new System.Drawing.Point(17, 26);
            this.listBox3.Name = "listBox3";
            this.listBox3.Size = new System.Drawing.Size(274, 82);
            this.listBox3.TabIndex = 17;
            // 
            // listBox4
            // 
            this.listBox4.FormattingEnabled = true;
            this.listBox4.Location = new System.Drawing.Point(17, 114);
            this.listBox4.Name = "listBox4";
            this.listBox4.Size = new System.Drawing.Size(274, 82);
            this.listBox4.TabIndex = 18;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 212);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(126, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "Step 2 Connect APC mini";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(748, 117);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(194, 13);
            this.label3.TabIndex = 19;
            this.label3.Text = "Step 4   Pick a Device to act as Control";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(748, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(245, 13);
            this.label4.TabIndex = 20;
            this.label4.Text = "Step 3   Pick a device for perfomance mode lights ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(748, 241);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(141, 13);
            this.label5.TabIndex = 21;
            this.label5.Text = "Step 5 Connect to FL Studio";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(1117, 513);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.listBox2);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.connectFLstudio);
            this.Controls.Add(this.sysRealtimeListBox);
            this.Controls.Add(this.sysExGroupBox);
            this.Controls.Add(this.sysCommonListBox);
            this.Controls.Add(this.channelListBox);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.sysExGroupBox.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listBox4;
        private System.Windows.Forms.ListBox listBox3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}

