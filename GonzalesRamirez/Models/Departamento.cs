namespace GonzalesRamirez.Models
{
    public class Departamento
    {
        public int? IdDepartamento { get; set; }
        public string? NombreDepartamento { get; set; }

        public List<Provincia> Provincias { get; set;}
    }
}
