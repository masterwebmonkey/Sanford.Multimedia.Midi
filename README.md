APC MINI (hack) for FL Studio perfomance mode 

I have FL Studio (https://www.image-line.com/flstudio/) 
they will let you play with but not save untill you buy

and I wanted to use my APC mini in performace mode.

You can use midi-ox and loopMIDI to map notes and it kind of works up to a point.
I went looking and did not find much.  MOST of this is source code from the C# MIDI toolkit from 
CodeProject by Leslie Sanford.  I forked it from Tebjan Halm  


I love the look of the APC MINI and seems like there should be no problem getting it to work 
but it needed some help working with FL Studio

the Idea is to predend the APC mini is a Launchpad for the grid and 
Launch Key for the row of nine sliders

[![IMAGE ALT TEXT](http://img.youtube.com/vi/QSCpdkFN_jU/0.jpg)](https://www.youtube.com/watch?v=QSCpdkFN_jU "Demo Clip")

--------------------------------------------------------------------------------------------------------
    UPDATE  for performace zones.

![IMAGE ALT TEXT](http://masterwebmonkey.com/APCmini-update.jpg)


--------------------------------------------------------------------------------------------------------
FIRST
--------------------------------------------------------------------------------------------------------
 to get started please use loopMIDI to make three midi ports
 https://www.tobias-erichsen.de/software/loopmidi.html

    APCpad
    APClights
    APCmixer

(it is not too hard you type a name in a box and click the plus sign)
UPDATE  I changed the port names for FL 20. 
It seems it automagicly connects channels for output devices now.


![IMAGE ALT TEXT](http://masterwebmonkey.com/loopmidi2.jpg)

--------------------------------------------------------------------------------------------------------
NEXT
--------------------------------------------------------------------------------------------------------
 APCmini_for_FL_Studio.zip

 http://www.masterwebmonkey.com/APCmini_for_FL_Studio.zip
 download and run setup

![IMAGE ALT TEXT](http://masterwebmonkey.com/myprog2.gif)
--------------------------------------------------------------------------------------------------------
 OR if you are feeling bold you can clone the whole thing and spin up Visual Studio
--------------------------------------------------------------------------------------------------------


IN FL STUDIO 
F10 for midi settings 
*NOTE*
Make sure in FL Studio under midi settings [F10] that the APCmini is disabled. 
For my app to translate FL Studio should use the midi port in loopMidi ONLY.

![IMAGE ALT TEXT](http://masterwebmonkey.com/fl_midi.jpg)




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
