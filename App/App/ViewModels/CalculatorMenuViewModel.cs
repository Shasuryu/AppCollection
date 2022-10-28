using App.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Xamarin.Forms;

namespace App.ViewModels;
public partial class CalculatorMenuViewModel : ObservableObject
{
    [RelayCommand]
    private async void GoToBody()
    {
        await Shell.Current.GoToAsync(nameof(BodyCalculator));
    }

    [RelayCommand]
    private async void GoToShape()
    {
        //Navigator.Navigate(new ShapeCalculatorViewModel(Navigator));
    }

    [RelayCommand]
    private async void GoToPythagoras()
    {
        await Shell.Current.GoToAsync(nameof(Pythagoras));

    }

    [RelayCommand]
    private async void GoToOrientation()
    {
        //Navigator.Navigate(new OrientationViewModel(Navigator));

    }

    [RelayCommand]
    private async void GoToFarmCalculator()
    {
        await Shell.Current.GoToAsync(nameof(FarmCalculator));
    }

    [RelayCommand]
    private async void GoToPercent()
    {
        await Shell.Current.GoToAsync(nameof(Percent));

    }

    [RelayCommand]
    private async void GoToCalculator()
    {
        await Shell.Current.GoToAsync(nameof(Calculator));

    }

    [RelayCommand]
    private async void GoToConverter()
    {
        await Shell.Current.GoToAsync(nameof(ValueConverter));
    }

    [RelayCommand]
    private async void GoToGrindCalculator()
    {
        await Shell.Current.GoToAsync(nameof(Grind));
    }
}