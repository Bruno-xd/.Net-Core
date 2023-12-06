namespace GonzalesRamirez.Models
{
    public class Provincia
    {
        public int? IdProvincia {  get; set; }
        public int? IdDepartamento { get; set; }
        public string? NombreProvincia { get; set; }

        public Departamento Departamento { get; set; }

        public List<Distrito> Distritos { get; set; }
    }
}
