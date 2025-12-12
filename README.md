SmartAlarm is a .NET console application designed to manage personal alarms with advanced scheduling capabilities. It allows users to create, view, and delete alarms, supporting specific days of the week and data persistence via JSON.

Features

CRUD Operations: Create, Read, and Delete alarms.

Weekly Scheduling: Set alarms to ring on specific days (e.g., Mon, Wed, Fri) or as one-time events.

Data Persistence: Automatically saves and loads alarms from alarms.json using System.Text.Json.

User Interface: Simple and intuitive Console Line Interface (CLI) in Ukrainian.

Smart Logic: Placeholder structure for "Smart Awakening" features.

Tech Stack

Language: C#

Framework: .NET 6.0 / .NET 7.0 (Console Application)

Data Format: JSON

IDE: Visual Studio / VS Code

Project Structure

Program.cs - Entry point and UI logic.

Alarm.cs - Data model (Time, Melody, Days, etc.).

AlarmManager.cs - Business logic (CRUD operations).

StorageService.cs - Handles saving/loading data.

How to Run

Clone the repository: git clone https://github.com/MikhailKalinin/SmartAlarm.git

Navigate to the project directory: cd SmartAlarm

Run the application: dotnet run