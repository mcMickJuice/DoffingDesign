using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DoffingDesign.DAL.Helpers
{
    internal class AppSlugTransformer
    {
        internal static string CreateSlug(string projectTitle)
        {
            var filteredTitle = filteredString(projectTitle);
            var splitsOnSpace = filteredTitle.ToLower().Split(' ').ToList();

            splitsOnSpace = splitsOnSpace.Take(4).ToList();
            return string.Join("-", splitsOnSpace);
        }

        private static string filteredString(string stringIn)
        {
            var regEx = new Regex(@"[^0-9a-zA-Z\s]");

            var filtered = regEx.Replace(stringIn, "");
            return filtered;
        }

        internal static bool CompareSlug(string slug1, string slug2)
        {
            throw new NotImplementedException();
            //do some work
            //TODO
#warning hash out compare slug

            //return slug1 == slug2;
        }
    }
}
