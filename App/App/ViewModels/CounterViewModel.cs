using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace App.ViewModels;
public partial class CounterViewModel : ObservableObject
{
    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(DecreaseCounterCommand))]
    private int _counter;

    private bool CanDecreaseCounter(object obj)
    {
        return _counter != 0;
    }

    [RelayCommand(CanExecute = nameof(CanDecreaseCounter))]
    private void DecreaseCounter(object arg)
    {
        Counter--;
    }

    [RelayCommand]
    private void IncreaseCounter(object obj)
    {
        Counter++;
    }

    [RelayCommand]
    private void ResetCounter(object obj)
    {
        Counter = 0;
    }
}
