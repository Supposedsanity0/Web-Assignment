# Course Management System API

This project is an ASP.NET Core Web API demonstrating database services, dependency injection, entity relationships, DTO validation, authentication, authorization, and optimized data querying.

## Technologies Used

- **ASP.NET Core 8 Web API:** Backend framework for building RESTful HTTP services.
- **Entity Framework Core (SQLite builder):** The ORM managing database operations and schema mappings using code-first migrations.
- **JWT (JSON Web Tokens):** Handles secure authentication by passing a digitally signed token as a Bearer string in the HTTP Authorization headers.
- **BCrypt.Net-Next:** Hashes passwords before saving them into the database to restrict unauthorized access to raw credentials.
- **Hangfire:** Implements a background worker memory storage that facilitates the cron-job simulations.
- **Swagger:** Automatically generates interactive API documentation interface.

## Running the Project

1. Keep the working directory inside `CourseManagementAPI`.
2. Run `dotnet restore` to resolve dependencies.
3. Apply Entity Framework migrations via `dotnet ef database update` to generate the local `coursemanagement.db` SQLite database.
4. Execute `dotnet run` to spin up the server.
5. In your browser or API platform, navigate to `https://localhost:<port>/swagger` to view and interact with the endpoints.
6. The Hangfire background job dashboard is available at `https://localhost:<port>/hangfire`.

## Why HTTP-Only Cookies Over LocalStorage For Auth?

While this API currently utilizes standard bearer tokens using incoming headers (as requested), industry standards lean toward HTTP-only cookies in real-world scenarios. The core reason lies in mitigating **Cross-Site Scripting (XSS)** attacks.

Tokens stored in LocalStorage or SessionStorage are easily accessible to maliciously injected front-end JavaScript logic. However, cookies specifically marked as `HttpOnly` can exclusively be transmitted through HTTP response-request handshakes directly handled by the browser, meaning JavaScript (and therefore malicious XSS scripts) physically cannot read them. This immensely reduces token theft risks.
