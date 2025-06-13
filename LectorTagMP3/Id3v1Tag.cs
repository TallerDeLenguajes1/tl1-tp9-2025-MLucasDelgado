namespace MP3
{
    public class Id3v1Tag
    {
        private string titulo;
        private string artista;
        private string album;
        private string año;

        public string Titulo { get => titulo; set => titulo = value; }
        public string Artista { get => artista; set => artista = value; }
        public string Album { get => album; set => album = value; }
        public string Año { get => año; set => año = value; }
    }
}
