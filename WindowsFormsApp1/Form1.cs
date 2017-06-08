using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Sanford.Multimedia.Midi;
using Sanford.Multimedia.Midi.UI;
using System.Threading;
using Sanford.Multimedia;

using System.Diagnostics;

namespace SequencerDemo
{
    public partial class Form1 : Form
    {
        /*
         * State vars
         
        private bool scrolling = false;
        private bool playing = false;
        private bool closing = false;
        */

        private bool outconnected = false;

        /*
         output vars
         */
        private OutputDevice toAPCmini;
        private OutputDevice toFLstudio;
        private OutputDeviceDialog outDialog = new OutputDeviceDialog();
        private ChannelMessageBuilder builder = new ChannelMessageBuilder();



        /*
        input vars and such 
        */
        private const int SysExBufferSize = 128;

        private InputDevice fromFLstudio = null;
        // private InputDevice inDevice = null;
        private InputDevice fromAPCmini = null;

        private SynchronizationContext context;

        



        public Form1()
        {
            InitializeComponent();            
        }
        protected override void OnLoad(EventArgs e)
        {
            if (OutputDevice.DeviceCount == 0)
            {
                MessageBox.Show("No MIDI output devices available.", "Error!",
                    MessageBoxButtons.OK, MessageBoxIcon.Stop);

                Close();
            }
            else
            {
                try
                {

                    int foo = InputDevice.DeviceCount;
                    int i = 0;
                    for (i = 0; i < foo; i++)
                    {
                        MidiInCaps mdevices = InputDevice.GetDeviceCapabilities(i);
                        int ii = i + 1;
                        listBox1.Items.Add((string)"PORT " + ii.ToString() + '\t' + '\t' + mdevices.name.ToString() + '\t');
                        listBox1.SelectedIndex = listBox1.Items.Count - 1;


                        listBox3.Items.Add((string)"PORT " + ii.ToString() + '\t' + '\t' + mdevices.name.ToString() + '\t');
                        if (mdevices.name.ToString() == "APC MINI")
                        {
                            listBox3.SelectedIndex = listBox3.Items.Count - 1;
                        }

                    }

                    int bar = OutputDevice.DeviceCount;
                    i = 0;
                    for (i = 0; i < bar; i++)
                    {
                        MidiOutCaps odevices = OutputDevice.GetDeviceCapabilities(i);
                        int ii = i + 1;
                        listBox2.Items.Add((string)"PORT " + ii.ToString() + '\t' + '\t' + odevices.name.ToString() + '\t');
                        listBox2.SelectedIndex = listBox2.Items.Count - 1;

                        listBox4.Items.Add((string)"PORT " + ii.ToString() + '\t' + '\t' + odevices.name.ToString() + '\t');
                        if (odevices.name.ToString() == "APC MINI")
                        {
                            listBox4.SelectedIndex = listBox4.Items.Count - 1;
                        }
                    }

                    //  outDevice = new OutputDevice((int)numericUpDown1.Value);



                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error!",
                        MessageBoxButtons.OK, MessageBoxIcon.Stop);

                    Close();
                }
            }

            base.OnLoad(e);
        }


        protected override void OnClosing(CancelEventArgs e)
        {


            if (fromFLstudio != null)
            {
                fromFLstudio.StopRecording();
                fromFLstudio.Close();
            }
           
            if (fromAPCmini != null)
            {
                fromAPCmini.StopRecording();
                fromAPCmini.Close();
            }
           
            base.OnClosing(e);
        }

        protected override void OnClosed(EventArgs e)
        { 

            if (toAPCmini != null)
            {
                toAPCmini.Dispose();
            }
            if (fromAPCmini != null)
            {
                fromAPCmini.Close();
            }
            if (toFLstudio != null)
            {
                toFLstudio.Dispose();
            }
            if (fromFLstudio != null)
            {
                fromFLstudio.Close();
            }

            outDialog.Dispose();

            base.OnClosed(e);
        }


        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void OutputDeviceToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutDialog dlg = new AboutDialog();

