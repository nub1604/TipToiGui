# TipToiGui

Gui for the tttool from Joachim Breitner https://github.com/entropia/tip-toi-reveng
This program requires the tttool.exe to work fully functional.

The first thing you should do is to set up the tttool.exe in the TipToiGui. 
For this go to tttool > setup, choose the path to the tttool.exe, and hit the validate button. 
Now you should see the usage message from the tttool in the log box underneath.

After setting up, you can use the TipToiGui for a Gui driven helper to assemble your YAML files or create oid-code images.

You can also get started with a new project. 
Use the node editor to define your logics, use the graphics editor to arrange your graphics in a scene, apply polygon frames for your product-id and other oids. 
Finally, you are also able to export the scene in two pictures, one is your image arrangement, and the other ist the generated oid mask.

As a funny and maybe useful feature, you can also debug and play directly in the scene.

Shortcuts in Graphics Editor
- [1 - 7] different switch different modes

Mouse Control in Graphics Editor
- [Right Click] select image or polygon area, also aktivate oid code in simulation mode
- [Left  Click] acts depend on the selected mode (like move image/vertice etc.)
- [Shift + Left CLick] move the selected polygon in the polygon-move mode

Shortcuts in TipToiGui
- [Strg]+[S] Save Project
- [Strg]+[L] Load Last Project
- [F7] Open Graphics Editor
- [F6] Open Speech Editor
- [F5] Open Media Manager

Important note for working with media files
- you have to use the media manager instead of putting the files into the audio folder
- Media Files that were not imported with the Media Manager are ignored
- at the moment, you have to validate the correct file format by yourself (Mono, 22050Hz)

Important note for using the "Welcome" field in the project settings
- Now, you can use the media name from a media file, which you can find in the Media Manager or the Speak Editor
- you also can put multiple sound files together by separating it with a comma
- keep in mind, if you want to use a "speak-name" which has the same name as a media file, the program chooses the media file
