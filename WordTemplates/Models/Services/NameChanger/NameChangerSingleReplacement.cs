using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Xceed.Document.NET;
using Xceed.Words.NET;

namespace WordTemplates_refactoring_refactofing.Services.NameChanger
{
    //TODO: there should be two variants of the method - singlename and multiname.
    //Maybe multiname changer should be more functional than the singlename one?
    //
    //it is maybe a good idea to make separate classes for single and multiple 
    //replacements
    //
    // do inheritance matter?
    // disinherited

    internal class NameChangerSingleReplacement: IExecutioneer
    {
        private static string replaceString;
        internal NameChangerSingleReplacement(string[] names) 
        {
             replaceString=String.Join(", ", names);

        }
        //internal override DocX Execute(DocX document)
        //{
        //    document= ExecuteWithMultipleReplacement(ExecuteWithSingleReplacement(document));
        //    return document;
        //}
        public DocX Execute(DocX document)
        {
            document = ExecuteWithSingleReplacement(document);
            return document;
        }

        private DocX ExecuteWithSingleReplacement(DocX document)
        {
            document.ReplaceText("<названия>", replaceString);
            return document;
        }
    }
}
