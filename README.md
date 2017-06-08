APC MINI FOR FL Studio Multimedia Midi 
=======================
I have FL Studio and I wanted to use my APC mini in performace mode.

You can use midi-ox and loopMIDi to map notes it Kinda works up to a point.

I went looking and did not find much.

MOST of this is source code from the C# MIDI toolkit from CodeProject by Leslie Sanford.
I forked it from Tebjan Halm  https://github.com/tebjan/Sanford.Multimedia.Midi


you will need 

Visual Studio, FL Studio, loopMIDI, and an APCmini.

the Idea is to predend the APC mini is a Launchpad but there are two problems the buttons and the colors
both need to be "remapped" to new values.

--------------------------------------------------------------------------------------------------------
Before you start make two "Virtual loopback MIDI" ports with loopMIDI I labled mine 
"APC Control" and "Lights"

run this solution (or the exe here in)

Click Connect for the APC mini (lights should flash on the APC)... 
Select the In/Out "Virtual loopback MIDI" for FL Studio

in FL Studio F10 (to open midi settings)
    - under Input choose "APC Control" and set it's controller type to "Novation Launchpad" and it's port to "1"
    - set the perfomance mode midi port to "1"
    - under Output choose "Lights" and set that port to "1"


Play with it. 

---------------------------------------------------------------------------------------------------------
My next thing is get the sliders maybe mapped to a third generic midi port so that they can be mapped.
---------------------------------------------------------------------------------------------------------

If you have any improvement or fix to this library, please don't hesitate to make a fork and open a pull request.
MIT License

Credits:
Leslie Sanford
Tebjan Halm
Tobias Erichsen

http://www.codeproject.com/Articles/6228/C-MIDI-Toolkit
https://code.google.com/p/vsticks/
https://www.tobias-erichsen.de/software/loopmidi.html
