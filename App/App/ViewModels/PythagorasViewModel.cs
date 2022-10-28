using System;
using System.Collections.Generic;
using System.Text;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Xamarin.Forms;

namespace App.ViewModels;
public partial class PythagorasViewModel : ObservableObject
{
    [ObservableProperty] 
    [NotifyCanExecuteChangedFor(nameof(CalculateCommand))]
    private string _sideA = "";
    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(CalculateCommand))]
    private string _sideB = "";
    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(CalculateCommand))]
    private string _sideC = "";
    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(CalculateCommand))]
    private string _winkel;

    [RelayCommand(CanExecute = nameof(CanCalculate))]
    private void Calculate()
    {
        if (_winkel == "Alpha" && _sideA == "")
        {
            SideA = Math.Round(Math.Pow(Math.Pow(double.Parse(_sideB), 2) + Math.Pow(double.Parse(_sideC), 2), 0.5), 2).ToString();
        }
        if (_winkel == "Alpha" && _sideA != "")
        {
            if (_sideB == "")
            {
                SideB = Math.Round(Math.Pow(Math.Pow(double.Parse(_sideA), 2) - Math.Pow(double.Parse(_sideC), 2), 0.5), 2).ToString();
            }
            if (_sideC == "")
            {
                SideC = Math.Round(Math.Pow(Math.Pow(double.Parse(_sideA), 2) - Math.Pow(double.Parse(_sideB), 2), 0.5), 2).ToString();
            }
        }
        if (_winkel == "Beta" && _sideB == "")
        {
            SideB = Math.Round(Math.Pow(Math.Pow(double.Parse(_sideA), 2) + Math.Pow(double.Parse(_sideC), 2), 0.5), 2).ToString();
        }
        if (_winkel == "Beta" && _sideB != "")
        {
            if (_sideA == "")
            {
                SideA = Math.Round(Math.Pow(Math.Pow(double.Parse(_sideB), 2) - Math.Pow(double.Parse(_sideC), 2), 0.5), 2).ToString();
            }
            if (_sideC == "")
            {
                SideC = Math.Round(Math.Pow(Math.Pow(double.Parse(_sideB), 2) - Math.Pow(double.Parse(_sideA), 2), 0.5), 2).ToString();
            }
        }
        if (_winkel == "Gamma" && _sideC == "")
        {
            SideC = Math.Round(Math.Pow(Math.Pow(double.Parse(_sideA), 2) + Math.Pow(double.Parse(_sideB), 2), 0.5), 2).ToString();
        }
        if (_winkel == "Gamma" && _sideC != "")
        {
            if (_sideA == "")
            {
                SideA = Math.Round(Math.Pow(Math.Pow(double.Parse(_sideC), 2) - Math.Pow(double.Parse(_sideB), 2), 0.5), 2).ToString();
            }
            if (_sideB == "")
            {
                SideB = Math.Round(Math.Pow(Math.Pow(double.Parse(_sideC), 2) - Math.Pow(double.Parse(_sideA), 2), 0.5), 2).ToString();
            }
        }
    }

    private bool CanCalculate()
    {
        if (_sideA == "" && _sideB != "" && _sideC != "" ||
            _sideA != "" && _sideB == "" && _sideC != "" ||
            _sideA != "" && _sideB != "" && _sideC == "" &&
            _winkel != null)
        {
            return true;
        }
        return false;
    }
}
