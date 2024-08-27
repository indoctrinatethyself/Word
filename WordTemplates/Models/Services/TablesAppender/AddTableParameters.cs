using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using WordTemplates_refactoring.Models;
using WordTemplates_refactoring_refactofing.Services;
using Xceed.Document.NET;
using Xceed.Words.NET;

namespace WordTemplates_refactoring_refactofing.Models.Services.TablesAppender
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
            t.MergeCellsInColumn(4, 0, 1);
            t.Rows[0].MergeCells(2, 3);

            this.data = data;
        }

        internal AddTableParameters(DocX document, )
        {
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
        private void NoteAppend(string note)
        {
            //copyPasted method
            var r = t.InsertRow();
            for (int k = 0; k < r.ColumnCount - 2; k++)
            {
                r.MergeCells(0, 1);
            }
            r.Cells[0].Paragraphs[0].Append(note);
        }

        public DocX Execute(DocX document)
        {
            //maybe do the same for each group? or how does it work, to understand
            for (int i = 0; i < data.Elements.Count; i++)
            {
                RowAppend(data.Elements[i].Value);
                        
            }

            //updated version
            for (int i= 0; i < data.Groups.Count; i++)
            {
                for (int j=0; j < data.Groups[i].ElectricalParameters.Count; j++)
                {
                    //blablabla
                }
                for (int j=0; j < data.Groups[i].ElectricalParametersNotes.Count; j++)
                {
                    NoteAppend($"{j+1}. {data.Groups[i].ElectricalParametersNotes[j].Text}");
                }
            }

            /*
            for (int i=0; i < data.Elements.Count; i++)
            {
                //for (int k=0; k< data.Elements[i)
                NoteAppend($"");
            }
            //creating a footer of a table
            for (int i = 0; i < data.Groups.Count;  i++)
            {
                //AppendNote(data.Groups.Items[i].ElectricalParametersNotes);
            }
            */

            document.ReplaceTextWithObject("<таблица 1 экспериментальная>", t);
            return document;
        }

    }
}
