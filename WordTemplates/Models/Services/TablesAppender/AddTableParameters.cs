using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordTemplates.Models;
using WordTemplates_refactofing.Services;
using Xceed.Document.NET;
using Xceed.Words.NET;

namespace WordTemplates_refactofing.Models.Services.TablesAppender
{
    internal class AddTableParameters:IExecutioneer
    {
        Table t;
        TemplateData data;
        // we do load data in constructors, DocX in execute
        internal AddTableParameters(DocX document, TemplateData data)
        {
            //creating a head part of a table
            t = document.AddTable(2, 5);
            t.Alignment = Alignment.center;
            t.Rows[0].Cells[0].Paragraphs[0].Append("Наименование параметра, единица измерения");
            t.Rows[0].Cells[1].Paragraphs[0].Append("Буквенное обозначение параметра");
            t.Rows[0].Cells[2].Paragraphs[0].Append("Норма параметра");
            t.Rows[0].Cells[4].Paragraphs[0].Append("Температура корпуса");
            t.Rows[1].Cells[2].Paragraphs[0].Append("не менее");
            t.Rows[1].Cells[3].Paragraphs[0].Append("не более");
            t.MergeCellsInColumn(0, 0, 1);
            t.MergeCellsInColumn(1, 0, 1);
            t.MergeCellsInColumn(4, 0, 1);//is not merging for some reason
            t.Rows[0].MergeCells(2, 3);

            this.data = data;
        }
        private void RowAppend(Element element)
        {
            var r = t.InsertRow();
            r.Cells[0].Paragraphs[0].Append(element.Name);
            r.Cells[1].Paragraphs[0].Append(element.Description);
            /*
            r.Cells[2].Paragraphs[0].Append(element.ParameterValues.);
            r.Cells[3].Paragraphs[0].Append(tableData.MaximumPermissible.AtMost);
            r.Cells[4].Paragraphs[0].Append(tableData.Limit.AtLeast);
            r.Cells[5].Paragraphs[0].Append(tableData.Limit.AtMost);
            r.Cells[6].Paragraphs[0].Append(tableData.NoteRefs);
            */
        }
        public DocX Execute(DocX document)
        {
            for (int i = 0; i < data.Elements.Count; i++)
            {
                RowAppend(data.Elements[i].Value);

            }

            document.ReplaceTextWithObject("<таблица 1 экспериментальная>", t);
            return document;
        }

    }
}
