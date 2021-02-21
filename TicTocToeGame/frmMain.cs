using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTocToeGame
{
    public partial class frmMain : Form
    {
        bool isPlayer1;

        TextsInButtons txtBTN = new TextsInButtons();

        List<string> listOfButtonTexts = new List<string>();
        int senderIndex;
        List<Button> allButtons;

        int filledButtons;

        public frmMain()
        {
            InitializeComponent();

        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            allButtons = tlpGame.Controls.OfType<Button>().OrderBy(x => x.Name).ToList();
            foreach (Button btn in allButtons)
            {
                listOfButtonTexts.Add(btn.Text);
            }
        }
        //Add text
        private void button_Click(object sender, MouseEventArgs e)
        {
            Button Sender = (Button)sender;
            senderIndex = int.Parse(Sender.Name.Remove(0, 3).ToString());
            if (Sender.Text == " ")
            {
                if (isPlayer1)
                {
                    Sender.Text = txtBTN.Cross.text;
                    Sender.ForeColor = txtBTN.Cross.foreColor;
                    Sender.BackColor = txtBTN.Cross.backColor;
                }
                else
                {
                    Sender.Text = txtBTN.Nought.text;
                    Sender.ForeColor = txtBTN.Nought.foreColor;
                    Sender.BackColor = txtBTN.Nought.backColor;
                }
                listOfButtonTexts[senderIndex] = Sender.Text;
                filledButtons++;
                checkTheWinner();
                isPlayer1 = !isPlayer1;
            }

        }
        //Remove text
        private void button_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Button Sender = (Button)sender;
                erase(Sender);
                isPlayer1 = !isPlayer1;
            }
        }

        private void checkTheWinner()
        {
            //Chcek for horizontal wins
            for (int i = 0; i < 3; i++)
            {
                if (listOfButtonTexts[0 + (i * 3)] != " " &&
                    listOfButtonTexts[1 + (i * 3)] == listOfButtonTexts[0 + (i * 3)] &&
                    listOfButtonTexts[2 + (i * 3)] == listOfButtonTexts[0 + (i * 3)])
                {
                    endOfTheGame();
                    return;
                }
            }
            //Chcek for horizontal wins
            for (int i = 0; i < 3; i++)
            {
                if (listOfButtonTexts[i + 0] != " " &&
                    listOfButtonTexts[i + 3] == listOfButtonTexts[i + 0] &&
                    listOfButtonTexts[i + 6] == listOfButtonTexts[i + 0])
                {
                    endOfTheGame();
                    return;
                }
            }
            //Chcek for diagonal wins
            for (int i = 2; i < 5; i = i + 2)
            {
                if (listOfButtonTexts[4 - i] != " " &&
                    listOfButtonTexts[4] == listOfButtonTexts[4 - i] &&
                    listOfButtonTexts[4 + i] == listOfButtonTexts[4 - i])
                {
                    endOfTheGame();
                    return;
                }
            }
            // Check that all of the buttons are filled or not
            if (filledButtons != listOfButtonTexts.Count)
                return;

            //There is no winner
            if (MessageBox.Show("Do you want to play the game again?", "There is no winner", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                foreach (Button btn in allButtons)
                {
                    erase(btn);
                }
                for (int i = 0; i < listOfButtonTexts.Count; i++)
                {
                    listOfButtonTexts[i] = txtBTN.Free.text;
                }
            }
            else
            {
                Application.Exit();
            }
        }

        private void endOfTheGame()
        {
            string winnerPlayer = "Player " + ((isPlayer1) ? "1" : "2");
            if (MessageBox.Show($"Winner player is {winnerPlayer}\nDo you want to playe game again?", "Game ended", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                foreach (Button btn in allButtons)
                {
                    erase(btn);
                }
                for (int i = 0; i < listOfButtonTexts.Count; i++)
                {
                    listOfButtonTexts[i] = txtBTN.Free.text;
                }
            }
            else
            {
                Application.Exit();
            }
        }

        private void erase(Button Sender)
        {
            filledButtons--;
            Sender.Text = txtBTN.Free.text;
            Sender.ForeColor = txtBTN.Free.foreColor;
            Sender.BackColor = txtBTN.Free.backColor;
        }
    }
}
