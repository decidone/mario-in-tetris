using Mario_In_Tetris.Resource;
using System;
using System.Collections.Generic;
using System.Media;
using System.Windows.Forms;

namespace Mario_In_Tetris
{
    class Player
    {
        #region 기본변수와 생성자
        public bool left;
        public bool right;
        public bool LastStandLeft;
        public bool jump;
        public int G = 25; //중력계수(숫자가 낮을수록 중력이 세짐)
        public int Force;
        public PictureBox character;
        public List<PictureBox> Blocks = new List<PictureBox>();
        SoundPlayer JumpSound = new SoundPlayer();

        public Player()
        {
            this.JumpSound.Stream = Sound.Jump;
            left = false;
            right = false;
            LastStandLeft = false;
        }

        #endregion

        #region 키이벤트
        public void KeyDown(object s, KeyEventArgs e)
        {
            //왼쪽키 다운
            if (e.KeyCode == Keys.Left)
            {
                character.Image = Character.walk_l;
                left = true;
                LastStandLeft = true;
            }


            //오른쪽키 다운
            if (e.KeyCode == Keys.Right)
            {
                character.Image = Character.walk_r;
                right = true;
                LastStandLeft = false;
            }

            //!jump상태일때 스페이스바 다운
            if (!jump)
            {
                if (e.KeyCode == Keys.Space)
                {
                    this.JumpSound.Play();
                    jump = true;
                    Force = G;
                }
            }
        }

        public void KeyUp(object s, KeyEventArgs e)
        {
            //왼쪽키 업
            if (e.KeyCode == Keys.Left)
            {
                character.Image = Character.stand_l;
                left = false;
            }

            //오른쪽키 업
            if (e.KeyCode == Keys.Right)
            {
                character.Image = Character.stand_r;
                right = false;
            }

        }

        public void TimerTickAction(object sender, EventArgs e, Panel p)
        {
            if (left == true && !CheckLeftCol(character) && character.Left > 0)
            {
                character.Left -= 5;
            }
            if (right == true && !CheckRightCol(character) && character.Right < p.Width)
            {
                character.Left += 5;
            }

            //현재 점프상태일때
            if (jump)
            {
                if (!CheckBottomCol(character))
                {
                    if (LastStandLeft)
                        character.Image = Character.jump_l;
                    else
                        character.Image = Character.jump_r;
                    //캐릭터는 Force만큼 올라감
                    character.Top -= Force;
                    //Force는 -2만큼 지속적으로 감소
                    Force -= 2;
                }
                else
                {
                    jump = false;
                }
            }


            //캐릭터가 바닥보다 아래로 갈려고 할 경우
            if (character.Bottom >= p.Height)
            {
                if (LastStandLeft)
                    character.Image = Character.stand_l;
                else
                    character.Image = Character.stand_r;
                //캐릭터 위치 아래로 못내려가게 보정
                character.Top = p.Height - character.Height;
                jump = false;
            }
            else
            {
                //바닥보다 아래가 아닐경우
                if (!CheckTopCol(character))
                    character.Top += 10;
                else
                    Force = 0;
            }
        }
        #endregion

        #region 블록과의충돌체크
        public bool CheckTopCol(PictureBox player)
        {
            foreach (PictureBox obj in Blocks)
            {
                if (obj != null)
                {
                    if (player.Bottom >= obj.Top &&
                        player.Bottom <= obj.Bottom &&
                        player.Right - 5 > obj.Left &&
                        player.Left + 5 < obj.Right)
                    {
                        if (LastStandLeft && !left && !right)
                            character.Image = Character.stand_l;
                        else if (!LastStandLeft && !left && !right)
                            character.Image = Character.stand_r;
                        player.Top = obj.Top - player.Height;
                        jump = false;
                        return true;
                    }
                }
            }
            return false;
        }

        public bool CheckBottomCol(PictureBox player)
        {
            foreach (PictureBox obj in Blocks)
            {
                if (obj != null)
                {
                    if (player.Top < obj.Bottom &&
                        player.Bottom > obj.Top + player.Height &&
                        player.Right - 5 > obj.Left &&
                        player.Left + 5 < obj.Right)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool CheckLeftCol(PictureBox player)
        {
            foreach (PictureBox obj in Blocks)
            {
                if (obj != null)
                {
                    if (player.Left < obj.Right + 3 &&
                        player.Right > obj.Left + player.Width &&
                        player.Bottom > obj.Top + 10 &&
                        player.Top < obj.Bottom)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool CheckRightCol(PictureBox player)
        {
            foreach (PictureBox obj in Blocks)
            {
                if (obj != null)
                {
                    if (player.Right > obj.Left - 3 &&
                        player.Left < obj.Right - player.Width &&
                        player.Bottom > obj.Top + 10 &&
                        player.Top < obj.Bottom)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool IsArriveEscapeTop(PictureBox player, PictureBox escape)
        {
            if (player.Bottom >= escape.Top &&
                player.Bottom <= escape.Bottom &&
                player.Right - 5 > escape.Left &&
                player.Left + 5 < escape.Right)
                return true;
            else return false;
        }

        public bool IsArriveEscapeLeft(PictureBox player, PictureBox escape)
        {
            if (player.Left < escape.Right &&
                player.Right > escape.Left + player.Width &&
                player.Bottom > escape.Top + 10 &&
                player.Top < escape.Bottom)
                return true;
            else return false;
        }
        #endregion
    }
}
