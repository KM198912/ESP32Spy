## ESP32-Spy ##

This is a Simple tool to detect Inputs from a NES or SNES Controller for the ESP32.
Inspired by [NintendoSpy](https://github.com/jaburns/NintendoSpy) i decided to start this little Project.

It uses the GameController Lib from [bitluni](https://github.com/bitluni/ArduinoGameController) .

Current plan is to create a win GUI that is able to show a GameController Overlay and Eventually add more Systems.


### Pin Layout ###

The SNES Pinout is relative easy:

![SNES/NES Lyout](https://cdn.discordapp.com/attachments/780070569038708767/1051233113239461922/NesSnesPinout.png)

Clock Pin goes to Pin 22
Data Pin goes to Pin 21
Latch Pin goes to Pin 17
5v goes to 3,3V
GND goes to any GND Pin
