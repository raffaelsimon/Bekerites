
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BekeritesPersistence;
using BekeritesModel;

namespace Bekerites
{
    public partial class Form1 : Form
    {
        
        
        #region Valtozok
        
        private int palyameret = 0;
        private int currentDirection = 0;
        private Model model;
        private IBekeritesDataAccess _dataAccess = null!;
        
        #endregion

       

        #region Form1, EventHandlerek
        public Form1()
        {
            InitializeComponent();
            _dataAccess = new BekeritesFileDataAccess();
            model = new Model(_dataAccess);
            model.WinnerDeclared += OnWinnerDeclared;
            model.MoveMade += OnMoveMade;
            
           
        }

        private void OnWinnerDeclared(object? sender, GameEventArgs e)
        {
            int winner = e.Player1;
            if (winner == 1)
                MessageBox.Show("A győztes: Piros", "Vége");
            else if (winner == 2)
                MessageBox.Show("A győztes: Kék", "Vége");
            else
                MessageBox.Show("A játék döntetlen", "Vége");
        }

        private void OnMoveMade(object? sender, GameEventArgs e)
        {
            szinez();
            label4.Text = ("Piros:" + Convert.ToString(model.calculateScore(1)));
            label5.Text = ("Kék:" + Convert.ToString(model.calculateScore(2)));
            
        }

        #endregion

        #region Jatek setup, board setup, label setup
        private void setUpGame(int size)
        {
            
            model.newGame(size);
            
            cleanBoard();
            for (int i = 0; i < size; i++)
                for (int j = 0; j < size; j++)

                {
                    Button button = new Button();
                    button.Size = new Size(50, 50);
                    button.Location = new Point(i * 50, j * 50 + menuStrip1.Height * 2);
                    button.Click += Button_Click;
                    this.Controls.Add(button);
                    button.MouseUp += Button_MouseUp;

                }
           

            labels();
        }

        private void setUpBoard(Board board)
        {

            for (int i = 0; i < board.getSize(); i++)
                for (int j = 0; j < board.getSize(); j++)
                {
                    Button? button = new Button();
                    button.Size = new Size(50, 50);
                    button.Location = new Point(i * 50, j * 50 + menuStrip1.Height * 2);
                    button.Click += Button_Click;
                    this.Controls.Add(button);
                    button.MouseUp += Button_MouseUp;

                }

            szinez();
            labels();

        }

        void labels()
        {
            //labelek elrendezese hogy lehessen meretezni az ablakot tehat valahol semi responsive legyen (ehhez hasznaltam segitseget)
            label3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label4.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label5.Anchor = AnchorStyles.Top | AnchorStyles.Right;


            label1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            label2.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;


            label2.Text = "Játékos: Piros";
            label1.Text = "Irány: Jobbról balra";
            label3.Text = "A játék állása:";
            label4.Text = "Piros: " + Convert.ToString(model.calculateScore(1));
            label5.Text = "Kék: " + Convert.ToString(model.calculateScore(2));
        }

        #endregion









        #region Button metodusok
        // ez adja meg hogy milyen erteke legyen a directionnek
        private void Button_MouseUp(object? sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                currentDirection = (currentDirection + 1) % 4;
                switch (currentDirection)
                {
                    case 0:
                        label1.Text = "Irány: Jobbról balra";
                        break;
                    case 1:
                        label1.Text = "Irány: Balról jobbra";
                        break;
                    case 2:
                        label1.Text = "Irány: Lentről felfele";
                        break;
                    case 3:
                        label1.Text = "Irány: Fentről lefele";
                        break;
                }
            }
        }

