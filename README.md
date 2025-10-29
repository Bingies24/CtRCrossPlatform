# Cut the Rope Cross Platform Decompilation

This is a better version of the Cut the Rope Decompilation which can be found on [Cut the Rope Home](https://ctrhome.github.io) (specifically the original unpatched version on the Discord server) that has been freed from the clutches of WinForms for future modding.



### Compiles on:

* Windows — Windows and Linux, via Visual Studio or build\_windows.bat.
* Linux — Windows (probably works) and Linux, via build\_linux.sh.



## To-do

* Fix the "candy" and "grab" same x value glitch. https://discord.com/channels/1112531659078762617/1112532661773283438/1433224924495089694

* Fix the cursor clicking bug on fading screens. The problem is the function "initFromPixels" in "iframework/visual/Texture2D.cs" loads the cursor from memory(?) instead of the screen.
* Implement a video player, preferably something that is light on size (so no ffmpeg), CPU and GPU load.
* Redo game and window scaling.
* Add fullscreen back.
* Add touchscreen support.
* Make an Android version.



## Notes

To keep OpenAL happy, make sure your sound effects are stereo.



## Disclaimer

Cut the Rope, Feed with Candy, Nommies, Om Nom and ZeptoLab are trademarks of ZeptoLab UK Limited. Anyone who has worked or is working on this are not associated with ZeptoLab in any way.

