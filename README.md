# 🚀 C# Robot Wars Simulation

This project is a **C# console application** simulating a robot navigating a 5x5 grid for the **Robot Wars** competition. The robot moves according to movement instructions (`L`, `R`, `M`) while tracking penalties for boundary collisions.

## 🔥 Features
- **Grid Navigation:** The robot moves within a 5x5 arena, respecting boundaries.  
- **Instruction Handling:**  
    - `L`: Rotate 90° left.  
    - `R`: Rotate 90° right.  
    - `M`: Move forward one step.  
- **Penalty System:** Tracks invalid moves that attempt to go out of bounds.  
- **Console Output:** Displays the robot's final position and penalty count.  
- **Unit Tests:** Ensures the program behaves as expected for multiple scenarios.  

## ⚙️ Tech Stack
- **Language:** C#  
- **Framework:** .NET  
- **IDE:** Visual Studio  

## 🛠️ Installation and Execution
1. Clone the repository.
2. Open the solution in **Visual Studio**.
3. Build and run the project.
4. View the console output for robot movements and penalties.

## ✅ Usage
The program runs multiple scenarios with initial positions, movement instructions, and final results:
```
Scenario 1: 0, 2, E → MLMRMMMRMMRR  
Final Position: 4, 1, N  
Penalties: 0  

Scenario 2: 4, 4, S → LMLLMMLMMMRMM  
Final Position: 0, 1, W  
Penalties: 1  
```

## 🚦 Unit Testing
The solution includes unit tests to validate the following:
- Correct handling of movement instructions.
- Penalty tracking for boundary collisions.
- Proper robot navigation and direction changes.





