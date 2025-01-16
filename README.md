# Proyecto .NET Core 8 - API con SQLite

Este proyecto es una API construida con **.NET Core 8** que utiliza **SQLite** como base de datos. A continuación se encuentran las instrucciones para ejecutar el proyecto, configurar SQLite, ejecutar migraciones y ejemplos de cómo realizar peticiones a la API.

## Requisitos previos

Antes de comenzar, asegúrate de tener los siguientes requisitos instalados:

- **.NET 8 SDK**: Puedes descargarlo desde [aquí](https://dotnet.microsoft.com/download/dotnet).
- **SQLite**: Asegúrate de tener el proveedor de SQLite configurado en tu proyecto (esto se gestiona automáticamente a través de NuGet).
- **IDE recomendado**: Visual Studio 2022 o Visual Studio Code.

## Instalación y configuración

1. **Clona el repositorio:**

    ```bash
    git clone https://github.com/IJoseCruz/Examen.git
    ```

2. **Navega al directorio del proyecto:**

    ```bash
    cd nombre-del-repositorio
    ```

3. **Restaurar las dependencias:**

    ```bash
    dotnet restore
    ```

4. **instala Entity Framework Core CLI:**

    ```bash
    dotnet tool install --global dotnet-ef
    ```


## Ejecutar Migraciones

1. **Crear las migraciones** (si has realizado cambios en el modelo de datos):

    ```bash
    dotnet ef migrations add InitialCreate
    ```

2. **Aplicar las migraciones** para crear la base de datos y sus tablas:

    ```bash
    dotnet ef database update
    ```

Esto creará el archivo de base de datos SQLite y configurará las tablas de acuerdo con el modelo de datos.

## Ejecutar la aplicación

Para ejecutar la API usa el siguiente comando:

```bash
dotnet run
```

## Ejecutar prueba unitarias

Para ejecutar las pruebas unitarias usa el siguiente comando:
```bash
dotnet test
```

# Ejemplos de peticiones API.

### Obtener pruductos
**Endpoint:** `GET /api/productos`  
**Descripción:** Obtiene los detalles de los registros de productos.

#### Ejemplo de Petición:
```bash
GET http://localhost:5021/api/productos
```
### Respuesta Exitosa
```json
[
  {
    "id": 2,
    "nombre": "Producto 2",
    "descripcion": "Descripción del Producto 2",
    "precio": 50.75,
    "cantidadStock": 5,
    "fechaCreacion": "2025-01-15T22:12:58.1299765"
  },
  {
    "id": 3,
    "nombre": "Producto 3",
    "descripcion": "Descripción del Producto 3",
    "precio": 25.99,
    "cantidadStock": 20,
    "fechaCreacion": "2025-01-15T22:12:58.1299772"
  }
]
```
### Respuesta Exitosa sin registros
[]

### Obtener un producto por ID
**Endpoint:** `GET /api/productos/{id}`  
**Descripción:** Obtiene los detalles de un producto especificando su ID.

#### Ejemplo de Petición:
```bash
GET http://localhost:5021/api/productos/1
```
### Respuesta Exitosa
```json
{
  "id": 1,
  "nombre": "Producto 1",
  "descripcion": "Descripción del Producto 1",
  "precio": 100.5,
  "cantidadStock": 10,
  "fechaCreacion": "2025-01-15T22:12:58.1284678"
}
```

### Respuesta cuando no se encuentra el producto

No se encontro el producto

### Eliminar un producto por ID
**Endpoint:** DELETE /api/productos/{id}
**Descripción:** Elimina un producto especificando su ID.

#### Ejemplo de Petición:
```bash
DELETE http://localhost:5021/api/productos/1
```

### Respuesta Exitosa

Se ha elimitado el producto

### Respuesta 404

El producto con el id 30 no existe

### Crear Producto
**Endpoint:** `POST /api/productos`
**Descripción:** Crea un producto acorde a validaciones.

## Request Body:
```json
  {
  "nombre": "Nombre",
  "description": "",
  "precio": 20,
  "cantidadStock": 30
}
```
### Respuesta Exitosa
```json
{
  "urlHelper": null,
  "actionName": "Producto/id",
  "controllerName": "ProductosController",
  "routeValues": {
    "id": 4
  },
  "value": {
    "id": 4,
    "nombre": "Nombre",
    "descripcion": "",
    "precio": 20,
    "cantidadStock": 30,
    "fechaCreacion": "2025-01-15T23:38:22.6129867-06:00"
  },
  "formatters": [],
  "contentTypes": [],
  "declaredType": null,
  "statusCode": 201
}
```
### Respuesta cuando las validaciones no se cumplen 
```
El nombre es obligatorio.
El nombre debe tener entre 3 y 100 caracteres.
El precio debe ser mayor que 0.
La cantidad en stock no puede ser negativa.
```

### Actualizar un Producto
**Endpoint:** PUT /api/productos/{id}
**Descripción:** Actualiza un producto especificando su ID.

#### Ejemplo de Petición:
```bash
GET http://localhost:5021/api/productos/5
```
### Request Body:
```json
{
  "nombre": "Nuevo nombre",
  "description": "Este es un producto con nuevo nombre",
  "precio": 20.90,
  "cantidadStock": 0
}
```

### Respuesta Exitosa: 
```json
{
  "value": {
    "id": 5,
    "nombre": "Nuevo nombre",
    "descripcion": "Este es un producto con nuevo nombre",
    "precio": 20.9,
    "cantidadStock": 0,
    "fechaCreacion": "2025-01-15T23:51:24.2624066"
  },
  "formatters": [],
  "contentTypes": [],
  "declaredType": null,
  "statusCode": 200
}
```
