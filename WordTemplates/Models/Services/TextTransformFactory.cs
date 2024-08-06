using System.Collections.Generic;

using WordTemplates.Models;
using WordTemplates_refactofing.Services.NameChanger;
using Xceed.Words.NET;
using System.Linq;
using WordTemplates_refactofing.Services.TablesRenamer;


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
        //this part of code adds microscheme's name(s) into the document
        IExecutioneer singleReplacement = new NameChangerSingleReplacement(((IList<Element>)staticData.Elements).Select(e => e.Name).ToArray());
        staticDocument = singleReplacement.Execute(staticDocument);
        singleReplacement = null!;

        //the following code adds name(s) and description(s)
        //maybe use interface?
        IExecutioneer multipleReplacement = new NameChangerMultipleReplacement(((IList<Element>)staticData.Elements).Select(e => e.Name).ToArray(), ((IList<Element>)staticData.Elements).Select(e => e.Description).ToArray());
        staticDocument = multipleReplacement.Execute(staticDocument);
        multipleReplacement = null!;

        //the next lines are about a table 


        
        AddTable addTable = new AddTable();
        return staticDocument;
    }

}
