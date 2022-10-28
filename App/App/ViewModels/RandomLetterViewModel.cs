using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;

namespace App.ViewModels;
public partial class RandomLetterViewModel : ObservableObject
{
    private char _letterWithout;
    private char _letterWith;

    public char LetterWithout
    {
        get => _letterWithout;
        set
        {
            _letterWithout = value;
            OnPropertyChanged();
        }
    }

    public char LetterWith
    {
        get => _letterWith;
        set
        {
            _letterWith = value;
            OnPropertyChanged();
        }
    }

    [RelayCommand]
    private void RandomLetterWithoutSpecial()
    {
        var alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        var random = new Random();

        LetterWithout = alphabet[random.Next(alphabet.Length)];
    }

    [RelayCommand]
    private void RandomLetterWithSpecial()
    {
        var alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZÄÖÜß";
        var random = new Random();

        LetterWith = alphabet[random.Next(alphabet.Length)];
    }
}
