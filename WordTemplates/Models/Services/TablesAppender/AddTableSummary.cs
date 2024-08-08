using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordTemplates.Models;
using WordTemplates_refactofing.Services;
using Xceed.Words.NET;

namespace WordTemplates_refactofing.Models.Services.TablesAppender
{
    internal class AddTableSummary:IExecutioneer
    {
        // TODO: find out, how many tables do we need and where exaclty should they be putted 
        internal AddTableSummary() 
        { 

        }
        internal AddTableSummary(DocX document, TemplateData data) 
        { 

        }
        private void RowAppend()
        {

        }
        public DocX Execute(DocX document)
        {
            return document;
        }
    }
}
