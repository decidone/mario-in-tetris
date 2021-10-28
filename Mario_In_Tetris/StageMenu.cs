using Mario_In_Tetris.Resource;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mario_In_Tetris
{
    public partial class StageMenu : Form
    {
        public StageMenu()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (IsClear.STAGE1 == false)
                Stage1.Image = StageButton.stage1;
            else
                Stage1.Image = StageButton.stage1_clear;

            if (IsClear.STAGE2 == false)
                Stage2.Image = StageButton.stage2;
            else
                Stage2.Image = StageButton.stage2_clear;

            if (IsClear.STAGE3 == false)
                Stage3.Image = StageButton.stage3;
            else
                Stage3.Image = StageButton.stage3_clear;

            if (IsClear.STAGE4 == false)
                Stage4.Image = StageButton.stage4;
            else
                Stage4.Image = StageButton.stage4_clear;

            if (IsClear.STAGE5 == false)
                Stage5.Image = StageButton.stage5;
            else
                Stage5.Image = StageButton.stage5_clear;

        }

        private void Stage1_Click(object sender, EventArgs e)
        {
            new Stage1().Show();
        }

        private void Stage2_Click(object sender, EventArgs e)
        {
            new Stage2().Show();
        }

        private void Stage3_Click(object sender, EventArgs e)
        {
            new Stage3().Show();
        }

        private void Stage4_Click(object sender, EventArgs e)
        {
            new Stage4().Show();
        }

        private void Stage5_Click(object sender, EventArgs e)
        {
            new Stage5().Show();
        }
    }
}
