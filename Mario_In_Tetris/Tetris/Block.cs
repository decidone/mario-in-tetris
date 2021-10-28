using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mario_In_Tetris
{
    //테트리스 블럭
    class Block
    {
        public int x { get; set; }
        public int y { get; set; }
        public int[][,] blockSetting = new int[7][,];
        public int[,] selectedBlock = null;
        public int[,] nextSelectedBlock = null;
        Random ran = new Random();

        public Block()
        {
            this.Shapes();
        }

        private void Shapes()   //블럭 설정
        {
            int[,] line = new int[4, 4]{{ 0, 1, 0, 0 },
                                        { 0, 1, 0, 0 },
                                        { 0, 1, 0, 0 },
                                        { 0, 1, 0, 0 }
                                       };
            int[,] zShape = new int[4, 4]{{ 0, 0, 0, 0 },
                                          { 2, 2, 0, 0 },
                                          { 0, 2, 2, 0 },
                                          { 0, 0, 0, 0 }
                                         };
            int[,] rzShape = new int[4, 4]{{ 0, 0, 0, 0 },
                                           { 0, 0, 3, 3 },
                                           { 0, 3, 3, 0 },
                                           { 0, 0, 0, 0 }
                                          };
            int[,] triangle = new int[4, 4]{{ 0, 0, 4, 0 },
                                            { 0, 4, 4, 0 },
                                            { 0, 0, 4, 0 },
                                            { 0, 0, 0, 0 }
                                           };
            int[,] rightL = new int[4, 4]{{ 0, 0, 0, 0 },
                                          { 0, 5, 5, 0 },
                                          { 0, 0, 5, 0 },
                                          { 0, 0, 5, 0 }
                                         };
            int[,] leftL = new int[4, 4]{{ 0, 0, 0, 0 },
                                         { 0, 6, 6, 0 },
                                         { 0, 6, 0, 0 },
                                         { 0, 6, 0, 0 }
                                        };
            int[,] square = new int[4, 4]{{ 0, 0, 0, 0 },
                                          { 0, 7, 7, 0 },
                                          { 0, 7, 7, 0 },
                                          { 0, 0, 0, 0 }
                                         };

            for (int i = 0; i < 7; i++)
                blockSetting[i] = new int[4, 4];

            blockSetting[0] = line;
            blockSetting[1] = zShape;
            blockSetting[2] = rzShape;
            blockSetting[3] = triangle;
            blockSetting[4] = rightL;
            blockSetting[5] = leftL;
            blockSetting[6] = square;
        }

        public void GetNextBlock(int nextBlock)  //여기에 마지막 내린 블록 x좌표 받아서 this.x에 대입
        {
            this.x = 2;
            this.y = 0;

            this.selectedBlock = this.blockSetting[nextBlock];
        }

        public void ShowNextBlock(int nextBlock)  //여기에 마지막 내린 블록 x좌표 받아서 this.x에 대입
        {
            this.x = 0;
            this.y = 0;

            this.nextSelectedBlock = this.blockSetting[nextBlock];
        }

        public void RotateBlock()   //시계방향 회전
        {
            int[,] rotate = new int[4, 4];

            for (int i = 3; i > -1; i--)
            {
                for (int j = 0; j < 4; j++)
                {
                    rotate[j, 3 - i] = this.selectedBlock[i, j];
                }
            }
            this.selectedBlock = rotate;
        }

        public void ReverseRotateBlock()    //반시계방향 회전
        {
            this.RotateBlock();
            this.RotateBlock();
            this.RotateBlock();
        }

        public Block Clone()    //블록이 이동 가능한지 확인하기 위한 복사
        {
            return (Block)this.MemberwiseClone();
        }

        public Location2D GetLocation(Location2D location)  //좌표값
        {
            location.x += this.x;
            location.y += this.y;
            return location;
        }

    }
}
