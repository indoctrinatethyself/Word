using WordTemplates.Models;
using WordTemplates.Services.DocumentProcessing;
using Xceed.Words.NET;

namespace WordTemplates.Services;

public interface IDocumentProcessor
{
    DocX Process(DocX document, TemplateData data);
}


public class DocumentProcessor : IDocumentProcessor
{
    public DocX Process(DocX document, TemplateData data)
    {
        DocumentProcessorCore processor = new(document, data);
        processor.Process();
        return document;
    }
}