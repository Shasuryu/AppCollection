using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;

namespace App.ViewModels;
public partial class CoinViewModel : ObservableObject
{
    [ObservableProperty]
    private string _coinUri = Number;

    private static readonly string Number = "Zahl.png";
    private static readonly string Head = "Kopf.png";

    [RelayCommand]
    private void FlipCoin() => CoinUri = new Random().Next(0, 2) == 0 ? Head : Number;
}