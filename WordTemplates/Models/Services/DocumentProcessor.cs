using WordTemplates.Models;
//using WordTemplates.Services.DocumentProcessing;
using WordTemplates_refactofing.Services;
using Xceed.Words.NET;

namespace WordTemplates.Services;

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