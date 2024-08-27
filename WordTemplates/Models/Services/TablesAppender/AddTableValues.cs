using Avalonia.Controls.Platform;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WordTemplates_refactoring.Models;
using Xceed.Document.NET;
using Xceed.Words.NET;

namespace WordTemplates_refactoring_refactofing.Services.TablesRenamer
{

    internal class AddTableValues: IExecutioneer
    {
        Table t;
        TemplateData data;
        int headerNumber;
        // we do load data in constructors, DocX in execute
        internal AddTableValues(DocX document, TemplateData data, int number) 
        {
            //creating a head part of a table
            this.headerNumber = number;
            t = document.AddTable(3, 7);
            t.Alignment = Alignment.center;
            t.Rows[0].Cells[0].Paragraphs[0].Append("Наименование параметра, \r\nединица измерения, режим \r\nизмерения");
            t.Rows[0].Cells[1].Paragraphs[0].Append("Буквенное \r\nобозначение \r\nпараметра");
            t.Rows[0].Cells[2].Paragraphs[0].Append("Предельно допустимый \r\nрежим");
            t.Rows[0].Cells[4].Paragraphs[0].Append("Предельный режим");
            t.Rows[0].Cells[6].Paragraphs[0].Append("Номер \r\nпункта \r\nприме\u0002чания");
            t.Rows[1].Cells[2].Paragraphs[0].Append("не менее");
            t.Rows[1].Cells[3].Paragraphs[0].Append("не более");
            t.Rows[1].Cells[4].Paragraphs[0].Append("не менее");
            t.Rows[1].Cells[5].Paragraphs[0].Append("не более");
            /* =) */
            t.Rows[2].Cells[0].Paragraphs[0].Append("1");
            t.Rows[2].Cells[1].Paragraphs[0].Append("2");
            t.Rows[2].Cells[2].Paragraphs[0].Append("3");
            t.Rows[2].Cells[3].Paragraphs[0].Append("4");
            t.Rows[2].Cells[4].Paragraphs[0].Append("5");
            t.Rows[2].Cells[5].Paragraphs[0].Append("6");
            t.Rows[2].Cells[6].Paragraphs[0].Append("7");

            t.MergeCellsInColumn(0, 0, 1);
            t.MergeCellsInColumn(1, 0, 1);
            t.MergeCellsInColumn(6, 0, 1);
            t.Rows[0].MergeCells(2, 3);
            t.Rows[0].MergeCells(3, 4);
            this.data = data;
        }
        internal AddTableValues(DocX document, TemplateData data)
        {
            //creating a head part of a table
            //this.headerNumber = number;
            t = document.AddTable(3, 7);
            t.Alignment = Alignment.center;
            t.Rows[0].Cells[0].Paragraphs[0].Append("Наименование параметра, \r\nединица измерения, режим \r\nизмерения");
            t.Rows[0].Cells[1].Paragraphs[0].Append("Буквенное \r\nобозначение \r\nпараметра");
            t.Rows[0].Cells[2].Paragraphs[0].Append("Предельно допустимый \r\nрежим");
            t.Rows[0].Cells[4].Paragraphs[0].Append("Предельный режим");
            t.Rows[0].Cells[6].Paragraphs[0].Append("Номер \r\nпункта \r\nприме\u0002чания");
            t.Rows[1].Cells[2].Paragraphs[0].Append("не менее");
            t.Rows[1].Cells[3].Paragraphs[0].Append("не более");
            t.Rows[1].Cells[4].Paragraphs[0].Append("не менее");
            t.Rows[1].Cells[5].Paragraphs[0].Append("не более");
            /* =) */
            t.Rows[2].Cells[0].Paragraphs[0].Append("1");
            t.Rows[2].Cells[1].Paragraphs[0].Append("2");
            t.Rows[2].Cells[2].Paragraphs[0].Append("3");
            t.Rows[2].Cells[3].Paragraphs[0].Append("4");
            t.Rows[2].Cells[4].Paragraphs[0].Append("5");
            t.Rows[2].Cells[5].Paragraphs[0].Append("6");
            t.Rows[2].Cells[6].Paragraphs[0].Append("7");

            t.MergeCellsInColumn(0, 0, 1);
            t.MergeCellsInColumn(1, 0, 1);
            t.MergeCellsInColumn(6, 0, 1);
            t.Rows[0].MergeCells(2, 3);
            t.Rows[0].MergeCells(3, 4);
            this.data = data;
        }
        private void RowAppend(OperatingConditionsParameter tableData)
        {
            var r = t.InsertRow();
            r.Cells[0].Paragraphs[0].Append(tableData.Name);
            r.Cells[1].Paragraphs[0].Append(tableData.Symbol);
            r.Cells[2].Paragraphs[0].Append(tableData.MaximumPermissible.AtLeast);
            r.Cells[3].Paragraphs[0].Append(tableData.MaximumPermissible.AtMost);
            r.Cells[4].Paragraphs[0].Append(tableData.Limit.AtLeast);
            r.Cells[5].Paragraphs[0].Append(tableData.Limit.AtMost);
            r.Cells[6].Paragraphs[0].Append(tableData.NoteRefs);
        }
        private void NoteAppend(string note)
        {
            //column with "номер пункта примечания" remains after the CellMerging, postprocess it?
            var r=t.InsertRow();
            for (int k = 0; k < r.ColumnCount - 2; k++)
            {
                r.MergeCells(0, 1);
            }
            r.Cells[0].Paragraphs[0].Append(note);
        }

        public DocX Execute(DocX document)
        {
            /*
            var r = t.InsertRow();
            for (int k = 0; k < r.ColumnCount-2; k++)
            {
                r.MergeCells(0, 1);
            }
            r.Cells[0].Paragraphs[0].Append($"{data.Groups[i].Name}");

            //r.Cells[0].Paragraphs[0].Append($"{data.Groups[i].Name} Group {i+1}");
            //UPD: 12.08.24

            for (int j = 0; j < data.Groups[i].OperatingConditionsParameters.Count; j++)
            {
                RowAppend(data.Groups[i].OperatingConditionsParameters[j]);
            }
            for (int j=0; j < data.Groups[i].OperatingConditionsParametersNotes.Count; j++)
            {
                NoteAppend($"{j+1}. {data.Groups[i].OperatingConditionsParametersNotes[j].Text}");
            }

            //TODO: insert page break after the table
            //Get rid of ReplaceTextWithObject and do everything manually?
            for (int i = 0; i < data.Groups.Count-1; i++)
            {
                document.ReplaceText("<предельнодопустимые>", $"Таблица 4.{headerNumber+i} – Предельно допустимые и предельные значения электрических режимов эксплуатации микросхем К1324ПП2У, К1324ПП3У) <таблица 2 экспериментальная> <предельнодопустимые>");
                //ну кароч перед этим надо еще реализовать создание этой таблицы, но это не сегодня.
                //и не завтра, и не послезавтра. мб еще позже
                document.ReplaceTextWithObject("<таблица 2 экспериментальная>", t);
            }
            document.ReplaceText("<предельнодопустимые>", $"Таблица 4.{headerNumber + data.Groups.Count} – Предельно допустимые и предельные значения электрических режимов эксплуатации микросхем К1324ПП2У, К1324ПП3У)");
            document.ReplaceTextWithObject("<таблица 2 экспериментальная>", t);
           */
            return document;
        }
    }
}
