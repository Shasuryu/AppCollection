using System;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace App.ViewModels;
public partial class FarmCalculatorViewModel : ObservableObject
{
    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(CalculateFarmTimeCommand))]
    private string _amountNeeded;
    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(CalculateFarmTimeCommand))]
    private string _amountGot;
    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(CalculateFarmTimeCommand))]
    private string _amountGainedInXMinutes;
    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(CalculateFarmTimeCommand))]
    private string _xMinutesPassed;

    [ObservableProperty]
    private double _minutes;
    [ObservableProperty]
    private double _hours;
    

    [RelayCommand(CanExecute=nameof(CanCalculateFarmTime))]
    private void CalculateFarmTime()
    {
        var currentNeeded = double.Parse(_amountNeeded) - double.Parse(_amountGot);
        var neededCycles = currentNeeded / double.Parse(_amountGainedInXMinutes);
        var timeNeededInMinutes = neededCycles * double.Parse(_xMinutesPassed);
        for (int i = 0; i < timeNeededInMinutes; i++)
        {
            if (i * 60 < timeNeededInMinutes)
            {
                Hours = i;
            }
        }
        Minutes = Math.Round(timeNeededInMinutes - Hours * 60, 2);
    }

    private bool CanCalculateFarmTime()
    {
        try
        {
            double.Parse(_amountNeeded);
            double.Parse(_amountGot);
            double.Parse(_amountGainedInXMinutes);
            double.Parse(_xMinutesPassed);
        }
        catch
        {
            return false;
        }
        return true;
    }
}
