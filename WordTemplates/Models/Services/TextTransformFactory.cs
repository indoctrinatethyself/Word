using System.Collections.Generic;

using WordTemplates.Models;
using WordTemplates_refactofing.Services.NameChanger;
using Xceed.Words.NET;
using System.Linq;


namespace WordTemplates_refactofing.Services;

public class TextTransformFactory
{
    static DocX staticDocument;
    static TemplateData staticData;
    public TextTransformFactory(DocX document, TemplateData data)
    {
        staticDocument = document;
        staticData = data;
    }
    TextTransformFactory(DocX document)
    {
        staticDocument = document;
    }
    /*public DocX Transform(DocX document, string savePath)
    {  

        staticDocument.SaveAs(savePath);
        return staticDocument;
    }*/

    public DocX Transform()
    {
        //This is a main method, used as a factory for step-by-step edition ov the document
        //the following row is a copy-pasted one from the pervious coder
        NameChangerSingleReplacement singleReplacement = new NameChangerSingleReplacement(((IList<Element>)staticData.Elements).Select(e => e.Name).ToArray());
        staticDocument = singleReplacement.Execute(staticDocument);
        return staticDocument;
    }

}
