namespace GonzalesRamirez.Models
{
    public class Trabajador
    {
        public int IdTrabajador {  get; set; }
        public string? TipoDocumento { get; set; }
        public string? NumDocumento {  get; set; }
        public string? Nombres {  get; set; }
        public string? Sexo {  get; set; }

        public int? IdDepartamento { get; set; }
        public string NombreDepartamento { get; set; }
        public Departamento Departamento { get; set; }

        public int? IdProvincia { get; set; }
        public string NombreProvincia { get; set; }
        public Provincia Provincia { get; set; }

        public int? IdDistrito { get; set; }
        public string NombreDistrito {  get; set; }
        public Distrito Distrito { get; set; }

    }
}
