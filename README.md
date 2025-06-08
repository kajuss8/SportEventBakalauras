# SportMeet

## Overview
SportSync Events is a web application built using **ASP.NET Blazor** and **C#**, designed to streamline the organization and discovery of sports events. The platform addresses the challenges of participant shortages and inefficient event organization often encountered in social media groups, such as those on Facebook, where advertisements and irrelevant messages complicate coordination.

Our goal is to provide a specialized, user-friendly platform that enables users to:
- Easily **find** sports events.
- **Organize** sports events with minimal hassle.
- Connect with other sports enthusiasts efficiently.
- Leverage an **AI-powered chatbot** powered by GitHub Models to assist with event searches, recommendations, and user queries.

## Features
- **Event Search**: Quickly search for sports events sport type or skill level.
- **Event Creation**: Create and manage sports events.
- **User Profiles**: Manage personal profiles.
- **AI Chatbot**: Powered by the .NET AI Template with GitHub Models (`gpt-4o-mini` for chat, `text-embedding-3-small` for embeddings), the chatbot provides real-time assistance, such as suggesting events, answering FAQs, and guiding users through event creation.

## Tech Stack
- **Frontend**: ASP.NET Blazor
- **Backend**: C# with ASP.NET Core
- **Database**: SQL Server
- **AI Integration**: .NET AI Template with GitHub Models for chatbot functionality
- **Hosting**: local server
- **Other Tools**: 
  - Bootstrap for responsive UI design
  - Entity Framework Core for data access

## Getting Started

### Prerequisites
- [.NET SDK](https://dotnet.microsoft.com/download) (version 9.0 or later)
- [Visual Studio](https://visualstudio.microsoft.com/) or [VS Code](https://code.visualstudio.com/) with C# extensions
- [SQL Server](https://www.microsoft.com/en-us/sql-server) or another compatible database
- Git for version control
- GitHub personal access token for GitHub Models integration

### Installation
1. **Clone the Repository**:
   ```bash
   git clone https://github.com/kajuss8/SportEventBakalauras.git
   cd SportEventBakalauras

2. **Restore Dependencies**:
   ```bash
   dotnet restore

3. **Set Up the Database**:
   - Update the connection string in appsettings.json to point to your database.
   - Run migrations to set up the database schema:
     ```bash
     dotnet ef migrations add InitialCreate
     dotnet ef database update

4. **Configure the AI Chatbot**:
   - Install the .NET AI Template: dotnet new install Microsoft.Extensions.AI.Templates.
   - Configure GitHub Models by adding your GitHub personal access token to secrets.json:
   ```bash
   {
      "GitHubModels:Token": "<your-personal-access-token>"
   }

  - The project uses gpt-4o-mini for chat and text-embedding-3-small for embeddings by default, as specified in the .NET AI Template configuration.
  - Refer to the .NET AI Template documentation for additional setup details.

5. **Run the Application**:
   ```bash
   dotnet run

Open your browser and navigate to https://localhost:7040 (or the port specified in your configuration).
