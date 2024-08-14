﻿using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using CommunityToolkit.Mvvm.ComponentModel;
using WordTemplates_refactoring_refactofing.Models.DataTypes;

namespace WordTemplates_refactoring.Models;

public partial class TemplateData : ObservableObject
{
    [ObservableProperty] private ObservableCollection<Variable> _variables = new();

    [ObservableProperty, NotifyPropertyChangedFor(nameof(CollectionElements))]
    private ObservableLinkedCollection<TemplateData, Element> _elements;

    [ObservableProperty] private ObservableCollection<Group> _groups = new();

    public TemplateData()
    {
        _elements = new(this);
    }

    // IDE bug workaround
    public IList<ObservableLinkedCollection<TemplateData, Element>.CollectionElement> CollectionElements => Elements;

    public void CopyFrom(TemplateData data)
    {
        this.Variables = data.Variables;
        this.Groups = data.Groups;
        this.Elements = data.Elements;
    }

    public TemplateDataJsonModel ToJsonModel() => new()
    {
        Variables = this.Variables.ToArray(),
        Groups = this.Groups.Select(g => g.ToJsonModel()).ToArray(),
        Elements = ((IList<Element>)this.Elements).Select(e => e.ToJsonModel()).ToArray(),
    };
}

public class TemplateDataJsonModel
{
    public Variable[] Variables { get; set; } = [ ];
    public ElementJsonModel[] Elements { get; set; } = [ ];
    public GroupJsonModel[] Groups { get; set; } = [ ];

    public TemplateData ToTemplateData()
    {
        var data = new TemplateData();
        data.Variables = new(Variables);
        data.Groups = new(Groups.Select(g => g.ToGroup()));
        data.Elements = new(data, Elements.Select(e => e.ToElement(data)));
        return data;
    }
}