namespace CheckerBoard
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            createCheckBoardButton();
        }

        private void createCheckBoardButton()
        {
            Button[,] ourButtons = new Button[8, 8];
            this.Width = 400;
            this.Height = 400;
            int top = 0;
            int left = 15;
            for (int i = 0; i < ourButtons.GetUpperBound(0); i++)
            {
                for (int j = 0; j < ourButtons.GetUpperBound(1); j++)
                {
                    ourButtons[i, j] = new Button();
                    ourButtons[i, j].Width = 50;
                    ourButtons[i, j].Height = 50;
                    ourButtons[i, j].Left = left;
                    ourButtons[i, j].Top = top;
                    left += 50;
                    this.Controls.Add(ourButtons[i, j]);
                    if ((i + j) % 2 == 0)
                    {
                        ourButtons[i, j].BackColor = Color.Brown;
                    }
                }

                left = 15;
                top += 50;
            }
        }
    }
}