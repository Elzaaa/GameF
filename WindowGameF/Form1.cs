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
        }
        void ShowDigitAt(int digit, int x, int y)
        {
            Button button = (Button)Controls["btn" + x + y]; //выбор кнопки
            button.Text = digit.ToString();
            button.Visible = digit > 0;
        }
    }
}
