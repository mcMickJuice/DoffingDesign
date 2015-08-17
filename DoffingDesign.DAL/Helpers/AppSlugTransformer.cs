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
#warning hash out create Slug, including whitelisted characters
            //should be whole list of chars not allowed in url
            //filter out non whitelister chars
            var splitsOnSpace = projectTitle.ToLower().Split(' ').ToList();
//            var splitsOnSpace = projectTitle.ToLower().Split(' ').Where(isAllowedCharacter).ToList();
            //only first four
            splitsOnSpace = splitsOnSpace.Take(4).ToList();
            return string.Join("-", splitsOnSpace);
        }

        private static bool isAllowedCharacter(string val)
        {
            var regEx = new Regex("[0-9a-zA-Z\\s]");
            return regEx.IsMatch(val);
        }

        internal static bool CompareSlug(string slug1, string slug2)
        {
            //do some work
            //TODO
#warning hash out compare slug

            return slug1 == slug2;
        }
    }
}
