using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordTemplates_refactoring_refactofing.Services;
using Xceed.Words.NET;

namespace WordTemplates_refactofing.Models.Services.PostProcessing
{
    internal class StrangeSymbolsReplacer:IExecutioneer
    {
        internal StrangeSymbolsReplacer()
        {

        }
        public DocX Execute(DocX document) 
        {
            return document;
        }   

    }
}
