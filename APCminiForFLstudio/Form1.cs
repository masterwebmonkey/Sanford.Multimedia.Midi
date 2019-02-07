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

namespace APCmini
{

    public partial class Form1 : Form
    {

        private bool outconnected = false;

        private OutputDevice toAPCmini;
        private OutputDevice toFLstudio;
        private OutputDevice toFLstudioMixer;

        private InputDevice fromFLstudio = null;
        private InputDevice fromAPCmini = null;

        private OutputDeviceDialog outDialog = new OutputDeviceDialog();
        private ChannelMessageBuilder builder = new ChannelMessageBuilder();

        private const int SysExBufferSize = 128;
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
                    GlobalVariables.up1DataArray = new int[127] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
                    GlobalVariables.up2DataArray = new int[127] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
                    GlobalVariables.noteValueDataArray = new int[127] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

                    int foo = InputDevice.DeviceCount;
                    int i = 0;
                    int APCfound = 0;

                    for (i = 0; i < foo; i++)
                    {
                        MidiInCaps mdevices = InputDevice.GetDeviceCapabilities(i);
                        int ii = i + 1;
                        listBox1.Items.Add((string)"PORT " + ii.ToString() + '\t' + '\t' + mdevices.name.ToString() + '\t');
                        if (mdevices.name.ToString() == "APCpad")
                        {
                            listBox1.SelectedIndex = listBox1.Items.Count - 1;
                        }

                        listBox3.Items.Add((string)"PORT " + ii.ToString() + '\t' + '\t' + mdevices.name.ToString() + '\t');
                        if (mdevices.name.ToString() == "APC MINI")
                        {
                            APCfound = 1;
                            listBox3.SelectedIndex = listBox3.Items.Count - 1;
                        }


                        listBox5.Items.Add((string)"PORT " + ii.ToString() + '\t' + '\t' + mdevices.name.ToString() + '\t');
                        if (mdevices.name.ToString() == "APCmixer")
                        {
                            listBox5.SelectedIndex = listBox5.Items.Count - 1;
                        }


                    }


                    if (APCfound == 0)
                    {
                        MessageBox.Show("No APC MINI device available.", "Error!",
                            MessageBoxButtons.OK, MessageBoxIcon.Stop);

                        Close();
                    }


