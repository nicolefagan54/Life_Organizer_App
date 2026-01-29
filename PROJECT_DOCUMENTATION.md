# Life Organizer App
## Professional Practicum Documentation

### Table of Contents
1. [Introduction](#1-introduction)
2. [Target Users](#2-target-users)
3. [System Overview](#3-system-overview)
4. [Functional Requirements](#4-functional-requirements)
5. [Module Requirements](#5-module-requirements)
6. [Non-Functional Requirements](#6-non-functional-requirements)
7. [System Architecture](#7-system-architecture)
8. [Database Design](#8-database-design)
9. [Workflow Descriptions](#9-workflow-descriptions)
10. [Folder Structure](#10-folder-structure)
11. [Conclusion](#11-conclusion)

---

## 1. Introduction

### 1.1 Purpose of the Application
The **Life Organizer App** is designed to help individuals and families manage the core areas of daily living: health, work, home responsibilities, and parenting. The application centralizes schedules, tasks, reminders, and progress tracking into one unified platform, enabling users to maintain balance, reduce stress, and improve productivity.

### 1.2 Project Scope
The app provides tools for:
*   **Health Tracking**: Goal setting, daily habits, and history.
*   **Work Management**: Task lists, project organization, and focus tools.
*   **Home Life**: Household chores, bill tracking, and shared responsibilities.
*   **Parenting**: Kids’ profiles, school schedules, and assigned activities.
*   **Unified Dashboard**: A "single pane of glass" view for daily overview.

The system is designed for scalability, multi-user support, and cross-device synchronization.

## 2. Target Users

| User Type | Primary Needs Addressed |
| :--- | :--- |
| **Working Professionals** | Work tasks, meeting schedules, health habits |
| **Parents** | Kids’ schedules, school events, chore assignments |
| **Students** | Study planning, habit tracking |
| **Families** | Shared calendars, household maintenance, bills |
| **Health-Conscious Users** | Water intake, step counting, mood tracking |

## 3. System Overview
The Life Organizer App is divided into four primary modules:
1.  **Health Management Module**
2.  **Work Life Management Module**
3.  **Home Life Management Module**
4.  **Parenting / Kids Module**

Each module contains its own screens, workflows, and data structures but integrates into a shared **Dashboard** and **Calendar**.

## 4. Functional Requirements

### 4.1 Global Functional Requirements
*   User registration and secure authentication.
*   Dashboard displaying a daily overview of all modules.
*   Centralized Calendar with Day/Week/Month views.
*   Smart reminders and notifications for due items.
*   Full CRUD (Create, Read, Update, Delete) operations for all entities.
*   Multi-profile support (e.g., Family Mode).

## 5. Module Requirements

### 5.1 Health Module
**Features**
*   Daily health checklist (Water, Steps, Sleep).
*   Mood tracking with visual history.
*   Health history log (7-day view).
*   Goal setting for daily habits.

**Functions**
*   Log daily water intake and step counts.
*   Update mood status.
*   View historical health trends.

### 5.2 Work Module
**Features**
*   Task Manager with Priority levels (Low, Medium, High).
*   Active vs. Completed task views.
*   Upcoming Work Meetings sidebar.
*   Focus Mode (Pomodoro style timer).

**Functions**
*   Create, edit, and delete work tasks.
*   Mark tasks as complete.
*   Filter tasks by priority or due date.

### 5.3 Home Life Module
**Features**
*   Bill Tracker (Amount, Due Date, Status).
*   Household Chore Scheduler (General/Unassigned).
*   Visual status indicators for Overdue Bills.

**Functions**
*   Add and track monthly bills.
*   Mark bills as Paid.
*   Manage general household maintenance tasks.

### 5.4 Parenting / Kids Module
**Features**
*   Child Profiles (Name, Age, School Info).
*   School Schedule and Event Calendar.
*   Assigned Chore Charts per child.

**Functions**
*   Add and manage child profiles.
*   Assign specific chores to children.
*   Track school events and activities.

## 6. Non-Functional Requirements

### 6.1 Performance
*   Dashboard loads within 2 seconds.
*   Database queries are optimized for responsiveness.

### 6.2 Security
*   Password hashing for user accounts.
*   Secure database connections.
*   Data validation for all inputs.

### 6.3 Usability
*   Clean, modern, and intuitive User Interface (UI).
*   Color-coded categories for easy visual distinction.
*   Responsive design for various screen sizes.

### 6.4 Scalability
*   Built on ASP.NET Core MVC for robust scalability.
*   Entity Framework Core support for SQL Server or SQLite.

## 7. System Architecture

### 7.1 MVC Pattern
The application follows the **Model-View-Controller** architectural pattern.

**Models** (Data Structures)
*   `User`: System user/parent.
*   `AppTask`: Work and personal tasks.
*   `HealthRecord`: Daily statistics.
*   `Kid`: Child profiles.
*   `Event`: Calendar scheduler.
*   `Chore`: Household tasks.
*   `Bill`: Financial tracking.

**Views** (User Interface)
*   Dashboard (Overview)
*   Health (Tracker)
*   Work (Tasks)
*   Home (Bills/Chores)
*   Kids (Parenting)

**Controllers** (Logic)
*   `DashboardController`
*   `HealthController`
*   `WorkController`
*   `HomeController`
*   `KidsController`

## 8. Database Design

### Key Tables
| Table | Primary Key | Key Attributes |
| :--- | :--- | :--- |
| **Users** | `UserId` | Name, Email, PasswordHash |
| **Tasks** | `TaskId` | Title, Category, DueDate, Priority, Status |
| **HealthRecords** | `HealthId` | Steps, Water, Mood, Date |
| **Kids** | `KidId` | Name, Age, SchoolInfo |
| **Events** | `EventId` | Title, Category, Date, Time |
| **Chores** | `ChoreId` | Title, AssignedTo, Frequency, Status |
| **Bills** | `BillId` | Amount, DueDate, Category, Status |

### Relationships
*   **1 User** has **Many** Tasks, HealthRecords, Kids, Chores, Bills.
*   **1 Kid** has **Many** Events (School/Activities).
*   **1 Chore** can be assigned to **1 Kid** (optional).

## 9. Workflow Descriptions

### 9.1 Add Task Workflow
1.  User selects “New Task” in Work Module.
2.  Enters Title, Due Date, and Priority.
3.  Saves task; System updates Database.
4.  Task appears in "Active Tasks" list immediately.

### 9.2 Health Tracking Workflow
1.  User clicks "Log Water (+1)" or "Add Steps".
2.  System retrieves today's record or creates a new one.
3.  Updates the specific counter.
4.  Dashboard reflects the new numbers instantly.

### 9.3 Kids Chore Assignment
1.  Parent adds a Child Profile.
2.  Clicks "Assign Chore" on the child's card.
3.  Enters chore details (e.g., "Clean Room").
4.  Chore appears under that specific child's profile.

## 10. Folder Structure
The project follows a standard professional ASP.NET Core MVC layout:

```text
LifeOrganizerApp/
│
├── Controllers/
│   ├── DashboardController.cs
│   ├── HealthController.cs
│   ├── WorkController.cs
│   ├── HomeController.cs
│   ├── KidsController.cs
│
├── Models/
│   ├── User.cs
│   ├── AppTask.cs
│   ├── HealthRecord.cs
│   ├── Kid.cs
│   ├── Event.cs
│   ├── Chore.cs
│   ├── Bill.cs
│
├── Views/
│   ├── Dashboard/
│   ├── Health/
│   ├── Work/
│   ├── Home/
│   ├── Kids/
│   ├── Shared/
│
├── Services/
│   ├── CalendarService.cs
│   ├── HealthService.cs
│   ├── TaskService.cs
│   ├── NotificationService.cs
│
├── Data/
│   ├── AppDbContext.cs
│
├── wwwroot/
│   ├── css/
│   ├── js/
│   ├── lib/
│
└── appsettings.json
```

## 11. Conclusion
The **Life Organizer App** is a comprehensive solution for personal family management. By integrating health, work, and family responsibilities into a single interface, it simplifies daily logistics and empowers users to stay organized. This project demonstrates full-stack development capabilities using **ASP.NET Core**, **Entity Framework Core**, and modern **MVC** principles.
