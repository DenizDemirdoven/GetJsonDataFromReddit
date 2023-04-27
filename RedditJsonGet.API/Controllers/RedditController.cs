using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RedditJsonGet.API;
using System.Security.Claims;
using System.Text.Json;

namespace UserLogin.Controllers
{
    [ApiController]
    [Route("[controller]/{keyword}")]
    public class RedditController : ControllerBase
    {
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Get(string keyword)
        {
            var userName = User.FindFirst(ClaimTypes.Name)?.Value;

            if (!string.IsNullOrEmpty(userName))
            {

                string lowercaseKeyword = keyword.ToLower();

                HttpClient client = new HttpClient();

                var jsonurl = "https://www.reddit.com/r/" + lowercaseKeyword + "/top.json";

                var response = await client.GetAsync(jsonurl);

                if (!response.IsSuccessStatusCode)
                {
                    return Problem();
                }

                var json = await response.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                var data = JsonSerializer.Deserialize<Rootobject>(json, options);
                var posts = data.Data.Children
                    .Where(p => p.Data.Subreddit.ToLower() == lowercaseKeyword)
                    .Select(p => new { p.Data.Title, p.Data.Url, p.Data.Author_fullname })
                    .ToList();

                int urlCount = 0;

                foreach (var post in posts)
                {
                    var url = post.Url;

                    if (string.IsNullOrEmpty(url))
                    {
                        throw new Exception("404 Not Found");
                    }
                    urlCount++;
                }
                return Ok(new { subreddit = lowercaseKeyword, children = posts, numberOfImages = urlCount });
            }
            else
            {
                return Unauthorized();
            }
        }
    }
}