using Mario_In_Tetris.Resource;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mario_In_Tetris
{
    //테트리스 보드
    class Board
    {
        public static int Row;
        public static int Col;
        public int blockCount { get; set; }   //주어진 블럭 개수
        public int count { get; set; }

        public Queue<int> blockNumList = new Queue<int>(); //주어진 블록을 순서대로 넣는 큐
        public int blockNum { get; set; }
        public int[,] grid;
        public int[,] nextBlockGrid = new int[4, 16];
        public List<int> blockStorage = new List<int>();
        public bool isFull { get; set; }
        public Block block;
        public Location2D location;

        public Board()
        {
            this.isFull = false;
            this.block = new Block();
            this.location = new Location2D(0, 0);
            this.count = 0;     //블럭 개수 카운트
            this.blockNum = 0;
        }

        public Board(int row, int col)
        {
            Row = row;
            Col = col;
            this.grid = new int[row, col];
            this.isFull = false;
            this.block = new Block();
            this.location = new Location2D(0, 0);
            this.count = 0;     //블럭 개수 카운트
            this.blockNum = 0;
        }

        public void resetButton()
        {
            count = 0;
            blockNum = 0;
            block.selectedBlock = null;
            ResetGrid();
            ClearNextGrid();
        }


        public void setBlock(string line)   //블럭 번호를 받음
        {
            string[] words = line.Split(' ');
            for (int i = 0; i < words.Length; i++)
            {
                blockStorage.Add(Convert.ToInt32(words[i]));
            }
        }

        public bool running() //여기 메소드 구현부터 시작
        {
            if (count <= blockCount && block.selectedBlock == null || count <= blockCount && !this.CanDrop())
            {
                if (count == blockCount)
                {
                    count++;
                }
                else
                {
                    //다음블럭 표시
                    ClearNextGrid();
                    for (int i = 1; i <= 4; i++)
                    {
                        if (blockNum + i < blockCount)
                        {
                            int a = blockStorage[blockNum + i];
                            block.ShowNextBlock(a);
                            if (i > 1)
                            {
                                block.x = block.x + 4*(i-1);
                            }
                            InsertInNextGrid();
                        }
                    }
                    //if(blockNum == blockCount)
                    int b = blockStorage[blockNum];
                    block.GetNextBlock(b);
                    blockNum++;
                    count++;
                }
                CheckAndRemove();   //한줄이 완성되었는지 확인하고 제거 및 빈줄 채움
            }
            
            if (count > blockCount)
            {
                return false;
            }
            this.DropBlock();       //블럭을 한칸 아래로

            return true;
        }

        public void CheckAndRemove()   //줄이 완성되었는지 확인하고 제거, 채움
        {
            for (int row = 0; row < Row; row++)
            {
                if (this.CheckFullRow(row))
                {
                    this.RemoveRow(row);
                }
            }
        }

        private bool CheckFullRow(int row)  //줄이 완성되었는지 확인
        {
            for (int col = 0; col < Col; col++)
            {
                if (this.grid[row, col] == 0)
                {
                    return false;
                }
            }
            return true;
        }

        private void RemoveRow(int thisRow) //완성된 줄을 지우고 위 줄을 끌어당겨 채움
        {
            for (int row = thisRow; row > 0; row--)
            {
                for (int col = 0; col < Col; col++)
                {
                    if (row - 1 <= 0)
                    {
                        this.grid[row, col] = 0;
                    }
                    else
                    {
                        this.grid[row, col] = this.grid[row - 1, col];
                    }
                }
            }
        }

        public void DropBlock()    //배열 내용 이동하는것도 추가
        {
            if (this.CanDrop())
            {
                ClearGrid();
                this.block.y++;
                InsertInGrid();
            }
        }

        private bool CanDrop()  //블럭이 아래로 이동할 수 있는지 검사
        {
            bool canDrop = true;
            ClearGrid();

            Block blockIf = block.Clone();
            blockIf.y++;

            if (!CanMove(blockIf))
            {
                canDrop = false;
            }

            InsertInGrid();

            return canDrop;
        }

        private void InsertInGrid() //받아온 블럭을 그리드 안으로
        {
            if (block.selectedBlock != null)
            {
                Location2D c = null;

                for (int row = 0; row < 4; row++)
                {
                    for (int col = 0; col < 4; col++)
                    {
                        if (block.selectedBlock[row, col] != 0)
                        {
                            c = block.GetLocation(new Location2D(col, row));
                            this.grid[c.y, c.x] = block.selectedBlock[row, col];
                        }
                    }
                }
            }
        }

        private void ClearGrid()    //이동 가능 검사 전에 그리드에서 블럭을 지움
        {
            if (block.selectedBlock != null)
            {
                Location2D c = null;

                for (int row = 0; row < 4; row++)
                {
                    for (int col = 0; col < 4; col++)
                    {
                        if (block.selectedBlock[row, col] != 0)
                        {
                            c = block.GetLocation(new Location2D(col, row));
                            this.grid[c.y, c.x] = 0;
                        }
                    }
                }
            }
        }

        private bool CanMove(Block selBlock)    //이동했을 경우 겹치는 부분이 있는지 검사
        {
            Location2D c = null;

            for (int row = 0; row < 4; row++)
            {
                for (int col = 0; col < 4; col++)
                {
                    if (selBlock.selectedBlock[row, col] != 0)
                    {
                        c = selBlock.GetLocation(new Location2D(col, row));
                        if (IsVaild(c) || c.x >= Col || c.x < 0 || c.y >= Row)
                        {
                            return false;
                        }
                    }
                }
            }
            return true;
        }

        private bool IsVaild(Location2D c)  //그리드 밖으로 나온 부분이 있는지 검사
        {
            if (c.x < Col && c.x >= 0 && c.y < Row && c.y >= 0 && this.grid[c.y, c.x] == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public void MoveLeft()  //왼쪽으로 이동
        {
            if (this.CanMoveLeft())
            {
                ClearGrid();
                this.block.x--;
                InsertInGrid();
            }
        }

        private bool CanMoveLeft()  //왼쪽으로 이동할 수 있는지 검사
        {
            bool canMoveLeft = true;
            ClearGrid();

            Block blockIf = block.Clone();
            blockIf.x--;

            if (!CanMove(blockIf))
            {
                canMoveLeft = false;
            }

            InsertInGrid();

            return canMoveLeft;
        }

        public void MoveRight()  //오른쪽으로 이동
        {
            if (this.CanMoveRight())
            {
                ClearGrid();
                this.block.x++;
                InsertInGrid();
            }
        }

        private bool CanMoveRight()  //오른쪽으로 이동할 수 있는지 검사
        {
            bool canMoveRight = true;
            ClearGrid();

            Block blockIf = block.Clone();
            blockIf.x++;

            if (!CanMove(blockIf))
            {
                canMoveRight = false;
            }

            InsertInGrid();

            return canMoveRight;
        }

        public void Rotate()  //시계방향으로 회전
        {
            if (this.CanRotate())
            {
                ClearGrid();
                this.block.RotateBlock();
                InsertInGrid();
            }
        }

        private bool CanRotate()  //시계방향으로 회전할 수 있는지 검사
        {
            bool canRotate = true;
            ClearGrid();

            Block blockIf = block.Clone();
            blockIf.RotateBlock();

            if (!CanMove(blockIf))
            {
                canRotate = false;
            }
            InsertInGrid();

            return canRotate;
        }

        public void ReverseRotate()  //반시계방향으로 회전
        {
            if (this.CanReverseRotate())
            {
                ClearGrid();
                this.block.ReverseRotateBlock();
                InsertInGrid();
            }
        }

        private bool CanReverseRotate()  //반시계방향으로 회전할 수 있는지 검사
        {
            bool canReverseRotate = true;
            ClearGrid();

            Block blockIf = block.Clone();
            blockIf.ReverseRotateBlock();

            if (!CanMove(blockIf))
            {
                canReverseRotate = false;
            }

            InsertInGrid();

            return canReverseRotate;
        }

        public Bitmap bitImg(bool isEnd = false)    //배열의 내용을 디스플레이 패널에 그림
        {
            Bitmap b = new Bitmap(Col * 30 + 30, Row * 30 + 30);

            SolidBrush white = new SolidBrush(Color.White);
            SolidBrush black = new SolidBrush(Color.Black);
            SolidBrush red = new SolidBrush(Color.Red);
            SolidBrush green = new SolidBrush(Color.Green);
            SolidBrush blue = new SolidBrush(Color.Blue);
            SolidBrush pink = new SolidBrush(Color.Pink);
            SolidBrush purple = new SolidBrush(Color.Purple);
            SolidBrush yellowgreen = new SolidBrush(Color.YellowGreen);
            SolidBrush backcolor = new SolidBrush(Color.FromArgb(153,180,209));

            Image Blue = TetrisImage.blue;
            Image Gold = TetrisImage.gold;
            Image Green = TetrisImage.green;
            Image Purple = TetrisImage.purple;
            Image Red = TetrisImage.red;
            Image Skyblue = TetrisImage.skyblue;
            Image Yellow = TetrisImage.yellow;
            Image Back = TetrisImage.back;
            Image Backline = TetrisImage.backline;
            Image Wall = TetrisImage.wall;


            //formGraphics.DrawLine(Pens.Black, 50, 50, 70, 50);

            using (Graphics g = Graphics.FromImage(b))
            {
                for (int i = 0; i < Row; i++)
                {
                    for (int j = 0; j < Col; j++)
                    {
                        if (grid[i, j] == 0)
                        {
                            if (isEnd)
                            {
                                g.FillRectangle(backcolor, new Rectangle(j * 30, i * 30, 30, 30));
                            }
                            if (!isEnd)
                            {
                                g.DrawImage(Backline, new Point(j * 30, i * 30));
                            }
                        }
                        if (grid[i, j] == 1)
                        {
                            g.DrawImage(Skyblue, new Point(j * 30, i * 30));
                        }
                        if (grid[i, j] == 2)
                        {
                            g.DrawImage(Red, new Point(j * 30, i * 30));
                        }
                        if (grid[i, j] == 3)
                        {
                            g.DrawImage(Green, new Point(j * 30, i * 30));
                        }
                        if (grid[i, j] == 4)
                        {
                            g.DrawImage(Purple, new Point(j * 30, i * 30));
                        }
                        if (grid[i, j] == 5)
                        {
                            g.DrawImage(Gold, new Point(j * 30, i * 30));
                        }
                        if (grid[i, j] == 6)
                        {
                            g.DrawImage(Blue, new Point(j * 30, i * 30));
                        }
                        if (grid[i, j] == 7)
                        {
                            g.DrawImage(Yellow, new Point(j * 30, i * 30));
                        }
                        if (grid[i, j] == 8)
                        {
                            g.DrawImage(Back, new Point(j * 30, i * 30));
                        }
                        if (grid[i, j] == 9)
                        {
                            g.DrawImage(Wall, new Point(j * 30, i * 30));
                        }
                    }
                }
            }
            return b;
        }

        // 여기부터 블럭 미리보기
        private void InsertInNextGrid() //받아온 블럭을 그리드 안으로
        {
            if (block.nextSelectedBlock != null)
            {
                Location2D c = null;

                for (int row = 0; row < 4; row++)
                {
                    for (int col = 0; col < 4; col++)
                    {
                        if (block.nextSelectedBlock[row, col] != 0)
                        {
                            c = block.GetLocation(new Location2D(col, row));
                            this.nextBlockGrid[c.y, c.x] = block.nextSelectedBlock[row, col];
                        }
                    }
                }
            }
        }

        private void ClearNextGrid()    //이동 가능 검사 전에 그리드에서 블럭을 지움
        {
            for (int row = 0; row < 4; row++)
            {
                for (int col = 0; col < 16; col++)
                {
                    this.nextBlockGrid[row, col] = 0;
                }
            }
        }

        public void ResetGrid()    //이동 가능 검사 전에 그리드에서 블럭을 지움
        {
            for (int row = 0; row < Row; row++)
            {
                for (int col = 0; col < Col; col++)
                {
                    this.grid[row, col] = 0;
                }
            }
        }

        public Bitmap nextbitImg(int w, int h, int size)    //배열의 내용을 디스플레이 패널에 그림
        {
            Bitmap b = new Bitmap(16 * size + size, 4 * size + size);

            SolidBrush white = new SolidBrush(Color.White);
            SolidBrush black = new SolidBrush(Color.Black);
            SolidBrush red = new SolidBrush(Color.Red);
            SolidBrush green = new SolidBrush(Color.Green);
            SolidBrush blue = new SolidBrush(Color.Blue);
            SolidBrush pink = new SolidBrush(Color.Pink);
            SolidBrush purple = new SolidBrush(Color.Purple);
            SolidBrush yellowgreen = new SolidBrush(Color.YellowGreen);
            SolidBrush backcolor = new SolidBrush(Color.FromArgb(153, 180, 209));

            Image Blue = TetrisImage.nextblue;
            Image Gold = TetrisImage.nextgold;
            Image Green = TetrisImage.nextgreen;
            Image Purple = TetrisImage.nextpurple;
            Image Red = TetrisImage.nextred;
            Image Skyblue = TetrisImage.nextskyblue;
            Image Yellow = TetrisImage.nextyellow;
            Image Back = TetrisImage.nextback;


            //formGraphics.DrawLine(Pens.Black, 50, 50, 70, 50);

            using (Graphics g = Graphics.FromImage(b))
            {
                for (int i = 0; i < h; i++)
                {
                    for (int j = 0; j < w; j++)
                    {
                        if (nextBlockGrid[i, j] == 0)
                        {
                            g.FillRectangle(backcolor, new Rectangle(j * size, i * size, size, size));
                            //g.DrawImage(Back, new Point(j * size, i * size));
                        }
                        if (nextBlockGrid[i, j] == 1)
                        {
                            g.DrawImage(Skyblue, new Point(j * size, i * size));
                        }
                        if (nextBlockGrid[i, j] == 2)
                        {
                            g.DrawImage(Red, new Point(j * size, i * size));
                        }
                        if (nextBlockGrid[i, j] == 3)
                        {
                            g.DrawImage(Green, new Point(j * size, i * size));
                        }
                        if (nextBlockGrid[i, j] == 4)
                        {
                            g.DrawImage(Purple, new Point(j * size, i * size));
                        }
                        if (nextBlockGrid[i, j] == 5)
                        {
                            g.DrawImage(Gold, new Point(j * size, i * size));
                        }
                        if (nextBlockGrid[i, j] == 6)
                        {
                            g.DrawImage(Blue, new Point(j * size, i * size));
                        }
                        if (nextBlockGrid[i, j] == 7)
                        {
                            g.DrawImage(Yellow, new Point(j * size, i * size));
                        }
                    }
                }
            }
            return b;
        }

        //스테이지 배열의 내용을 디스플레이 패널에 그림
        public List<PictureBox> makeObj(List<PictureBox> pictureBoxes, DisplayPanel panel)
        {
            for (int i = 0; i < Row; i++)
            {
                for (int j = 0; j < Col; j++)
                {
                    if (grid[i, j] == 0)
                    {
                        //0은 빈공간
                    }
                    else
                    {
                        pictureBoxes.Add(new PictureBox()
                        {
                            Top = panel.Top + (30 * i),
                            Left = panel.Left + (30 * j),
                            Width = 30,
                            Height = 30
                        });
                    }
                }
            }
            return pictureBoxes;
        }

        public void KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
                MoveRight();
            if (e.KeyCode == Keys.Left)
                MoveLeft();
            if (e.KeyCode == Keys.Up)
                Rotate();
            if (e.KeyCode == Keys.Down)
                ReverseRotate();
            if (e.KeyCode == Keys.Space)
                DropBlock();
        }
    }
}