        //a lerakasert felelo metodus
        private void Button_Click(object? sender, EventArgs e)
        {
            Button? clickedButton = sender as Button;
            try
            {
                if (clickedButton != null)
                {
                    int x = clickedButton.Location.X / 50;
                    int y = clickedButton.Location.Y / 50 - menuStrip1.Height * 2 / 50;
                    bool isBlockPlaced = false;
                    if (model.getCurrentPlayer() == 1)
                    {
                        isBlockPlaced = model.PlaceBlock((Model.directions)currentDirection, x, y, model.getCurrentPlayer());

                    }
                    else if (model.getCurrentPlayer() == 2)
                    {
                        isBlockPlaced = model.PlaceBlock((Model.directions)currentDirection, x, y, model.getCurrentPlayer());

                    }

                    if (model.getCurrentPlayer() == 1)
                    {
                        label2.Text = "Játékos: Piros";
                    }
                    else label2.Text = "Játékos: Kék";

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           



        }
        //palya letisztitasa. ez atmegy a vezerlokon, berakja oket egy listaba, amennyiben gomb, majd egyenkent leszedi oket
        private void cleanBoard()
        {
            List<Button> buttonsToRemove = new List<Button>();
            foreach (Control control in this.Controls)
            {
                if (control is Button)
                {
                    buttonsToRemove.Add((Button)control);
                }
            }
            foreach (Button button in buttonsToRemove)
            {
                this.Controls.Remove(button);
            }
        }



        void szinez()
        {
            foreach (Control control in this.Controls)
            {
                if (control is Button)
                {

                    Button? button = control as Button;
                    if (button != null)
                    {
                        int i = button.Location.X / 50;
                        int j = button.Location.Y / 50 - menuStrip1.Height * 2 / 50;

                        if (model.getBoard().getCell(i, j) == 1)
                        {
                            button.BackColor = Color.Red; //  amit direktben foglaltunk el 1-el
                        }
                        else if (model.getBoard().getCell(i, j) == 2)
                        {
                            button.BackColor = Color.CornflowerBlue; // amit direktben foglaltunk el 2-vel
                        }
                        else if (model.getBoard().getCell(i, j) == 3)
                        {
                            button.BackColor = Color.Pink; // amit az 1-el bezártunk
                        }
                        else if (model.getBoard().getCell(i, j) == 4)
                        {
                            button.BackColor = Color.LightBlue; // amit a 2-vel bezártunk
                        }
                    }
                }
            }
        }
        #endregion

        #region Beallitasok


        private void közepesPálya8X8ToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            cleanBoard();
            palyameret = 8;
            setUpGame(palyameret);
            
            
        }

        private void kisPálya6X6ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cleanBoard();
            palyameret = 6;
            setUpGame(palyameret);

        }
        private void nagyPálya10X10ToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            cleanBoard();
            palyameret = 10;
            setUpGame(palyameret);
        }
        #endregion









        #region Új játék, játék betöltése, játék mentése, kilépés

        //uj jatek inditasa
        private void újJátékToolStripMenuItem1_Click(object sender, EventArgs e)
        {

            játékMentéseToolStripMenuItem.Enabled = true;

            if (model.getBoard() == null)
            {
                MessageBox.Show("Először indíts egy játékot a Játék indítása menüpontál!", "Hiba");
            }
            else
            {
                cleanBoard();
                labels();
            }

        }


        //jatek mentese

        private void játékMentéseToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (model.getBoard() == null)
            {
                MessageBox.Show("Először indíts el egy játékot, mielőtt mented.");
                return;
            }
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {

                    model.Save(saveFileDialog1.FileName, model.getCurrentPlayer());

                }
                catch (BekeritesDataException)
                {
                    MessageBox.Show("Játék mentése sikertelen!" + Environment.NewLine + "Hibás az elérési út, vagy a könyvtár nem írható.", "Hiba!", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }

            }
        }

        //letezo jatek betoltese
        private void játékBetöltéseToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {

                    cleanBoard();
                    Board board = model.Load(openFileDialog1.FileName);
                    model.getPlayerASave();
                    játékBetöltéseToolStripMenuItem.Enabled = true;
                    currentDirection = 0;
                    setUpBoard(board);
                    if (model.getCurrentPlayer() == 2)
                    {
                        label2.Text = "Játékos: Kék";
                    }
                    else label2.Text = "Játékos: Piros";
                    if (model.IsGameOver())
                    {
                        MessageBox.Show("Ennek a játéknak már vége van.");
                    }



                }
                catch (BekeritesDataException)
                {
                    MessageBox.Show("Játék betöltése sikertelen!" + Environment.NewLine + "Hibás az elérési út, vagy a fájlformátum.", "Hiba!", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    játékBetöltéseToolStripMenuItem.Enabled = true;
                }

            }
        }

        //kilépés
        private void kilépésToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("Biztosan ki szeretne lépni?", "Bekerítés", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

                Close();
            }
        }
        #endregion

        #region Oket nem tudtam kitorolni
        private void játékIndításaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

       
        private void újJátékToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        #endregion


    }

}
