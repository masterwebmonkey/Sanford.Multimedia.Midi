APC MINI FOR FL Studio Multimedia Midi 
=======================
I have FL Studio and I wanted to use my APC mini in performace mode.

You can use midi-ox and loopMIDi to map notes it Kinda works up to a point.

I went looking and did not find much.

MOST of this is source code from the C# MIDI toolkit from CodeProject by Leslie Sanford.
I forked it from Tebjan Halm  https://github.com/tebjan/Sanford.Multimedia.Midi


I love the APC MINI but it needed some help working with FL Studio

the Idea is to predend the APC mini is a Launchpad for the grid and 
Launch Key for the slider

--------------------------------------------------------------------------------------------------------
to get started use loopMIDI to make 

    APC control
    Lights
    Mixer
--------------------------------------------------------------------------------------------------------
NEXT
--------------------------------------------------------------------------------------------------------
run setup from APCmini_for_FL_Studio.zip

--------------------------------------------------------------------------------------------------------
OR you can
--------------------------------------------------------------------------------------------------------

clone the whole thing for that you will need

Visual Studio, FL Studio, loopMIDI, and an APCmini.

--------------------------------------------------------------------------------------------------------

Play with it. 

---------------------------------------------------------------------------------------------------------
If you have any improvement or fix to this library, 
please don't hesitate to make a fork and open a pull request.

MIT License

Credits:
Leslie Sanford
Tebjan Halm
Tobias Erichsen

http://www.codeproject.com/Articles/6228/C-MIDI-Toolkit
https://code.google.com/p/vsticks/
https://www.tobias-erichsen.de/software/loopmidi.html
