
using Bekerites;
using BekeritesModel;
using BekeritesPersistence;

namespace BekeritesTest
{
    [TestClass]
    public class UnitTest1
    {   
        //teszt arra, ha nincs v�ge a j�t�knak.
        [TestMethod]
        public void GameOverTest1()
        {
            Model model = new Model(null!);
            model.newGame(6);
            model.PlaceBlock(Model.directions.LR, 0, 0, 1);
            model.PlaceBlock(Model.directions.LR, 2, 0, 2);
            model.PlaceBlock(Model.directions.UD, 0, 1, 1);
            model.PlaceBlock(Model.directions.LR, 0, 3, 1);
            model.PlaceBlock(Model.directions.LR, 2, 3, 1);
            model.PlaceBlock(Model.directions.DU, 3, 2, 1);
            model.FillClosedShapes(1);
            
            Assert.AreEqual(false, model.IsGameOver());

        }

        //teszt arra, ha v�ge van a j�t�knak
        [TestMethod]
        public void GameOverTest2()
        {

            Model model = new Model(null!);
            model.newGame(6);

            model.PlaceBlock(Model.directions.RL, 1, 0, 1);
            model.PlaceBlock(Model.directions.RL, 1, 1, 2);
            model.PlaceBlock(Model.directions.RL, 1, 2, 1);
            model.PlaceBlock(Model.directions.RL, 1, 3, 1);
            model.PlaceBlock(Model.directions.RL, 1, 4, 2);
            model.PlaceBlock(Model.directions.RL, 1, 5, 1);
            model.PlaceBlock(Model.directions.RL, 3, 0, 2);
            model.PlaceBlock(Model.directions.RL, 3, 1, 1);
            model.PlaceBlock(Model.directions.RL, 3, 2, 2);
            model.PlaceBlock(Model.directions.RL, 3, 3, 1);
            model.PlaceBlock(Model.directions.RL, 3, 4, 2);
            model.PlaceBlock(Model.directions.RL, 3, 5, 1);
            model.PlaceBlock(Model.directions.RL, 5, 0, 2);
            model.PlaceBlock(Model.directions.RL, 5, 1, 1);
            model.PlaceBlock(Model.directions.RL, 5, 2, 2);
            model.PlaceBlock(Model.directions.RL, 5, 3, 1);
            model.PlaceBlock(Model.directions.RL, 5, 4, 2);
            model.PlaceBlock(Model.directions.RL, 5, 5, 1);
            model.FillClosedShapes(1);
            model.FillClosedShapes(2);

            Assert.AreEqual(true, model.IsGameOver());
        }

        //teszt a board elkeszitesekor.
        [TestMethod]
        public void BekeritesBoardTest()
        {
            Model model = new Model(null!);
            model.newGame(8);
            Assert.AreEqual(false, model.IsGameOver()); // nem lehet vege az elejen
            Assert.AreEqual(1, model.getCurrentPlayer()); // minden uj jatek eseten 1-es jatekos kezd.
            Assert.AreEqual(0, model.calculateScore(model.getCurrentPlayer()));  //nem lehet pontja egyik jatekosnak sem kezdetben.
        }

        //calculatescore teszt
        [TestMethod]
        public void CalculateScore_Player1()
        {
            Model model = new Model(null!);
            int playerId = 1;
            model.newGame(6);
            model.PlaceBlock(Model.directions.LR, 0, 1, playerId);
            model.PlaceBlock(Model.directions.LR, 2, 2, playerId);
            int score = model.calculateScore(playerId);
            Assert.AreEqual(4, score);
        }




        [TestMethod]
        public void FillTest1()
        {

            /* Teh�t: 1 1 2 2 0 0 0 0               Itt m�r �res kell maradjon a belseje.
                      1 0 0 1 0 0 0 0
                      1 0 0 1 0 0 0 0
                      1 1 1 1 0 0 0 0
                       . . .
               */


            Model model = new Model(null!);
            model.newGame(8);

            model.PlaceBlock(Model.directions.LR, 0, 0, 1);
            model.PlaceBlock(Model.directions.LR, 2, 0, 2);
            model.PlaceBlock(Model.directions.UD, 0, 1, 1);
            model.PlaceBlock(Model.directions.LR, 0, 3, 1);
            model.PlaceBlock(Model.directions.LR, 2, 3, 1);
            model.PlaceBlock(Model.directions.DU, 3, 2, 1);
            model.FillClosedShapes(1);

            Assert.AreEqual(0, model.getBoard().getCell(1, 1));
            Assert.AreEqual(0, model.getBoard().getCell(1, 2));
            Assert.AreEqual(0, model.getBoard().getCell(2, 1));
            Assert.AreEqual(0, model.getBoard().getCell(2, 2));



        }

        [TestMethod]
        public void FillTest2()
        {
            Model model = new Model(null!);
            model.newGame(6);
            //Most megn�zz�k, hogy a board sz�lein ker�t-e az algoritmus, mivel ott nem vessz�k figyelembe, nem szabad ker�tsen.

            model.PlaceBlock(Model.directions.LR, 0, 2, 1);
            model.PlaceBlock(Model.directions.DU, 2, 1, 1);

            Assert.AreEqual(0, model.getBoard().getCell(1, 0));
            Assert.AreEqual(0, model.getBoard().getCell(0, 1));
            Assert.AreEqual(0, model.getBoard().getCell(0, 0));
            Assert.AreEqual(0, model.getBoard().getCell(1, 1));

        }

       

        [TestMethod]
        public void FillTest3()
        {
            //itt azt n�zz�k meg, hogy be tudjuk-e ker�teni a m�sik j�t�kost.


            /*
            T�bla:
            0 1 1 1 1 ... 
            0 1 2 2 1 ...
            0 1 1 1 1 ...
               ...

            Majd -> 

            0 1 1 1 1 ... 
            0 1 3 3 1 ...
            0 1 1 1 1 ...
               ...
             */

           

            Model model = new(null!);
            model.newGame(8);
            model.PlaceBlock(Model.directions.LR, 1, 0, 1);
            model.FillClosedShapes(1);
            model.PlaceBlock(Model.directions.LR, 3, 0, 1);
            model.PlaceBlock(Model.directions.UD, 1, 1, 1);
            model.PlaceBlock(Model.directions.UD, 4, 1, 1);
            model.FillClosedShapes(1);
            model.PlaceBlock(Model.directions.LR, 2, 2, 1);
           

            model.FillClosedShapes(1);
            model.FillClosedShapes(2);

            Assert.AreEqual(3, model.getBoard().getCell(2, 1));
            Assert.AreEqual(3, model.getBoard().getCell(3, 1));

        }









    }
}