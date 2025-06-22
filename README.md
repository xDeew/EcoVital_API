# EcoVital API

Welcome to the EcoVital API. This API provides several endpoints to manage activity records, feedback, security questions, user activity logs, and user goals. Below you'll find details on how to use each available endpoint.

## Endpoints

### Activity

- **GET /api/Activity**: Retrieves all activity records.
- **GET /api/Activity/{id}**: Retrieves a specific activity record by ID.
- **POST /api/Activity**: Creates a new activity record.
- **DELETE /api/Activity/{id}**: Deletes an activity record by ID. (Requires authentication)

### Feedback

- **GET /api/Feedback**: Retrieves all feedback entries.
- **GET /api/Feedback/{id}**: Retrieves a specific feedback entry by ID.
- **POST /api/Feedback**: Creates a new feedback entry.
- **DELETE /api/Feedback/{id}**: Deletes a feedback entry by ID. (Requires authentication)

### Security Questions

- **GET /api/SecurityQuestions**: Retrieves all security questions.
- **GET /api/SecurityQuestions/{id}**: Retrieves a security question by ID.
- **GET /api/SecurityQuestions/GetSecurityQuestionByUserId/{userId}**: Retrieves a security question by the user's ID.
- **GET /api/SecurityQuestions/GetSecurityQuestionByQuestion/{questionText}/{userId}**: Retrieves a security question by the question text and user ID.
- **POST /api/SecurityQuestions**: Creates a new security question.

### User Activity Records

- **GET /api/UserActivityRecords**: Retrieves all user activity records.
- **GET /api/UserActivityRecords/{id}**: Retrieves a specific user activity record by ID.
- **GET /api/UserActivityRecords/ByUser/{userId}**: Retrieves user activity records by user ID.
- **POST /api/UserActivityRecords**: Creates a new user activity record.
- **PUT /api/UserActivityRecords/{id}**: Updates a user activity record by ID.
- **DELETE /api/UserActivityRecords/{id}**: Deletes a user activity record by ID. (Requires authentication)

### User Goal

- **GET /api/UserGoal**: Retrieves all user goals.
- **GET /api/UserGoal/{id}**: Retrieves a user goal by ID.
- **GET /api/UserGoal/Activity/{activityId}**: Retrieves a user goal by activity ID.
- **POST /api/UserGoal**: Creates a new user goal.
- **POST /api/UserGoal/{userId}**: Creates a new user goal for a specific user.
- **POST /api/UserGoal/UpdateGoal**: Updates an existing user goal.
- **DELETE /api/UserGoal/{id}**: Deletes a user goal by ID. (Requires authentication)

## Notes

- All endpoints are publicly accessible **except** `DELETE` endpoints, which require authentication.
- The API is documented and accessible via Swagger. You can view the Swagger documentation by navigating to the Swagger URL of your application.

## Example Usage

### Retrieve all activity records

```http
GET /api/Activity
POST /api/Activity
Content-Type: application/json

{
  "name": "Running",
  "duration": 30
}
DELETE /api/Activity/{id}
