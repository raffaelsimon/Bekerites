using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;


[assembly: InternalsVisibleTo("BekeritesModel")]

namespace BekeritesPersistence
{
    public class Board
    {
        private int Size { get; set; }
        private int[,] cells;

        public int getCell(int x, int y)
        {
            return cells[x,y];
        }

        protected internal void setCell(int x, int y, int z)
        {
            cells[x, y] = z;
        }

        //tabla inicializalasa
        public Board(int size)
        {
            Size = size;
            cells = new int[Size, Size];
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    cells[i, j] = 0;
                }
            }

        }

        //get es set 
        public int getSize()
        { return Size; }


        



        //tabla kiirasa, leginkabb teszteleshez
        public void PrintBoard()
        {
            for (int y = 0; y < Size; y++)
            {
                for (int x = 0; x < Size; x++)
                {
                    Debug.Write(cells[x, y] + " ");
                }
                Debug.WriteLine("");
            }
        }



        //teglak lehelyezese 

        public void PlaceBlockLeftRight(int x, int y, int playerId)
        {
            if (x > Size - 2 || y > Size - 1 || x < 0 || y < 0)
                throw new ArgumentOutOfRangeException("Hibás lépés.");
            cells[x, y] = playerId;
            cells[x + 1, y] = playerId;
        }

        public void PlaceBlockRightLeft(int x, int y, int playerId)
        {
            if (x > Size - 1 || y > Size - 1 || x < 1 || y < 0)
                throw new ArgumentOutOfRangeException("Hibás lépés.");
            cells[x, y] = playerId;
            cells[x - 1, y] = playerId;
        }

        public void PlaceBlockTopBot(int x, int y, int playerId)
        {
            if (x > Size - 1 || y > Size - 2 || x < 0 || y < 0)
                throw new ArgumentOutOfRangeException("Hibás lépés.");
            cells[x, y] = playerId;
            cells[x, y + 1] = playerId;
        }

        public void PlaceBlockBotTop(int x, int y, int playerId)
        {
            if (x > Size - 1 || y > Size - 1 || x < 0 || y < 1)
                throw new ArgumentOutOfRangeException("Hibás lépés.");
            cells[x, y] = playerId;
            cells[x, y - 1] = playerId;
        }



    }
}
