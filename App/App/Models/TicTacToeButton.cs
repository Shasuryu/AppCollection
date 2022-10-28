using System;

namespace App.Models
{
    public class TicTacToeButton
    {

        public int Index { get; set; }

        public string ButtonUri { get; set; }

        public TicTacToeButton(int index, string buttonUri)
        {
            Index = index;
            ButtonUri = buttonUri;
        }
    }
}