                    int bar = OutputDevice.DeviceCount;
                    i = 0;
                    for (i = 0; i < bar; i++)
                    {
                        MidiOutCaps odevices = OutputDevice.GetDeviceCapabilities(i);
                        int ii = i + 1;
                        listBox2.Items.Add((string)"PORT " + ii.ToString() + '\t' + '\t' + odevices.name.ToString() + '\t');

                        if (odevices.name.ToString() == "APClights")
                        {
                            listBox2.SelectedIndex = listBox2.Items.Count - 1;
                        }

                        listBox4.Items.Add((string)"PORT " + ii.ToString() + '\t' + '\t' + odevices.name.ToString() + '\t');
                        if (odevices.name.ToString() == "APC MINI")
                        {
                            listBox4.SelectedIndex = listBox4.Items.Count - 1;
                        }

                    }

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
            if (toFLstudioMixer != null)
            {
                toFLstudioMixer.Dispose();
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
            /*
             * the APC is talking this funtion is listening  
             */
            int setDebugMode = 0;
            int a = -1;
            int b = -1;
            string notice = "";
            string commCheck = e.Message.Command.ToString();
            int comChan = (int)e.Message.MidiChannel;

            a = (int)e.Message.Data1;
            b = (int)e.Message.Data2;
            commCheck = e.Message.Command.ToString();
            comChan = (int)e.Message.MidiChannel;

            /*
             * this git project can listen to different 
             * communication command types 
             * 
             * the three if blocks below are converting apc signals to novation launch pad 
             * 
             * Controller
             * NoteOn
             * NoteOff
             * 
             */
            if (commCheck == "Controller")
            {

                /* me trying to guess a defualt 
                 * midi note values 48 to 56 on the Controller
                 * are the 9 sliders 
                 */
                if (a >= 48 && a <= 56)
                {
                    int aa = a - 8;
                    builder.Command = ChannelCommand.Controller;
                    builder.MidiChannel = comChan;
                    builder.Data1 = a;
                    builder.Data2 = b;
                    builder.Build();
                    toFLstudioMixer.Send(builder.Result);
                    if (setDebugMode == 1)
                    {
                        notice = " Controler " + comChan + ":" + a + ":" + b;
                    }

                }
            }
            else if (commCheck == "NoteOn")
            {
                // array of values 
                // 0-49, 50-99 100-127
                // set outgoing comm channel
                int[] chanArr = new int[] {
                      1,   1,   1,   1,   1,   1,   1,   1,   1,   1,
                      1,   1,   1,   1,   1,   1,   1,   1,   1,   1,
                      1,   1,   1,   1,   1,   1,   1,   1,   1,   1,
                      1,   1,   1,   1,   1,   1,   1,   1,   1,   1,
                      1,   1,   1,   1,   1,   1,   1,   1,   1,   1,

                      1,   1,   1,   1,   1,   1,   1,   1,   1,   1,
                      1,   1,   1,   1,   2,   2,   2,   2,   2,   2,
                      2,   2,   1,   1,   1,   1,   1,   1,   1,   1,
                      1,   1,   1,   1,   1,   1,   1,   1,   1,   1,
                      1,   1,   1,   1,   1,   1,   1,   1,   2,   1,

                      1,   1,   1,   1,   1,   1,   1,   1,   1,   1,
                      1,   1,   1,   1,   1,   1,   1,   1,   1,   1,
                      1,   1,   1,   1,   1,   1,   1,   1 };

                // array of values 
                // 0-49, 50-99 100-127
                // set out going note
                int[] noteArr = new int[] {
                    112, 113, 114, 115, 116, 117, 118, 119,  96,  97,
                     98,  99, 100, 101, 102, 103,  80,  81,  82,  83,
                     84,  85,  86,  87,  64,  65,  66,  67,  68,  69,
                     70,  71,  48,  49,  50,  51,  52,  53,  54,  55,
                     32,  33,  34,  35,  36,  37,  38,  39,  16,  17,

                     18,  19,  20,  21,  22,  23,   0,   1,   2,   3,
                      4,   5,   6,   7, 104, 105, 106, 107, 108, 109,
                    110, 111,   9,   9,   9,   9,   9,   9,   9,   9,
                      9,   9,   8,   24, 40,  56,  72,  88, 104, 120,
                      9,   9,   9,   9,   9,   9,   9,   9,   9,   9,

                      9,   9,   9,   9,   9,   9,   9,   9,   9,   9,
                      9,   9,   9,   9,   9,   9,   9,   9,   9,   9,
                      9,   9,   9,   9,   9,   9,   9,   9 };

                int control_or_note = chanArr[a];
                int newnote = noteArr[a];

                if (control_or_note == 2)
                {
                    /*
                    for (int i = 0; i < 119; i = i + 1)
                    {

                        builder.Command = ChannelCommand.NoteOn;
                        builder.MidiChannel = 1;
                        builder.Data1 = i;
                        builder.Data2 = 0;
                        builder.Build();
                        toAPCmini.Send(builder.Result);

                    }
                    */
                    if ( a == 68 || a == 98)
                    {
                        for (int i = 0; i <= 63; i = i + 1)
                        {
                         
                               
                                builder.Command = ChannelCommand.NoteOn;
                                builder.MidiChannel = 1;
                                builder.Data1 = i;
                                builder.Data2 = 0;
                                builder.Build();
                                toAPCmini.Send(builder.Result);
                        }

                    }

                    builder.Command = ChannelCommand.Controller;
                    builder.MidiChannel = comChan;
                    builder.Data1 = newnote;
                    builder.Data2 = 127;
                    builder.Build();
                    toFLstudio.Send(builder.Result);

                    builder.Command = ChannelCommand.Controller;
                    builder.MidiChannel = comChan;
                    builder.Data1 = newnote;
                    builder.Data2 = 0;
                    builder.Build();
                    toFLstudio.Send(builder.Result);


                    if (setDebugMode == 1)
                    {
                        notice = " Controler " + comChan + ":" + newnote + ":127 ";
                    }
                }
                else
                {
                    builder.Command = ChannelCommand.NoteOn;
                    builder.MidiChannel = comChan;
                    builder.Data1 = newnote;
                    builder.Data2 = 127;
                    builder.Build();
                    toFLstudio.Send(builder.Result);
                    if (setDebugMode == 1)
                    {
                        notice = " NoteOn " + comChan + ":" + newnote + ":0 ";
                    }
                }

            }
            else if (commCheck == "NoteOff")
            {
                // array of values 
                // 0-49, 50-99 100-127

                int[] chanArr = new int[] {
                      1,   1,   1,   1,   1,   1,   1,   1,   1,   1,
                      1,   1,   1,   1,   1,   1,   1,   1,   1,   1,
                      1,   1,   1,   1,   1,   1,   1,   1,   1,   1,
                      1,   1,   1,   1,   1,   1,   1,   1,   1,   1,
                      1,   1,   1,   1,   1,   1,   1,   1,   1,   1,

                      1,   1,   1,   1,   1,   1,   1,   1,   1,   1,
                      1,   1,   1,   1,   2,   2,   2,   2,   2,   2,
                      2,   2,   1,   1,   1,   1,   1,   1,   1,   1,
                      1,   1,   1,   1,   1,   1,   1,   1,   1,   1,
                      1,   1,   1,   1,   1,   1,   1,   1,   2,   1,

                      1,   1,   1,   1,   1,   1,   1,   1,   1,   1,
                      1,   1,   1,   1,   1,   1,   1,   1,   1,   1,
                      1,   1,   1,   1,   1,   1,   1,   1 };

                // array of values 
                // 0-49, 50-99 100-127
                int[] noteArr = new int[] {
                    112, 113, 114, 115, 116, 117, 118, 119,  96,  97,
                     98,  99, 100, 101, 102, 103,  80,  81,  82,  83,
                     84,  85,  86,  87,  64,  65,  66,  67,  68,  69,
                     70,  71,  48,  49,  50,  51,  52,  53,  54,  55,
                     32,  33,  34,  35,  36,  37,  38,  39,  16,  17,

                     18,  19,  20,  21,  22,  23,   0,   1,   2,   3,
                      4,   5,   6,   7, 104, 105, 106, 107, 108, 109,
                    110, 111,   9,   9,   9,   9,   9,   9,   9,   9,
                      9,   9,   8,   24, 40,  56,  72,  88, 104, 120,
                      9,   9,   9,   9,   9,   9,   9,   9,   9,   9,

                      9,   9,   9,   9,   9,   9,   9,   9,   9,   9,
                      9,   9,   9,   9,   9,   9,   9,   9,   9,   9,
                      9,   9,   9,   9,   9,   9,   9,   9 };

                int control_or_note = chanArr[a];
                int newnote = noteArr[a];
                if (control_or_note == 2)
                {
                    builder.Command = ChannelCommand.Controller;
                    builder.MidiChannel = comChan;
                    builder.Data1 = newnote;
                    builder.Data2 = 0;
                    builder.Build();
                    toFLstudio.Send(builder.Result);
                    if (setDebugMode == 1)
                    {
                        notice = " Controler " + comChan + ":" + newnote + ":0 ";
                    }
                }
                else
                {
                    builder.Command = ChannelCommand.NoteOff;
                    builder.MidiChannel = comChan;
                    builder.Data1 = newnote;
                    builder.Data2 = 0;
                    builder.Build();
                    toFLstudio.Send(builder.Result);
                    if (setDebugMode == 1)
                    {
                        notice = " NoteOff " + comChan + ":" + newnote + ":0 ";
                    }

                }
            }
            // done thinking about what now say it 
            if (setDebugMode == 1)
            {
                /*
                * add translation result to the channel list box 
                * APC say what you said to me
                * 
                */
                context.Post(delegate (object dummy)
                {
                    channelListBox.Items.Add(
                        "APC " + '\t' +
                        e.Message.Command.ToString() + '\t' +
                        e.Message.MidiChannel.ToString() + '\t' +
                        e.Message.Data1.ToString() + '\t' +
                        e.Message.Data2.ToString() + '\t' + notice);
                    channelListBox.SelectedIndex = channelListBox.Items.Count - 1;
                }, null);
            }
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

            /*
             * FL Studio is talking get ready to tanslate and tell  the APC mini something
             * 
             */

            int setDebugMode = 0;
            int a = -1;
            int b = -1;
            string notice = "";
            string commCheck = e.Message.Command.ToString();
            int comChan = (int)e.Message.MidiChannel;

            a = (int)e.Message.Data1;
            b = (int)e.Message.Data2;
            commCheck = e.Message.Command.ToString();
            comChan = (int)e.Message.MidiChannel;



            if (commCheck == "Controller" && comChan == 0)
            {
                //context.Post(delegate (object dummy)
                //{
                if (e.Message.Data2 == 49)
                {
                    GlobalVariables.startStopVariable = 1;
                    GlobalVariables.countingVariable = 0;
                }
                else if (e.Message.Data2 == 52)
                {
                    GlobalVariables.startStopVariable = 1;
                    GlobalVariables.countingVariable = 0;
                }

                if (e.Message.Data1 == 0 && e.Message.Data2 == 0)
                {
                    for (int i = 0; i <= 119; i = i + 1)
                    {
                        builder.Command = ChannelCommand.NoteOn;
                        builder.MidiChannel = 1;
                        builder.Data1 = i;
                        builder.Data2 = 0;
                        builder.Build();
                        toAPCmini.Send(builder.Result);
                    }

                }

                //channelListBox.SelectedIndex = channelListBox.Items.Count - 1;
                //}, null);

                if (setDebugMode == 1)
                {
                    context.Post(delegate (object dummy)
                    {
                        channelListBox.Items.Add(
                            "FLS " + '\t' +
                            e.Message.Command.ToString() + '\t' +
                            e.Message.MidiChannel.ToString() + '\t' +
                            e.Message.Data1.ToString() + '\t' +
                            e.Message.Data2.ToString() + '\t' + notice

                            );

                        channelListBox.SelectedIndex = channelListBox.Items.Count - 1;
                    }, null);

                }

            }
            else if (commCheck == "NoteOn" && comChan == 2)
            {
                //context.Post(delegate (object dummy)                {

                    if (GlobalVariables.startStopVariable == 1) { 
                        int[] noteArr = new int[] {

                            56, 57, 58, 59, 60, 61, 62, 63, 82, 99,
                            99, 99, 99, 99, 99, 99, 48, 49, 50, 51,
                            52, 53, 54, 55, 83, 99, 99, 99, 99, 99,
                            99, 99, 40, 41, 42, 43, 44, 45, 46, 47,
                            84, 99, 99, 99, 99, 99, 99, 99, 32, 33,

                            34, 35, 36, 37, 38, 39, 85, 99, 99, 99,
                            99, 99, 99, 99, 24, 25, 26, 27, 28, 29,
                            30, 31, 86, 99, 99, 99, 99, 99, 99, 99,
                            16, 17, 18, 19, 20, 21, 22, 23, 87, 99,
                            99, 99, 99, 99, 99, 99,  8,  9, 10, 11,

                            12, 13, 14, 15, 88, 65, 66, 67, 68, 69,
                            70, 71,  0,  1,  2,  3,  4,  5,  6,  7,
                            89, 99, 99, 99, 99, 99, 99, 99 };

                        int[] seqArr = new int[] {
                             0,  1,  2,  3,  4,  5,  6,  7,
                            16, 17, 18, 19, 20, 21, 22, 23,
                            32, 33, 34, 35, 36, 37, 38, 39,
                            48, 49, 50, 51, 52, 53, 54, 55,
                            64, 65, 66, 67, 68, 69, 70, 71,
                            80, 81, 82, 83, 84, 85, 86, 87,
                            96, 97, 98, 99,100,101,102,103,
                            112,113,114,115,116,117,118,119,
                            121,121,121,121,121,121,121,121,
                            121,121,121,121,121,121,121,121,
                            121,121,121,121,121,121,121,121,
                            121,121,121,121,121,121,121,121,
                            121,121,121,121,121,121,121,121,
                            121,121,121,121,121,121,121,121
                            };

                    int def1color = 1;
                    int def2color = 1;
                    if (e.Message.Data1 == 19 || e.Message.Data1 == 31)
                    {
                        def1color = 3;
                    }
                    if (e.Message.Data1 == 51)
                    {
                        def1color = 5;
                    }
                    if (e.Message.Data2 == 19 || e.Message.Data1 == 31)
                    {
                        def2color = 3;
                    }
                    if (e.Message.Data2 == 51)
                    {
                        def1color = 5;
                    }


                    if (e.Message.Data1 > 0)
                        {
                            int newnote = noteArr[seqArr[GlobalVariables.countingVariable]];
                            if (outconnected == true)
                            {
                                builder.Command = ChannelCommand.NoteOn;
                                builder.MidiChannel = 0;
                                builder.Data1 = newnote;
                                builder.Data2 = def1color;
                                builder.Build();
                                toAPCmini.Send(builder.Result);
                            }
                        }
                        GlobalVariables.countingVariable++;
                        if (e.Message.Data2 > 0) {
                            int newnote2 = noteArr[seqArr[GlobalVariables.countingVariable]];
                            if (outconnected == true)
                            {
                                builder.Command = ChannelCommand.NoteOn;
                                builder.MidiChannel = 0;
                                builder.Data1 = newnote2;
                                builder.Data2 = def2color;
                                builder.Build();
                                toAPCmini.Send(builder.Result);
                            }

                        }
                        GlobalVariables.countingVariable++;
                    }

                    if (setDebugMode == 1)
                    {
                        context.Post(delegate (object dummy)
                        {
                            channelListBox.Items.Add(
                                "FLS " + '\t' +
                                e.Message.Command.ToString() + '\t' +
                                e.Message.MidiChannel.ToString() + '\t' +
                                e.Message.Data1.ToString() + '\t' +
                                e.Message.Data2.ToString() + '\t' + notice

                                );

                            channelListBox.SelectedIndex = channelListBox.Items.Count - 1;
                        }, null);

                    }
                    /*
                    listBox6.Items.Add(
                        "chanTWO " + '\t' +
                        GlobalVariables.countingVariable + "\t" +
                        e.Message.Command.ToString() + '\t' +
                        e.Message.MidiChannel.ToString() + '\t' +
                        e.Message.Data1.ToString() + '\t' +
                        e.Message.Data2.ToString() + '\t'

                        );

                    listBox6.SelectedIndex = listBox6.Items.Count - 1;
                    */
                //}, null);
            }
            else if (commCheck == "NoteOn" && comChan == 0)
            {

                /*
                if (GlobalVariables.startStopVariable == 2)
                {
                    context.Post(delegate (object dummy)
                    {
                        int j = 0;
                        string outstring = "";
                        while (j < GlobalVariables.pageDataArray.Length)
                        {
                            outstring = outstring + "," + GlobalVariables.pageDataArray[j].ToString();
                        }
                        listBox6.Items.Add(
                            outstring

                            );
                        channelListBox.SelectedIndex = listBox6.Items.Count - 1;
                    }, null);
                    GlobalVariables.startStopVariable = 0;


                }
                */

                // MAIN PAD
                int[] noteArr = new int[] {

                   56, 57, 58, 59, 60, 61, 62, 63, 82, 99,
                   99, 99, 99, 99, 99, 99, 48, 49, 50, 51,
                   52, 53, 54, 55, 83, 99, 99, 99, 99, 99,
                   99, 99, 40, 41, 42, 43, 44, 45, 46, 47,
                   84, 99, 99, 99, 99, 99, 99, 99, 32, 33,

                   34, 35, 36, 37, 38, 39, 85, 99, 99, 99,
                   99, 99, 99, 99, 24, 25, 26, 27, 28, 29,
                   30, 31, 86, 99, 99, 99, 99, 99, 99, 99,
                   16, 17, 18, 19, 20, 21, 22, 23, 87, 99,
                   99, 99, 99, 99, 99, 99,  8,  9, 10, 11,

                   12, 13, 14, 15, 88, 65, 66, 67, 68, 69,
                   70, 71,  0,  1,  2,  3,  4,  5,  6,  7,
                   89, 99, 99, 99, 99, 99, 99, 99 };

                int newnote = noteArr[a];

                int[] onoffArr = new int[] {
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 5,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
                    1, 1, 1, 1, 1, 1, 0, 0, 0, 0,

                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0,

                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0};

                int[] colorArr = new int[] {
                    0, 0, 5, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 4, 0, 0, 0, 0, 3,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 3, 1, 1, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 1, 1, 0, 0, 0, 0,

                    0, 5, 5, 5, 5, 5, 5, 5, 5, 5,
                    5, 5, 5, 5, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 1, 1, 1, 0,

                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0 };
                int newcolor = -1;

                if (newnote >= 82 && newnote <= 89)
                {
                    newcolor = onoffArr[b];
                }
                else if (newnote >= 64 && newnote <= 71)
                {
                    newcolor = onoffArr[b];
                }
                else
                {
                    newcolor = colorArr[b];
                }

                if (outconnected == true)
                {
                    builder.Command = ChannelCommand.NoteOn;
                    builder.MidiChannel = 0;
                    builder.Data1 = newnote;
                    builder.Data2 = newcolor;
                    builder.Build();
                    toAPCmini.Send(builder.Result);
                    if (setDebugMode == 1)
                    {
                        notice = " NoteOn " + "0:" + newnote + ":" + newcolor;
                    }
                }
                if (setDebugMode == 1)
                {
                    context.Post(delegate (object dummy)
                    {
                        channelListBox.Items.Add(
                            "FLSsss " + '\t' +
                            e.Message.Command.ToString() + '\t' +
                            e.Message.MidiChannel.ToString() + '\t' +
                            e.Message.Data1.ToString() + '\t' +
                            e.Message.Data2.ToString() + '\t' + notice

                            );

                        channelListBox.SelectedIndex = channelListBox.Items.Count - 1;
                    }, null);

                }
            }
            else if (commCheck == "NoteOff" && comChan == 0)
            {
                // MAIN PAD

                int[] noteArr = new int[] {

                   56, 57, 58, 59, 60, 61, 62, 63, 82, 99,
                   99, 99, 99, 99, 99, 99, 48, 49, 50, 51,
                   52, 53, 54, 55, 83, 99, 99, 99, 99, 99,
                   99, 99, 40, 41, 42, 43, 44, 45, 46, 47,
                   84, 99, 99, 99, 99, 99, 99, 99, 32, 33,

                   34, 35, 36, 37, 38, 39, 85, 99, 99, 99,
                   99, 99, 99, 99, 24, 25, 26, 27, 28, 29,
                   30, 31, 86, 99, 99, 99, 99, 99, 99, 99,
                   16, 17, 18, 19, 20, 21, 22, 23, 87, 99,
                   99, 99, 99, 99, 99, 99,  8,  9, 10, 11,

                   12, 13, 14, 15, 88, 65, 66, 67, 68, 69,
                   70, 71,  0,  1,  2,  3,  4,  5,  6,  7,
                   89, 99, 99, 99, 99, 99, 99, 99 };

                int newnote = noteArr[a];

                int[] onoffArr = new int[] {
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 5,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
                    1, 1, 1, 1, 1, 1, 0, 0, 0, 0,

                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0,

                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0};

                int[] colorArr = new int[] {
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 4, 0, 0, 0, 0, 3,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 3, 1, 1, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 1, 1, 0, 0, 0, 0,

                    0, 5, 5, 5, 5, 5, 5, 5, 5, 5,
                    5, 5, 5, 5, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 1, 1, 1, 0,

                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0 };
                int newcolor = -1;

                if (newnote >= 82 && newnote <= 89)
                {
                    newcolor = onoffArr[b];
                }
                else if (newnote >= 64 && newnote <= 71)
                {
                    newcolor = onoffArr[b];
                }
                else
                {
                    newcolor = colorArr[b];
                }

                if (outconnected == true)
                {
                    builder.Command = ChannelCommand.NoteOff;
                    builder.MidiChannel = 0;
                    builder.Data1 = newnote;
                    builder.Data2 = newcolor;
                    builder.Build();
                    toAPCmini.Send(builder.Result);
                    if (setDebugMode == 1)
                    {
                        notice = " NoteOff " + "0:" + newnote + ":" + newcolor;
                    }
                }
                if (setDebugMode == 1)
                {
                    context.Post(delegate (object dummy)
                    {
                        channelListBox.Items.Add(
                            "FLS " + '\t' +
                            e.Message.Command.ToString() + '\t' +
                            e.Message.MidiChannel.ToString() + '\t' +
                            e.Message.Data1.ToString() + '\t' +
                            e.Message.Data2.ToString() + '\t' + notice

                            );

                        channelListBox.SelectedIndex = channelListBox.Items.Count - 1;
                    }, null);
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
            /*
            context.Post(delegate (object dummy)
            {
                string result = "\n\n"; ;

                foreach (byte b in e.Message)
                {
                    result += string.Format("{0:X2} ", b);
                }

                sysExRichTextBox.Text += result;
            }, null);
            */
        }


        private void HandleSysRealtimeMessageReceived(object sender, SysRealtimeMessageEventArgs e)
        {
            /*
            context.Post(delegate (object dummy)
            {
                sysRealtimeListBox.Items.Add(
                    e.Message.SysRealtimeType.ToString());

                sysRealtimeListBox.SelectedIndex = sysRealtimeListBox.Items.Count - 1;
            }, null);
            */
        }

        private void InDevice_Error(object sender, ErrorEventArgs e)
        {
            MessageBox.Show(e.Error.Message.ToString(), "Error!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
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

        private void Button5_Click(object sender, EventArgs e)
        {


            int ii = (listBox3.SelectedIndex + 1);
            int i = (listBox4.SelectedIndex - 1);
            context = SynchronizationContext.Current;

            toAPCmini = new OutputDevice(ii);


            fromAPCmini = new InputDevice(i);
            // fromAPCmini.StartRecording();


            if (toAPCmini != null)
            {
                toAPCmini.Dispose();
            }
            if (fromAPCmini != null)
            {
                fromAPCmini.StopRecording();
                fromAPCmini.Close();
            }



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
                channelListBox.Items.Add("CONNECTION APC MINI Attempted");
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
                channelListBox.Items.Add("CONNECTED APC mini to APC control");
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

        private void button5_Click_1(object sender, EventArgs e)
        {
            int i = (listBox5.SelectedIndex + 1);
            context.Post(delegate (object dummy)
            {
                channelListBox.Items.Add("CONNECTED APC sliders to Mixer");
                channelListBox.SelectedIndex = channelListBox.Items.Count - 1;
            }, null);
            toFLstudioMixer = new OutputDevice(i);
            button5.Enabled = false;

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void listBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
    static class GlobalVariables
    {
        static public int goStartVariable { get; set; }
        static public int startStopVariable { get; set; }
        static public int countingVariable { get; set; }
        static public int[] up1DataArray { get; set; }
        static public int[] up2DataArray { get; set; }
        static public int[] noteValueDataArray { get; set; }
    }

}