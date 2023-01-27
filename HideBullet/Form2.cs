using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HideBullet
{
    public partial class Form2 : Form
    {
        int pLeft, pTop, count_min, count_second, Bseconds, left, right, up, down, BoomB = 0;
        int CanMove=1;
        string time_second, time_min;

        private void Slow_Tick(object sender, EventArgs e)  //慢速彈 X、Y增加量較少
        {
            bGo(-2, -1, 0, 25, 1);
            bGo(+2, +1, 26, 50, 1);
            bGo(-2, +1, 51, 75, 1);
            bGo(+2, -1, 76, 99, 1);
        }



        private void Normal_Tick(object sender, EventArgs e) //普通速度的子彈
        {

            bGo(-5, -5, 0, 25, 1);
            bGo(+5, +5, 26, 50, 1);
            bGo(-5, +5, 51, 75, 1);
            bGo(+5, -5, 76, 99, 1);
        }

        private void Second_Tick(object sender, EventArgs e) //計時器
        {
            count_second++;
            time_second = count_second.ToString();
            time_min = 0 + count_min.ToString();
            pLeft = Player.Left;
            pTop = Player.Top;

            if (count_second <= 9)
            {
                time_second = 0 + count_second.ToString();
            }

            label1.Text = time_min + ":" + time_second;
            if (count_second >= 59)
            {
                count_second = -1;
                count_min++;
            }
        }

        private void timer1_Tick(object sender, EventArgs e) //檢查子彈是否出界如果出界則重設位置
                                                             //檢查是否碰撞到玩家

        {
            cBullet();
            Out();
        }

        private void Trace_Tick(object sender, EventArgs e)  //追蹤彈
        {
            bGo(0, 0, 0, 25, 2);
            bGo(0, 0, 26, 50, 2);
            bGo(0, 0, 51, 75, 2);
            bGo(0, 0, 76, 99, 2);
        }

        private void Fast_Tick(object sender, EventArgs e)  //快速彈
        {
            bGo(-7, -7, 0, 25, 1);
            bGo(+7, +7, 26, 50, 1);
            bGo(-7, +7, 51, 75, 1);
            bGo(+7, -7, 76, 99, 1);
        }

        private void BackG_Tick(object sender, EventArgs e)  //讓背景動起來
        {

            PictureBox[] pbb8 = new PictureBox[107] {pictureBox100,pictureBox101,pictureBox102,pictureBox103,pictureBox104,pictureBox105,pictureBox106,pictureBox107,
                pictureBox108,pictureBox109,pictureBox110,pictureBox111,pictureBox112,pictureBox113,pictureBox114,pictureBox115,pictureBox116,pictureBox117,pictureBox118,pictureBox119,
                pictureBox120,pictureBox121,pictureBox122,pictureBox123,pictureBox124,pictureBox125,pictureBox126,pictureBox127,pictureBox128,pictureBox129,pictureBox130,
                pictureBox131,pictureBox132,pictureBox133,pictureBox134,pictureBox135,pictureBox136,pictureBox137,pictureBox138,pictureBox139,pictureBox140,pictureBox141,pictureBox142,
                pictureBox143,pictureBox144,pictureBox145,pictureBox146,pictureBox147,pictureBox148,pictureBox149,pictureBox150,pictureBox151,pictureBox152,pictureBox153,pictureBox154,pictureBox155,pictureBox156,pictureBox157,pictureBox158,pictureBox159,
            pictureBox160,pictureBox161,pictureBox162,pictureBox163,pictureBox164,pictureBox165,pictureBox166,pictureBox167,pictureBox168,pictureBox169,pictureBox170,
            pictureBox171,pictureBox172,pictureBox173,pictureBox174,pictureBox175,pictureBox176,pictureBox177,pictureBox178,pictureBox179,pictureBox180,pictureBox181,
            pictureBox182,pictureBox183,pictureBox184,pictureBox185,pictureBox186,pictureBox187,pictureBox188,pictureBox189,pictureBox190,pictureBox191,pictureBox192,
            pictureBox193,pictureBox194,pictureBox195,pictureBox196,pictureBox197,pictureBox198,pictureBox199,pictureBox200,pictureBox201,pictureBox202,pictureBox203,
            pictureBox204,pictureBox205,pictureBox206};

            for (int k = 0; k < 107; k++)                 //往下移動
            {
                pbb8[k].Top += 1;

                if (pbb8[k].Top >= 285)                    //出界後隨機位置
                {
                    int X = Rnd.Next(0, 300);
                    int Y = Rnd.Next(-5, 300);
                    pbb8[k].Location = new System.Drawing.Point(X, Y);
                }
            }
        }

        private void Boom_Tick(object sender, EventArgs e)     //如果子彈碰撞到玩家 則啟動此Timer
                                                               //3~8模擬爆炸
                                                               //9將畫面隱藏並把資料庫界面叫出
        {

            BoomB++;
            if (BoomB == 3)
            {
                
                Player.BackColor = Color.DarkRed;
                Player.Size = new System.Drawing.Size(5, 5);
            }
            if (BoomB == 4)
            {
                
                Player.BackColor = Color.White;
                Player.Size = new System.Drawing.Size(10, 10);
            }
            if (BoomB == 5)
            {
               
                Player.BackColor = Color.Red;
                Player.Size = new System.Drawing.Size(5, 5);
            }
            if (BoomB == 6)
            {
               
                Player.BackColor = Color.White;
                Player.Size = new System.Drawing.Size(10, 10);
            }
            if (BoomB == 7)
            {
                
                Player.BackColor = Color.DarkRed;
                Player.Size = new System.Drawing.Size(15, 15);
            }
            if (BoomB == 8)
            {
                
                Player.BackColor = Color.Red;
                Player.Size = new System.Drawing.Size(20, 20);

            }
            if (BoomB == 9)
            {
           
                Player.BackColor = Color.Black;
                Player.Size = new System.Drawing.Size(25, 25);
                this.tableBindingSource.AddNew();
                nameTextBox1.Visible = true;
                timeTextBox1.Visible = true;
                timeTextBox1.Text = count_min + "分" + count_second + "秒";
                button1.Visible = true;
                button2.Visible = true;
                label4.Visible = true;
                label5.Visible = true;
                label1.Visible = false;
                tableDataGridView.Visible = true;             
            }
        }

        private void Remix_Tick(object sender, EventArgs e) //混合彈
        {
            bGo(0, 0, 0, 0, 3);
        }

        private void tableBindingNavigatorSaveItem_Click(object sender, EventArgs e)  //更新資料庫
        {
            this.Validate();
            this.tableBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.database1DataSet);

        }

        private void button1_Click(object sender, EventArgs e)    //更新資料庫
        {
            this.Validate();
            this.tableBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.database1DataSet);
        }

        private void button2_Click(object sender, EventArgs e)        //跳回Form1
        {
            Form1 f = (Form1)this.Owner;//產生Form2的物件，才可以使用它所提供的Method
            f.Text = "你上次撐過了" + count_min + "分" + count_second + "秒";
            f.TextBosMsg= "你上次撐過了"+count_min + "分" + count_second + "秒";
            f.Visible = true;
            this.Visible = false;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Nice_Tick(object sender, EventArgs e)
        {
            left = 0;
              up = 0;
            down = 0;
            right = 0;
        }

        private void Bsecond_Tick(object sender, EventArgs e)    //切換子彈模式
        {
            if (Trace.Enabled == true && Slow.Enabled == true)    
            {
                Bseconds++;
                if (Bseconds == 7)                     //此模式維持7秒
                {
                    Slow.Enabled = false;
                    Trace.Enabled = false;
                    Normal.Enabled = true;
                    Bseconds = 0;
                    Bsecond.Enabled = false;
                    Randd.Enabled = true;
                }
            }

            if (Trace.Enabled == true)         
            {
                Bseconds++;
                if (Bseconds == 4)
                {
                    Trace.Enabled = false;
                    Normal.Enabled = true;
                    Bseconds = 0;
                    Bsecond.Enabled = false;
                    Randd.Enabled = true;
                }
            }
             
            if (Slow.Enabled == true)         
            {
                Bseconds++;
                if (Bseconds == 5)
                {
                    Slow.Enabled = false;
                    Normal.Enabled = true;
                    Bseconds = 0;
                    Bsecond.Enabled = false;
                    Randd.Enabled = true;
                }
            }

            if (Fast.Enabled == true)
            {
                Bseconds++;
                if (Bseconds == 7)
                {

                    Fast.Enabled = false;
                    Normal.Enabled = true;
                    Bseconds = 0;
                    Bsecond.Enabled = false;
                    Randd.Enabled = true;
                }
            }

            if (Remix.Enabled == true)
            {
                Bseconds++;
                if (Bseconds == 7)
                {
                    Remix.Enabled = false;
                    Normal.Enabled = true;
                    Bseconds = 0;
                    Bsecond.Enabled = false;
                    Randd.Enabled = true;
                }
            }
        }

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

            this.tableTableAdapter.Fill(this.database1DataSet.Table);
            PictureBox[] pbb = new PictureBox[99] { pictureBox1, pictureBox2, pictureBox3, pictureBox4, pictureBox5, pictureBox6, pictureBox7, pictureBox8, pictureBox9,
                    pictureBox10,pictureBox11,pictureBox12,pictureBox13,pictureBox14,pictureBox15,pictureBox16,pictureBox17,pictureBox18,pictureBox19,pictureBox20,
                pictureBox21,pictureBox22,pictureBox23,pictureBox24,pictureBox25,pictureBox26,pictureBox27,pictureBox28,pictureBox29,pictureBox30,
                pictureBox31,pictureBox32,pictureBox33,pictureBox34,pictureBox35,pictureBox36,pictureBox37,pictureBox38,pictureBox39,pictureBox40,
                pictureBox41,pictureBox42,pictureBox43,pictureBox44,pictureBox45,pictureBox46,pictureBox47,pictureBox48,pictureBox49,pictureBox50,
                pictureBox51,pictureBox52,pictureBox53,pictureBox54,pictureBox55,pictureBox56,pictureBox57,pictureBox58,pictureBox59,pictureBox60,
                pictureBox61,pictureBox62,pictureBox63,pictureBox64,pictureBox65,pictureBox66,pictureBox67,pictureBox68,pictureBox69,pictureBox70,
                pictureBox71,pictureBox72,pictureBox73,pictureBox74,pictureBox75,pictureBox76,pictureBox77,pictureBox78,pictureBox79,pictureBox80,
                pictureBox81,pictureBox82,pictureBox83,pictureBox84,pictureBox85,pictureBox86,pictureBox87,pictureBox88,pictureBox89,pictureBox90,
                pictureBox91,pictureBox92,pictureBox93,pictureBox94,pictureBox95,pictureBox96,pictureBox97,pictureBox98,pictureBox99};

            for (int i = 0; i < 99; i++)                                               //宣告並決定子彈的初始位置
            {
                pbb[i].Size = new System.Drawing.Size(5, 5);

                int X = Rnd.Next(1, 5);
                int Y = Rnd.Next(-100, 0);
                int Z = Rnd.Next(300, 400);
                int W = Rnd.Next(0, 300);


                switch (X)
                {
                    case 1:
                        pbb[i].Location = new System.Drawing.Point(Y, W);

                        break;
                    case 2:
                        pbb[i].Location = new System.Drawing.Point(Z, W);

                        break;
                    case 3:
                        pbb[i].Location = new System.Drawing.Point(W, Y);

                        break;
                    case 4:
                        pbb[i].Location = new System.Drawing.Point(W, Z);

                        break;

                }
            }

            tableDataGridView.Font=new Font("jf open",9,FontStyle.Bold);

             PictureBox[] pbb8 = new PictureBox[107] {pictureBox100,pictureBox101,pictureBox102,pictureBox103,pictureBox104,pictureBox105,pictureBox106,pictureBox107,
                pictureBox108,pictureBox109,pictureBox110,pictureBox111,pictureBox112,pictureBox113,pictureBox114,pictureBox115,pictureBox116,pictureBox117,pictureBox118,pictureBox119,
                pictureBox120,pictureBox121,pictureBox122,pictureBox123,pictureBox124,pictureBox125,pictureBox126,pictureBox127,pictureBox128,pictureBox129,pictureBox130,
                pictureBox131,pictureBox132,pictureBox133,pictureBox134,pictureBox135,pictureBox136,pictureBox137,pictureBox138,pictureBox139,pictureBox140,pictureBox141,pictureBox142,
                pictureBox143,pictureBox144,pictureBox145,pictureBox146,pictureBox147,pictureBox148,pictureBox149,pictureBox150,pictureBox151,pictureBox152,pictureBox153,pictureBox154,pictureBox155,pictureBox156,pictureBox157,pictureBox158,pictureBox159,
            pictureBox160,pictureBox161,pictureBox162,pictureBox163,pictureBox164,pictureBox165,pictureBox166,pictureBox167,pictureBox168,pictureBox169,pictureBox170,
            pictureBox171,pictureBox172,pictureBox173,pictureBox174,pictureBox175,pictureBox176,pictureBox177,pictureBox178,pictureBox179,pictureBox180,pictureBox181,
            pictureBox182,pictureBox183,pictureBox184,pictureBox185,pictureBox186,pictureBox187,pictureBox188,pictureBox189,pictureBox190,pictureBox191,pictureBox192,
            pictureBox193,pictureBox194,pictureBox195,pictureBox196,pictureBox197,pictureBox198,pictureBox199,pictureBox200,pictureBox201,pictureBox202,pictureBox203,
            pictureBox204,pictureBox205,pictureBox206};

            for (int k = 0; k < 107; k++)                             //背景的初始位置
            {
                int X = Rnd.Next(0, 300);
                int Y = Rnd.Next(-5, 300);
                pbb8[k].Location = new System.Drawing.Point(X, Y);
            }

            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form2_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form2_KeyUp);
        }

        private void Randd_Tick(object sender, EventArgs e)        //決定子彈的模式
        {
            Random Rnd = new Random();
            int X = Rnd.Next(1, 7);
            switch (X)
            {
                case 1:                    //慢
                    Normal.Enabled = false;
                    Slow.Enabled = true;
                    Randd.Enabled = false;
                    Bsecond.Enabled = true;
                    break;
                case 2:                    //追蹤
                    Normal.Enabled = false;
                    Trace.Enabled = true;
                    Randd.Enabled = false;
                    Bsecond.Enabled = true;
                    break;
                case 3:                    //快
                    Normal.Enabled = false;
                    Fast.Enabled = true;
                    Randd.Enabled = false;
                    Bsecond.Enabled = true;
                    break;
                case 4:                         //追蹤+慢
                    Normal.Enabled = false;
                    Trace.Enabled = true;
                    Slow.Enabled = true;
                    Randd.Enabled = false;
                    Bsecond.Enabled = true;
                    break;
                case 5:                        //混合
                    Remix.Enabled = true;
                    Normal.Enabled = false;
                    Randd.Enabled = false;
                    Bsecond.Enabled = true;
                    break;
            }
        }
        Random Rnd = new Random();
        private void cBullet()                           //出界後重設子彈位置
        {
            PictureBox[] pbb = new PictureBox[99] { pictureBox1, pictureBox2, pictureBox3, pictureBox4, pictureBox5, pictureBox6, pictureBox7, pictureBox8, pictureBox9,
                    pictureBox10,pictureBox11,pictureBox12,pictureBox13,pictureBox14,pictureBox15,pictureBox16,pictureBox17,pictureBox18,pictureBox19,pictureBox20,
                pictureBox21,pictureBox22,pictureBox23,pictureBox24,pictureBox25,pictureBox26,pictureBox27,pictureBox28,pictureBox29,pictureBox30,
                pictureBox31,pictureBox32,pictureBox33,pictureBox34,pictureBox35,pictureBox36,pictureBox37,pictureBox38,pictureBox39,pictureBox40,
                pictureBox41,pictureBox42,pictureBox43,pictureBox44,pictureBox45,pictureBox46,pictureBox47,pictureBox48,pictureBox49,pictureBox50,
                pictureBox51,pictureBox52,pictureBox53,pictureBox54,pictureBox55,pictureBox56,pictureBox57,pictureBox58,pictureBox59,pictureBox60,
                pictureBox61,pictureBox62,pictureBox63,pictureBox64,pictureBox65,pictureBox66,pictureBox67,pictureBox68,pictureBox69,pictureBox70,
                pictureBox71,pictureBox72,pictureBox73,pictureBox74,pictureBox75,pictureBox76,pictureBox77,pictureBox78,pictureBox79,pictureBox80,
                pictureBox81,pictureBox82,pictureBox83,pictureBox84,pictureBox85,pictureBox86,pictureBox87,pictureBox88,pictureBox89,pictureBox90,
                pictureBox91,pictureBox92,pictureBox93,pictureBox94,pictureBox95,pictureBox96,pictureBox97,pictureBox98,pictureBox99};
            for (int i = 1; i < 99; i++)
            {
                if (pbb[i].Left > 300 || pbb[i].Left < 0 || pbb[i].Top > 300 || pbb[i].Top < 0)
                {

                    int X = Rnd.Next(1, 5);
                    int Y = Rnd.Next(-100, 0);
                    int Z = Rnd.Next(300, 400);
                    int W = Rnd.Next(0, 300);


                    switch (X)
                    {
                        case 1:
                            pbb[i].Location = new System.Drawing.Point(Y, W);

                            break;
                        case 2:
                            pbb[i].Location = new System.Drawing.Point(Z, W);

                            break;
                        case 3:
                            pbb[i].Location = new System.Drawing.Point(W, Y);

                            break;
                        case 4:
                            pbb[i].Location = new System.Drawing.Point(W, Z);

                            break;

                    }
                }
            }
        }
        private void bGo(int X, int Y, int Z, int ZZ, int M)                   //子彈移動
        {
            PictureBox[] pbb = new PictureBox[99] { pictureBox1, pictureBox2, pictureBox3, pictureBox4, pictureBox5, pictureBox6, pictureBox7, pictureBox8, pictureBox9,
                    pictureBox10,pictureBox11,pictureBox12,pictureBox13,pictureBox14,pictureBox15,pictureBox16,pictureBox17,pictureBox18,pictureBox19,pictureBox20,
                pictureBox21,pictureBox22,pictureBox23,pictureBox24,pictureBox25,pictureBox26,pictureBox27,pictureBox28,pictureBox29,pictureBox30,
                pictureBox31,pictureBox32,pictureBox33,pictureBox34,pictureBox35,pictureBox36,pictureBox37,pictureBox38,pictureBox39,pictureBox40,
                pictureBox41,pictureBox42,pictureBox43,pictureBox44,pictureBox45,pictureBox46,pictureBox47,pictureBox48,pictureBox49,pictureBox50,pictureBox51,pictureBox52,pictureBox53,pictureBox54,pictureBox55,pictureBox56,pictureBox57,pictureBox58,pictureBox59,pictureBox60,
                pictureBox61,pictureBox62,pictureBox63,pictureBox64,pictureBox65,pictureBox66,pictureBox67,pictureBox68,pictureBox69,pictureBox70,
                pictureBox71,pictureBox72,pictureBox73,pictureBox74,pictureBox75,pictureBox76,pictureBox77, pictureBox78, pictureBox79, pictureBox80,
                pictureBox81, pictureBox82, pictureBox83, pictureBox84, pictureBox85, pictureBox86, pictureBox87, pictureBox88, pictureBox89, pictureBox90,
                pictureBox91, pictureBox92, pictureBox93, pictureBox94, pictureBox95, pictureBox96, pictureBox97, pictureBox98, pictureBox99 };

            if (M == 1)                               //模式1
            {
                for (int j = Z; j < ZZ; j++)
                {
                    if (Fast.Enabled == true)
                    {
                        pbb[j].BackColor = Color.Red;
                    }
                    if (Normal.Enabled == true)
                    {
                        pbb[j].BackColor = Color.Orange;
                    }
                    if (Slow.Enabled == true && Trace.Enabled == false)
                    {
                        pbb[j].BackColor = Color.LightGreen;
                    }
                    pbb[j].Left = pbb[j].Left + X;
                    pbb[j].Top = pbb[j].Top + Y;
                }
            }

            if (M == 2)                          //模式2(追蹤彈用)
            {
                for (int j = Z; j < ZZ; j++)
                {
                    if (Trace.Enabled == true)
                    {
                        pbb[j].BackColor = Color.MediumPurple;
                    }
                    if (Trace.Enabled == true && Slow.Enabled == true)
                    {
                        pbb[j].BackColor = Color.Purple;
                    }

                    if (pbb[j].Left < Player.Left)
                    {
                        pbb[j].Left = pbb[j].Left + (pLeft - pbb[j].Left) / 50 + 1;

                    }
                    if (pbb[j].Left > Player.Left)
                    {
                        pbb[j].Left = pbb[j].Left - (pbb[j].Left - pLeft) / 50 - 1;

                    }

                    if (pbb[j].Top > Player.Top)
                    {

                        pbb[j].Top = pbb[j].Top - (pbb[j].Top - pTop) / 50 - 1;
                    }

                    if (pbb[j].Top < Player.Top)
                    {

                        pbb[j].Top = pbb[j].Top + (pTop - pbb[j].Top) / 50 + 1;
                    }
                }
            }

            if (M == 3)                             //模式3(混合彈用)
            {
                for (int j = 67; j < 77; j++)
                {
                    pbb[j].Left = pbb[j].Left + 5;
                    pbb[j].Top = pbb[j].Top - 5;
                }

                for (int j = 78; j < 88; j++)
                {
                    pbb[j].Left = pbb[j].Left + 5;
                    pbb[j].Top = pbb[j].Top + 5;
                }

                for (int j = 89; j < 99; j++)
                {
                    pbb[j].Left = pbb[j].Left - 5;
                    pbb[j].Top = pbb[j].Top - 5;
                }

                for (int j = 34; j < 66; j++)
                {
                    pbb[j].Left = pbb[j].Left - 7;
                    pbb[j].Top = pbb[j].Top + 7;
                    pbb[j].BackColor = Color.Red;
                }
                for (int j = 1; j < 33; j++)
                {
                    pbb[j].BackColor = Color.MediumPurple;
                    if (pbb[j].Left < Player.Left)
                    {
                        pbb[j].Left = pbb[j].Left + (pLeft - pbb[j].Left) / 50 + 1;
                    }
                    if (pbb[j].Left > Player.Left)
                    {
                        pbb[j].Left = pbb[j].Left - (pbb[j].Left - pLeft) / 50 - 1;
                    }
                    if (pbb[j].Top > Player.Top)
                    {
                        pbb[j].Top = pbb[j].Top - (pbb[j].Top - pTop) / 50 - 1;
                    }
                    if (pbb[j].Top < Player.Top)
                    {
                        pbb[j].Top = pbb[j].Top + (pTop - pbb[j].Top) / 50 + 1;
                    }
                }
            }

        }
        private void Form2_KeyUp(object sender, KeyEventArgs e)   //鍵盤操控玩家移動
        {
            switch (e.KeyCode)
            {
                case Keys.A:
                    left = 0;

                    break;
                case Keys.D:
                    right = 0;

                    break;
                case Keys.W:
                    up = 0;

                    break;
                case Keys.S:
                    down = 0;

                    break;
            }
        }
        private void Form2_KeyDown(object sender, KeyEventArgs e)
        {
            {
                if (CanMove == 1)
                {
                    switch (e.KeyCode)
                    {
                        case Keys.A:

                            if (Player.Left <= 1)
                            {
                                left = 0;
                            }
                            else
                            {
                                left = 1;
                            }
                            break;
                        case Keys.D:
                            if (Player.Left >= 282)
                            {
                                left = 0;
                            }
                            else
                            {
                                right = 1;
                            }


                            break;
                        case Keys.W:
                            if (Player.Top <= 1)
                            {
                                up = 0;
                            }
                            else
                            {
                                up = 1;
                            }

                            break;
                        case Keys.S:
                            if (Player.Top >= 255)
                            {
                                down = 0;
                            }
                            else
                            {
                                down = 1;
                            }
                            break;
                    }

                    if (left == 1)
                    {
                        Player.Location = new System.Drawing.Point(Player.Location.X - 3, Player.Location.Y);
                    }
                    if (right == 1)
                    {
                        Player.Location = new System.Drawing.Point(Player.Location.X + 3, Player.Location.Y);
                    }
                    if (down == 1)
                    {
                        Player.Location = new System.Drawing.Point(Player.Location.X, Player.Location.Y + 3);
                    }
                    if (up == 1)
                    {
                        Player.Location = new System.Drawing.Point(Player.Location.X, Player.Location.Y - 3);
                    }
                    if (left == 1)
                    {
                        if (up == 1)
                        {
                            Player.Location = new System.Drawing.Point(Player.Location.X - 1, Player.Location.Y - 1);
                        }
                    }
                    if (left == 1 & down == 1)
                    {
                        Player.Location = new System.Drawing.Point(Player.Location.X - 1, Player.Location.Y + 1);
                    }
                    if (right == 1 & up == 1)
                    {
                        Player.Location = new System.Drawing.Point(Player.Location.X + 1, Player.Location.Y - 1);
                    }
                    if (right == 1 & down == 1)
                    {
                        Player.Location = new System.Drawing.Point(Player.Location.X + 1, Player.Location.Y + 1);
                    }
                }

            }
        }
        private void Out()         //檢查碰撞、啟動Boom_Timer 關掉其他Timer(計時、子彈移動...等)
        {
            PictureBox[] pbb = new PictureBox[99] { pictureBox1, pictureBox2, pictureBox3, pictureBox4, pictureBox5, pictureBox6, pictureBox7, pictureBox8, pictureBox9,
                    pictureBox10,pictureBox11,pictureBox12,pictureBox13,pictureBox14,pictureBox15,pictureBox16,pictureBox17,pictureBox18,pictureBox19,pictureBox20,
                pictureBox21,pictureBox22,pictureBox23,pictureBox24,pictureBox25,pictureBox26,pictureBox27,pictureBox28,pictureBox29,pictureBox30,
                pictureBox31,pictureBox32,pictureBox33,pictureBox34,pictureBox35,pictureBox36,pictureBox37,pictureBox38,pictureBox39,pictureBox40,
                pictureBox41,pictureBox42,pictureBox43,pictureBox44,pictureBox45,pictureBox46,pictureBox47,pictureBox48,pictureBox49,pictureBox50,
                pictureBox51,pictureBox52,pictureBox53,pictureBox54,pictureBox55,pictureBox56,pictureBox57,pictureBox58,pictureBox59,pictureBox60,
                pictureBox61,pictureBox62,pictureBox63,pictureBox64,pictureBox65,pictureBox66,pictureBox67,pictureBox68,pictureBox69,pictureBox70,
                pictureBox71,pictureBox72,pictureBox73,pictureBox74,pictureBox75,pictureBox76,pictureBox77,pictureBox78,pictureBox79,pictureBox80,
                pictureBox81,pictureBox82,pictureBox83,pictureBox84,pictureBox85,pictureBox86,pictureBox87,pictureBox88,pictureBox89,pictureBox90,
                pictureBox91,pictureBox92,pictureBox93,pictureBox94,pictureBox95,pictureBox96,pictureBox97,pictureBox98,pictureBox99};

            PictureBox[] pbb8 = new PictureBox[107] {pictureBox100,pictureBox101,pictureBox102,pictureBox103,pictureBox104,pictureBox105,pictureBox106,pictureBox107,
                pictureBox108,pictureBox109,pictureBox110,pictureBox111,pictureBox112,pictureBox113,pictureBox114,pictureBox115,pictureBox116,pictureBox117,pictureBox118,pictureBox119,
                pictureBox120,pictureBox121,pictureBox122,pictureBox123,pictureBox124,pictureBox125,pictureBox126,pictureBox127,pictureBox128,pictureBox129,pictureBox130,
                pictureBox131,pictureBox132,pictureBox133,pictureBox134,pictureBox135,pictureBox136,pictureBox137,pictureBox138,pictureBox139,pictureBox140,pictureBox141,pictureBox142,
                pictureBox143,pictureBox144,pictureBox145,pictureBox146,pictureBox147,pictureBox148,pictureBox149,pictureBox150,pictureBox151,pictureBox152,pictureBox153,pictureBox154,pictureBox155,pictureBox156,pictureBox157,pictureBox158,pictureBox159,
            pictureBox160,pictureBox161,pictureBox162,pictureBox163,pictureBox164,pictureBox165,pictureBox166,pictureBox167,pictureBox168,pictureBox169,pictureBox170,
            pictureBox171,pictureBox172,pictureBox173,pictureBox174,pictureBox175,pictureBox176,pictureBox177,pictureBox178,pictureBox179,pictureBox180,pictureBox181,
            pictureBox182,pictureBox183,pictureBox184,pictureBox185,pictureBox186,pictureBox187,pictureBox188,pictureBox189,pictureBox190,pictureBox191,pictureBox192,
            pictureBox193,pictureBox194,pictureBox195,pictureBox196,pictureBox197,pictureBox198,pictureBox199,pictureBox200,pictureBox201,pictureBox202,pictureBox203,
            pictureBox204,pictureBox205,pictureBox206};


            for (int i = 1; i < 99; i++)
            {
                if (pbb[i].Right >= Player.Left && pbb[i].Top <= Player.Bottom && pbb[i].Bottom >= Player.Top && pbb[i].Left <= Player.Right)
                {
                    for (int j = 0; j < 99; j++)
                    {
                        pbb[j].Visible = false;
                    }
                    for (int k = 0; k < 107; k++)
                    {
                        pbb8[k].Visible = false;
                    }
                    Bsecond.Enabled = false;
                    Slow.Enabled = false;
                    Fast.Enabled = false;
                    Trace.Enabled = false;
                    Second.Enabled = false;
                    Normal.Enabled = false;
                    timer1.Enabled = false;
                    Randd.Enabled = false;
                    BackG.Enabled = false;
                    Nice.Enabled = true;
                    Player.BackColor = Color.Red;
                    Player.Size = new System.Drawing.Size(10, 10);
                    Boom.Enabled = true;
                    CanMove = 0;
                    this.KeyPreview = false;
                }
            }
        }

    }
}

