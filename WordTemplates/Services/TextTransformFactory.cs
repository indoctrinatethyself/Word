using System.Text.RegularExpressions;
using WordTemplates.Models;
using Xceed.Words.NET;

namespace WordTemplates_refactofing.Services;

public class TextTransformFactory
{
    static DocX staticDocument;
    static TemplateData staticData;
    TextTransformFactory(DocX _document, TemplateData _data)
    {
        staticDocument = _document;
        staticData = _data;
    }
   DocX Transform()
    {
        IExecute executioneer;
        /*somecode*/
        return staticDocument;
    }

}
