using App.Views;
using System;
using Xamarin.Forms;
using Color = App.Views.Color;

namespace App
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(BodyCalculator), typeof(BodyCalculator));
            Routing.RegisterRoute(nameof(CalculatorMenu), typeof(CalculatorMenu));
            Routing.RegisterRoute(nameof(Calculator), typeof(Calculator));
            Routing.RegisterRoute(nameof(Coin), typeof(Coin));
            Routing.RegisterRoute(nameof(Color), typeof(Color));
            Routing.RegisterRoute(nameof(Counter), typeof(Counter));
            Routing.RegisterRoute(nameof(FarmCalculator), typeof(FarmCalculator));
            Routing.RegisterRoute(nameof(Grind), typeof(Grind));
            Routing.RegisterRoute(nameof(Percent), typeof(Percent));
            Routing.RegisterRoute(nameof(PngFade), typeof(PngFade));
            Routing.RegisterRoute(nameof(Pythagoras), typeof(Pythagoras));
            Routing.RegisterRoute(nameof(Timer), typeof(Timer));
            Routing.RegisterRoute(nameof(RandomLetter), typeof(RandomLetter));
            Routing.RegisterRoute(nameof(RandomNumber), typeof(RandomNumber));
            Routing.RegisterRoute(nameof(TicTacToeGamePage), typeof(TicTacToeGamePage));
            Routing.RegisterRoute(nameof(TicTacToeWinnerPage), typeof(TicTacToeWinnerPage));
            Routing.RegisterRoute(nameof(UselessMachine), typeof(UselessMachine));
            Routing.RegisterRoute(nameof(ValueConverter), typeof(ValueConverter));
        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//LoginPage");
        }
    }
}
