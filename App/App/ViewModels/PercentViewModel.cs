using App.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;

namespace App.ViewModels;
public partial class PercentViewModel : ObservableObject
{
    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(CalculateValueOfFullCommand))]
    private string _percentOfFull = "";
    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(CalculateValueOfFullCommand))]
    private string _valueOfFull = "";
    [ObservableProperty]
    private string _percentValueOfFull = "0";

    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(CalculatePercentValueOfValueCommand))]
    private string _percentValue = "";
    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(CalculatePercentValueOfValueCommand))]
    private string _valueForHundretPercent = "";
    [ObservableProperty]
    private string _percentValueOfValue = "0";

    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(CalculateHundretPercentCommand))]
    private string _percentValueOfLast = "";
    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(CalculateHundretPercentCommand))]
    private string _xPercent = "";
    [ObservableProperty]
    private string _hundretPercent = "0";

    [RelayCommand(CanExecute = nameof(CanCalculateValueOfFull))]
    private void CalculateValueOfFull()
    {
        PercentValueOfFull = Math.Round((double.Parse(_valueOfFull) / 100) * double.Parse(_percentOfFull), 2).ToString();
    }
    private bool CanCalculateValueOfFull()
    {
        if (_percentOfFull != "" && _valueOfFull != "")
        {
            return true;
        }
        return false;
    }

    [RelayCommand(CanExecute = nameof(CanCalculatePercentValueOfValue))]
    private void CalculatePercentValueOfValue()
    {
        PercentValueOfValue = Math.Round((double.Parse(_percentValue) / double.Parse(_valueForHundretPercent)) * 100, 2).ToString();
    }
    private bool CanCalculatePercentValueOfValue()
    {
        if (_percentValue != "" && _valueForHundretPercent != "")
        {
            return true;
        }
        return false;
    }

    [RelayCommand(CanExecute = nameof(CanCalculateHundretPercent))]
    private void CalculateHundretPercent()
    {
        HundretPercent = Math.Round((double.Parse(_percentValueOfLast) / double.Parse(_xPercent)) * 100, 2).ToString();
    }
    private bool CanCalculateHundretPercent()
    {
        if (_percentValueOfLast != "" && _xPercent != "")
        {
            return true;
        }
        return false;
    }
}
