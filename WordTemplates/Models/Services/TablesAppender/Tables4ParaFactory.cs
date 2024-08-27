using System;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
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
        private DocX MultiplyTablesPointers(DocX document, TemplateData data)
        {
            string replacement1 = "";
            string replacement2 = "";
            for (int i=0; i<data.Groups.Count; i++)
            {
                replacement1 += $"<элпараметрзаголовок {i+1}> \n <элпараметр {i + 1}>";
            }
            replacement1 += "\n";
            for (int i=0; i<data.Groups.Count; i++)
            {
                replacement2 += $"<предельнодопустимоезаголовок {i+1}> \n <предельнодопустимое {i+1}>";
            }
            replacement2 += "\n";
            document.ReplaceText("<элпараметры>", replacement1);
            document.ReplaceText("<предельнодопустимые>", replacement2);
            return document;
        }
        private DocX MakeValueHeader(DocX document, TemplateData data, string chipsName, int table_number)
        {
            string replacement = $"Таблица 4.{table_number} – Значения электрических параметров микросхем "+chipsName;
            document.ReplaceText($"<элпараметрзаголовок {table_number}>", replacement);
            return document;
        }
        private DocX MakeParamHeader(DocX document, TemplateData data, string chipsName, int table_number)
        {
            string replacement = $"Таблица 4.{table_number + this.data.Groups.Count} – Предельно допустимые и предельные значения электрических режимов эксплуатации микросхем " + chipsName;
            document.ReplaceText($"<предельнодопустимоезаголовок {table_number}>", replacement);
            return document;
        }
        public DocX Execute(DocX document)
        {
            /*
            int count = 2 * data.Groups.Count;
            IExecutioneer addTableValues = new AddTableValues(document, data);
            document = addTableValues.Execute(document);

            for (int i=0; i<count; i++)
            {
                IExecutioneer addTableValues = new AddTableValues
            }

            // replace another text sample with another table
            IExecutioneer addTableParameters = new AddTableParameters(document, data);
            document = addTableParameters.Execute(document);

            IExecutioneer exec = new Requirements431(counter);
            exec.Execute(document);
            //TODO: add table headers
            */

            //насколько же в проекте всрато выполнено ООП и насколько же меня
            //заебало жить чтобы хоть минимум остатка усилий вложить в исправление 

            //создаем заголовки
            IExecutioneer reqs431 = new Requirements431(2*data.Groups.Count);
            document = reqs431.Execute(document);
            document= MultiplyTablesPointers (document, this.data);

            for (int i=0; i<data.Groups.Count; i++)
            {
                document=MakeValueHeader(document, this.data, $"chipyyyy", i+1);
                document=MakeParamHeader(document, this.data, $"chipchiki", i+1);
            }

            //создаем таблицы
            
            for (int i=0; i<data.Groups.Count; i++)
            {
                /*
                IExecutioneer createValueTable = new AddTableValues();
                IExecutioneer createParameterTable = new AddTableParameters();

                document=createParameterTable.Execute(document);
                document=createValueTable.Execute(document);
                */
            }
            //по идее это вся содржательная часть 4 раздела документов
            return document;
        }
    }
}
