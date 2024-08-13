using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    //UPD: it is successful, now i may move on to the table part
    internal class NameChangerMultipleReplacement: IExecutioneer
    {
        //this is a class made for turning a string into the string
        //with replaced words

        private Dictionary<string, string> replaceKeys;
        string[] names;
        string[] descriptions;
        internal NameChangerMultipleReplacement(string[] names, string[] descriptions)
        {
           this.names = names;
           this.descriptions = descriptions;
        }

        private string ConcatenateStrings()
        {
            string replacement = "";

            for (int i = 0; i < names.Length; i++) 
            {
                if (descriptions[i] != null)
                {
                    replacement += names[i] + " представляет собой " + descriptions[i]+", ";
                }
                else if (descriptions[i] == null)
                {
                    replacement += names[i] + ", ";
                }
            }
            return replacement.Substring(0, replacement.Length-2)+".";
        }
        private DocX ExecuteReplacement(DocX document)
        {
            document.ReplaceText("<названия_с_описаниями>", ConcatenateStrings());
            return document;
        }
        public DocX Execute(DocX document)
        {
            document = ExecuteReplacement(document);
            return document;
        }
    }
}
