using System.Text.RegularExpressions;
using WordTemplates.Models;
using Xceed.Words.NET;

namespace WordTemplates_refactofing.Services;

public class TextTransformFactory
{
    static DocX staticDocument;
    static TemplateData staticData;
    TextTransformFactory(DocX document, TemplateData data)
    {
        staticDocument = document;
        staticData = data;
    }
   DocX Transform(DocX document, string savePath)
    {

        /*somecode*/
        staticDocument.SaveAs(savePath);
        return staticDocument;
    }

}
