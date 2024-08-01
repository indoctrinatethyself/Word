using System.Collections.Generic;
using System.Linq;
using WordTemplates.Models;
using Xceed.Words.NET;

namespace WordTemplates.Services.DocumentProcessing;

public partial class DocumentProcessorCore
{
    private readonly DocX _document;
    private readonly TemplateData _data;

    private Dictionary<string, string> _tempVariables = new();

    public DocumentProcessorCore(DocX document, TemplateData data)
    {
        _document = document;
        _data = data;
    }

    public void Process()
    {
        _tempVariables = new();
        InitializeGeneralVariables();

        ProcessConditions();

        ProcessSpecialBlockVariables();

        // ProcessConditionsInTables();

        ProcessTempVariables();
        ProcessVariables();
    }

    public void InitializeGeneralVariables()
    {
        var names = string.Join(", ", ((IList<Element>)_data.Elements).Select(e => e.Name));
        _tempVariables["названия"] = names;

        _tempVariables["номера таблиц 1"] = $"4.1 - 4.{_data.Groups.Count+1}";
        _tempVariables["номера таблиц 2"] = $"4.{_data.Groups.Count + 1} - 4.{(_data.Groups.Count+1) * 2}";
        _tempVariables["номера таблиц 3"] = $"6.1 - 6.{_data.Groups.Count+1}";
    }
}