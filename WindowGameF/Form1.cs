using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GameF;

namespace WindowGameF
{
    public partial class FormGameF : Form
    {
        const int size = 4; 
        Game game;
        public FormGameF()
        {
            InitializeComponent();
            game = new Game(size);
            HideButtons();
        }

        private void btn00_Click(object sender, EventArgs e)
        {
            if (game.Solved()) return; //если игра решена кнопки не нажимаются 
            Button button = (Button)sender; //btn00
            int x = int.Parse(button.Name.Substring(3, 1));
            int y = int.Parse(button.Name.Substring(4, 1));
            game.PressAt(x, y);
            ShowButtons();
            if (game.Solved())
            {
                labStep.Text = "Game finished in " + game.moves + " moves";
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            game.Start(10);
            ShowButtons();
        }
        void HideButtons()
        {
            for (int x = 0; x < size; x++)
            {
                for (int y = 0; y < size; y++)
                {
                    ShowDigitAt(0, x, y);
                }
            }
        }

        void ShowButtons()
        {
            for (int x = 0; x < size; x++)
            {
                for (int y = 0; y < size; y++)
                {
                    ShowDigitAt(game.GetDigitAt(x, y), x, y);
                }
            }
            labStep.Text = "Number of steps: " + game.moves;
        }

        void ShowDigitAt(int digit, int x, int y)
        {
            Button button = (Button)Controls["btn" + x + y]; //выбор кнопки
            button.Text = digit.ToString();
            button.Visible = digit > 0;
        }

        private void FormGameF_Load(object sender, EventArgs e)
        {

        }
    }
}
