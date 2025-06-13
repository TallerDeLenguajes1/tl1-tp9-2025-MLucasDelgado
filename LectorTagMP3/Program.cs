using System.Text;
using MP3;
using CreacionMP3;

string ruta;

CrearMP3ConTag creador = new CrearMP3ConTag();
creador.CrearArchivo();
string rutaArchivo = Path.GetFullPath("prueba.mp3");
Console.WriteLine($"Archivo 'prueba.mp3' creado en:\n{rutaArchivo}");
do
{
    Console.Write("Ingrese la ruta del archivo MP3: ");
    ruta = Console.ReadLine();

    if (!File.Exists(ruta))
    {
        Console.WriteLine("Ruta inválida. Inténtelo de nuevo.\n");
    }

} while (!File.Exists(ruta));

FileStream archivoMp3 = new FileStream(ruta, FileMode.Open, FileAccess.Read); // Abro el archivo en modo lectura binaria.
archivoMp3.Seek(-128, SeekOrigin.End); // Esto mueve el puntero 128 bytes hacia atrás desde el final del archivo

// Creamos un buffer para leer los 128 bytes
byte[] buffer = new byte[128];
archivoMp3.Read(buffer, 0, buffer.Length);

// Verificamos que los primeros 3 bytes sean "TAG"
string cabecera = Encoding.ASCII.GetString(buffer, 0, 3);
if (cabecera != "TAG")
{
    Console.WriteLine("El archivo no tiene una etiqueta ID3v1.");
    return;
}

Id3v1Tag EstructuraMP3 = new Id3v1Tag();

// Utilizo el Trim porque si el valor real ocupa menos, el resto se rellena con \0 o espacios
EstructuraMP3.Titulo = Encoding.ASCII.GetString(buffer, 3, 30).Trim('\0', ' ');
EstructuraMP3.Artista = Encoding.ASCII.GetString(buffer, 33, 30).Trim('\0', ' ');
EstructuraMP3.Album = Encoding.ASCII.GetString(buffer, 63, 30).Trim('\0', ' ');
EstructuraMP3.Año = Encoding.ASCII.GetString(buffer, 93, 4).Trim('\0', ' ');


Console.WriteLine("\n--- Información del MP3 ---");
Console.WriteLine($"Título : {EstructuraMP3.Titulo}");
Console.WriteLine($"Artista: {EstructuraMP3.Artista}");
Console.WriteLine($"Álbum  : {EstructuraMP3.Album}");
Console.WriteLine($"Año    : {EstructuraMP3.Año}");
