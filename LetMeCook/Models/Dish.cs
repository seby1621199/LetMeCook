using System.Text.RegularExpressions;

namespace LetMeCook.Models
{
    public class Dish
    {
        public string? Name { get; set; }
        private string? _rating { get; set; }
        public string Rating
        {
            get
            {
                if (_rating != null)
                    return _rating;
                else
                    return "Error/No rating";
            }
            set { _rating = ExtractRating(value); }
        }


        private static string ExtractRating(string text)
        {
            string pattern = @"A star rating of (\d+\.\d+) out of 5";

            Match match = Regex.Match(text, pattern);

            if (match.Success)
            {
                if (double.TryParse(match.Groups[1].Value, out double rating))
                {
                    return rating.ToString();
                }
            }

            return "Error/No rating";
        }
    }
}
