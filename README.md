# Proyecto: Exploración de Directorios y Lectura de Etiquetas ID3v1 en MP3

Este proyecto contiene dos aplicaciones de consola desarrolladas en C# dentro del entorno .NET. Cada una cumple una función específica relacionada con la manipulación de archivos y directorios.

---

## 📁 Ejercicio 1 – LectorDirectorio

### Descripción:
Una aplicación que permite al usuario explorar el contenido de un directorio, listar sus archivos y generar un informe en formato CSV con datos relevantes de cada archivo.

### Funcionalidades:
- Solicita al usuario la ruta de un directorio para analizar.
- Valida si el directorio ingresado existe.
- Lista en consola:
  - Todas las carpetas contenidas directamente en ese path.
  - Todos los archivos directamente dentro de esa carpeta con su tamaño en kilobytes (KB).
- Genera un archivo llamado `reporte_archivos.csv` en el mismo directorio analizado, que contiene:
  - **Nombre del archivo**
  - **Tamaño (KB)** con dos decimales
  - **Fecha de última modificación**

---

## 🎵 Ejercicio 2 – LectorTagMP3

### Descripción:
Una aplicación que permite leer la etiqueta ID3v1 de un archivo MP3 y mostrar en consola los datos básicos del archivo musical.

### Funcionalidades:
- Solicita al usuario la ruta de un archivo MP3.
- Verifica si el archivo contiene una etiqueta ID3v1 válida.
- Si existe, muestra en consola:
  - **Título**
  - **Artista**
  - **Álbum**
  - **Año**

### Estructura ID3v1:
Esta etiqueta ocupa los últimos 128 bytes de un archivo MP3 y contiene información básica de la canción.

### Herramientas utilizadas:
- `System.IO.FileStream` para abrir archivos en modo binario.
- `FileStream.Seek()` para ubicar los últimos 128 bytes.
- `System.Text.Encoding.ASCII` para convertir bytes a texto.

---

## 🚀 Cómo ejecutar

1. Clonar este repositorio.
2. Abrir la solución en Visual Studio o abrir las carpetas desde terminal.
3. Compilar y ejecutar el proyecto deseado (`LectorDirectorio` o `LectorTagMP3`).
4. Seguir las instrucciones por consola.

