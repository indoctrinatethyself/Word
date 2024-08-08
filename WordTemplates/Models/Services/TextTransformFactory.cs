using System.Collections.Generic;

using WordTemplates.Models;
using WordTemplates_refactofing.Services.NameChanger;
using Xceed.Words.NET;
using System.Linq;
using WordTemplates_refactofing.Services.TablesRenamer;
using WordTemplates_refactofing.Models.Services.TablesAppender;


namespace WordTemplates_refactofing.Services;
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

        //this part of code adds microscheme's name(s) into the document
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

        // replace another text sample with parameters
        IExecutioneer addTableParameters = new AddTableParameters(staticDocument, staticData);
        staticDocument=addTableParameters.Execute(staticDocument);


        IExecutioneer addTableSummary = new AddTableSummary(staticDocument, staticData);
        staticDocument = AddTableSummary.Execute(staticDocument);

        return staticDocument;
    }

}
