using Bekerites;
using System;
using System.ComponentModel.Design.Serialization;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Media;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Policy;
using System.Security.Principal;
using System.Threading.Tasks;
using System.Windows.Forms;
using BekeritesPersistence;

namespace BekeritesModel
{
    public class Model
    {


        private IBekeritesDataAccess _dataAccess;
        public enum directions { RL, LR, DU, UD };
        private int currentPlayer = 1;
        private Board? board;
        public event EventHandler<GameEventArgs>? WinnerDeclared;
        public event EventHandler<GameEventArgs>? MoveMade;
        public Board getBoard() { if (board != null) return board; else return null!; }
        private int currentDirection = 0;
        

        public Model(IBekeritesDataAccess dataAccess)
        {
            _dataAccess = dataAccess;


        }

       

        public void newGame(int n)
        {
            board = new Board(n);
            currentPlayer = 1;
            currentDirection = 0;
            

        }

        
     

        public bool PlaceBlock(directions d, int x, int y, int id)
        {
            try
            {

                if (d == directions.RL)
                {
                    if (board?.getCell(x, y) != 0 || board?.getCell(x - 1, y) != 0)
                    {
                        throw new ArgumentException("Itt már le van rakva valami.");
                    }

                    board.PlaceBlockRightLeft(x, y, id);
                }
                else if (d == directions.LR)
                {
                    if (board?.getCell(x, y) != 0 || board?.getCell(x + 1, y) != 0)
                    {
                        throw new ArgumentException("Itt már le van rakva valami.");
                    }

                    board.PlaceBlockLeftRight(x, y, id);
                }
                else if (d == directions.UD)
                {
                    if (board?.getCell(x, y) != 0 || board?.getCell(x, y + 1) != 0)
                    {
                        throw new ArgumentException("Itt már le van rakva valami.");
                    }

                    board.PlaceBlockTopBot(x, y, id);
                }
                else if (d == directions.DU)
                {
                    if (board?.getCell(x, y) != 0 || board?.getCell(x, y - 1) != 0)
                    {
                        throw new ArgumentException("Itt már le van rakva valami.");
                    }

                    board.PlaceBlockBotTop(x, y, id);
                }
                FillClosedShapes(id);

                try
                {
                    calculateScore(id);
                }
                catch (Exception e)
                {
                    throw new Exception("Hiba történt a pontszám számításakor: " + e.Message);
                }

                if (IsGameOver())
                {
                    int winner = getWinner(1, 2); ;
                    WinnerDeclared?.Invoke(this, new GameEventArgs(winner, 0));

                }
                ChangePlayer();

                MoveMade?.Invoke(this, new GameEventArgs(1, 2));
               
                return true; 

            }



            catch (Exception e)
            {
                MessageBox.Show("Helytelen lépés. (" + e.Message + ")");
                return false;
            }

        }


        public void ChangePlayer()
        {
            if (currentPlayer == 1)
                currentPlayer = 2;
            else currentPlayer = 1;
        }


        //floodfill kitolteshez
        public bool FloodFill(int x, int y, bool[,] visited, int playerId)
        {
            if (x < 0 || x >= board?.getSize() || y < 0 || y >= board?.getSize())
            {
                return false;
            }

            if (visited[x, y] || board?.getCell(x, y) == playerId)
            {
                return true;
            }

            visited[x, y] = true;

            bool left = FloodFill(x - 1, y, visited, playerId);
            bool right = FloodFill(x + 1, y, visited, playerId);
            bool up = FloodFill(x, y - 1, visited, playerId);
            bool down = FloodFill(x, y + 1, visited, playerId);
            
            if (left && right && up && down)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //jatek vegenek ellenorzese

        public bool IsGameOver()
        {
            for (int i = 0; i < board?.getSize(); i++)
            {
                for (int j = 0; j < board?.getSize(); j++)
                {
                    if (board?.getCell(i, j) == 0)
                    {
                        if (j > 0 && board.getCell(i, j - 1) == 0)
                        {
                            return false;
                        }
                        if (j < board.getSize() - 1 && board.getCell(i, j + 1) == 0)
                        {
                            return false;
                        }
                        if (i > 0 && board.getCell(i - 1, j) == 0)
                        {
                            return false;
                        }
                        if (i < board.getSize() - 1 && board.getCell(i + 1, j) == 0)
                        {
                            return false;
                        }
                    }
                }
            }

            return true;
        }


        // player meghatarozasa mentesnel

        public void getPlayerASave()

        {
            if (board?.getCell(0, 0) >= 200)
            {
                board?.setCell(0, 0, board.getCell(0, 0) - 200);
                setCurrentPlayer(1);


            }
            else if (board?.getCell(0, 0) >= 100)
            {
                board.setCell(0, 0, board.getCell(0, 0) - 100);
                setCurrentPlayer(2);
            }
        }

        //bezart alakzat kitoltese
        public void FillClosedShapes(int playerId)
        {
            // Végigmegyünk a táblán
            for (int i = 0; i < board?.getSize(); i++)
            {
                for (int j = 0; j < board?.getSize(); j++)
                {

                    if (board.getCell(i, j) != playerId)
                    {
                        if (FloodFill(i, j, new bool[board.getSize(), board.getSize()], playerId))
                        {
                            // mivel kettovel osztunk es mas szint szeretnenk a lehelyezett es elkeritett dolgoknak ez eleg optimalisnak tunik
                            board.setCell(i, j, playerId + 2);
                        }
                    }
                }
            }
        }


        //pontszam kiszamitasa 
        public int calculateScore(int playerId)
        {
            int score = 0;
            for (int i = 0; i < board?.getSize(); i++)
                for (int j = 0; j < board.getSize(); j++)
                    if (board.getCell(i, j) != 0 && board.getCell(i, j) % 2 == 0 && playerId == 2)
                    {
                        score++;
                    }
                    else if (board.getCell(i, j) != 0 && board.getCell(i, j) % 2 != 0 && playerId == 1)
                    {
                        score++;
                    }

            return score;

        }
        //gyoztes 
        public int getWinner(int id1, int id2)
        {
            if (calculateScore(id1) > calculateScore(id2))
                return 1;
            else if (calculateScore(id1) < calculateScore(id2))
                return 2;
            else return 0;

        }

        //folyamatos valtoztatast szolgalo metodus

        private void setCurrentPlayer(int x)
        {
            if (x == 1) currentPlayer = 2;
            else currentPlayer = 1;
        }

        //currentplayer get

        public int getCurrentPlayer() { return currentPlayer; }

        //betoltes
        public Board Load(String path)
        {
            if (_dataAccess == null)
                throw new InvalidOperationException("Nincs megadva adateleres.");

            board = _dataAccess.Load(path);
            return board;

        }


        //mentes
        public void Save(String path, int id)
        {   
            if (_dataAccess == null || board == null)
                throw new InvalidOperationException("Nincs megadva adateleres");
            _dataAccess.Save(path, board, id);
        }
        
    }



}


