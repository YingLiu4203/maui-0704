﻿//using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Test0704;

partial class MainViewModel : BaseViewModel
{
    [ObservableProperty]
    int _clickCount = 0;

    [RelayCommand]
    public void IncrementClickMeButton() => ClickCount++;
}
