
# Prosigliere backend challenge

  

## Index

  

- [Introduction](#introduction)

- [Challenge Requirements](#challenge-requirements)

- [Stack Used](#stack-used)

- [Instructions to Run Locally with Docker](#instructions-to-run-locally-with-docker)

- [Testing](#testing)

- [License](#license)

  

## Introduction

  

This repository contains the solution for the Prosigliere backend challenge, which involves building an API for a simple blogging platform using .NET

  

## Challenge Requirements

  

1.  **Data Models**:

  

- Create two data models: BlogPost and Comment.

- A BlogPost has a title and content.

- Each BlogPost can have multiple Comment objects associated with it.

  

2.  **API Endpoints**:

  

-  `GET /api/posts`: Return a list of all blog posts, including their titles and the number of comments associated with each post.

-  `POST /api/posts`: Create a new blog post.

-  `GET /api/posts/{id}`: Retrieve a specific blog post by its ID, including its title, content, and a list of associated comments.

-  `POST /api/posts/{id}/comments`: Add a new comment to a specific blog post.

  

## Stack Used

  

The following technologies and tools were used between others to build the solution:

  

-  **Backend**:

  

- ASP.NET Core

- Entity Framework Core

- SQL Server

- AutoMapper

- MediatR

- FluentValidation

  

-  **Testing**:

  

- xUnit

- Moq

- In-Memory Database for Integration Tests

  

-  **Containerization**:

- Docker

- Docker Compose

  

## Instructions to Run Locally with Docker

  

Follow these steps to run the project locally using Docker:

  

1.  **Prerequisites**:

  

- Install Docker and Docker Compose on your machine.

  

2.  **Clone the Repository**:

  

```bash

git clone <repository-url>

cd prosigliere-backend-challenge

```

  

3.  **Build and Start Services**: Run the following command to build and start all services:

  

```bash

docker-compose up --build api

```

  

4.  **Access the Services**:

  

-  **Backend API**:

  

- HTTP: [http://localhost:18080](http://localhost:18080)

- HTTPS: [https://localhost:18081](https://localhost:18081)

  

-  **SQL Server**:

  

- Port: `11433`

  

5.  **Stop Services**: To stop all services, run:

```bash

docker-compose down

```

  

## Testing

  

There are automated tests included in the solution, which can be run in two ways:

  

1.  **Using the xUnit Project Locally**

You can run the tests using the built-in xUnit test project in the solution. Use your preferred .NET test runner or execute:

  

```bash

dotnet test

```

  

inside the test project directory.

  

2.  **Using Docker Compose**

You can run:

  

```bash

docker-compose up --build test

```

  

Test results will show in your terminal. The tests cover both unit and integration scenarios for the main features of the API.

  

## Next Steps

  

To scale and prepare this API for production, several improvements should be considered. The domain entities could be further refined to better reflect business needs, for example by including author information, timestamps for posts and comments, tags, categories, and publication status.

  

Implementing caching strategies (in-memory or distributed) would help improve performance and reduce database load. Pagination should be added to endpoints returning collections, and API usage should be limited and documented to prevent abuse (e.g., rate limiting).

  

Structured logging and metrics collection are essential for monitoring, debugging, and maintaining the health of the application. Setting up alerts for critical errors or performance issues is also recommended.

  

Test coverage can be expanded, especially for repositories and command/query handlers. Load and stress testing should be considered to ensure the system behaves correctly under high demand.

  

Other best practices include adding authentication and authorization, secure configuration management, add docker environments, and language resources.

  

## License

  

This project is developed for the Prosigliere Challenge and is intended for educational and assessment purposes only.