# Village Assault - 3D RPG Game

![Unity](https://img.shields.io/badge/Engine-Unity-black?style=flat-square&logo=unity)
![C#](https://img.shields.io/badge/Language-C%23-blue?style=flat-square&logo=csharp)
![Platform](https://img.shields.io/badge/Platform-PC%20%7C%20Windows-lightgrey?style=flat-square)

## Overview
**Village Assault** is an immersive third-person action RPG developed in Unity. The project demonstrates core RPG game architecture, including point-and-click movement, AI navigation, blend-tree character animations, responsive combat mechanics, and custom environment sculpting.

---

## Core Features & Mechanics

- **Terrain & Environment Design:** Custom sculpted terrain featuring textured mountains, paths, foliage density controls, and modular medieval village assets.
- **Navigation & Pathfinding:** Integrated Unity AI Navigation (NavMesh) allowing click-to-move pathfinding with smooth camera follow behavior.
- **Character Rigs & Animations:** Character models created using Adobe Fuse and rigged via Mixamo, featuring advanced Animator Blend Trees for seamless Idle-to-Run transitions.
- **Combat System:** Real-time attack combinations, hit detection, dynamic animation triggers, and state machine transitions.

---

## Technologies Used

- **Engine:** Unity Engine (Rendering, Physics, NavMesh, Mecanim Animator)
- **Programming Language:** C# (Gameplay systems, Camera controls, Player controller)
- **IDE:** Visual Studio
- **3D Modeling & Rigging:** Adobe Fuse & Mixamo

---

## Repository Structure

```text
├── Assets/                                # Core scripts, materials, prefabs, and models
├── ProjectSettings/                       # Unity project settings and input configurations
├── Project Stages and Presentation.pdf    # Comprehensive breakdown with dev screenshots
└── README.md                              # Project documentation
```

---

## How to Run & Explore

### 1. Exploring the Project (Unity Editor)
1. Clone the repository to your local machine:
   ```bash
   git clone https://github.com/your-username/village-assault-rpg-game.git
   ```
2. Open **Unity Hub** and click **Add Project from disk**.
3. Select the cloned repository folder and launch the project using the corresponding Unity version.
4. Navigate to `Assets/Scenes` and open the main scene to test or modify game mechanics.

### 2. Playing the Game
- Pre-compiled builds are available under the [Releases](../../releases) tab. Download the latest release package, extract the files, and launch `Village Assault.exe`.

### 3. Reviewing Development Stages
- For step-by-step development notes, architecture decisions, and in-editor screenshots, refer to [`Project Stages and Presentation.pdf`](./Project%20Stages%20and%20Presentation.pdf).

---

## Developer Information

- **Developer:** Tufan Şahin Düzel  
- **Contact:** [tufanduzelsocial@gmail.com](mailto:tufanduzelsocial@gmail.com)  

---
*Developed as a showcase of Unity 3D RPG systems and gameplay programming.*