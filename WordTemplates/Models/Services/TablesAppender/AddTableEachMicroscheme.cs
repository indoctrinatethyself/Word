using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordTemplates_refactoring.Models;
using WordTemplates_refactoring_refactofing.Services;
using Xceed.Document.NET;
using Xceed.Words.NET;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WordTemplates_refactoring_refactofing.Models.Services.TablesAppender
{
    internal class AddTableEachMicroscheme:IExecutioneer
    {
        // TODO: find out, how many tables do we need and where exaclty should they be putted 
        Table t;
        TemplateData data;
        internal AddTableEachMicroscheme(DocX document, TemplateData data) 
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
            t.MergeCellsInColumn(4, 0, 1);
            t.Rows[0].MergeCells(2, 3);

            this.data = data;
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
