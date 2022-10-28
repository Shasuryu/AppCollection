using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace App.ViewModels;
public partial class CalculatorViewModel : ObservableObject
{
    [ObservableProperty] 
    private string _display;

    [RelayCommand]
    private void One()
    {
        Display += "1";
    }
    [RelayCommand]
    private void Two()
    {
        Display += "2";
    }
    [RelayCommand]
    private void Three()
    {
        Display += "3";
    }
    [RelayCommand]
    private void Four()
    {
        Display += "4";
    }
    [RelayCommand]
    private void Five()
    {
        Display += "5";
    }
    [RelayCommand]
    private void Six()
    {
        Display += "6";
    }
    [RelayCommand]
    private void Seven()
    {
        Display += "7";
    }
    [RelayCommand]
    private void Eight()
    {
        Display += "8";
    }
    [RelayCommand]
    private void Nine()
    {
        Display += "9";
    }
    [RelayCommand]
    private void Zero()
    {
        Display += "0";
    }
    [RelayCommand]
    private void Point()
    {
        Display += ".";
    }
    [RelayCommand]
    private void Plus()
    {
        Display += "+";
    }
    [RelayCommand]
    private void Minus()
    {
        Display += "-";
    }
    [RelayCommand]
    private void Multiply()
    {
        Display += "*";
    }
    [RelayCommand]
    private void Divide()
    {
        Display += "/";
    }
    [RelayCommand]
    private void OpenBracket()
    {
        Display += "(";
    }
    [RelayCommand]
    private void CloseBracket()
    {
        Display += ")";
    }
    [RelayCommand]
    private void Calculate()
    {
        DataTable dt = new DataTable();
        try
        {
            Display = dt.Compute(_display, "").ToString();
        }
        catch
        {
            var equation = _display;
            Display = $"Rechnung mathematisch nicht logisch: {equation}";
        }
    }
    [RelayCommand]
    private void Clear()
    {
        Display = "";
    }

    [RelayCommand]
    private void Back()
    {
        var stringWithoutLastChar = _display.Remove(_display.Length - 1);
        Display = stringWithoutLastChar;
    }
}
