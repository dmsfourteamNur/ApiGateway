using System.Net;
using System.Net.Http.Headers;
using FourteamApiGateway.Dto;
using Newtonsoft.Json;
using Ocelot.Middleware;
using Ocelot.Multiplexer;


namespace FourteamApiGateway.Aggregator
{
    public class UsersPostAgregator : IDefinedAggregator
    {
        public async Task<DownstreamResponse> Aggregate(List<HttpContext> responses)
        {
            if (responses.Any(x => x.Items.Errors().Count > 0))
            {
                return new DownstreamResponse(null, HttpStatusCode.BadRequest, null as List<Header>, null);
            }

            var vueloResponseContent = await responses[0].Items.DownstreamResponse().Content.ReadAsStringAsync();
            var aeronaveResponseContent = await responses[1].Items.DownstreamResponse().Content.ReadAsStringAsync();


            var vuelo = JsonConvert.DeserializeObject<List<Vuelo>?>(vueloResponseContent);
            var aeronave = JsonConvert.DeserializeObject<List<Aeronave>?>(aeronaveResponseContent);

            foreach (var vuelos in vuelo!)
            {
                var vueloAeros = aeronave?.Where(p => p.key == vuelos.keyAeronave).ToList();
                vuelos.Aeronave?.AddRange(vueloAeros!);
            }

            var vueloString  = JsonConvert.SerializeObject(vuelo);
            var stringContent = new StringContent(vueloString)

            {
                Headers = { ContentType = new MediaTypeHeaderValue("application/json") }
            };

            return new DownstreamResponse(stringContent, HttpStatusCode.OK, new List<KeyValuePair<string, IEnumerable<string>>>(), "OK");
        }
    }
}
