using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using WordTemplates_refactofing.Services.NameChanger;
using Xceed.Document.NET;
using Xceed.Words.NET;


namespace WordTemplates_refactofing.Models.Services.NameChanger
{
    //Long story short, everything is FUCKED. but samir gave me an idea 
    //how to fix things im toiling to build, briefly:
    //1) even in oop-witted mindset you dont have to put everything in different boxes,
    //   sometimes creating a big class matters
    //
    //2) the biggest ones are derived ones, simple thing i did not realize
    //
    //3) dont be idiot, idiot!
    internal class NameChangerBase
    {
        protected static Dictionary<string, string[]> replaceKeys;
        NameChangerBase(string[] names)
        {
            replaceKeys = new Dictionary<string, string[]>()
                {
                    {"название",names }
                };
        }
        private DocX ExecuteReplacement(DocX document)
        {

            if (document.FindUniqueByPattern(@"<[\w \=]{4,}>", RegexOptions.IgnoreCase).Count > 0)
            {
                // Do the replacement of all the found tags and with green bold strings.
                var replaceTextOptions = new FunctionReplaceTextOptions()
                {
                    FindPattern = "@{(.*?)}",
                    RegexMatchHandler = NameChangerSingleReplacement.ReplaceFunc,
                    RegExOptions = RegexOptions.IgnoreCase,
                    NewFormatting = new Formatting() { Bold = true, FontColor = System.Drawing.Color.Red }
                };
                document.ReplaceText(replaceTextOptions);
            }
            return document;
        }
        private DocX ExecuteReplacement(DocX document)
        {
            NameChangerMultipleReplacement multipleReplacement = new NameChangerMultipleReplacement();
            document=multipleReplacement.Execute(document);
            NameChangerSingleReplacement singleReplacement = new NameChangerSingleReplacement();
            document = singleReplacement.Execute(document);
            return document;
        }

    }
}
