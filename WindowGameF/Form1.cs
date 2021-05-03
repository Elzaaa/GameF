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

        public int iCountDownSec = 60;
        public int iCountDownMin = 9;// Seconds
        public bool bTimeEnd = false;
        public bool bAttempt = false;
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
        private void btnStart_Click(object sender, EventArgs e)
        {
            StartGame();
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
        public void Timer()
        {
            _timer = new Timer();
            _timer.Tick += new EventHandler(timer1_Tick);
            _timer.Interval = 1000;
        }  
        public void StartGame()
        {
            iCountDownMin = 9;
            iCountDownSec = 60;
            bAttempt = false;
            _timer.Start();
            game.Start(10);
            ShowButtons();
        }
        public void EndGame()
        {
            _timer.Stop();
            labStep.Text = "Game was end";
            HideButtons();
        }

        public void TimeWasEnd()
        {
            labStep.Text = "Time was end";
            if (!bAttempt) // 1 попытка
            {
                bAttempt = true;
                game.Shuffle(11);
                ShowButtons();
                iCountDownMin = 4;
                iCountDownSec = 60;
                labStep.Text = "Try again";
            }
            if (iCountDownMin == 0 && iCountDownSec == 0) // вермя вышло
            {
                EndGame();
            }
        }

        private void btnEnd_Click(object sender, EventArgs e)
        {
            EndGame();
        }
       
        private void timer1_Tick(object sender, EventArgs e)
        {
            
            if(!(iCountDownMin == 0 && iCountDownSec == 0))
            {
                iCountDownSec--;   
            }
            else //время вышло
            {
                TimeWasEnd();
            }
            if (iCountDownSec < 1 && iCountDownMin > 0) //- минута
            {
                iCountDownMin--;
                iCountDownSec = 59;
            }
            labTimer.Text = iCountDownMin.ToString() + " : " + iCountDownSec.ToString();
        }
    }
}
