# 🧾 Simple Product Order API

A simple RESTful Web API built with .NET Core 9, utilizing Entity Framework Core and SQL Server for managing orders, products, and authentication.

## 🛠️ Tech Stack

- **Backend**: C# with ASP.NET Core 9
- **Database**: SQL Server
- **ORM**: Entity Framework Core
- **Authentication**: JWT Bearer Tokens
- **Validation**: FluentValidation

## 🚀 Getting Started

### Prerequisites

- [.NET 9 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/9.0)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)
- [Docker](https://www.docker.com/) (optional, for containerization)a

### Installation (Locally)

1. **Clone the repository:**

   ```bash
   git clone https://github.com/fajarhikmal214/simple-product-order-api.git
   cd simple-product-order-api
   ```

2. **Make Sure `appsettings.json` file exists:**

   Example:
   ```json
   {
     "ConnectionStrings": {
       "DefaultConnection": "Server=localhost;Database=OrderManagementDb;User Id=sa;Password=yourStrongPassword;"
     },
     "Jwt": {
       "Key": "your_jwt_secret_key"
     }
   }
   ```

3. **Install required dependencies:**

   For running the project locally, you can use the .NET CLI to restore the project dependencies.
    
   ```bash
   dotnet restore
   ```

4. Build the project

   Build the project to ensure all the dependencies are correctly set up.

   ```bash
   dotnet build
   ```

5. Run the API:

   To start the application locally in development mode, use the following command:

   ```bash
   dotnet run
   ```

   This will launch the API at http://localhost:5000 (default).

### Installation (using Docker)

1. Build the Docker container:

   If you prefer to run the application in a containerized environment, you can use Docker Compose.

   ```bash
   docker-compose up --build
   ```
   
2. Stopping the Docker container:

   To stop the container and remove the containers, networks, and volumes, use:

   ```bash
   docker-compose down
   ```
