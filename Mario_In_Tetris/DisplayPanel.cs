using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mario_In_Tetris
{
    public partial class DisplayPanel : Panel
    {
        public DisplayPanel()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
        }
    }
}
