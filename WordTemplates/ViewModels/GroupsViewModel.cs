using CommunityToolkit.Mvvm.Input;
using WordTemplates.Models;

namespace WordTemplates.ViewModels;

public partial class GroupsViewModel : ViewModelBase
{
    public GroupsViewModel(TemplateData templateData)
    {
        TemplateData = templateData;
    }

    public TemplateData TemplateData { get; }

    [RelayCommand]
    private void Add()
    {
        TemplateData.Groups.Add(new());
    }

    [RelayCommand]
    private void Remove(Group g)
    {
        TemplateData.Groups.Remove(g);
    }
}