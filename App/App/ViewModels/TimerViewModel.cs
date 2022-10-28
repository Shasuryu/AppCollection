using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Timers;

namespace App.ViewModels;
public partial class TimerViewModel : ObservableObject
{
    private Timer _timer;
    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(PauseTimerCommand))]
    private bool _paused = true;
    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(ResetTimerCommand))]
    private bool _canReset;

    private DateTime _time;
    private DateTime _pause;
    private TimeSpan _pausedTime;
    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(ResetTimerCommand))]
    private TimeSpan _timerState;

    private void Timer_Elapsed(object sender, ElapsedEventArgs e)
    {
        TimerState = DateTime.Now - (_time - _pausedTime);
    }

    [RelayCommand(CanExecute = nameof(CanStartTimer))]
    private void StartTimer(object obj)
    {
        _timer = new Timer();
        _timer.Interval = 1;  
        _timer.Elapsed += Timer_Elapsed; ;
        _timer.Start();
        _paused = true;
        _canReset = true;
        if (_timerState == TimeSpan.Zero)
        {
            _time = DateTime.Now;
        }
        else
        {
            _pausedTime -= DateTime.Now - _pause;
        }
    }

    private bool CanStartTimer(object arg)
    {
        return _paused;
    }

    [RelayCommand(CanExecute = nameof(CanPauseTimer))]
    private void PauseTimer(object obj)
    {
        _pause = DateTime.Now;
        _timer.Stop();
        _paused = false;
    }

    private bool CanPauseTimer(object arg)
    {
        return _paused;
    }

    [RelayCommand(CanExecute = nameof(CanResetTimer))]
    private void ResetTimer(object obj)
    {
        _pausedTime = TimeSpan.Zero;
        _timer.Stop();
        _paused = false;
        TimerState = TimeSpan.Zero;
    }

    private bool CanResetTimer(object arg)
    {
        _canReset = false;
        return !_canReset;
    }
}