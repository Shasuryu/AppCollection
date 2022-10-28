using System;
using CommunityToolkit.Mvvm.ComponentModel;
using Xamarin.Forms;

namespace App.ViewModels;
public partial class ColorViewModel : ObservableObject
{
    private int _red;
    private int _green;
    private int _blue;

    public int Red
    {
        get => _red;

        set
        {
            if (value != _red)
            {
                _red = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(Color));
            }
        }
    }

    public int Green
    {
        get => _green;

        set
        {
            if (value != _green)
            {
                _green = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(Color));
            }
        }
    }

    public int Blue
    {
        get => _blue;

        set
        {
            if (value != _blue)
            {
                _blue = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(Color));
            }
        }
    }

    public Brush Color => new SolidColorBrush(Xamarin.Forms.Color.FromRgb(Red, Green, Blue));
}