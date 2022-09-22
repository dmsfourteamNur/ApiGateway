using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FourteamApiGateway.Dto
{
    public class Tripulante
    {
        public string? Key { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public Cargo? Cargo { get; set; } 

    }
}
