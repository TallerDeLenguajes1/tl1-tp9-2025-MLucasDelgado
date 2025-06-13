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
if (archivos.Length > 0)
{
    Console.WriteLine("\nArchivos encontrados:");
    foreach (var archivo in archivos)
    {
        var nombreArchivo = Path.GetFileName(archivo);
        FileInfo fileInfo = new FileInfo(archivo);
        long tamañoKb = fileInfo.Length / 1024;
        Console.WriteLine($"- {nombreArchivo} ({tamañoKb} KB)");
    }
}
else
{
    Console.WriteLine("No se encontraron archivos");
}
