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

namespace tiktok
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            TikTok.F2.ShowDialog();

            if (Form2.CloseTheApp == true)
                this.Close();

            label1.Text = TikTok.User1name;
            label3.Text = TikTok.User2name;


            CheckWhatModeIsOn();
        }

        #region AIMethods
        public void FindAvailableButtons()
        {
            foreach (Button btn in this.Controls.OfType<Button>().Where(x => x.Text == ""))
            {
                TikTok.List.Add(btn);
            }
        }

        //public void DisableAvailableButtons()
        //{
        //    foreach (Button btn in list)
        //    {
        //        btn.Enabled = false;
        //    }
        //}

        //public void EnableAvailableButtons() 
        //{
        //    foreach (Button btn in list)
        //    {
        //        btn.Enabled = true;
        //    }
        //}

        private void AIMove(object sender, EventArgs e)
        {
            FindAvailableButtons();

            if (!TikTok.HardMode)
            {
                int index = TikTok.Rand.Next(TikTok.List.Count);

                TikTok.List[index].PerformClick();
            }

            if (TikTok.HardMode)
            {
                Button move = null;

                move = SmartPCMove("O");
                if (move == null)
                {
                    move = SmartPCMove("X");
                    if (move == null)
                    {
                        move = look_for_corner();
                        if (move == null)
                        {
                            move = look_for_open_space();
                        }
                    }
                }

                move.PerformClick();
            }

            TikTok.List.Clear();
            timer1.Stop();
        }

        private Button SmartPCMove(string Player)
        {
            //horizontal
            if ((button1.Text == Player) && (button2.Text == Player) && (button3.Text == ""))
                return button3;

            if ((button2.Text == Player) && (button3.Text == Player) && (button1.Text == ""))
                return button1;

            if ((button1.Text == Player) && (button3.Text == Player) && (button2.Text == ""))
                return button2;


            if ((button4.Text == Player) && (button5.Text == Player) && (button6.Text == ""))
                return button6;

            if ((button5.Text == Player) && (button6.Text == Player) && (button4.Text == ""))
                return button4;

            if ((button4.Text == Player) && (button6.Text == Player) && (button5.Text == ""))
                return button5;


            if ((button7.Text == Player) && (button8.Text == Player) && (button9.Text == ""))
                return button9;

            if ((button8.Text == Player) && (button9.Text == Player) && (button7.Text == ""))
                return button7;

            if ((button7.Text == Player) && (button9.Text == Player) && (button8.Text == ""))
                return button8;

            //vertical
            if ((button1.Text == Player) && (button4.Text == Player) && (button7.Text == ""))
                return button7;

            if ((button4.Text == Player) && (button7.Text == Player) && (button1.Text == ""))
                return button1;

            if ((button1.Text == Player) && (button7.Text == Player) && (button4.Text == ""))
                return button4;


            if ((button2.Text == Player) && (button5.Text == Player) && (button7.Text == ""))
                return button7;

            if ((button5.Text == Player) && (button8.Text == Player) && (button2.Text == ""))
                return button2;

            if ((button2.Text == Player) && (button8.Text == Player) && (button5.Text == ""))
                return button5;


            if ((button3.Text == Player) && (button6.Text == Player) && (button9.Text == ""))
                return button9;

            if ((button6.Text == Player) && (button9.Text == Player) && (button3.Text == ""))
                return button3;

            if ((button3.Text == Player) && (button9.Text == Player) && (button6.Text == ""))
                return button6;

            //diagonal
            if ((button1.Text == Player) && (button5.Text == Player) && (button9.Text == ""))
                return button9;

            if ((button5.Text == Player) && (button9.Text == Player) && (button1.Text == ""))
                return button1;

            if ((button1.Text == Player) && (button9.Text == Player) && (button5.Text == ""))
                return button5;


            if ((button3.Text == Player) && (button5.Text == Player) && (button7.Text == ""))
                return button7;

            if ((button5.Text == Player) && (button7.Text == Player) && (button3.Text == ""))
                return button3;

            if ((button3.Text == Player) && (button7.Text == Player) && (button5.Text == ""))
                return button5;

            return null;
        }

        private Button look_for_corner()
        {

            if (button1.Text == TikTok.Player.O.ToString())
            {
                if (button3.Text == "")
                    return button3;
                if (button9.Text == "")
                    return button9;
                if (button7.Text == "")
                    return button7;
            }

            if (button3.Text == TikTok.Player.O.ToString())
            {
                if (button1.Text == "")
                    return button1;
                if (button9.Text == "")
                    return button9;
                if (button7.Text == "")
                    return button7;
            }

            if (button9.Text == TikTok.Player.O.ToString())
            {
                if (button1.Text == "")
                    return button3;
                if (button3.Text == "")
                    return button3;
                if (button7.Text == "")
                    return button7;
            }

            if (button7.Text == TikTok.Player.O.ToString())
            {
                if (button1.Text == "")
                    return button3;
                if (button3.Text == "")
                    return button3;
                if (button9.Text == "")
                    return button9;
            }

            if (button1.Text == "")
                return button1;
            if (button3.Text == "")
                return button3;
            if (button7.Text == "")
                return button7;
            if (button9.Text == "")
                return button9;

            return null;
        }

        private Button look_for_open_space()
        {
            Button b = null;
            foreach (Control c in Controls)
            {
                b = c as Button;
                if (b != null)
                {
                    if (b.Text == "")
                        return b;
                }
            }

            return null;
        }

        #endregion

        #region Buttons
        private void onButton_click(object sender, EventArgs e)
        {

            Button btn = (Button)sender;
            if (TikTok.Turn)
                btn.Text = TikTok.Player.X.ToString();
            else
                btn.Text = TikTok.Player.O.ToString();

            TikTok.Turn = !TikTok.Turn;

            btn.Enabled = false;

            TikTok.Count++;

            CheckAWinner();

            if (!TikTok.Turn && Form2.OnePlayerMode && TikTok.Count != 9)
                timer1.Start();



            label8.Focus();
        }

        private void button_enter(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (btn.Enabled)
            {
                if (TikTok.Turn)
                    btn.Text = TikTok.Player.X.ToString();
                else
                    btn.Text = TikTok.Player.O.ToString();
            }


        }

        private void button_leave(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (btn.Enabled)
            {
                btn.Text = "";
            }
        }
        #endregion

        #region ToolStripMenu
        private void resetCountsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ResetCounts();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Made by: Darko Josipović", "Tic tac toe game.");
        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewGame();
        }

        private void easyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TikTok.HardMode = false;
            CheckWhatModeIsOn();
        }

        private void hardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TikTok.HardMode = true;
            CheckWhatModeIsOn();
        }

        private void changePlayerNamesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TikTok.F2.ShowDialog();
            label7.Text = "";
            ResetCounts();
            if (TikTok.HardMode)
                TikTok.HardMode = false;

            label1.Text = TikTok.User1name;
            label3.Text = TikTok.User2name;


            CheckWhatModeIsOn();
        }
        #endregion

        public void CheckWhatModeIsOn()
        {
            if (!Form2.OnePlayerMode)
                changeDificultyToolStripMenuItem.Visible = false;

            if (Form2.OnePlayerMode)
            {
                changeDificultyToolStripMenuItem.Visible = true;

                if (TikTok.HardMode)
                {
                    label7.Text = "Hard mode on: " + TikTok.HardMode;
                }

                if (!TikTok.HardMode)
                {
                    label7.Text = "Hard mode on: " + TikTok.HardMode;
                }
            }
        }

        public static void SetPlayerNames(string s1, string s2 = "O")
        {
            TikTok.User1name = s1;
            TikTok.User2name = s2;
        }
      

        public void CheckAWinner()
        {

            TikTok.Win = false;

            //horizontal
            if ((button1.Text == button2.Text) && (button2.Text == button3.Text) && (!button1.Enabled))
            {
                TikTok.Win = true;
                button1.BackColor = button2.BackColor = button3.BackColor = Color.GreenYellow;
            }

            else if ((button4.Text == button5.Text) && (button5.Text == button6.Text) && (!button4.Enabled))
            {
                TikTok.Win = true;
                button4.BackColor = button5.BackColor = button6.BackColor = Color.GreenYellow;
            }

            else if ((button7.Text == button8.Text) && (button8.Text == button9.Text) && (!button7.Enabled))
            {
                TikTok.Win = true;
                button7.BackColor = button8.BackColor = button9.BackColor = Color.GreenYellow;
            }

            //vertical
            else if ((button1.Text == button4.Text) && (button4.Text == button7.Text) && (!button1.Enabled))
            {
                TikTok.Win = true;
                button1.BackColor = button4.BackColor = button7.BackColor = Color.GreenYellow;
            }

            else if ((button2.Text == button5.Text) && (button5.Text == button8.Text) && (!button2.Enabled))
            {
                TikTok.Win = true;
                button2.BackColor = button5.BackColor = button8.BackColor = Color.GreenYellow;
            }

            else if ((button3.Text == button6.Text) && (button6.Text == button9.Text) && (!button3.Enabled))
            {
                TikTok.Win = true;
                button3.BackColor = button6.BackColor = button9.BackColor = Color.GreenYellow;
            }


            //diagonal
            else if ((button1.Text == button5.Text) && (button5.Text == button9.Text) && (!button1.Enabled))
            {
                TikTok.Win = true;
                button1.BackColor = button5.BackColor = button9.BackColor = Color.GreenYellow;
            }

            else if ((button3.Text == button5.Text) && (button5.Text == button7.Text) && (!button7.Enabled))
            {
                TikTok.Win = true;
                button3.BackColor = button5.BackColor = button7.BackColor = Color.GreenYellow;
            }

            if (TikTok.Win || TikTok.Count == 9)
            {

                disableButtons();

                if (TikTok.Count == 9 && !TikTok.Win) 
                {
                    foreach (Button btn in this.Controls.OfType<Button>())
                    {
                        if (btn.Text.Equals("X"))
                            btn.BackColor = Color.AliceBlue;
                        else
                            btn.BackColor = Color.BlueViolet;
                    }
                }

                if (!TikTok.Turn && TikTok.Win)
                    label2.Text = (Int32.Parse(label2.Text) + 1).ToString();

                if (TikTok.Turn && TikTok.Win)
                    label4.Text = (Int32.Parse(label4.Text) + 1).ToString();

                if (TikTok.Count == 9 && !TikTok.Win)
                    label6.Text = (Int32.Parse(label6.Text) + 1).ToString();

                string title = TikTok.Turn ? TikTok.User2name + " is a winner!" : TikTok.Count == 9 ? "It's a draw!" : TikTok.User1name + " is a winner!";


                TikTok.Result = MessageBox.Show("Awesome! Would you like to play a new game?", title, TikTok.DialogButtons, MessageBoxIcon.Question);

                if (TikTok.Result == DialogResult.No)
                {
                    this.Close();
                }

                if (TikTok.Result == DialogResult.Yes)
                {
                    NewGame();
                }

            }

        }

        public void disableButtons()
        {
            foreach (Button btn in this.Controls.OfType<Button>())
            {
                btn.Enabled = false;
            }
        }

        public void ResetCounts()
        {
            label2.Text = "0";
            label4.Text = "0";
            label6.Text = "0";
        }
      

        public void NewGame()
        {
            TikTok.Turn = true;
            TikTok.Count = 0;
            foreach (Button btn in this.Controls.OfType<Button>())
            {
                btn.Enabled = true;
                btn.Text = "";
                btn.BackColor = SystemColors.ControlLight;
            }
        }

    }
}
