namespace GonzalesRamirez.Models
{
    public class Distrito
    {
        public int? IdDistrito {  get; set; }
        public int? IdProvincia { get; set; }
        public string? NombreDistrito { get; set; }

        public Provincia Provincia { get; set; }
    }
}
