# C# Web App Example
This is an example of a web application written in C#.
The application uses CircleCI to deploy to Heroku.
View the application here: https://csharp-web-app-example.herokuapp.com

## Projects
The application has been split in to multiple projects

### Triangles
This is the base service that handles the business logic of processing requests for triangles.
Each use case is split in to it's own name space to improve encapsulation and maintainability.

#### Model
Contains the domain model for the problem

##### Triangle
The vertices within a Triangle are always ordered from top left to bottom right,
through left to right scanning. This allows Triangles to be easily compared.

#### TriangleByPosition
This case covers the first requirement to allow the vertices of a triangle within the configured grid
to be looked up by the position defined as row and column.
The row is specified as a char, and column as int as per the business requirements

The service depends on a Repository to provide the triangle requested. This is handled using DI.
The response from the service is specific to the use case, so the required details are mapped to a DTO
using AutoMapper to reduce risk of typos and ease updating code.

#### TriangleByVertices
This is pretty much just the reverse of the above case, and follows much the same rules.

### CalculatedTriangleRepo
This provides an implementation of the Repositories required by Triangles.
This specific implementation calculates the responses based on its configuration.
This can therefore be easily replaced with a different implementation without affecting the Triangles project at all.

### WebApp
This is the .NET application that handles the incoming HTTP requests and converts them to calls to the
Triangles services. This is mostly wiring and does not have any business logic. 

#### VetexTypeConverter
This is used to convert the query string parameters on the Find request to an expected structure.

#### CheckModelStateAttribute
This is used to check the request is valid before making the controller request, i.e. it ensures that
the request conforms to the required structure.

#### wwwroot
This project also contains a basic single page website at its route to assist in exercising the API.
The website uses Bootstrap for layout and leverages JQuery to access the API.

## Unit Tests
Unit testing is done on the Triangles and CalculatedTriangleRepo projects to cover key business logic.
Classes purely involved in wiring .NET do not have associated unit tests as they do not have any business logic.

# How To Run
`launchSettings.json` is provided to allow running of the application in development.

A `Dockerfile` is present as used by *CircleCI* to build a container containing the application.
Along with the configuration at `.circleci/config.yml` this is used to automatically deploy to Heroku