using App.Models;
using App.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using Xamarin.Forms;

namespace App.ViewModels;
public partial class TicTacToeGamePageViewModel : ObservableObject
{
    public static string WinnerUri;
    private readonly RefreshableObservableCollection<TicTacToeButton> _buttons = new();

    private readonly TicTacToeModel _ticTacToeModel = new();
    public RefreshableObservableCollection<TicTacToeButton> Buttons => _buttons;

    public TicTacToeGamePageViewModel()
    {
        WinnerUri = TicTacToeModel.EmptyWonUri;
        foreach (var ticTacToeButton in _ticTacToeModel.Buttons)
        {
            _buttons.Add(ticTacToeButton);
        }
    }

    [RelayCommand(CanExecute = nameof(CanButtonClick))]
    public async void ButtonClick(object param)
    {
        if (param is not int index)
        {
            return;
        }
        _ticTacToeModel.UpdateButton(index);
        _buttons.Refresh();
        if (_ticTacToeModel.CheckForWinner())
        {
            WinnerUri = TicTacToeModel.WinnerUri;
            _ticTacToeModel.Reset();
            _buttons.Refresh();
            await Shell.Current.GoToAsync(nameof(TicTacToeWinnerPage));
        }
    }

    public bool CanButtonClick(object param)
    {
        return param is int index && _ticTacToeModel.ButtonClickable(index);
    }
}

public class RefreshableObservableCollection<T> : ObservableCollection<T>
{
    public RefreshableObservableCollection()
    {
    }

    public RefreshableObservableCollection(IEnumerable<T> collection) : base(collection)
    {
    }

    public RefreshableObservableCollection(List<T> list) : base(list)
    {
    }

    public void Refresh()
    {
        OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
    }
}