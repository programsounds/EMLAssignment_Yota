# EML Assignment

## Deriverables

This repository contains the full Unity project source code and a runnable Windows build.

### Runnable build:

`Build/EMLAssignment_Yota.exe`

## Project synopsis

Developed in Unity 6000.0.60f1 (Windows) using Starter Assets (First Person Controller).

This prototype presents a simple first-person interactive system that includes a working inventory, data persistence, and an additional gameplay system that demonstrates extended interactivity and technical integration.

When launched, the game starts immediately in first-person view. The player can move, collect and use items, and interact with a robot enemy that responds to player actions.

The single item type temporarily increases the player’s movement speed for 3 seconds. The robot enemy can be destroyed after being hit three times.

## Operation

| Action | Key / Mouse |
|:--|:--|
| Move | **W A S D** |
| Jump | **Space** |
| Look around | **Mouse movement (left/right, up/down)** |
| Shoot | **Left Mouse Click** |
| Use item | **Right Mouse Click** |
| Drop item | **E** |
| Restart scene | **1** |
| Quit game | **2** |

## List of additional features implemented

- NavMesh Agent AI for the robot enemy that autonomously follows the player.
- Raycast-based shooting system with hit detection and enemy health.
- Impact visual effects (VFX) at raycast hit points.
- Sound effects (SFX) for item pickup, use, and drop actions.
- Restart and quit system using the new Input System.

### Additional system: AI navigation and raycast shooting

For the “additional system,” I implemented a NavMesh Agent AI that continuously tracks and follows the player, combined with a raycast-based shooting mechanic that allows the player to destroy the enemy after several hits. 

I chose this because it reflects my interest in creating reactive, systemic interactions—where behavior, feedback, and player action are closely connected.

It demonstrates my ability to combine Unity subsystems such as NavMesh navigation, physics raycasting, and VFX/SFX feedback into a cohesive interactive loop.

## Item inventory

The player’s inventory count is automatically saved and loaded using a JSON file.

### Save location:

`C:\Users\<user>\Documents\YKGame\Inventory.json`

(The folder is created automatically if it doesn’t exist.)

This file persists between play sessions and stores the total number of collected items.

## How this project represents myself as a developer

This project represents my approach to development—modular, methodical, and experience-driven. I focus on building clear, maintainable systems first, then layering responsive feedback to create an engaging and intuitive experience. Each component—inventory, AI, shooting, sound—was implemented with simplicity and clarity in mind, showing how I structure interactive systems from the ground up.

As a developer with a background in interactive media and audio-visual systems, I enjoy blending technical precision with creative expression.
Even within this small prototype, my goal was to make the interactions feel connected and alive, reflecting how I approach emerging-media projects that merge software engineering with artistic design.