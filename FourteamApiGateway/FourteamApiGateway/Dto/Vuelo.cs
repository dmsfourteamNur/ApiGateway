using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FourteamApiGateway.Dto
{
    public class Vuelo
    {
       // public int key { get; set; }
        public string? nroVuelo { get; set; }
        public string? keyAeronave { get; set; }
        public string? keyTripulacion { get; set; }

        public string? origen { get; set; }
        public string? destino { get; set; } 
        public List<Aeronave>? Aeronave{ get; set; } = new List<Aeronave>();
        public List<Tripulacion>? Tripulacion{ get; set; } = new List<Tripulacion>();

    }
}
