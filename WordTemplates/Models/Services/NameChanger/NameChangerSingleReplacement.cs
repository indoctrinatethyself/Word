using System;
using System.Collections.Generic;
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
    //
    // do inheritance matter?
    // disinherited

    internal class NameChangerSingleReplacement
    {
        private static Dictionary<string, string> replaceKeys;
        internal NameChangerSingleReplacement(string[] names) 
        {
             replaceKeys = new Dictionary<string, string>()
                {
                    {"названия", String.Join(",", names) }
                };
        }
       
        private static string ReplaceFunc(string findStr)
        {
            if (replaceKeys.ContainsKey(findStr))
            {
                return String.Join(",", replaceKeys[findStr]);
            }
            return findStr;
        }


        //internal override DocX Execute(DocX document)
        //{
        //    document= ExecuteWithMultipleReplacement(ExecuteWithSingleReplacement(document));
        //    return document;
        //}
        internal DocX Execute(DocX document)
        {
            document = ExecuteWithSingleReplacement(document);
            return document;
        }

        private DocX ExecuteWithSingleReplacement(DocX document)
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
    }
}
