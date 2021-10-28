using Mario_In_Tetris.Resource;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Media;
using System.Threading;
using System.Windows.Forms;

namespace Mario_In_Tetris
{
    public partial class Stage2 : Form
    {
        SoundPlayer Song = new SoundPlayer();
        SoundPlayer ClearSound = new SoundPlayer();
        public static List<PictureBox> Blocks = new List<PictureBox>();
        Player pr;
        bool mariostart;
        bool playingTetris;
        bool gameStart;

        // 보드의 가로세로
        private static int col = 6;
        private static int row = 15;
        Board board = new Board(row, col);

        public Stage2()
        {
            InitializeComponent();
            this.ClearSound.Stream = Sound.enterPipe;
            pr = new Player();
            pr.character = Mario;

            //만일 테트리스객체를 PictureBox로 변환시키는데 성공하면 해당 객체를 모두 Block에 순서대로 삽입
            Blocks.Add(Block1);
            Blocks.Add(Block2);
            Blocks.Add(Block3);
            Blocks.Add(Escape);
            pr.Blocks = Blocks;

            //마리오 스타트(테트리스가 끝났을시 true로 전환)
            TetrisTimer.Enabled = false;
            MarioTimer.Enabled = false;
            mariostart = false;
            playingTetris = true;
            gameStart = false;
            KeyPreview = true;

            //테트리스
            //0 - 1자, 1 - z, 2 - 반대z, 3 - T자, 4 - 오른쪽L, 5 - 왼쪽L, 6 - 사각형
            board.blockCount = 6;           //스테이지에 주어진 블록 수 설정
            board.setBlock("1 1 1 3 3 4");    //스테이지에 주어진 블록 모양 설정
            btnGameStart.Click += btnGameStart_Click;
            
        }
        
        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (mariostart)
            {
                pr.KeyUp(sender, e);
            }
        }

        private void MarioTimer_Tick(object sender, EventArgs e)
        {
            if (mariostart)
            {
                pr.TimerTickAction(sender, e, MapSize);
            }
        }

        private void TetrisTimer_Tick(object sender, EventArgs e)
        {
            if (playingTetris)
            {
                if (!board.running())
                {
                    playingTetris = false;
                    TetrisTimer.Enabled = false;
                    MarioTimer.Enabled = true;
                    mariostart = true;
                    Blocks = board.makeObj(Blocks, Tetris);    //테트리스 블럭 자리에 이미지박스를 만듬
                }
            }
            BoardImg();
            NextBlock.BackgroundImage = board.nextbitImg(16, 4, 20);
            if (!playingTetris)
            {
                BoardImg(true);
            }
        }

        //보드 이미지 변경
        private void BoardImg(bool isEnd = false)
        {
            if (isEnd)
            {
                Tetris.BackgroundImage = board.bitImg(true);
            }
            if (!isEnd)
            {
                Tetris.BackgroundImage = board.bitImg();
            }
        }

        private void OnKeyDownHandler(object sender, KeyEventArgs e)
        {
            //테트리스
            if (playingTetris && gameStart)    //테트리스 일 때
            {
                board.KeyDown(sender, e);
                BoardImg();
            }

            //마리오
            if (mariostart)
            {
                pr.KeyDown(sender, e);
            }

            //클리어조건
            if (e.KeyCode == Keys.Down && pr.IsArriveEscapeTop(Mario, Escape))
            {
                mariostart = false;
                pr.character.Left = Escape.Left + Mario.Width;
                this.ClearSound.Play();
                while (pr.character.Top <= Escape.Top)
                {
                    pr.character.Top += 1;
                    Thread.Sleep(10);
                }
                MessageBox.Show("클리어!");
                IsClear.STAGE2 = true;
                this.Song.Stop();
                this.Close();
            }

            
        }

        //게임시작 버튼 클릭
        private void btnGameStart_Click(object sender, EventArgs e)
        {
            TetrisTimer.Enabled = true;
            gameStart = true;
        }

        //리셋버튼
        private void ResetButton_Click(object sender, EventArgs e)
        {

            TetrisTimer.Enabled = false;
            MarioTimer.Enabled = false;
            mariostart = false;
            playingTetris = true;
            gameStart = false;

            pr.character.Left = 149;
            pr.character.Top = 496;
            board.resetButton();    //보드 리셋

            Blocks.Clear(); //리스트에 넣은 텍스트박스들 초기화
            Blocks.Add(Block1);
            Blocks.Add(Block2);
            Blocks.Add(Block3);
            Blocks.Add(Escape);

            BoardImg(true); //보드 이미지 초기화
            NextBlock.BackgroundImage = board.nextbitImg(16, 4, 20);    //다음블록 이미지 초기화
        }

    }
}
