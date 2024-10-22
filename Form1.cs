using System.Windows.Forms;

namespace tic_tac_2
{
    public partial class Form1 : Form
    {
        private tictac t; // Instance of the custom Tic-Tac-Toe control

        public Form1()
        {
            InitializeComponent();
            t = new tictac(); // Initialize the custom control
            t.Visible = true; // Make sure the Tic-Tac-Toe control is visible
            this.Controls.Add(t); // Add the control to the form's control collection
        }
    }
}
