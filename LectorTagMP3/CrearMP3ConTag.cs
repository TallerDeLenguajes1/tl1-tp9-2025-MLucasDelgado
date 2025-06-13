namespace CreacionMP3
{
    public class CrearMP3ConTag
    {
        public void CrearArchivo()
        {
            string rutaArchivo = "prueba.mp3";

            FileStream fs = new FileStream(rutaArchivo, FileMode.Create);

            // Escribir 1KB de ceros para simular datos del mp3
            byte[] ceros = new byte[1024];
            fs.Write(ceros, 0, ceros.Length);

            byte[] tag = new byte[128];

            Array.Copy(System.Text.Encoding.ASCII.GetBytes("TAG"), 0, tag, 0, 3);
            Array.Copy(System.Text.Encoding.ASCII.GetBytes("Nebula"), 0, tag, 3, "Nebula".Length);
            Array.Copy(System.Text.Encoding.ASCII.GetBytes("The Rose"), 0, tag, 33, "The Rose".Length);
            Array.Copy(System.Text.Encoding.ASCII.GetBytes("WRLD"), 0, tag, 63, "WRLD".Length);
            Array.Copy(System.Text.Encoding.ASCII.GetBytes("2025"), 0, tag, 93, 4);

            fs.Write(tag, 0, tag.Length);
            fs.Close();
        }
    }
}

