using CommunityToolkit.Mvvm.ComponentModel;

namespace WordTemplates.Models;

public partial class Variable(string name, string value) : ObservableObject
{
    [ObservableProperty] private string _name = name;
    [ObservableProperty] private string _value = value;
}