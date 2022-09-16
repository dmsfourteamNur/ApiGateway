using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FourteamApiGateway.Dto
{
    public class Aeronave
    {
        public string? key { get; set; }
        public string? matricula { get; set; }
         public List<Asientos> Asientos { get; set; } = new List<Asientos>();
    }
}
