﻿namespace FirstAPI.Models
{
    public class Cliente
    {
        public int? Id { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public string? Direccion { get; set; }
        public int? Dni { get; set; }
        public DateTime Fecha { get; set; }
    }

}
