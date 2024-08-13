using System.Collections.Generic;

using WordTemplates_refactoring.Models;
using WordTemplates_refactoring_refactofing.Services.NameChanger;
using Xceed.Words.NET;
using System.Linq;
using WordTemplates_refactoring_refactofing.Services.TablesRenamer;
using WordTemplates_refactoring_refactofing.Models.Services.TablesAppender;
using WordTemplates_refactoring_refactofing.Models.Services.Appendixes;


namespace WordTemplates_refactoring_refactofing.Services;
internal interface IExecutioneer
{
    DocX Execute(DocX document);
}

public class TextTransformFactory
{
    static DocX staticDocument;
    static TemplateData staticData;
    public TextTransformFactory(DocX document, TemplateData data)
    {
        staticDocument = document;
        staticData = data;
    }
    /*TextTransformFactory(DocX document)
    {
        staticDocument = document;
    }

    */
    /*public DocX Transform(DocX document, string savePath)
    {  

        staticDocument.SaveAs(savePath);
        return staticDocument;
    }*/

    public DocX Transform()
    {
        //TODO: throw an exception when user tries to execute the program
        //with an empty microschemes amount. currently the error seems strange

        //TODO: "не более" и "не менее" из раздела "микросхемы" не работает
        //прям ВООБЩе, сделать и поправить. 

        //this part of code adds microscheme's name(s) into the document

        //сейчас иду на обед, пишу чтобы не отлечься от важной задачи. а именно:
        //формируем таблицу "Значения электрических параметров модулей", надо подебажить
        //и понять где у чувака лежат электрические параметры микросхем
        IExecutioneer singleReplacement = new NameChangerSingleReplacement(((IList<Element>)staticData.Elements).Select(e => e.Name).ToArray());
        staticDocument = singleReplacement.Execute(staticDocument);

        //the following code adds name(s) and description(s)
        //maybe use interface?
        IExecutioneer multipleReplacement = new NameChangerMultipleReplacement(((IList<Element>)staticData.Elements).Select(e => e.Name).ToArray(), ((IList<Element>)staticData.Elements).Select(e => e.Description).ToArray());
        staticDocument = multipleReplacement.Execute(staticDocument);

        //two lines which replace text with a table with 
        //maximal or minimal data 
        IExecutioneer addTableValues = new AddTableValues(staticDocument, staticData);
        staticDocument= addTableValues.Execute(staticDocument);

        // replace another text sample with another table
        IExecutioneer addTableParameters = new AddTableParameters(staticDocument, staticData);
        staticDocument=addTableParameters.Execute(staticDocument);

        /*
        IExecutioneer addTableSummary = new AddTableSummary(staticDocument, staticData);
        staticDocument = AddTableSummary.Execute(staticDocument);
        */

        IExecutioneer addAppendix = new AppendixA(staticDocument, staticData);

        return staticDocument;
    }

}
