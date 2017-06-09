APC MINI FOR FL Studio Multimedia Midi 
=======================
I have FL Studio and I wanted to use my APC mini in performace mode.

You can use midi-ox and loopMIDI to map notes and it kind of works up to a point.

I went looking and did not find much.

MOST of this is source code from the C# MIDI toolkit from CodeProject by Leslie Sanford.
I forked it from Tebjan Halm  


I love the APC MINI but it needed some help working with FL Studio

the Idea is to predend the APC mini is a Launchpad for the grid and 
Launch Key for the slider

--------------------------------------------------------------------------------------------------------
FIRST
--------------------------------------------------------------------------------------------------------

 use loopMIDI to make three midi ports 
 https://www.tobias-erichsen.de/software/loopmidi.html

    APC control
    Lights
    Mixer

it s not hard you type a name in a box and click the plus sign


--------------------------------------------------------------------------------------------------------
NEXT
--------------------------------------------------------------------------------------------------------
 APCmini_for_FL_Studio.zip

 http://www.masterwebmonkey.com/APCmini_for_FL_Studio.zip

 download and run setup

--------------------------------------------------------------------------------------------------------
    OR if you are feeling bold you can clone the whole thing and spin up Visual Studio
--------------------------------------------------------------------------------------------------------

Play with it. Enjoy.

---------------------------------------------------------------------------------------------------------
MIT License

Credits:

Leslie Sanford
http://www.codeproject.com/Articles/6228/C-MIDI-Toolkit

Tebjan Halm
https://github.com/tebjan/Sanford.Multimedia.Midi

Tobias Erichsen
https://www.tobias-erichsen.de/software/loopmidi.html
