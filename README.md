# Refiq6! Technology Department - Online Store API

This project is a simple implementation of an online quiz application with a focus on clean code and simplicity. 
The API provides endpoints to manage quiz without the need for an authentication system.

## Entities

### Quiz
- Id
- Name
- AuthorName
- QuestionCount
- OptionCount
- Avatar
- Code

### Question
- Id
- Title
- Order
- QuizId

### Option
- Id
- Title
- ImageUrl
- IsCorrect
- Order
- QuestionId

## Requirements

The following endpoints need to be implemented as REST APIs:

1. **Add a Quiz:**
   - Endpoint: POST /api/quiz
   - Description: Adds a new quiz 

2. **Get Quiz by code:**
   - Endpoint: PUT /api/quiz/{code}
   - Description: Get quiz by code

### Side Notes

- Use `ef core` as the ORM (code first).
- There is no need for an authentication system.
- Both simplicity and cleanliness of code are essential.

## Getting Started

1. Make sure you have .NET Core SDK installed.
2. Clone this repository.
3. Update the database connection string in the `appsettings.json` file.
4. Run `dotnet ef database update` to apply the migrations and create the database.
5. Run the application using `dotnet run`.

## API Documentation

The API documentation will be available at `/swagger` endpoint when the application is running.

## Dependencies

The project uses EF Core, ASP.NET Core, and other standard C# libraries.

## Contributions

Contributions are welcome. Feel free to fork the repository and submit pull requests.

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.