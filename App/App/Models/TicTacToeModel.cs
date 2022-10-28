using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace App.Models
{
    public class TicTacToeModel
    {
        public static readonly string EmptyUri = "Empty.png";
        public static readonly string CrossUri = "Kreuz.png";
        public static readonly string CircleUri = "Kreis.png";
        public static readonly string CrossWonUri = "CrossWon.png";
        public static readonly string CircleWonUri = "CircleWon.png";
        public static readonly string EmptyWonUri = "EmptyWon.png";

        private bool _isCross = true;

        public static string WinnerUri;

        public List<TicTacToeButton> Buttons { get; set; } = new();

        public TicTacToeModel()
        {
            CreateButtons();
        }

        private void CreateButtons()
        {
            for (var i = 0; i < 9; i++)
            {
                Buttons.Add(new TicTacToeButton(i, EmptyUri));
            }
        }

        public void Reset()
        {
            for (var i = 0; i < Buttons.Count; i++)
            {
                Buttons[i].ButtonUri = EmptyUri;
            }
            _isCross = true;
        }

        public void UpdateButton(int index)
        {
            SetBoardPos(index);
            _isCross = !_isCross;
        }

        public bool CheckForWinner()
        {
            var winningIndexes = new[]
            {
                new [] { 0, 1, 2 },
                new [] { 3, 4, 5 },
                new [] { 6, 7, 8 },
                new [] { 0, 3, 6 },
                new [] { 1, 4, 7 },
                new [] { 2, 5, 8 },
                new [] { 0, 4, 8 },
                new [] { 2, 4, 6 }
            };
            return winningIndexes.Any(index => CheckPositions(index[0], index[1], index[2]));
        }

        private bool CheckPositions(int index1, int index2, int index3)
        {
            var indexes = new List<int> { index1, index2, index3 };
            if(Buttons.All(x => x.ButtonUri != EmptyUri) && indexes.Any(x => Buttons[x] != Buttons[index1]))
            {
                WinnerUri = EmptyWonUri;
            }
            return indexes.All(x => Buttons[x].ButtonUri != EmptyUri)
                   && indexes.All(x => Buttons[x].ButtonUri == Buttons[index1].ButtonUri)
                   || Buttons.All(x => x.ButtonUri != EmptyUri);
        }

        private void SetBoardPos(int index)
        {
            Buttons[index].ButtonUri = GetPlayerSymbol();
        }

        private string GetPlayerSymbol()
        {
            if (_isCross)
            {
                WinnerUri = CrossWonUri;
                return CrossUri;
            }
            WinnerUri = CircleWonUri;
            return CircleUri;
        }

        internal bool ButtonClickable(int index)
        {
            return Buttons[index].ButtonUri == EmptyUri;
        }
    }
}
