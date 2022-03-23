using System;
using System.Collections.Generic;

namespace WebAPI.Models
{
    public partial class Proveedore
    {
        public Guid Id { get; set; }
        public string Direccion { get; set; } = null!;
        public string CodPostal { get; set; } = null!;
        public string Tel1 { get; set; } = null!;
        public string Tel2 { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Cuit { get; set; } = null!;
        public string Contacto { get; set; } = null!;
        public string? Observacion { get; set; }
        public string Gln { get; set; } = null!;
        public Guid LocalidadId { get; set; }
        public Guid DepartamentoId { get; set; }
        public Guid ProvinciaId { get; set; }
        public string Descripcion { get; set; } = null!;
        public bool Habilitado { get; set; }
        public DateTime Creado { get; set; }
        public string? CreadoPor { get; set; }
        public DateTime Modificado { get; set; }
        public string? ModificadoPor { get; set; }
    }
}
