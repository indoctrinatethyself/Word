using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordTemplates_refactofing.Models.Services.NameChanger;
using WordTemplates_refactoring.Models;
using WordTemplates_refactoring_refactofing.Models.Services.TablesAppender;
using WordTemplates_refactoring_refactofing.Services;
using WordTemplates_refactoring_refactofing.Services.TablesRenamer;
using Xceed.Words.NET;

namespace WordTemplates_refactofing.Models.Services.TablesAppender
{
    internal class Tables4ParaFactory: IExecutioneer
    {
        DocX document;
        TemplateData data;
        internal Tables4ParaFactory(DocX document, TemplateData data)
        {
            this.document = document;
            this.data = data;
        }

        public DocX Execute(DocX document)
        {
            int counter = 2 * data.Groups.Count;
            IExecutioneer addTableValues = new AddTableValues(document, data);
            document = addTableValues.Execute(document);

            // replace another text sample with another table
            IExecutioneer addTableParameters = new AddTableParameters(document, data);
            document = addTableParameters.Execute(document);

            IExecutioneer exec = new Requirements431(counter);
            exec.Execute(document);
            //TODO: add table headers)
            return document;
        }
    }
}
