using System;

namespace BekeritesModel
{
    public class GameEventArgs : EventArgs
    {
        public int Player1 { get; }
        public int Player2 { get; }




        public GameEventArgs(int player1, int player2)
        {
            Player1 = player1;
            Player2 = player2;

        }
    }
}