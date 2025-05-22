namespace EN
{
    public class Clientes
    {
        public int ClienteID { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Apellido { get; set; } = string.Empty;
        public long NumeroTelefono { get; set; }
        public string Correo { get; set; } = string.Empty;
        public string NombreUsuario { get; set; } = string.Empty; 
    }
}
