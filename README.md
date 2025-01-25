# QueHaceres-Cli 📋✅

[![Licencia: MIT](https://img.shields.io/badge/Licencia-MIT-green.svg)](https://opensource.org/licenses/MIT)

![Demo CLI](https://via.placeholder.com/800x400.png?text=Captura+de+Demo+Interactiva)

# Spanish Version

## Description
QueHaceres-Cli is a command-line interface (CLI) application designed to help users manage their daily tasks efficiently. It allows users to add, remove, and list tasks directly from the terminal.

## Key Features 🚀

- ✏️ Add new tasks
- 🗑️ Remove existing tasks
- 📝 List all tasks
- ✅ Mark tasks as completed
- 💾 Save tasks to a file
- 📤 Load tasks from a file
- 🛠️ Persistence in JSON format

## Installation

To install QueHaceres-Cli, follow these steps:

1. Clone the repository:
2. Navigate to the project directory:
3. Build the project:

## Usage 🖥️

To use QueHaceres-Cli, run the following command:

### Commands

- `help`: Help command.
- `add <description>`: Adds a new task.
- `remove <taskId>`: Removes a task by its ID.
- `list [status]`: Lists all tasks, with an optional status filter.
- `change-status <taskId>`: Marks a task as completed.
- `update <taskId> <status>`: Updates the status of the task.

### Examples 📚

- Help: `help`
- Add a new task: `add buy milk`
- Remove a task: `remove 1`
- List all tasks: `list completed`
- Mark a task as completed: `change-status 1 completed`

## Data Structure 💾

Tasks are stored in JSON format:

```json
[
  {
    "Id": 1,
    "Description": "MostriTareaUpdate",
    "Status": 2,
    "CreatedAt": "2025-01-25T15:09:38.1224134-03:00",
    "UpdatedAt": "2025-01-25T15:12:21.3581263-03:00",
    "CompletedAt": null,
    "CancelledAt": null
  }
]

## Possible Improvements 🗺️

- Search tasks by keyword
- Filter by date
- Categorization system
- Export to CSV format

## Contributing 🤝

You could include more specific details on how to contribute to the project, such as:

- Create an issue if you find a bug or have a suggestion.
- Follow code style guidelines (if relevant).
- Detail the pull request workflow.

�Contributions are welcome! Please fork the repository and submit a pull request.

1. Fork this repository.
2. Create a new branch with a descriptive name (git checkout -b feature/new-feature).
3. Make your changes and commit with a clear message.
4. Submit a pull request for review.

Please make sure to follow the code style used in the project and add tests if possible.

License 📄
This project is licensed under the MIT License.

# Version Espaool

## Descripcion
QueHaceres-Cli es una aplicaci�n de interfaz de l�nea de comandos (CLI) dise�ada para ayudar a los usuarios a gestionar sus tareas diarias de manera eficiente. Permite a los usuarios a�adir, eliminar y listar tareas directamente desde el terminal.

## Características principales 🚀

- ✏️ Añadir nuevas tareas
- 🗑️ Eliminar tareas existentes
- 📝 Listar todas las tareas
- ✅ Marcar tareas como completadas
- 💾 Guardar tareas en archivo
- 📤 Cargar tareas desde archivo
- 🛠️ Persistencia en formato JSON

## Instalaci�n

Para instalar QueHaceres-Cli, siga estos pasos:

1. Clone el repositorio:
2. Navega hasta el directorio del proyecto:
3. Construye el proyecto:

## Uso 🖥️

Para utilizar QueHaceres-Cli, ejecute el siguiente comando:

### Comandos

- `ayuda`: Comando de ayuda.
- `agregar <descripcion>`: A�ade una nueva tarea.
- `eliminar <taskId>`: Elimina una tarea por su ID.
- `listar [estado]`: Lista todas las tareas, el filtro de estado es opcional.
- `cambiar-estado <taskId>`: Marca una tarea como completada.
- `actualizar <taskId> <estado>`: Actualiza el estado de la tarea.

### Ejemplos 📚

- Ayuda: ayuda
- A�adir una nueva tarea: agregar comprar leche
- Eliminar una tarea: eliminar 1
- Listar todas las tareas: listar completadas
- Marcar una tarea como completada: cambiar-estado 1 completada

## Estructura de datos 💾

Las tareas se guardan en formato JSON:

[
  {
  "Id": 1,
  "Description": "MostriTareaUpdate",
  "Status": 2,
  "CreatedAt": "2025-01-25T15:09:38.1224134-03:00",
  "UpdatedAt": "2025-01-25T15:12:21.3581263-03:00",
  "CompletedAt": null,
  "CancelledAt": null
  }
]

## Posibles mejoras 🗺️

- Búsqueda de tareas por palabra clave
- Filtrado por fechas
- Sistema de categorías
- Exportación a formato CSV

## Contribuir 🤝

Podr�as incluir detalles m�s espec�ficos sobre c�mo contribuir al proyecto, tales como:
- Crear un issue si encuentras un bug o tienes una sugerencia.
- Seguir las reglas de estilo de c�digo (si es relevante).
- Detallar el flujo de trabajo del pull request.

�Las contribuciones son bienvenidas! Por favor, haga un fork del repositorio y env�e un pull request.

1. Haz un fork de este repositorio.
2. Crea una nueva rama con un nombre descriptivo (`git checkout -b feature/nueva-funcionalidad`).
3. Realiza tus cambios y haz un commit con un mensaje claro.
4. Env�a un pull request para que lo revisemos.

Por favor, aseg�rate de seguir el estilo de c�digo utilizado en el proyecto y agregar pruebas si es posible.

## Licencia 📄
Este proyecto est� licenciado bajo la Licencia MIT.
>>>>>>> 855a530349785eb2bd772562bf7cdb8decc9f854