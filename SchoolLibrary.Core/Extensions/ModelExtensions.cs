using SchoolLibrary.Core.Contracts;
using System.Text.RegularExpressions;

namespace SchoolLibrary.Core.Extensions
{
    public static class ModelExtensions
    {
        public static string GetInformation(this IBookModel book)
        {
            string info = book.Title.Replace(" ", "-") + GetPositionInLibrary(book.PositionInLibrary);
            info = Regex.Replace(info, @"[^a-zA-Z0-9\-]", string.Empty);

            return info;
        } 

        private static string GetPositionInLibrary(string location)
        {
             location = string.Join("-",location.Split(" ").Take(3));

            return location;
        }
    }
}
