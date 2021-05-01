using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tiktok
{
    public static class TikTok
    {
        public static bool Turn = true;

        public static int Count = 0;

        public static MessageBoxButtons DialogButtons = MessageBoxButtons.YesNo;

        public static DialogResult Result;

        public static bool Win = false;

        public static string User1name, User2name;

        public static bool HardMode = false;

        public static Random Rand = new Random();

        public static Form2 F2 = new Form2();

        public static List<Button> List = new List<Button>();
        public enum Player
        {
            X, O
        }
    }
}
