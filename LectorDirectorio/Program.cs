string path;

do
{
    Console.Write("Por favor ingresar un path con la dirección que desea analizar: ");
    path = Console.ReadLine();

    if (!Directory.Exists(path))
    {
        Console.WriteLine("Path inválido. Inténtelo de nuevo.\n");
    }

} while (!Directory.Exists(path));

// Una vez que el path es válido, listamos los subdirectorios
string[] carpetas = Directory.GetDirectories(path);

if (carpetas.Length > 0)
{
    Console.WriteLine("\nCarpetas encontradas:");
    foreach (var carpeta in carpetas)
    {
        string nombreCarpeta = Path.GetFileName(carpeta);
        Console.WriteLine($"- {nombreCarpeta}");
    }
}
else
{
    Console.WriteLine("\nNo se encontraron carpetas.");
}

string[] archivos = Directory.GetFiles(path);
string rutaReporte = Path.Combine(path, "reporte_archivos.csv");

if (archivos.Length > 0)
{
    Console.WriteLine("\nArchivos encontrados:");

    var writer = new StreamWriter(rutaReporte); // crea un archivo nuevo o sobrescribe uno existente
    writer.WriteLine("Nombre del Archivo; Tamaño (KB); Fecha de Última Modificación");

    foreach (var archivo in archivos)
    {
        var nombreArchivo = Path.GetFileName(archivo);
        FileInfo fileInfo = new FileInfo(archivo);
        double tamañoKb = Math.Round(fileInfo.Length / 1024.0, 2);
        string fechaModificacion = fileInfo.LastWriteTime.ToString("yyyy-MM-dd HH:mm:ss");
        Console.WriteLine($"- {nombreArchivo} ({tamañoKb} KB)");

        string lineaCsv = $"{nombreArchivo}; {tamañoKb}; {fechaModificacion}";
        writer.WriteLine(lineaCsv);
    }

    writer.Close(); // para asegurar de que se liberen los recursos y se guarde correctamente el archivo
}
else
{
    Console.WriteLine("No se encontraron archivos");
}
Console.WriteLine($"\nArchivo de reporte generado: {rutaReporte}");
