using BusinessLayer.Models;
using HtmlAgilityPack;
using System.Net.Http.Headers;

namespace BusinessLayer.Services
{
    public class FoodService : IFoodService
    {
        public async Task<List<Dish>> GetFood(string ingredient)
        {
            var dishes = new List<Dish>();
            string url = "https://www.bbcgoodfood.com/search?q=" + ingredient;
            using HttpClient client = new();
            try
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("text/html"));
                client.DefaultRequestHeaders.UserAgent.ParseAdd("Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/91.0.4472.124 Safari/537.36");

                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                string pageContents = await response.Content.ReadAsStringAsync();

                HtmlDocument doc = new();
                doc.LoadHtml(pageContents);
                var articleNodes = doc.DocumentNode.SelectNodes("//article[contains(@class, 'card text-align-left card--horizontal card--inline card--with-borders')]");

                if (articleNodes != null)
                {
                    foreach (var articleNode in articleNodes)
                    {
                        var titleNode = articleNode.SelectSingleNode(".//a[@class='link d-block']//h2");
                        var ratingNode = articleNode.SelectSingleNode(".//div[contains(@class, 'rating__values')]/span[@class='sr-only']");

                        if (titleNode != null)
                        {
                            var dish = new Dish()
                            {
                                Name = titleNode.InnerText.Trim().Replace("&amp;", "&"),
                                Rating = ratingNode != null ? (ratingNode.InnerText.Trim()) : "No rating"
                            };
                            dishes.Add(dish);
                        }
                    }
                }
                return dishes.OrderByDescending(d => d.Rating).ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return dishes;
            }

        }
    }
}
