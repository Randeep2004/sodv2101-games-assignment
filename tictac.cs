using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tic_tac_2
{
    public partial class tictac : UserControl
    {
        bool player1 = true; // true for Player 1 (X), false for Player 2 (O)
        Button[,] button = new Button[3, 3]; // 3x3 grid of buttons for the game
        int w1 = 0; // Player 1 win count
        int w2 = 0; // Player 2 win count

        public tictac()
        {
            InitializeComponent();
            // Map UI buttons to the 2D array
            button[0, 0] = button1;
            button[0, 1] = button2;
            button[0, 2] = button3;
            button[1, 0] = button4;
            button[1, 1] = button5;
            button[1, 2] = button6;
            button[2, 0] = button7;
            button[2, 1] = button8;
            button[2, 2] = button9;
        }

        private bool checkWin()
        {
            // Check rows and columns for a win
            for (int i = 0; i < 3; i++)
            {
                if (button[i, 0].Text == button[i, 1].Text && button[i, 1].Text == button[i, 2].Text && button[i, 0].Text != "")
                    return true;
                if (button[0, i].Text == button[1, i].Text && button[1, i].Text == button[2, i].Text && button[0, i].Text != "")
                    return true;
            }
            // Check diagonals
            if (button[0, 0].Text == button[1, 1].Text && button[1, 1].Text == button[2, 2].Text && button[0, 0].Text != "")
                return true;
            if (button[0, 2].Text == button[1, 1].Text && button[1, 1].Text == button[2, 0].Text && button[0, 2].Text != "")
                return true;

            return false;
        }

        private void resetBoard()
        {
            // Clear all buttons and reset turn to Player 1
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                {
                    button[i, j].Text = "";
                    button[i, j].Enabled = true;
                }

            player1 = true;
            turn.Text = "Player: X";
        }

        private void b_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            b.Text = player1 ? "X" : "O";
            player1 = !player1;
            turn.Text = player1 ? "Player: X" : "Player: O";
            b.Enabled = false;

            if (checkWin())
            {
                if (!player1)
                {
                    MessageBox.Show("Winner Player 1 (X)");
                    w1++;
                    win1.Text = $"{w1}";
                }
                else
                {
                    MessageBox.Show("Winner Player 2 (O)");
                    w2++;
                    win2.Text = $"{w2}";
                }

                if (MessageBox.Show("Play again?", "Restart", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    resetBoard();
                else
                    this.FindForm().Close();
            }
            else if (button.Cast<Button>().All(b => !b.Enabled))
            {
                MessageBox.Show("It's a draw!");
                resetBoard();
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            resetBoard();
        }
    }
}
