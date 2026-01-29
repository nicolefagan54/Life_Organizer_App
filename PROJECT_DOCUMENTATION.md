# Life Organizer App — Full Project Documentation

## 1. App Overview
The **Life Organizer App** is a personal management system designed to help users balance **health**, **work**, **home life**, and **parenting responsibilities**. It centralizes schedules, tasks, goals, reminders, and progress tracking into one intuitive platform.

The app adapts to different lifestyles:
- Single adults
- Working professionals
- Parents
- Students
- Families

## 2. Target Users
| User Type | Needs |
|---|---|
| Working Adults | Work tasks, meetings, health tracking |
| Parents | Kids’ schedules, chores, school reminders |
| Students | Study schedules, health habits |
| Families | Shared calendars, meal planning |
| Health‑focused users | Fitness, meals, mood tracking |

## 3. Core Modules
The app features four main modules:

### A. Health Module
- Daily health checklist
- Water, sleep, steps tracking
- Workout planner
- Meal planning & Grocery list (integrated)
- Medication reminders
- Mood tracker
- Health goals + streaks

### B. Work Module
- Work tasks
- Priority levels
- Project tracking
- Meeting reminders
- Focus mode (Pomodoro)

### C. Home Life Module
- Household chores
- Bill reminders & Budget tracker
- Home maintenance schedule
- Family events calendar

### D. Parenting Module
- Kids’ school schedule
- Homework tracker
- Extracurricular activities
- Chore charts for kids
- Medical info & Emergency contacts

## 4. Global Features
- **Dashboard**: Aggegated view of daily overview.
- **Smart Reminders**: Unified notifications.
- **Cloud Sync**: SQLite database designed for portability or cloud hosting.
- **Dark/Light Mode**: Premium aesthetic support.

## 5. App Screens (UI Structure)

### 1. Login / Registration
- Email + password Authentication.
- Option for multiple family profiles.

### 2. Dashboard
- **Today’s Overview**: Tasks, Health Stats, Upcoming Events.
- **Quick Actions**: Add Task, Log Health.

### 3. Calendar
- Color‑coded categories (Health=Green, Work=Blue, Home=Yellow, Kids=Purple).
- Monthly/Weekly/Day views.

### 4. Health Screen
- Visual progress bars for water/steps.
- History log.

### 5. Work Screen
- Task lists compatible with KanBan or List view.
- Deadline tracking.

## 6. Functional Requirements

### A. CRUD Operations
Full Create, Read, Update, Delete support for:
- Users
- Tasks
- Health Records
- Events
- Kids
- Chores
- Bills

### B. Data Storage
- **Database**: SQLite (`lifeorganizer.db`)
- **ORM**: Entity Framework Core 10.0

### C. Database Schema
| Table | Description |
|---|---|
| `Users` | Stores user credentials and profile info. |
| `Tasks` | Work and personal tasks with priorities and due dates. |
| `HealthRecords` | Daily logs of steps, water, sleep,mood. |
| `Kids` | profiles for children linked to a parent user. |
| `Events` | Calendar events with categories. |
| `Chores` | Household tasks assigned to users or kids. |
| `Bills` | Financial tracking with amounts and due dates. |

## 7. Technical Architecture
- **Framework**: ASP.NET Core MVC (.NET 10)
- **Language**: C#
- **Front-End**: Razor Views + Bootstrap 5 + Custom Premium CSS
- **Tools**: Git for Version Control