            dlg.ShowDialog();
        }














        private void HandleFromAPCminiMessageReceived(object sender, ChannelMessageEventArgs e)
        {
            
            int a = -1;
            int b = -1;
            string commCheck = e.Message.Command.ToString();
            int comChan = (int)e.Message.MidiChannel;
            
            a = (int)e.Message.Data1;
            b = (int)e.Message.Data2;
            commCheck = e.Message.Command.ToString();
            comChan = (int)e.Message.MidiChannel;
            
            if (commCheck == "NoteOn" )
            {
                int[] noteArr = new int[] { 112, 113, 114, 115, 116, 117, 118, 119, 96, 97, 98, 99, 100, 101, 102, 103, 80, 81, 82, 83, 84, 85, 86, 87, 64, 65, 66, 67, 68, 69, 70, 71, 48, 49, 50, 51, 52, 53, 54, 55, 32, 33, 34, 35, 36, 37, 38, 39, 16, 17, 18, 19, 20, 21, 22, 23, 0, 1, 2, 3, 4, 5, 6, 7, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 8, 24, 40, 56, 72, 88, 104, 120, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9 };
                int newnote = noteArr[a];

                builder.Command = ChannelCommand.NoteOn;
                builder.MidiChannel = comChan;
                builder.Data1 = newnote;
                builder.Data2 = 127;
                builder.Build();
                toFLstudio.Send(builder.Result);
            }
            /*
            
            if (commCheck == "NoteOn")
            {


                context.Post(delegate (object dummy)
                {
                    channelListBox.Items.Add(
                        e.Message.Command.ToString() + '\t' + '\t' +
                        e.Message.MidiChannel.ToString() + '\t' +
                        e.Message.Data1.ToString() + '\t' +
                        e.Message.Data2.ToString());

                    channelListBox.SelectedIndex = channelListBox.Items.Count - 1;
                }, null);

            }
            */
        }



        private void HandleChannel2MessageReceived(object sender, ChannelMessageEventArgs e)
        {
            /*
            context.Post(delegate (object dummy)
            {
                channelListBox.Items.Add(
                    e.Message.Command.ToString() + '\t' + '\t' +
                    e.Message.MidiChannel.ToString() + '\t' +
                    e.Message.Data1.ToString() + '\t' +
                    e.Message.Data2.ToString());

                channelListBox.SelectedIndex = channelListBox.Items.Count - 1;
            }, null);
            */


        }

        private void HandleChannelMessageReceived(object sender, ChannelMessageEventArgs e)
        {
            /*
            context.Post(delegate (object dummy)
            {
                channelListBox.Items.Add(
                    e.Message.Command.ToString() + '\t' + '\t' +
                    e.Message.MidiChannel.ToString() + '\t' +
                    e.Message.Data1.ToString() + '\t' +
                    e.Message.Data2.ToString());

                channelListBox.SelectedIndex = channelListBox.Items.Count - 1;
            }, null);
            */


        }

        private void HandleFLstudioMessageReceived(object sender, ChannelMessageEventArgs e)
        {


            int a = -1;
            int b = -1;
            string commCheck = e.Message.Command.ToString();
            int comChan = (int)e.Message.MidiChannel;

            a = (int)e.Message.Data1;
            b = (int)e.Message.Data2;
            commCheck = e.Message.Command.ToString();
            comChan = (int)e.Message.MidiChannel;
          

            

            int inrange = 0;
            if (a >=  0 && a <=  8) { inrange = 1; }
            if (a >= 16 && a <= 24) { inrange = 1; }
            if (a >= 32 && a <= 40) { inrange = 1; }
            if (a >= 48 && a <= 56) { inrange = 1; }
            if (a >= 64 && a <= 72) { inrange = 1; }
            if (a >= 80 && a <= 88) { inrange = 1; }
            if (a >= 96 && a <= 104) { inrange = 1; }
            if (a >= 112 && a <= 120) { inrange = 1; }
            /*
            if (commCheck == "NoteOn" && (comChan == 0 ) && inrange == 1)
            {

                Debug.WriteLine("pad value a is " + a);
                Debug.WriteLine("pad3 value b is " + b);
            }
           */

            if (commCheck == "NoteOn" && comChan == 0 && inrange == 1)
            {



                // MAIN PAD
                int[] noteArr = new int[] { 56, 57, 58, 59, 60, 61, 62, 63, 82, 0, 0, 0, 0, 0, 0, 0, 48, 49, 50, 51, 52, 53, 54, 55, 83, 0, 0, 0, 0, 0, 0, 0, 40, 41, 42, 43, 44, 45, 46, 47, 84, 0, 0, 0, 0, 0, 0, 0, 32, 33, 34, 35, 36, 37, 38, 39, 85, 0, 0, 0, 0, 0, 0, 0, 24, 25, 26, 27, 28, 29, 30, 31, 86, 0, 0, 0, 0, 0, 0, 0, 16, 17, 18, 19, 20, 21, 22, 23, 87, 0, 0, 0, 0, 0, 0, 0, 8, 9, 10, 11, 12, 13, 14, 15, 88, 0, 0, 0, 0, 0, 0, 0, 0, 1, 2, 3, 4, 5, 6, 7, 89, 0, 0, 0, 0, 0, 0, 0 };

                // int[] noteArr = new int[] { 112, 113, 114, 115, 116, 117, 118, 119, 96, 97, 98, 99, 100, 101, 102, 103, 80, 81, 82, 83, 84, 85, 86, 87, 64, 65, 66, 67, 68, 69, 70, 71, 48, 49, 50, 51, 52, 53, 54, 55, 32, 33, 34, 35, 36, 37, 38, 39, 16, 17, 18, 19, 20, 21, 22, 23, 0, 1, 2, 3, 4, 5, 6, 7, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 8, 24, 40, 56, 72, 88, 104, 120, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9};
                int newnote = noteArr[a];
                //Debug.WriteLine("pad1 value a is " + a);
                //Debug.WriteLine("pad2 value a is " + newnote.ToString());
                //Debug.WriteLine("pad3 value b is " + b);


                // int[] colorArr = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 5, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 5, 1, 5, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 3, 1, 1, 1, 1, 1, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };
                int[] onoffArr = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 5, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0};
                int[] colorArr = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4, 0, 0, 0, 0, 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 5, 1, 5, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 0, 0, 0, 0, 0, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
                int newcolor = -1;

                if (newnote >= 82 && newnote <= 89)
                {
                   newcolor = onoffArr[b];
                } else {
                   newcolor = colorArr[b];
                }

                //    Debug.WriteLine("pad4 value b is " + newcolor.ToString());
                /*
                context.Post(delegate (object dummy)
                {
                    channelListBox.Items.Add(
                        e.Message.Command.ToString() + '\t' + '\t' +
                        e.Message.MidiChannel.ToString() + '\t' +
                        e.Message.Data1.ToString() + '\t' +
                        e.Message.Data2.ToString());

                    channelListBox.SelectedIndex = channelListBox.Items.Count - 1;
                }, null);


                
                context.Post(delegate (object dummy)
                {
                    listBox2.Items.Add(
                        e.Message.Command.ToString() + '\t' + '\t' +
                        e.Message.MidiChannel.ToString() + '\t' +
                        e.Message.Data1.ToString() + '\t' +
                        e.Message.Data2.ToString());

                    listBox2.SelectedIndex = listBox2.Items.Count - 1;
                }, null);
                */

                if (outconnected == true)
                {
                    builder.Command = ChannelCommand.NoteOn;
                    builder.MidiChannel = 1;
                    builder.Data1 = newnote;
                    builder.Data2 = newcolor;
                    builder.Build();
                    toAPCmini.Send(builder.Result);
                }

            }

            

        }

        /// <summary>
        /// zork 2
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void HandleSysCommonMessageReceived(object sender, SysCommonMessageEventArgs e)
        {
            /*
            context.Post(delegate (object dummy)
            {
                sysCommonListBox.Items.Add(
                    e.Message.SysCommonType.ToString() + '\t' + '\t' +
                    e.Message.Data1.ToString() + '\t' +
                    e.Message.Data2.ToString());

                sysCommonListBox.SelectedIndex = sysCommonListBox.Items.Count - 1;
            }, null);
            */

        }


        private void HandleSysExMessageReceived(object sender, SysExMessageEventArgs e)
        {
            context.Post(delegate (object dummy)
            {
                string result = "\n\n"; ;

                foreach (byte b in e.Message)
                {
                    result += string.Format("{0:X2} ", b);
                }

                sysExRichTextBox.Text += result;
            }, null);
        }


        private void HandleSysRealtimeMessageReceived(object sender, SysRealtimeMessageEventArgs e)
        {
            context.Post(delegate (object dummy)
            {
                sysRealtimeListBox.Items.Add(
                    e.Message.SysRealtimeType.ToString());

                sysRealtimeListBox.SelectedIndex = sysRealtimeListBox.Items.Count - 1;
            }, null);
        }

        private void InDevice_Error(object sender, ErrorEventArgs e)
        {
            MessageBox.Show(e.Error.Message.ToString(), "Error!",    MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }


















        private void Button2_Click(object sender, EventArgs e)
        {


            for (int a = 0; a < 119; a = a + 1)
            {

                builder.Command = ChannelCommand.NoteOn;
                builder.MidiChannel = 1;
                builder.Data1 = a;
                builder.Data2 = 1;
                builder.Build();
                toAPCmini.Send(builder.Result);

            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {

            for (int a = 0; a < 119; a = a + 1)
            {

                builder.Command = ChannelCommand.NoteOn;
                builder.MidiChannel = 1;
                builder.Data1 = a;
                builder.Data2 = 0;
                builder.Build();
                toAPCmini.Send(builder.Result);

            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            for (int a = 0; a < 32; a = a + 1)
            {

                builder.Command = ChannelCommand.NoteOn;
                builder.MidiChannel = 1;
                builder.Data1 = a;
                builder.Data2 = 3;
                builder.Build();
                toAPCmini.Send(builder.Result);

            }
            for (int a = 32; a < 64; a = a + 1)
            {

                builder.Command = ChannelCommand.NoteOn;
                builder.MidiChannel = 1;
                builder.Data1 = a;
                builder.Data2 = 6;
                builder.Build();
                toAPCmini.Send(builder.Result);

            }
        }

        private void Button4_Click(object sender, EventArgs e)
        {

            builder.Command = ChannelCommand.NoteOn;
            builder.MidiChannel = 1;
            builder.Data1 = 27;
            builder.Data2 = 3;
            builder.Build();
            toAPCmini.Send(builder.Result);
            builder.Command = ChannelCommand.NoteOn;
            builder.MidiChannel = 1;
            builder.Data1 = 28;
            builder.Data2 = 3;
            builder.Build();
            toAPCmini.Send(builder.Result);
            builder.Command = ChannelCommand.NoteOn;
            builder.MidiChannel = 1;
            builder.Data1 = 35;
            builder.Data2 = 3;
            builder.Build();
            toAPCmini.Send(builder.Result);

            builder.Command = ChannelCommand.NoteOn;
            builder.MidiChannel = 1;
            builder.Data1 = 36;
            builder.Data2 = 3;
            builder.Build();
            toAPCmini.Send(builder.Result);

            builder.Command = ChannelCommand.NoteOn;
            builder.MidiChannel = 1;
            builder.Data1 = 34;
            builder.Data2 = 5;
            builder.Build();
            toAPCmini.Send(builder.Result);

            builder.Command = ChannelCommand.NoteOn;
            builder.MidiChannel = 1;
            builder.Data1 = 26;
            builder.Data2 = 5;
            builder.Build();
            toAPCmini.Send(builder.Result);

            builder.Command = ChannelCommand.NoteOn;
            builder.MidiChannel = 1;
            builder.Data1 = 37;
            builder.Data2 = 5;
            builder.Build();
            toAPCmini.Send(builder.Result);

            builder.Command = ChannelCommand.NoteOn;
            builder.MidiChannel = 1;
            builder.Data1 = 29;
            builder.Data2 = 5;
            builder.Build();
            toAPCmini.Send(builder.Result);


            for (int a = 42; a < 46; a = a + 1)
            {

                builder.Command = ChannelCommand.NoteOn;
                builder.MidiChannel = 1;
                builder.Data1 = a;
                builder.Data2 = 5;
                builder.Build();
                toAPCmini.Send(builder.Result);

            }
            for (int a = 18; a < 22; a = a + 1)
            {

                builder.Command = ChannelCommand.NoteOn;
                builder.MidiChannel = 1;
                builder.Data1 = a;
                builder.Data2 = 5;
                builder.Build();
                toAPCmini.Send(builder.Result);

            }
        }

        private void Button5_Click(object sender, EventArgs e)  {



            int ii = (listBox3.SelectedIndex + 1);
            int i = (listBox4.SelectedIndex - 1);
            context = SynchronizationContext.Current;

            toAPCmini = new OutputDevice(ii);
            outconnected = true;

            for (int a = 0; a < 24; a = a + 1)
            {

                builder.Command = ChannelCommand.NoteOn;
                builder.MidiChannel = 1;
                builder.Data1 = a;
                builder.Data2 = 1;
                builder.Build();
                toAPCmini.Send(builder.Result);

            }
            for (int a = 24; a < 40; a = a + 1)
            {

                builder.Command = ChannelCommand.NoteOn;
                builder.MidiChannel = 1;
                builder.Data1 = a;
                builder.Data2 = 5;
                builder.Build();
                toAPCmini.Send(builder.Result);

            }
            for (int a = 40; a < 64; a = a + 1)
            {

                builder.Command = ChannelCommand.NoteOn;
                builder.MidiChannel = 1;
                builder.Data1 = a;
                builder.Data2 = 3;
                builder.Build();
                toAPCmini.Send(builder.Result);

            }


            int milliseconds = 500;
            Thread.Sleep(milliseconds);

            for (int a = 0; a < 120; a = a + 1)
            {

                builder.Command = ChannelCommand.NoteOn;
                builder.MidiChannel = 1;
                builder.Data1 = a;
                builder.Data2 = 0;
                builder.Build();
                toAPCmini.Send(builder.Result);

            }

            context.Post(delegate (object dummy)
            {
                channelListBox.Items.Add("CONNECTION TO APC MINI Attempted");
                channelListBox.SelectedIndex = channelListBox.Items.Count - 1;
            }, null);


            
            
            fromAPCmini = new InputDevice(i);
            fromAPCmini.ChannelMessageReceived += HandleFromAPCminiMessageReceived;
            fromAPCmini.StartRecording();

            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;
            button6.Enabled = true;
            connectAPCmini.Enabled = false;
        
        }


        private void Button7_Click(object sender, EventArgs e)
        {

        //    int ii = (listBox2.SelectedIndex - 1);
            
         //   int i = (listBox1.SelectedIndex);

            int i = (listBox1.SelectedIndex + 1);
            int ii = (listBox2.SelectedIndex - 1);
            // context = SynchronizationContext.Current;


            /*
            context = SynchronizationContext.Current;
            inDevice = new InputDevice(ii);
            inDevice.ChannelMessageReceived += HandleChannelMessageReceived;
            inDevice.SysCommonMessageReceived += HandleSysCommonMessageReceived;
            inDevice.SysExMessageReceived += HandleSysExMessageReceived;
            inDevice.SysRealtimeMessageReceived += HandleSysRealtimeMessageReceived;
            inDevice.Error += new EventHandler<ErrorEventArgs>(InDevice_Error);

            inDevice.StartRecording();
            */

            // icontext = SynchronizationContext.Current;

            context.Post(delegate (object dummy)
            {
                channelListBox.Items.Add(  "CONNECTED from out ") ;
                channelListBox.SelectedIndex = channelListBox.Items.Count - 1;
            }, null);

            toFLstudio = new OutputDevice(i);

            fromFLstudio = new InputDevice(ii);
            fromFLstudio.ChannelMessageReceived += HandleFLstudioMessageReceived;
            
            fromFLstudio.SysCommonMessageReceived += HandleSysCommonMessageReceived;
            fromFLstudio.SysExMessageReceived += HandleSysExMessageReceived;
            fromFLstudio.SysRealtimeMessageReceived += HandleSysRealtimeMessageReceived;
            fromFLstudio.Error += new EventHandler<ErrorEventArgs>(InDevice_Error);
           
            fromFLstudio.StartRecording();
            connectFLstudio.Enabled = false;
        

        }


        private void Button6_Click(object sender, EventArgs e)
        {

            int[] n = new int[8];

            n[0] = 56;
            n[1] = 57;
            n[2] = 58;
            n[3] = 59;
            n[4] = 60;
            n[5] = 61;
            n[6] = 62;
            n[7] = 63;

            foreach (int j in n)
            {
                builder.Command = ChannelCommand.NoteOn;
                builder.MidiChannel = 1;
                builder.Data1 = j;
                builder.Data2 = 2;
                builder.Build();
                toAPCmini.Send(builder.Result);

            }
        }

        private void Button8_Click(object sender, EventArgs e)
        {
            /*
            int ii = (listBox1.SelectedIndex + 1);
            context = SynchronizationContext.Current;
            fromAPCmini = new InputDevice(ii);
            fromAPCmini.ChannelMessageReceived += HandleChannel2MessageReceived;
            fromAPCmini.Error += new EventHandler<ErrorEventArgs>(InDevice_Error);
            fromAPCmini.StartRecording();
            */
        }


        private void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}