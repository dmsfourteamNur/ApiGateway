using System.Net;
using System.Net.Http.Headers;
using ejemplo.Dto;
using Newtonsoft.Json;
using Ocelot.Middleware;
using Ocelot.Multiplexer;


namespace ejemplo.Aggregator
{
    public class UsersPostAgregator : IDefinedAggregator
    {
        public async Task<DownstreamResponse> Aggregate(List<HttpContext> responses)
        {
            if (responses.Any(x => x.Items.Errors().Count > 0))
            {
                return new DownstreamResponse(null, HttpStatusCode.BadRequest, null as List<Header>, null);
            }

            var userResponseContent = await responses[0].Items.DownstreamResponse().Content.ReadAsStringAsync();
            var postResponseContent = await responses[1].Items.DownstreamResponse().Content.ReadAsStringAsync();

            var users = JsonConvert.DeserializeObject<List<User>?>(userResponseContent);
            var posts = JsonConvert.DeserializeObject<List<Post>?>(postResponseContent);



            foreach (var user in users!)
            {
                var userPosts = posts?.Where(p => p.UserId == user.Id).ToList();
                user.Posts?.AddRange(userPosts!);
            }

            var postByUserString = JsonConvert.SerializeObject(users);
            var stringContent = new StringContent(postByUserString)

            {
                Headers = { ContentType = new MediaTypeHeaderValue("application/json") }
            };

            return new DownstreamResponse(stringContent, HttpStatusCode.OK, new List<KeyValuePair<string, IEnumerable<string>>>(), "OK");

        }
    }
}
