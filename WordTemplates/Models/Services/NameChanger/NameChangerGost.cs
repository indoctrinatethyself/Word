using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordTemplates_refactoring.Models;
using WordTemplates_refactoring_refactofing.Services;
using Xceed.Document.NET;
using Xceed.Words.NET;

namespace WordTemplates_refactofing.Models.Services.NameChanger
{
    internal class NameChangerGost :IExecutioneer
    {
        private TemplateData data;
        private DocX document;
        internal NameChangerGost(DocX document, TemplateData templateData)
        {
            this.data=templateData;
            this.document=document;
        }
        private void MultiplyGosts() 
        {
            string replacement = "";
            for(int i=0; i<data.Variables.Count; i++)
            {
                replacement+= $"7.3.1.{i+1} Измерение {data.Variables[i].Name} проводят в соответствии с ГОСТ 20271.1 {data.Variables[i].Value}, в режимах и условиях, указанных в таблицах 6.1, 6.2, по схемам включения, приведенным на рисунках 7.4–7.5. \r\n";
            }
            document.ReplaceText("<госты>", replacement);
        }
        public DocX Execute(DocX document) 
        {
            MultiplyGosts();
            return document;
        }
    }

}
