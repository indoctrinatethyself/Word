using CommunityToolkit.Mvvm.Input;
using WordTemplates.Models;

namespace WordTemplates.ViewModels;

public partial class VariablesViewModel : ViewModelBase
{
    public VariablesViewModel(TemplateData templateData)
    {
        TemplateData = templateData;
    }

    public TemplateData TemplateData { get; }

    [RelayCommand]
    private void Add()
    {
        TemplateData.Variables.Add(new("",""));
    }

    [RelayCommand]
    private void Remove(Variable v)
    {
        TemplateData.Variables.Remove(v);
    }
}