using RedditAPI.Models;
using System.Text.Json.Serialization;
using System.Collections.Generic;

namespace RedditAPI.Services
{
    [JsonSerializable(typeof(Post))]
    [JsonSerializable(typeof(List<PostList>))]
    internal partial class MyJsonContext : JsonSerializerContext
    {
    }
}
