# Life Organizer App - Implementation Plan

## Goal Description
Build a comprehensive "Life Organizer App" as a personal command-center for health, work, home life, and parenting. The app will be built using ASP.NET Core MVC with Entity Framework Core, following the user's requested structure and features.

## User Review Required
> [!NOTE]
> Database: I will use **SQLite** for the database as it is self-contained and perfect for a standalone portfolio/practicum project without requiring a separate SQL Server instance installation.
> Authentication: I will implement a basic custom authentication or ASP.NET Core Identity depending on complexity fit. For a practicum/portfolio, standard Identity is usually best.

## Proposed Changes

### Project Structure
- Create a new solution and project `LifeOrganizerApp`.
- Organize into `Controllers`, `Models`, `Views`, `Services`, `Data`.

### Data Layer (`Data/` & `Models/`)
- **AppDbContext**: Define `DbSet`s for all entities.
- **Models**:
    - `User`: Identity user.
    - `Task`: Work/Personal tasks.
    - `HealthRecord`: Daily stats (water, steps, sleep).
    - `Kid`: Child profiles.
    - `Event`: Calendar events.
    - `Chore`: Household/Kid chores.
    - `Budget/Bill`: Financial tracking.

### Business Logic (`Services/`)
- `HealthService`: Logic for aggregating health stats.
- `CalendarService`: Logic for organizing events for the dashboard.
- `NotificationService`: Logic for generating reminders.

### UI Layer (`Controllers/` & `Views/`)
- **Dashboard**: aggregated view of "Today".
- **Health**: Charts/Input for health data.
- **Work**: Task lists, project boards.
- **Kids**: Schedules, profiles.
- **Styling**: `wwwroot/css/site.css` with a modern, premium look (dark/light mode).

## Verification Plan

### Automated Tests
- Build verification: `dotnet build`
- Runtime verification: `dotnet run` and accessing `http://localhost:5000`

### Manual Verification
- [x] Verify User Registration/Login (Using Demo User for MVP).
- [x] Verify Dashboard loads.
- [x] Create a Health Record and verify it appears.
- [x] Create a Work Task and see it on the list.
- [x] Add a Kid profile and assign a chore.
- [x] Verify Home Life (Bills/Chores) module.
