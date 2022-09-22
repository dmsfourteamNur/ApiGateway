using System.Net;
using System.Net.Http.Headers;
using FourteamApiGateway.Dto;
using Newtonsoft.Json;
using Ocelot.Middleware;
using Ocelot.Multiplexer;


namespace FourteamApiGateway.Aggregator
{
    public class TripulacionPostAgregator : IDefinedAggregator
    {
        public async Task<DownstreamResponse> Aggregate(List<HttpContext> responses)
        {
            if (responses.Any(x => x.Items.Errors().Count > 0))
            {
                return new DownstreamResponse(null, HttpStatusCode.BadRequest, null as List<Header>, null);
            }

            var userResponseContent = await responses[0].Items.DownstreamResponse().Content.ReadAsStringAsync();
            var postResponseContent = await responses[1].Items.DownstreamResponse().Content.ReadAsStringAsync();

            var vuelo = JsonConvert.DeserializeObject<List<Vuelo>?>(userResponseContent);
            var aero = JsonConvert.DeserializeObject<List<Aeronave>?>(postResponseContent);

            //var users = JsonConvert.DeserializeObject<List<Vuelo>?>(userResponseContent["data"].ToString());
            //var posts = JsonConvert.DeserializeObject<List<Aeronave>?>(postResponseContent["Pr"].ToString());
            // Console.Out.WriteLine("chaval aqui : "+ users);
            // Console.Out.WriteLine("ostias aqui : " + posts);

            foreach (var user in vuelo!)
            {
                var userPosts = aero?.Where(p => p.key == user.keyAeronave).ToList();
                user.Aeros?.AddRange(userPosts!);
            }

            var postByUserString = JsonConvert.SerializeObject(vuelo);
            var stringContent = new StringContent(postByUserString)

            {
                Headers = { ContentType = new MediaTypeHeaderValue("application/json") }
            };

            return new DownstreamResponse(stringContent, HttpStatusCode.OK, new List<KeyValuePair<string, IEnumerable<string>>>(), "OK");
            
        }
    }
}
