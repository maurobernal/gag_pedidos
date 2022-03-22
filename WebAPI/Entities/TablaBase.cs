namespace WebAPI.Entities
{
    public abstract class TablaBase
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public bool Habilitado { get; set; }
    }
}
