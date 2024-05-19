# EcoVital API

Bienvenido a la API de EcoVital. Esta API proporciona varios endpoints para manejar registros de actividades, feedback, preguntas de seguridad, registros de actividades de usuarios y metas de usuarios. A continuación se detalla cómo utilizar cada uno de los endpoints disponibles.

## Endpoints

### Activity

- **GET /api/Activity**: Obtiene todos los registros de actividades.
- **GET /api/Activity/{id}**: Obtiene un registro de actividad por ID.
- **POST /api/Activity**: Crea un nuevo registro de actividad.
- **DELETE /api/Activity/{id}**: Elimina un registro de actividad por ID. (Requiere autenticación)

### Feedback

- **GET /api/Feedback**: Obtiene todos los feedbacks.
- **GET /api/Feedback/{id}**: Obtiene un feedback por ID.
- **POST /api/Feedback**: Crea un nuevo feedback.
- **DELETE /api/Feedback/{id}**: Elimina un feedback por ID. (Requiere autenticación)

### Security Questions

- **GET /api/SecurityQuestions**: Obtiene todas las preguntas de seguridad.
- **GET /api/SecurityQuestions/{id}**: Obtiene una pregunta de seguridad por ID.
- **GET /api/SecurityQuestions/GetSecurityQuestionByUserId/{userId}**: Obtiene la pregunta de seguridad por el ID del usuario.
- **GET /api/SecurityQuestions/GetSecurityQuestionByQuestion/{questionText}/{userId}**: Obtiene una pregunta de seguridad por el texto de la pregunta y el ID del usuario.
- **POST /api/SecurityQuestions**: Crea una nueva pregunta de seguridad.

### User Activity Records

- **GET /api/UserActivityRecords**: Obtiene todos los registros de actividades de usuarios.
- **GET /api/UserActivityRecords/{id}**: Obtiene un registro de actividad de usuario por ID.
- **GET /api/UserActivityRecords/ByUser/{userId}**: Obtiene los registros de actividades de usuario por ID de usuario.
- **POST /api/UserActivityRecords**: Crea un nuevo registro de actividad de usuario.
- **PUT /api/UserActivityRecords/{id}**: Actualiza un registro de actividad de usuario por ID.
- **DELETE /api/UserActivityRecords/{id}**: Elimina un registro de actividad de usuario por ID. (Requiere autenticación)

### User Goal

- **GET /api/UserGoal**: Obtiene todas las metas de usuario.
- **GET /api/UserGoal/{id}**: Obtiene una meta de usuario por ID.
- **GET /api/UserGoal/Activity/{activityId}**: Obtiene una meta de usuario por ID de actividad.
- **POST /api/UserGoal**: Crea una nueva meta de usuario.
- **POST /api/UserGoal/{userId}**: Crea una nueva meta de usuario para un usuario específico.
- **POST /api/UserGoal/UpdateGoal**: Actualiza una meta de usuario.
- **DELETE /api/UserGoal/{id}**: Elimina una meta de usuario por ID. (Requiere autenticación)

## Notas

- Todos los endpoints están disponibles sin necesidad de autenticación, excepto los endpoints `DELETE`, que requieren autenticación.
- La API está documentada y accesible a través de Swagger. Puedes acceder a la documentación de Swagger navegando a la URL de Swagger en tu aplicación.

## Ejemplo de Uso

### Obtener todos los registros de actividades

```http
GET /api/Activity

POST /api/Activity
Content-Type: application/json

{
  "name": "Running",
  "duration": 30
}


DELETE /api/Activity/{id}


