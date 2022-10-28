using System;
using System.Collections.Generic;
using System.Text;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace App.ViewModels;
public partial class GrindViewModel : ObservableObject
{
    [ObservableProperty] 
    [NotifyCanExecuteChangedFor(nameof(CalculateCommand))]
    private string _maxValue;
    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(CalculateCommand))]
    private string _minValue;
    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(CalculateCommand))]
    private string _time;
    [ObservableProperty]
    private double _value;

    [RelayCommand(CanExecute = nameof(CanCalculate))]
    private void Calculate()
    {
        Value = Math.Round((double.Parse(_maxValue) - double.Parse(_minValue)) / double.Parse(_time), 2);
    }

    private bool CanCalculate()
    {
        try
        {
            double.Parse(_maxValue);
            double.Parse(_minValue);
            double.Parse(_time);
        }
        catch
        {
            return false;
        }
        return true;
    }
}
