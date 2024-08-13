using WordTemplates_refactoring.Models;
//using WordTemplates_refactoring.Services.DocumentProcessing;
using WordTemplates_refactoring_refactofing.Services;
using Xceed.Words.NET;

namespace WordTemplates_refactoring.Services;

public interface IDocumentProcessor
{
    internal DocX Process(DocX document, TemplateData data);
}


public class DocumentProcessor : IDocumentProcessor
{
    public DocX Process(DocX document, TemplateData data)
    {
        //DocumentProcessorCore processor = new(document, data);
        //processor.Process();
        TextTransformFactory transform = new TextTransformFactory(document, data);
        return transform.Transform();
    }
}