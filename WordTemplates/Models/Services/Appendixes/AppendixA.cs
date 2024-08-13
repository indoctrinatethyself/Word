using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordTemplates_refactoring.Models;
using WordTemplates_refactoring_refactofing.Services;
using Xceed.Document.NET;
using Xceed.Words.NET;

namespace WordTemplates_refactoring_refactofing.Models.Services.Appendixes
{
    internal class AppendixA: IExecutioneer
    {
        Table t;
        TemplateData data;
        internal AppendixA(DocX document, TemplateData data)
        {
            //creating a head part of a table
            t = document.AddTable(1, 3);
            t.Alignment = Alignment.center;
            t.Rows[0].Cells[0].Paragraphs[0].Append("Термин по ТУ");
            t.Rows[0].Cells[1].Paragraphs[0].Append("Буквенное обозначение по ТУ");
            t.Rows[0].Cells[2].Paragraphs[0].Append("Определение");

            this.data = data;
        }
        private void RowAppend(Element element)
        {
            var r = t.InsertRow();
            r.Cells[0].Paragraphs[0].Append(element.Name);
            r.Cells[1].Paragraphs[0].Append(element.Description);
        }

        public DocX Execute(DocX document)
        {

            document.ReplaceTextWithObject("<таблица 2 экспериментальная>", t);

            return document;
        }
    }
}
