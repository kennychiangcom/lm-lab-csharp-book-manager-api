# 📖 Minimalist Book Manager API - C# ASP.NET Core MVC Web API

## Introduction
This is the starter repository for the Further APIs session. It provides some starter code to creating a Minimalist Book Manager API with synchronous API endpoints.

### Pre-Requisites
- C# / .NET 6
- NuGet

### Technologies & Dependencies
- ASP.NET Core MVC 6 (Web API Project)
- NUnit testing framework
- Moq

### How to Get Started
- Fork this repo to your Github and then clone the forked version of this repo.

### Main Entry Point
- The Main Entry Point for the application is: [Program.cs](./BookManagerApi/Program.cs)

### Running the Unit Tests
- You can run the unit tests in Visual Studio, or you can go to your terminal and inside the root of this directory, run:

`dotnet test`

### Tasks

Here are some tasks for you to work on:

📘 Discussion Task

Explore the code and make notes on the following features and how it is being implemented in the code. We'd like you to note down what classes and methods are used and how the objects interact.

The features are:
- Get All Books
- Get a Book by ID
- Add a Book
- Update a Book

📘 Task 1: Implement the following User Story with tests.

`User Story: As a user, I want to use the Book Manager API to delete a book using its ID`


📘 Extension Task: Oh no! 😭 We've only covered the happy paths in the solution, can you figure out a way
to add in exception handling to the project? 

- Clue 1: What if someone wants to add a book with an ID for a book that already exists? How do we handle this gracefully?

- Clue 2: What if someone wants to find a book by an ID that doesn't yet exist? 
  How can we improve the API by handling errors gracefully and show a helpful message to the client?

## Implementation of additional tasks
There are 2 updates implemented according to the tasks as specified above.

### Task 1: Implement delete book by id and its tests.
The following methods are added for implementing the feature:


**BookManagementServices.cs and IBookManagementServices.cs:**
  - `DeleteBook(long id)`

  This method verifies the existence of the specified book id and return true if the deletion is successful, false if the specified book id cannot be found. Its relevant interface is also updated.

**BookManagementController.cs:**
  - `DeleteBookById(long id)`

  This method provides the API interface of this delete book by id feature which gives relevant response to users.

**BookManagementControllerTests.cs:**
  - `DeleteBookById_Deletes_Correct_Book()`

  This method provides unit tests for the delete book by id feature.

  _***All unit tests were run without issues as of the previous commit._

### Extension Tasks: Handling exception situations:
All of the HTTP handling methods were reviewed and exception handlings were added as below:

`HttpGet` - Get all books: If there is nothing stored in the system, an error id 1 and message will be produced to the API client.

`HttpGet("{id}")` - Get book by id: If the book id isn't exist, an error id 2 and a message indicating the id of the non-existence book will be produced to the API client.

`HttpPut("{id}")` - Update book by id: If the relevant book id of the book specified to update was not found, an error id 3 and a message indicating the id of the non-existence book will be produced to the API client.
* The method Update() under BookManagementServices.cs has also been modified to properly return results for the identification of exceptions.

`HttpPost` - Add book: If the book id specified in the book to add was found exists in the system, an error id 4 and a message indicating the id of the non-existence book will be produced to the API client.
* The method Create() under BookManagementServices.cs has also been modified to properly return results for the identification of exceptions.

`HttpDelete("{id}")` - Delete book by id: If the book id specified for deletion doesn't exist, an error id 5 and a message indicating the id of the non-existence book will be produced to the API client for the peace of mind.
* The method DeleteBook() under BookManagementServices.cs has already been catered to properly return results for the identification of exceptions.

## Completed Assignment - API Lab 2 - Connecting to Real Databases. 

In this repo:
- Connected to local MySQL database: installed MySQL locally and established connection via localhost
- Created different appsettings.json files: which could contain different settings like database connection strings
- Created different launch profiles
