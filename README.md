TFS Checkout Notification
=======================
This is a notification app that lives in the system tray and will tell you when you forget some checkouts in the TFS Version Control (TFVC).

This is very useful for large teams and some particular situations:

* Exclusive checkouts
	* If your colleague forgets to checkin his changes, others will be unable to work until these pending changes are resolved;
* Careless Developer
	* He swears he finished that change request but you can see anything new neither in the source control nor in the CI Builds. And he's not a the office. If there was something that could notify him...
* Migration Situations
    * This is a very common scenario for ALM Consultants. Would you dare to migrate a Team Project Source Control with pending changes?
* Multi-Team Developer
    * Imagine a developer that works for several projects at the same time. I'm sure you know how crazy it is to work like one of them... Well, crazy work leads to crazy mistakes. Stop working on an unfinished task to start another in a different project, and so on... This app is a hero for these crazy guys that cannot forget little things like pending changes :-)

Requirements
=======================
* Team Explorer 2013 or newer

Installation
=======================
Simply run Installer/Output/tfscheckoutnotification_install.exe as **Administrator** and you're done. The app will start with Windows.

Configuration
=======================
You basically need to configure 2 things:
* The collection you're going to monitor - I always recommend an Organization to use only one Collection :-)
* The way the app will notify you:
    * By Interval: You decide the interval the App will check for pending changes and show the toast;
    * When Visual Studio closes: if you usually close your Visual Studio at the end of the work, this will probably be more useful and less annoying. It will show you a toast only after Visual Studio closes, every 10 minutes, only if you forget any checkout.

Version 1.1
=======================
This new version comes with these cool new stuff:
* Show Pending Changes window: With this new window you can:
	* View your pending changes;
	* Check-in all or selected ones. Here, if any of your pending changes belong to a Team Project with **Check-in policies**, they will be **all overriden. Be careful**;
	* Undo all or selected ones;
	* Added a shortcut to this window to the context menu and in the balloon notification click.
* Log implementation
	* Now, everytime an exception occurs in this app, you can check the Windows Event Log (Run > eventvwr.msc) for further details;