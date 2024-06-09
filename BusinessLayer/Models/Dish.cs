using System.Text.RegularExpressions;

namespace BusinessLayer.Models
{
    public class Dish
    {
        public string Name { get; set; }
        private string _rating { get; set; }
        public string Rating
        {
            get { return _rating; }
            set { _rating = ExtractRating(value).ToString(); }
        }


        private static double ExtractRating(string text)
        {
            string patterndouble = @"A star rating of (\d+\.\d+) out of 5";
            string patterninteger = @"A star rating of (\d+) out of 5";

            Match match = Regex.Match(text, patterndouble);
            if (match.Success && double.TryParse(match.Groups[1].Value, out double rating))
            {
                return rating;
            }

            Match match2 = Regex.Match(text, patterninteger);
            if (match2.Success && double.TryParse(match2.Groups[1].Value, out rating))
            {
                return rating;
            }

            return -1;
        }
    }
}
