# 🛠️ Device Repair Management System

A role-based device repair management platform that allows users to submit repair tickets and technicians to manage, investigate, bill, and complete repair jobs through a well-defined lifecycle.

---

## 📊 Project Status

![Build](https://img.shields.io/badge/build-in%20progress-yellow)
![Platform](https://img.shields.io/badge/platform-.NET%208-blue)
![Architecture](https://img.shields.io/badge/architecture-Clean%20Architecture-brightgreen)
![Auth](https://img.shields.io/badge/authentication-JWT%20%2B%20Cookies-orange)
![Frontend](https://img.shields.io/badge/frontend-ASP.NET%20MVC-lightgrey)

---

## 🧰 Tech Stack

**Backend**
- ASP.NET Core Web API
- Entity Framework Core
- AutoMapper
- JWT Authentication
- Role-based Authorization

**Frontend**
- ASP.NET Core MVC
- Razor Views
- Bootstrap 5

**Architecture**
- Clean Architecture
- Repository Pattern
- CQRS-style separation (Commands / Queries)
- DTO-based API contracts

**Security**
- JWT Tokens
- Cookie Authentication (MVC)
- Claims & Roles

---

## 🔁 Application Workflow Overview

This application is a role-based device repair management system designed to handle ticket creation, job processing, and repair lifecycle tracking. Users can register or log in to create repair tickets describing device issues. Technicians must also register or log in, but can only operate as technicians after an administrator assigns them the appropriate role. Once granted the **Technician** role, they can view, filter, and accept available tasks by assigning them to themselves, which automatically creates a job. With this role enabled, a **Jobs** section becomes available in the navigation, allowing technicians to manage only their accepted jobs. When a task is accepted, the system automatically creates a new job and initializes it with a **Reception** phase. If the job does not yet contain an investigation, the technician may add one, which generates a new **Investigation** phase. Similarly, if billing information has not been provided, the technician can add billing details, triggering the creation of a **Billing** phase. Once repair work is completed, the technician can add a **Repair** phase, followed by a final **Return** phase, which marks the job as completed and populates the job’s `EndDate`. Each job includes a `CreatedAt` timestamp representing the start of the job lifecycle and an `EndDate` representing its completion.

---

## 🧑‍💻 User Roles

### 👤 User
- Register / Login
- Create repair tickets
- Track ticket progress

### 🧑‍🔧 Technician
- Assigned role by Admin
- View and filter available tasks
- Accept tasks (creates Job)
- Manage job lifecycle
- Add investigation, billing, phases

### 🛡️ Admin
- Manage user roles
- Grant Technician permissions

---

## 🧭 Job Lifecycle (Mermaid Diagram)

flowchart LR
    User -->|Create Ticket| Ticket
    Admin -->|Assign Role| Technician
    Technician -->|Accept Ticket| Job
    Job --> Reception
    Reception --> Investigation
    Investigation --> Billing
    Billing --> Repair
    Repair --> Return


🚧 Known Limitations

Some features are not yet implemented in the frontend

APIs already contain full business logic

Notifications are not yet implemented


📝 TODOs

✅ Add functional tests

✅ Add request validation

🔔 Notify users after every state change

📊 Improve job filtering & search

📱 Responsive UI improvements

```mermaid
stateDiagram-v2
    [*] --> Reception
    Reception --> Investigation
    Investigation --> Billing
    Billing --> Repair
    Repair --> Return
    Return --> [*]


