# API Figuritas - Proyecto ISTEA

Una API REST desarrollada en **ASP.NET Core 8.0** que gestiona información sobre figuritas del Mundial de fútbol. El proyecto consume datos de una API externa (MockAPI) y expone endpoints para consultar figuritas por diferentes criterios.

## 📋 Descripción

API de Figuritas es una aplicación web servidor que forma parte del proyecto académico para la materia **Aplicaciones Web Servidor** en ISTEA. La API permite:

- Obtener todas las figuritas disponibles
- Filtrar figuritas por país
- Buscar figuritas por ID
- Consumir datos desde una API externa con patrón de inyección de dependencias

## 🛠️ Requisitos

- **.NET 8.0 SDK** o superior
- **Docker** (opcional, para ejecutar en contenedor)
- **Visual Studio 2022**, **Visual Studio Code** o **Rider**

## 📦 Instalación

### Opción 1: Ejecución Local

1. **Clonar el repositorio**
   ```bash
   git clone https://github.com/angeltirado09/API-Figuritas-ProyectoISTEA.git
   cd API-Figuritas-ProyectoISTEA
   ```

2. **Restaurar dependencias**
   ```bash
   dotnet restore
   ```

3. **Compilar el proyecto**
   ```bash
   dotnet build
   ```

4. **Ejecutar la aplicación**
   ```bash
   dotnet run --project Figuritas.Consumer
   ```

   La API estará disponible en: `http://localhost:5024`

### Opción 2: Ejecución con Docker

1. **Buildear la imagen**
   ```bash
   docker build -t figuritas:latest .
   ```

2. **Ejecutar el contenedor**
   ```bash
   docker run -p 5000:5000 figuritas:latest
   ```

   La API estará disponible en: `http://localhost:5000`

## 🔌 Endpoints

### GET `/api/figuritas/GetAllFiguritas`
Obtiene todas las figuritas disponibles en la base de datos.

**Respuesta exitosa (200):**
```json
[
  {
    "id": "1",
    "nombre": "Figurita 1",
    "pais": "Argentina",
    ...
  },
  ...
]
```

**Respuesta sin resultados (404):** No hay figuritas disponibles

---

### GET `/api/figuritas/getFigusByCountry/{country}`
Obtiene todas las figuritas de un país específico.

**Parámetros:**
- `country` (string, requerido): Nombre del país

**Ejemplo:** `/api/figuritas/getFigusByCountry/Argentina`

**Respuesta exitosa (200):**
```json
[
  {
    "id": "1",
    "nombre": "Figurita 1",
    "pais": "Argentina",
    ...
  }
]
```

**Respuesta sin resultados (404):** `No se encontró ninguna figurita del país introducido`

---

### GET `/api/figuritas/getFigusByID/{id}`
Obtiene una figurita específica por su ID.

**Parámetros:**
- `id` (string, requerido): ID de la figurita

**Ejemplo:** `/api/figuritas/getFigusByID/1`

**Respuesta exitosa (200):**
```json
[
  {
    "id": "1",
    "nombre": "Figurita 1",
    "pais": "Argentina",
    ...
  }
]
```

**Respuesta sin resultados (404):** `No se encontró ninguna figurita del ID introducido`

---

## 📚 Documentación API

La documentación interactiva está disponible en Swagger/OpenAPI cuando se ejecuta en modo Development:

```
http://localhost:5024/swagger/index.html
```

## 🏗️ Estructura del Proyecto

```
API-Figuritas-ProyectoISTEA/
├── Figuritas.Consumer/              # Proyecto principal (ASP.NET Core Web API)
│   ├── Controllers/                 # Controladores de la API
│   ├── Services/                    # Servicios de lógica de negocio
│   ├── Program.cs                   # Configuración de la aplicación
│   └── appsettings.json             # Configuración
├── Figuritas.Abstractions/          # Proyecto de abstracciones
│   ├── DTO/                         # Data Transfer Objects
│   ├── Interfaces/                  # Contratos/Interfaces
│   └── Models/                      # Modelos de datos
├── xUnitFiguritasTests/             # Pruebas unitarias con xUnit
├── Dockerfile                        # Configuración Docker
└── README.md                         # Este archivo
```

## 🔧 Configuración

### Fuente de Datos
La API consume datos de MockAPI en la siguiente URL base:
```
https://6a3adaf6917c7b14c74e2a0f.mockapi.io/backend/
```

Para cambiar la fuente de datos, edita el archivo `Program.cs`:
```csharp
builder.Services.AddHttpClient<IFiguritaService, FiguritaService>(client =>
{
    client.BaseAddress = new Uri("TU_URL_AQUI");
});
```

## ✅ Requisitos del Proyecto (ISTEA)

- ✅ Implementación de API REST con ASP.NET Core
- ✅ Inyección de dependencias (HttpClient)
- ✅ Patrón Repository/Service
- ✅ DTOs (Data Transfer Objects)
- ✅ Consumo de API externa
- ✅ Documentación con Swagger/OpenAPI
- ✅ Tests unitarios con xUnit
- ✅ Containerización con Docker

## 🧪 Tests

Para ejecutar los tests unitarios:

```bash
dotnet test
```

## 👨‍💻 Desarrollo

### Agregar una nueva funcionalidad

1. Crear el endpoint en `FiguritasController.cs`
2. Agregar el método en la interfaz `IFiguritaService`
3. Implementar en `FiguritaService.cs`
4. Crear tests en `FiguritasConsumerTests.cs`

## 📝 Notas Importantes

- La API utiliza inyección de dependencias para el servicio `IFiguritaService`
- Los endpoints retornan `404 NotFound` cuando no hay resultados
- Swagger UI está disponible en desarrollo para testear los endpoints
- El proyecto sigue convenciones de nomenclatura de ASP.NET Core

## 👤 Autor

**Ángel Raúl** - Proyecto académico para ISTEA

## 📄 Licencia

Este proyecto es parte del currículo académico de ISTEA.