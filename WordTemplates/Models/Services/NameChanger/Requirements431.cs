using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordTemplates_refactoring_refactofing.Services;
using Xceed.Document.NET;
using Xceed.Words.NET;

namespace WordTemplates_refactofing.Models.Services.NameChanger
{
    internal class Requirements431:IExecutioneer
    {
        private static int numberOvTables;
        internal Requirements431(int nums)
        {
            numberOvTables = nums;
        }
        //internal override DocX Execute(DocX document)
        //{
        //    document= ExecuteWithMultipleReplacement(ExecuteWithSingleReplacement(document));
        //    return document;
        //}
        public DocX Execute(DocX document)
        {
            string replaceText = $"4.3.1 Значения электрических параметров микросхем при приемке и поставке должны соответствовать нормам, установленным в таблицах 4.1–4.{numberOvTables}";
            document.ReplaceText("<431431>", replaceText);
            return document;
        }
    }
}

