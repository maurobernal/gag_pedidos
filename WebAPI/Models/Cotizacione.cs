using System;
using System.Collections.Generic;

namespace WebAPI.Models
{
    public partial class Cotizacione
    {
        public Guid Id { get; set; }
        public string Metodo { get; set; } = null!;
        public string Documento { get; set; } = null!;
        public int Numero { get; set; }
        public string? Auxiliar { get; set; }
        public string Estado { get; set; } = null!;
        public Guid EntidadId { get; set; }
        public Guid EspecialidadId { get; set; }
        public Guid SituacionDeIvaId { get; set; }
        public Guid TasaDeIvaid { get; set; }
        public Guid FormaDePagoId { get; set; }
        public Guid LugarId { get; set; }
        public Guid MantenimientoId { get; set; }
        public Guid PlazoEntregaId { get; set; }
        public Guid SucursalId { get; set; }
        public Guid ZonaId { get; set; }
        public Guid TipoOperacionId { get; set; }
        public int Plazo { get; set; }
        public string Descripcion { get; set; } = null!;
        public bool Habilitado { get; set; }
        public DateTime Creado { get; set; }
        public string? CreadoPor { get; set; }
        public DateTime Modificado { get; set; }
        public string? ModificadoPor { get; set; }
    }
}
