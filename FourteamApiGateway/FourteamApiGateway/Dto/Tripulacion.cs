using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FourteamApiGateway.Dto
{
    public class Tripulacion
    {
        public string? key { get; set; }
        public string? Descripcion { get; set; }
        public List<Tripulante>? Tripulantes { get; set; } = new List<Tripulante>();
    }
}
