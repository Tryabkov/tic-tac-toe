using System.Drawing.Printing;

namespace tic_tac_toe
{
    public partial class Form1 : Form
    {
        #region Sizes
        const int BUTTON_WIDTH = 120;
        const int BUTTON_HEIGHT = 120;
        #endregion

        private Button[,] buttonArray = new Button[3, 3]; //creating field 
        private string side = "X";

        private void CreateButtons()
        {
            for (int i = 0; i < buttonArray.GetLength(0); i++)
            {
                for (int j = 0; j < buttonArray.GetLength(1); j++)
                {
                    buttonArray[i, j] = new Button();
                    buttonArray[i, j].Size = new Size(BUTTON_WIDTH, BUTTON_HEIGHT);
                    buttonArray[i, j].Location = new Point(j * BUTTON_WIDTH, 20 + (i * BUTTON_HEIGHT));
                    buttonArray[i, j].Click += new EventHandler(Button_Click);
                    buttonArray[i, j].Font = new Font("Segoe UI", 30, FontStyle.Bold);
                    this.Controls.Add(buttonArray[i, j]); //creating buttons
                }
            }
        }

        public Form1()
        {
            CreateButtons();
            InitializeComponent();
            this.label1.Text = "Current move: X";
        }

        private void Button_Click(object sender, EventArgs e)
        {
            //bounds.location
            if (((Button)sender).Text == "")
            {
                ((Button)sender).Text = side;//sets symbol
                side = side == "X" ? "O" : "X";//change side
                this.label1.Text = "Current move: " + side;
            }
            IsSBWin();//win check
        }

        private void ClearField()
        {
            for (int i = 0; i < buttonArray.GetLength(0); i++)
            {
                for (int j = 0; j < buttonArray.GetLength(1); j++)
                {
                    buttonArray[i, j].Text = "";
                }
            }
        }

        private bool IsFull()//check is field is full
        {
            foreach (var item in buttonArray)
            {
                if (item.Text == "")
                {
                    return false;
                }
            }
            return true;
        }

        private void IsSBWin()
        {
            if (((buttonArray[0, 0].Text == "X") && (buttonArray[0, 1].Text == "X") && (buttonArray[0, 2].Text == "X")) ||
                ((buttonArray[1, 0].Text == "X") && (buttonArray[1, 1].Text == "X") && (buttonArray[1, 2].Text == "X")) ||
                ((buttonArray[2, 0].Text == "X") && (buttonArray[2, 1].Text == "X") && (buttonArray[2, 2].Text == "X")) ||

                ((buttonArray[0, 0].Text == "X") && (buttonArray[1, 0].Text == "X") && (buttonArray[2, 0].Text == "X")) ||
                ((buttonArray[0, 1].Text == "X") && (buttonArray[1, 1].Text == "X") && (buttonArray[2, 1].Text == "X")) ||
                ((buttonArray[0, 2].Text == "X") && (buttonArray[1, 2].Text == "X") && (buttonArray[2, 2].Text == "X")) ||

                ((buttonArray[0, 0].Text == "X") && (buttonArray[1, 1].Text == "X") && (buttonArray[2, 2].Text == "X")) ||
                ((buttonArray[0, 2].Text == "X") && (buttonArray[1, 1].Text == "X") && (buttonArray[2, 0].Text == "X")))
            {
                MessageBox.Show("X is win!");
                ClearField();
                this.label1.Text = "Current move: X";
            }

            if (((buttonArray[0, 0].Text == "O") && (buttonArray[0, 1].Text == "O") && (buttonArray[0, 2].Text == "O")) ||
                ((buttonArray[1, 0].Text == "O") && (buttonArray[1, 1].Text == "O") && (buttonArray[1, 2].Text == "O")) ||
                ((buttonArray[2, 0].Text == "O") && (buttonArray[2, 1].Text == "O") && (buttonArray[2, 2].Text == "O")) ||

                ((buttonArray[0, 0].Text == "O") && (buttonArray[1, 0].Text == "O") && (buttonArray[2, 0].Text == "O")) ||
                ((buttonArray[0, 1].Text == "O") && (buttonArray[1, 1].Text == "O") && (buttonArray[2, 1].Text == "O")) ||
                ((buttonArray[0, 2].Text == "O") && (buttonArray[1, 2].Text == "O") && (buttonArray[2, 2].Text == "O")) ||

                ((buttonArray[0, 0].Text == "O") && (buttonArray[1, 1].Text == "O") && (buttonArray[2, 2].Text == "O")) ||
                ((buttonArray[0, 2].Text == "O") && (buttonArray[1, 1].Text == "O") && (buttonArray[2, 0].Text == "O")))
            {
                MessageBox.Show("O is win!");
                ClearField();
                this.label1.Text = "Current move: X";
            }

            if (IsFull()) { MessageBox.Show("Nobody win"); ClearField(); this.label1.Text = "Current move: X"; }
        }
    }
}