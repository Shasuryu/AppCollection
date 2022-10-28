using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Timers;

namespace App.ViewModels;
public partial class UselessMachineViewModel : ObservableObject
{
    private Timer _timer;

    [ObservableProperty]
    private int _slider1;
    [ObservableProperty]
    private int _slider2;
    [ObservableProperty]
    private int _slider3;
    [ObservableProperty]
    private int _slider4;
    [ObservableProperty]
    private int _slider5;
    [ObservableProperty]
    private int _slider6;
    [ObservableProperty]
    private int _slider7;
    [ObservableProperty]
    private int _slider8;
    [ObservableProperty]
    private int _slider9;
    [ObservableProperty]
    private int _slider10;

    public UselessMachineViewModel()
    {
        _timer = new Timer();
        _timer.Interval = 3;
        _timer.Elapsed += GameTimeEvent;
        _timer.Start();
    }

    void GameTimeEvent(object? sender, EventArgs e)
    {
        var random = new Random().Next(0, 1000);
        if (random == 0)
        {
            Slider1 = 0;
        }
        if (random == 10)
        {
            Slider2 = 0;
        }
        if (random == 20)
        {
            Slider3 = 0;
        }
        if (random == 30)
        {
            Slider4 = 0;
        }
        if (random == 40)
        {
            Slider5 = 0;
        }
        if (random == 50)
        {
            Slider6 = 0;
        }
        if (random == 60)
        {
            Slider7 = 0;
        }
        if (random == 70)
        {
            Slider8 = 0;
        }
        if (random == 80)
        {
            Slider9 = 0;
        }
        if (random == 90)
        {
            Slider10 = 0;
        }
    }
}