using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;

namespace App.ViewModels;
public partial class RNGViewModel : ObservableObject
{
    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(GenerateRandomCommand))]
    private string _upper = string.Empty;
    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(GenerateRandomCommand))]
    private string _lower = string.Empty;
    [ObservableProperty]
    private int _number;

    [RelayCommand(CanExecute = nameof(CanGenerateRandom))]
    private void GenerateRandom()
    {
        Number = new Random().Next(int.Parse(_lower), int.Parse(_upper) + 1);
    }

    private bool CanGenerateRandom()
    {
        if(!int.TryParse(_lower, out int lower) || !int.TryParse(_upper, out int upper))
        {
            return false;
        }
        if (lower >= upper)
        {
            return false;
        }
        return true;
    }

    [RelayCommand]
    private void GenerateRandomZeroToTen()
    {
        Number = new Random().Next(0, 10 + 1);
    }

    [RelayCommand]
    private void GenerateRandomZeroToHundret()
    {
        Number = new Random().Next(0, 100 + 1);
    }
}
