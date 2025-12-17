Run Beyond - ESLSCA Final Project developed by Moataz Mobarak
Project Overview

Run Beyond is a 3D endless runner game developed in Unity. The player automatically moves forward along an infinite road, avoiding obstacles, collecting coins, and surviving for as long as possible while the game difficulty increases over time.

Features Implemented

Automatic forward movement along the Z-axis

Lane switching (left and right)

Physics-based jumping

Infinite environment using modular road tiles

Dynamic difficulty scaling (speed increases over time)

Obstacles that trigger a game over 

Collectible coins with score tracking

Main Menu, Pause Menu, and Game Over UI

Background music and sound effects

Particle effects on coin collection

Controls

A / Left Arrow – Move Left

D / Right Arrow – Move Right

Space – Jump

ESC – Pause / Resume

How to Run the Game
Option 1: Playable Build (EXE)

Download the playable build from the provided folder or release.

Run RunBeyond.exe.

The game will start from the Main Menu.

Option 2: Unity Project

Open Unity Hub.

Add the project folder.

Open the project using the appropriate Unity version.

Load the MainMenu scene.

Press Play.

Project Structure

Assets/Scenes – Main Menu and Game scenes

Assets/Scripts – All gameplay, UI, and system scripts

Assets/Prefabs – Player, obstacles, coins, and environment prefabs

Assets/Audio – Background music and sound effects

Challenges & Solutions

UI input conflicts between Pause and Game Over menus

Solved using proper UI state management and raycast blocking.

Animation and physics synchronization issues

Solved by separating input handling (Update) and physics logic (FixedUpdate).

Infinite environment performance concerns

Solved using modular tile spawning instead of expanding a single mesh.

Technologies Used:

Unity Engine

C#

Rigidbody Physics

Animator Controller

Mixamo character animations

More advanced difficulty scaling

