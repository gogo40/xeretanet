xeretanet
=========

XeretaNET is a very simple and stupid network traffic analyzer. I decided to create this application to see if it was possible
to analyze the network traffic of a testing network in some very fast and dumb way. The initial filter was for TCP packets
related to HTTP plain-text requests. Based on that it's possible to analyze any open request, like social networks and streaming
data.

The project is in C# and was created using MonoDevelop. It's not very "configurable" for now, but I'll probably work on that
sometime. The reason why I decided to use C# instead of other languages is because I got used to it (I work with C# on some other
projects), and also because SharpPcap is quite a nice lib!

Thinks you'll need:
- MonoDevelop (it should work perfectly on VisualStudio also, but I didn't have time to test)
- SharpPcap (http://sourceforge.net/projects/sharppcap/)

And, before I forget, a disclaimer: this project is for fun only and should not be used on any real network. Eavesdropping other
people's network traffic is illegal.


- Ricardo
