using CommunityToolkit.Mvvm.ComponentModel;
using WordTemplates.Models;

namespace WordTemplates.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    [ObservableProperty] private TemplateData _templateData = new();

    public MainWindowViewModel(
        MainViewModel mainViewModel,
        VariablesViewModel variablesViewModel,
        ElementsViewModel elementsViewModel, GroupsViewModel groupsViewModel)
    {
        MainViewModel = mainViewModel;
        VariablesViewModel = variablesViewModel;
        ElementsViewModel = elementsViewModel;
        GroupsViewModel = groupsViewModel;
    }

    public MainViewModel MainViewModel { get; }
    public VariablesViewModel VariablesViewModel { get; }
    public ElementsViewModel ElementsViewModel { get; }
    public GroupsViewModel GroupsViewModel { get; }
}