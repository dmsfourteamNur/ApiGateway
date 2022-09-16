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
        //public string? keyAeropuertoOrigen { get; set; }
        //public string? keyAeropuertoDestino { get; set; }
        //public DateTime? fechaSalida { get; set; }
        //public DateTime? fechaArribe { get; set; }
        public List<Aeronave>? Aeros{ get; set; } = new List<Aeronave>();
    }
}
