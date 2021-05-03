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

        public int _countDownSec = 60;
        public int _countDownMin = 9;// Seconds
        private Timer _timer;
        public FormGameF()
        {
            InitializeComponent();
            game = new Game(size);
            HideButtons();
            Timer();
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
                _timer.Stop();
                labStep.Text = "Game finished in " + game.moves + " moves";
            }
        }
        public void Timer ()
        {
            _timer = new Timer();
            _timer.Tick += new EventHandler(timer1_Tick);
            _timer.Interval = 1000;
           
        }
        private void btnStart_Click(object sender, EventArgs e)
        {
            _countDownSec= 60;
            _countDownMin = 9;
            _timer.Start();
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

        private void btnEnd_Click(object sender, EventArgs e)
        {
            _timer.Stop();
            labStep.Text = "Game was end";
            HideButtons();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            labTimer.Text = _countDownMin + ":" + _countDownSec;
            for (; _countDownMin > 0; _countDownMin--)
            {
                labTimer.Text = _countDownMin + ":" + _countDownSec;
                for (; _countDownSec > 0; _countDownSec--)
                {
                    labTimer.Text = _countDownMin + ":" + _countDownSec;
                    if (_countDownSec < 1)
                    {
                        labTimer.Text = _countDownMin.ToString() + ":" + _countDownSec.ToString();
                        _countDownSec = 60;
                    }
                }
            }
        }
    }
}
