using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarkdownDeep;

namespace DoffingDesign.Service.Markdown
{
    public interface IMarkdownService
    {
        string ConvertToHtml(string markdown);
        string ConvertToHtml(string markdown, bool isSafe);
    }

    public class MarkdownService : IMarkdownService
    {
        private readonly MarkdownDeep.Markdown _markdown;

        public MarkdownService()
        {
            _markdown = new MarkdownDeep.Markdown();
        }

        public string ConvertToHtml(string markdown)
        {
            return ConvertToHtml(markdown, true); //default is safemode
        }

        public string ConvertToHtml(string markdown, bool isSafe)
        {
            _markdown.SafeMode = isSafe;
            return _markdown.Transform(markdown);
        }
    }
}
