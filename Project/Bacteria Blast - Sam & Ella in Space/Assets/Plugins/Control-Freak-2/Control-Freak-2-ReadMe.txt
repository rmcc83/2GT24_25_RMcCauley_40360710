-------------------------------------------
Control Freak 2 (2.8.10)
Copyright (C) 2013-2025 Dan's Game Tools
http://DansGameTools.blogspot.com
-------------------------------------------

Online documentation:

https://dansgametools.blogspot.com/p/docs.html


WARNING:

Some script file names were shortened in version 2.8.10. In case of any problems during update, please create a new empty scene, unload any other scenes, then delete /Plugins/Control-Freak-2/Scripts/ directory and import latest Control Freak 2 package for a clean update.


WARNNG:

For some unknown reasons, touch controls may not show up when playing on devices with certain mobile GPUs.
When this happens, please check if your rig is using UI Images with custom materials. Removing these materials fixes the issue.
You can do this automatically by right-clicking on InputRig's component title and picking the dedicated command.



Version 2.8.10

	Fixed Script Converter's "parameter bug".
	Fixed Camera-Space and World-space canvas mode support.
	Changed main menu item structure - now it's main menu -> Tools -> Control Freak 2.
	Added missing gamepad profile banks for console platforms.


Version 2.8.9

	Fixed the Cinemachine Add-on problem.
	Updated Opsive integration package info.
	Updated MacOS gamepad profile bank.


Version 2.8.8

	Added Assembly Definition file.
	Script Converter will now detect and select affected Assembly Definition Files after conversion.
	Fixed 'affected keys' bug.
	Fixed gamepad detection's false positives.

Version 2.8.7

	Added tools to select or remove custom materials from rig's UI images (InputRig context commands).
	Updated UFE 2.4+ add-on.

Version 2.8.6

	Fixed UFE 2.4+ support.


Version 2.8.5

	Added Cinemachine Add-on.
	Fixed CanvasRenderer bug on newer Unity versions.
	Added Mouse emulation Input Rig prefabs.


Version 2.2.8.4

	Improved Unity comapatibility.
	Fixed bug in the Script Converter causing some rare false-positives.
	Fixed PS4 Controller compatibility.
	

Version 2.2.8.3

	Fixed the XBox One controller profile.
	Added keycode debugging option to CF2-Axis-Debugger script.


Version 2.2.8.2

	Added option to disable virtual touch markers for Super Touch Zone.


Version 2.2.8.1
	
	Added new Opsive Ultimate Character Controller Add-on link.
	Added Corgi Engine Rig prefab.


Version 2.2.8

	Fixed Super Touch Zone binding GUI bug.
	

Version 2.2.7

	Added extra utility scripts to /Plugins/Control-Freak-2/Extra/ (KeyPressEvent, AxisEvent, ButtonPressEvent and PressureLevelBinding)


Version 2.2.6
	
	Fixed gamepad profile selection bug.
	Fixed Joystick Animator's Digital mode problem.
	Fixed Unity 2018.1 compatibility.


Version 2.2.5f2
	
    Fixed the button hiding bug.
	

Version 2.2.5
	
    Fixed the TrackPad reset bug.
    Fixed Unity 2017.3 compatibility issues.


Version 2.2.4
	
    Added new axis config-related methods to InputRig class.
    Fixed the bug resetting Sprite Animator transform in the editor.
    Fixed Unity 2017 compatibility issues.

Version 2.2.3
	
    Added fix Unity 5.6 RectTransform bug.
    Playmaker action scripts can now be converted by the CF2 Script Converter.  
    Fixed the Scripting Define Symbols bug of the Installer. 

Version 2.2.2
	
    Added fix for the faulty Switch build target.
    Fixed Assistant losing Input Rig context when changing Play mode.	

Version 2.2.1
	
    Fixed Super Touch Zone bug.
    Initial setup of gamepad bindings for newly created rigs.
    Adjustable Digital Threshold for analog sources of digital-type axes in the Input Rig inspector.
    Added new events to InputRig - [onAddExtraInput] and [onAddExtraInputToActiveRig] for easier integration with external input sources.

Version 2.2.0

    Added UnitZ UNET Add-on. 
    Improved MFi Game Controller support.
    Fixed Script Converter bug causing false positive matches.
    Added SetResolution() method to CFScreen class to fix wrong dpi value returned by Unity after changing resolution.
    'Swipe Over from nothing' Input Rig option is now disabled by default.
 
Version 2.1.0

    Added UFPS Add-On.
    Added game controller profile for Stratus XL.
    Fixed touch pressure bug.
    Assistant will now igonre 'None' key code.

Version 2.0.7

    Simplified the InputRig Inspector.
    Eliminated potential TouchControlPanel bug.

Version 2.0.6

    Improved compatibility with Unity 5.4 and 5.5 (beta).
    Fixed bug in the Script Converter related to Touch struct declaration.
    Fixed bug preventing certain gamepads from being properly recognized by CF2.
    Added nVidia Shield gamepad profile.
    Added 'Send input while returning' option to Touch Steering Wheel.
    Improved CF2 Installer window's pop-up timing.
    Added a question box with option to skip Unity Input Manager axis configuration to newly created Input Rig.

Version 2.0.5

    Added new 'Turn' mode to Touch Steering Wheel control.
    Added new rig prefab for Edy's Vehicle Physics featuring a steering wheel.

Version 2.0.4

    Added auto fix for event systems created in older Unity versions (pre 5.3).
    Fixed Opsive Third Person Controller detection.

Version 2.0.3

    Added 3D touch pressure support.
    Universal Fighting Engine Add-on for older versions (ver. 1.7.1 and eariler).
    Fixed cursor lock bug.
    Added rig prefab for Realistic FPS Prefab ver. 1.23.
    Added rig prefab for Base Helicopter Controller asset.

Version 2.0.2

    Universal Fighting Engine Add-on (starting with ver. 1.7.2).
    Fixed Unity Remote support.
    Changed how Opsive Third Person Controller Add-on is installed.
    Fixed cursor locking on Android.
    Improved XBOX 360 Controller compatibility.
    Improved Input Manager to Rig transfer.
    Added new Playmaker actions : Get/Set Active Rig.
    Changed Unity 4.x version's folder structure to fix web-player compilation error.
    Other minor bug fixes.

Version 2.0.1

    Added support for Unity 4.7.
    Added Opsive Third Person Controller Add-On.
    Rearranged Super Touch Zone's Inspector.
    Fixed Assistant not showing keys affected by mobile-enabled axes as mobile-enabled keys.
    Fixed Super Touch Zone using 'Strict Multi Touch' mode even when only one finger is allowed.
    Fixed cursor not being locked in scenes without CF2 Input Rig.
    Fixed Gamepad Notifier prefab's path.
    Other minor bug fixes.

Version 2.0.0

    First public release.


