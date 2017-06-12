APC MINI (hack) for FL Studio perfomance mode 

=======================
I have FL Studio (https://www.image-line.com/flstudio/) 
they will let you play with but not save untill you buy

and I wanted to use my APC mini in performace mode.

You can use midi-ox and loopMIDI to map notes and it kind of works up to a point.
I went looking and did not find much.  MOST of this is source code from the C# MIDI toolkit from 
CodeProject by Leslie Sanford.  I forked it from Tebjan Halm  


I love the look of the APC MINI and seems like there should be no problem getting it to work 
but it needed some help working with FL Studio

the Idea is to predend the APC mini is a Launchpad for the grid and 
Launch Key for the slider

--------------------------------------------------------------------------------------------------------
<<<<<<< HEAD
BUGS 
--------------------------------------------------------------------------------------------------------
    1. when you first try to connect it fails (work around) connect if don't see lights flash or the 
        test buttons don't do anything... close it and restart and it should work

    2. I don't know what to send to FL Studio to change "pages" of shift performace zones.


--------------------------------------------------------------------------------------------------------
FIRST
--------------------------------------------------------------------------------------------------------

 use loopMIDI to make three midi ports 
=======
 to get started use loopMIDI to make 
>>>>>>> 22a13c3a17a6e59454ceef8239e47c0f72e831ea
 https://www.tobias-erichsen.de/software/loopmidi.html

    APC control
    Lights
    Mixer
<<<<<<< HEAD

it s not hard you type a name in a box and click the plus sign


--------------------------------------------------------------------------------------------------------
NEXT
--------------------------------------------------------------------------------------------------------
 APCmini_for_FL_Studio.zip

 http://www.masterwebmonkey.com/APCmini_for_FL_Studio.zip

 download and run setup

=======
--------------------------------------------------------------------------------------------------------
NEXT
--------------------------------------------------------------------------------------------------------
 APCmini_for_FL_Studio.zip
 http://www.masterwebmonkey.com/APCmini_for_FL_Studio.zip
 download and run setup

--------------------------------------------------------------------------------------------------------
    OR if you are feeling bold you can
    clone the whole thing for that you will need
>>>>>>> 22a13c3a17a6e59454ceef8239e47c0f72e831ea
--------------------------------------------------------------------------------------------------------
    OR if you are feeling bold you can clone the whole thing and spin up Visual Studio
--------------------------------------------------------------------------------------------------------

Play with it. Enjoy.

---------------------------------------------------------------------------------------------------------
MIT License

Credits:

Image-Line Software makers of FL Studio
(https://www.image-line.com/flstudio/) 

Leslie Sanford
http://www.codeproject.com/Articles/6228/C-MIDI-Toolkit

Tebjan Halm
https://github.com/tebjan/Sanford.Multimedia.Midi

Tobias Erichsen
https://www.tobias-erichsen.de/software/loopmidi.html
