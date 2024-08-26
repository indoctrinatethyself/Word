using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordTemplates_refactoring.Models;
using WordTemplates_refactoring_refactofing.Services;
using Xceed.Words.NET;

namespace WordTemplates_refactofing.Models.Services.PostProcessing
{
    internal class TextPostProcessingFactory:IExecutioneer
    {
        DocX document;
        TemplateData data;
        public TextPostProcessingFactory(DocX doc, TemplateData dt) 
        {
            this.document = doc;
            this.data = dt;
        }
        public DocX Execute(DocX document)
        {
            IExecutioneer postrocessingStrangeSymbolsReplacer = new StrangeSymbolsReplacer();
            document = postrocessingStrangeSymbolsReplacer.Execute(document);

            return document;
        }

    }
}
