using CommunityToolkit.Mvvm.ComponentModel;
using System;
using App.Views;
using CommunityToolkit.Mvvm.Input;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;

namespace App.ViewModels;
public partial class TicTacToeWinnerPageViewModel : ObservableObject
{
    [ObservableProperty]
    private string _winnerUri;

    public TicTacToeWinnerPageViewModel()
    {
        WinnerUri = TicTacToeGamePageViewModel.WinnerUri;
    }

    [RelayCommand]
    public async void NewGame()
    {
        await Shell.Current.Navigation.PopToRootAsync();
    }
}