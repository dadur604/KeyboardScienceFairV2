# KeyboardScienceFairV2
  
## Directories & Files:  
**KeyboardScienceFair_V2\ :** C# Desktop Application for creating layouts, uploading to keyboard, and controlling layout changes  
**PCB\ :** Various PCB files for keyboard hardware, including built-in custom arduino using ATMega chip.  
  --> KeyboardFullBoard.pdf : Full Schematic for hardware  
  --> PCB Gerber Files (zip) : gerber files for manufacturing pcb's (ex: jlcpcb.com)  

## Dependancies:  
For the desktop application to compile and upload layouts to the keyboard, it requires two 3rd party dependancies  
- [AvrDude](https://www.nongnu.org/avrdude/) (To Upload to Arduino)  
- [Arduino Builder](https://github.com/arduino/arduino-builder) (To compile generated layouts using gcc)  
  
 \* Installing the [Arduino IDE](https://www.arduino.cc/en/Main/Software) is the easiest way to get both of these dependancies.
  
    
--------
Initially built for a science fair project, you can view the full abstract below:  

## Abstract: Creating a Multilingual Keyboard Utilizing LCD Screens to Aid Multilingual Typers
   
#### Objectives/Goals  
Our project's goal was to create a sort of multilingual keyboard to aid those who type in multiple
languages, or wish to learn a new one. Our objective was to make this keyboard so that the user would not
have to own multiple keyboard, memorize the locations of letters, or place stickers on a keyboard in order
to type in multiple languages. Instead, a single keyboard would be used to type in any language.  
  
#### Methods/Materials  
To create the working prototype, there are two components: hardware and software. Our hardware
consisted of an arduino and two (2) LCD-Desplay Switches by NKK, along with other general parts. We
put everything together from soldering to placing resistors. Two pieces of software were written: we wrote
a desktop program in C# that will run on the user's pc, and a second program, written in Arduino's
language (based off C) that runs on the arduino. The two programs communicate with each other using
serial communication via a USB cable. All software was written by ourselves, except for the arduino timer
interrupt code, to which credit was given.
  
#### Results  
Our result was a working prototype. The hardware included only two (2) keys ('e' and 'n'), that when
pressed, typed the letters on the computer. When the computer's typing language was changed (Pressing
'Shift + Alt' or 'Windows + Space'), the LCD displays on the keys would change their displays to show the
corresponding letters in the computer's new language.  
  
#### Conclusions/Discussion  
Since our project was only a prototype, we hope to continue development to be able to provide a full
keyboard of LCD-keys. We also only have two built-in languages supported. However, our code is
available online, open-source, so any developer can add on to our code.
