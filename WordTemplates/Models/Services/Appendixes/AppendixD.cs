using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordTemplates_refactoring_refactofing.Services;
using Xceed.Words.NET;
using Xceed.Document.NET;

namespace WordTemplates_refactofing.Models.Services.Appendixes
{
    internal class AppendixD: IExecutioneer
    {
        private Table table1 { get; }
        private Table table2 { get; }
        private Table table3 { get; }

        public AppendixD(int NumberOfTable) 
        {

        }

        public DocX Execute(DocX document)
        {
            
            return document;
        }
    }
    
}
