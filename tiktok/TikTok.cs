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
        public static bool turn = true;

        public static int count = 0;

        public static MessageBoxButtons DialogButtons = MessageBoxButtons.YesNo;

        public static DialogResult result;

        public static bool win = false;

        public static string user1name, user2name;

        public static bool HardMode = false;

        public static Random rand = new Random();

        public static Form2 f2 = new Form2();

        public static List<Button> list = new List<Button>();
        public enum Player
        {
            X, O
        }
    }
}
