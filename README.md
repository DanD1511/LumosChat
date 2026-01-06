# ⚡ LumosChat

> A robust, real-time Fullstack chat application built with modern Clean Architecture, .NET 8, and Angular 17.

![LumosChat Banner](./LumosChat.Frontend/public/LumosChat.png)

<div align="center">

![Status](https://img.shields.io/badge/Status-Completed-success?style=for-the-badge)
![NET](https://img.shields.io/badge/.NET%208-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![Angular](https://img.shields.io/badge/Angular%2017-DD0031?style=for-the-badge&logo=angular&logoColor=white)
![SignalR](https://img.shields.io/badge/SignalR-RealTime-blue?style=for-the-badge)
![PostgreSQL](https://img.shields.io/badge/PostgreSQL-316192?style=for-the-badge&logo=postgresql&logoColor=white)

</div>

---

## Project Overview

**LumosChat** is not just another To-Do list. It is a complex **Fullstack Single Page Application (SPA)** designed to demonstrate how to integrate an Enterprise-grade backend with a reactive, modern frontend.

The primary goal was to build a secure, scalable instant messaging system, solving real-world challenges such as token-based authentication, bidirectional real-time communication, complex state management, and a polished UI/UX.

The backend follows **Clean Architecture** principles to ensure separation of concerns and long-term maintainability.

---

## Key Features

### Real-Time Experience
* **Instant Messaging:** Powered by **SignalR (WebSockets)** to send and receive messages instantly without page reloads.
* **Live User Status:** The server tracks connected users in memory and broadcasts the "Online Users" list updates to all clients in real-time.

### Security & Authentication
* **Full Auth Flow:** Secure Registration and Login system.
* **JWT Protection:** All API routes and SignalR Hubs are protected using **JSON Web Tokens (JWT)**.

### Modern UI/UX (Teal Dark Mode)
* **Professional Design:** A minimalist dark interface with "Teal" accents, inspired by modern SaaS chat tools.
* **Smart Chat Bubbles:** WhatsApp-style dynamic layout; own messages align to the right (Teal), others to the left (White).
* **Auto-Avatars:** Integration with **DiceBear API** to generate unique avatars based on usernames automatically.
* **Responsive Layout:** CSS Grid and Flexbox implementation ensuring the app fits 100% of the viewport height (No double scrollbars).

### Architecture & Code Quality
* **Clean Backend:** Strict separation of layers (API, Application, Domain, Infrastructure).
* **Modern Frontend:** Built entirely with **Angular Standalone Components** (No NgModules) and the new **Signals API** for granular performance.

---

## Tech Stack

| Area | Technologies |
| :--- | :--- |
| **Backend** | .NET 8, ASP.NET Core Web API, **SignalR**, Entity Framework Core, JWT Auth. |
| **Frontend** | **Angular 17+**, TypeScript, Signals, Bootstrap 5, SCSS (Custom Properties). |
| **Database** | PostgreSQL (Configurable for SQL Server or In-Memory). |
| **Tools** | Visual Studio Code, Postman, ngrok, Git. |

---

## How to Run Locally (Development Mode)

Follow these steps to run the project on your machine for development (separate servers).

### Prerequisites
* [.NET 8 SDK](https://dotnet.microsoft.com/download)
* [Node.js (LTS)](https://nodejs.org/) & npm
* [Angular CLI](https://angular.io/cli) (`npm install -g @angular/cli`)

### 1. Start the Backend

```bash
cd LumosChat.Backend/LumosChat.API
dotnet restore
dotnet run --project LumosChat.API
```

Server starts at: http://localhost:5281

2. Start the Frontend

```bash
cd LumosChat.Frontend
npm install
ng serve -o
```

App opens at: http://localhost:4200

How to Deploy with ngrok (Public Access)
To share the application with friends over the internet without deploying to a cloud provider, we use a technique where .NET serves the Angular static files. This allows the entire fullstack app to run on a single port (tunnel).

Step 1: Build Angular for Production
In LumosChat.Frontend, update environment.ts to use relative paths (/api instead of localhost). Then run:

```Bash
ng build
```
Step 2: Serve via .NET

Copy the contents of dist/lumos-chat-frontend/browser into LumosChat.API/wwwroot.

Step 3: Run the Tunnel
Start the backend (dotnet run) and then open a terminal to expose the local port:

#### Replace 5281 with your actual HTTPS port
```
ngrok http http://localhost:5281
```
Copy the Forwarding URL provided by ngrok (e.g., https://xyz.ngrok-free.app) and share it. Users can now Register, Login, and Chat in real-time from anywhere!

🤝 Contributing
Contributions are welcome! If you have ideas for performance improvements or new UI features, feel free to open a Pull Request.