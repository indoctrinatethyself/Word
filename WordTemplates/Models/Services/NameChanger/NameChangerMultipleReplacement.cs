using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Xceed.Document.NET;
using Xceed.Words.NET;


namespace WordTemplates_refactofing.Services.NameChanger
{
    //TODO: there should be two variants of the method - singlename and multiname.
    //Maybe multiname changer should be more functional than the singlename one?
    //
    //it is maybe a good idea to make separate classes for single and multiple 
    //replacements
    internal class NameChangerMultipleReplacement 
    {
        private Dictionary<string, string> replaceKeys;
        NameChangerMultipleReplacement(string[] names, string[] descriptions)
        {
            Dictionary<string, string> replaceKeys = new Dictionary<string, string>()
                {
                    {"название",ConcatenateStrings(names, descriptions) }
                };
        }
        private string ConcatenateStrings(string[] names, string[] descriptions)
        {
            string replacement = "";

            for (int i = 0; i < names.Length; i++) 
            {
                replacement += names[i] + " представляет собой " + descriptions[i];
            }
            return replacement;
        }
        private string ReplaceFunc(string findStr)
        {
            if (replaceKeys.ContainsKey(findStr))
            {
                return replaceKeys[findStr];
            }
            return findStr;
        }
       

        private DocX ExecuteReplacement(DocX document)
        {

            if (document.FindUniqueByPattern(@"<[\w \=]{4,}>", RegexOptions.IgnoreCase).Count > 0)
            {
                // Do the replacement of all the found tags and with green bold strings.
                var replaceTextOptions = new FunctionReplaceTextOptions()
                {
                    FindPattern = "@{(.*?)}",
                    RegexMatchHandler = ReplaceFunc,
                    RegExOptions = RegexOptions.IgnoreCase,
                    NewFormatting = new Formatting() { Bold = true, FontColor = System.Drawing.Color.Red }
                };
                document.ReplaceText(replaceTextOptions);
            }
            return document;
        }
        internal DocX Execute(DocX document)
        {
            document = ExecuteReplacement(document);
            return document;
        }
    }
}
