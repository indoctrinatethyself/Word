using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using WordTemplates_refactofing.Models.Services.NameChanger;
using WordTemplates_refactofing.Services;
using Xceed.Document.NET;
using Xceed.Words.NET;


namespace WordTemplates_refactofing.Services.NameChanger
{
    //TODO: there should be two variants of the method - singlename and multiname.
    //Maybe multiname changer should be more functional than the singlename one?
    //
    //it is maybe a good idea to make separate classes for single and multiple 
    //replacements
    internal class NameChangerMultipleReplacement : NameChangerBase
    {

        private static string ReplaceFunc(string findStr)
        {
            if (replaceKeys.ContainsKey(findStr))
            {
                string replacement = "";
                foreach (string name in replaceKeys[findStr]) 
                {
                    replacement += name+ " представляет собой " ;
                }
                return replacement;
            }
            return findStr;
        }


        //internal override DocX Execute(DocX document)
        //{
        //    document = ExecuteWithMultipleReplacement(ExecuteWithSingleReplacement(document));
        //    return document;
        //}
        internal DocX Execute(DocX document)
        {
            document = ExecuteWithMultipleReplacement(document);
            return document;
        }

        private DocX ExecuteWithMultipleReplacement(DocX document)
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
    }
}
