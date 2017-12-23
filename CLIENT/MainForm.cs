/*
 * Created by SharpDevelop.
 * User: chepchip
 * Date: 4/18/2017
 * Time: 1:28 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
namespace CLIENT
{
    /// <summary>
    /// Description of MainForm.
    /// </summary>
    public partial class MainForm : Form
    {
        public MainForm()
        {
            //
            // The InitializeComponent() call is required for Windows Forms designer support.
            //
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            //System.Diagnostics.Process.GetCurrentProcess().PriorityClass = System.Diagnostics.ProcessPriorityClass.RealTime;

            //
            // TODO: Add constructor code after the InitializeComponent() call.
            //
        }
        volatile bool flagRuncancau = true;
        volatile bool flagdraw = false;
        volatile bool flagReady = false;
       // int My_Mark=0, Op_Mark=0;
        List<GOLD> lstGold = new List<GOLD>();
        private TCPModel tcp;
        bool master = false;
        object lockthis = new object();
        void refresh()
        {
            //lock (clockthis)
            { panel1.Refresh(); }
        }
        void Remove_Gold(GOLD a)
        {
            lock (lockthis)
            {
                lstGold.Remove(a);
            }
        }
        void Clear_LstGold()
        {
            lock (lockthis)
            {
                lstGold.Clear();
            }
        }
        void Clear_Panel1()
        {
            lock(lockthis)
            {
                panel1.Controls.Clear();
            }
        }
        void Run(object speed)
        {
            Point po ;
            int t = 1;
           

            while (true)
            {
             
                textBox3.Text = cancau.Location.ToString();
                while (flagReady == false) ;
                while (!flagRuncancau)
                {
                };
                po = cancau.Location;
                po.X = po.X + t;
                if (po.X == (panel5.Width - cancau.Width + 1) || po.X == -1)
                {
                    t = -t;
                }
                cancau.Location = po;
                Thread.Sleep(Cons.Speed_Cancau);
            }
        }
        void Addgold(String strgold)
        {
            string[] arrListStr = strgold.Split(',');
            GOLD gold = new GOLD(Int32.Parse(arrListStr[0]), Int32.Parse(arrListStr[1]), Int32.Parse(arrListStr[2]));
            lstGold.Add(gold); 
        }
        void HandleReceive(String str)
        {
            if(str[0]==Cons.Receive_OpDisconnect)
            {
                flagReady = false;
                panel3.Invoke((MethodInvoker)delegate
                {
                    //perform on the UI thread
                    label7.Visible = true;
                });
                //  
                btdao.Enabled = false;
                flagRuncancau = false;
                flagdraw = false;
                Clear_Panel1();
                Clear_LstGold();
                refresh();
                Thread.Sleep(1000);
                return;
            }
            if(str[0] == Cons.Receive_Ready)
            {
                btbatdau.Enabled = true;

                panel3.Invoke((MethodInvoker)delegate
                {
                    //perform on the UI thread
                    label7.Visible = false;
                });
                return;
            }
            if (str[0] == Cons.Receive_Room)
            {
                str = str.Substring(1);
                Room.Text = "Phong: "+str;
                tcp.SendData(Cons.Send_OK+"");
                return;
            }
            if (str[0] == Cons.Receive_Master)
            {
                master = true;
                btbatdau.Text = "Bắt đầu";
                btbatdau.Enabled = false;
                return;
            }
            if (str[0] == Cons.Receive_Start)
            {
                btbatdau.Enabled = false;
                flagRuncancau = true;
                flagReady = true;
                //timer1.Enabled = true;
                //timer1.Start();
                drawmap(lstGold);
                btdao.Enabled = true;
                BoxMyMark.Text = "0";
                return;
            }
            if (str[0] == Cons.Receive_Golg)
            {
                str = str.Substring(1);
                string[] arrListStr = str.Split(',');
                Point pt = new Point(Int32.Parse(arrListStr[0]), Int32.Parse(arrListStr[1]));
                GOLD remove = new GOLD(0,0,0);
                remove = lstGold.Find(x => x.pos == pt);
                if (remove != null)
                {
                    Remove_Gold(remove);
                    remove.lb.Visible = false;
                }
                return;
            }
            if (str[0] == Cons.Receive_map)
            {
                int i = 0;
                Clear_LstGold();
                Clear_Panel1();
                str = str.Substring(1);
                string[] arrListStr = str.Split('.');
                lock (lockthis)
                {
                    while (arrListStr.Length - 1 > i)
                    {
                        Addgold(arrListStr[i]);
                        i++;
                    }
                }
              //  tcp.SendData(Cons.Send_OK+"");
                return;
            }
            if (str[0] == Cons.Receive_OpMark)
            {
                str = str.Substring(1);
                BoxOpMark.Text = str;

                return;
            }

        }
        void drawmap(List<GOLD> gold)
        {
                panel1.Controls.Clear();
                for (int i = 0; i < gold.Count; i++)
                    //  panel1.Controls.Add(gold[i].lb);
                    panel1.Invoke((MethodInvoker)delegate
                    {
                    //perform on the UI thread
                    panel1.Controls.Add(gold[i].lb);
                    });
        }
    
        void AddMark(GOLD g)
        {
            BoxMyMark.Text = Convert.ToString(Int32.Parse(BoxMyMark.Text) + g.value);
        }
        GOLD Colligent(Point pt)
        {
            GOLD result;
            lock (lockthis)
            {
                result = lstGold.Find(
                delegate (GOLD bk)
                {
                    return ((bk.pos.Y == pt.Y) && (pt.X <= bk.pos.X + Cons.width_gold) && (pt.X >= bk.pos.X));
                }

            );
            }
            return result;
        }
        void dawnstrain()
        {
            Point start, run, end;
            int t;
            Pen pen = new Pen(Color.Red, 2);
            Pen pen1 = new Pen(Color.White, 2);
            Graphics g = panel1.CreateGraphics();
            GOLD tem=new GOLD(1,1,1);
            int t1,t2;
            while (true)
            {
              Label:  while (!flagdraw) ;
                t = 1;
                start = new Point(cancau.Location.X + cancau.Width / 2, 0);
                run = new Point(start.X, start.Y + 2);
                end = new Point(start.X, start.Y + panel1.Height);
                tem = Colligent(run);
                t1 = 0;
                t2 = 0;
                while (run.Y >= start.Y + 2)
                {
                    if (flagdraw == false)
                        goto Label;
                    if (t == 1)
                        g.DrawLine(pen, start, run);
                    else
                        g.DrawLine(pen1, end, run);
                    Thread.Sleep(Cons.SpeedThaCau);
                    if (tem == null)
                    {
                        if (t2 == 0)
                            tem = Colligent(run);
                    }
                    else
                    {
                        if (t1 == 0)
                        {
                            tcp.SendData(Cons.Send_CanCau + Convert.ToString(tem.lb.Location.X) + "," + tem.lb.Location.Y);
                            t1 = 1;
                            t2 = 1;
                        }
                        t = -1;
                        tem.setlb(tem.lb.Location.Y +t);
                    }
                    run.Y = run.Y + t;
                    if (run.Y == end.Y)
                        t = -1;
                }
                try
                {
                    if (tem.pos != tem.lb.Location)
                    {
                        AddMark(tem);
                        tem.lb.Visible = false;
                        Remove_Gold(tem);
                    }
                }
                catch
                {
                    Console.Write("ko co vang");
                }
                flagRuncancau = true;
                btdao.Enabled = true;
                flagdraw = false;
                refresh();
            }
        }
        
        private void nhandulieu(object o)
        {
            String str="";
            while (true)
            {
                str = tcp.ReadData();
               
                HandleReceive(str);
             //   tcp.SendData("OK");
            }
        }
    
        void ConnectClick(object sender, System.EventArgs e)
        {
            //Step 1: Ket noi toi server
            tcp = new TCPModel(textBox1.Text, int.Parse(textBox2.Text));
            int flag = tcp.ConnectToServer();
            btconnect.Enabled = false;
            btbatdau.Enabled = true;
            label7.Visible = false;
            progressBar1.Value = 0;
            Thread t = new Thread(nhandulieu);
            //t.Priority = ThreadPriority.AboveNormal;
            t.Start();

            Thread t1 = new Thread(dawnstrain);
           // t1.Priority = ThreadPriority.Normal;
            t1.Start();

            flagRuncancau = false;
            Thread t2 = new Thread(Run);
            //t2.Priority = ThreadPriority.Lowest;
            t2.Start();
        }
        private void btdao_Click(object sender, EventArgs e)
        {
            btdao.Enabled = false;
            flagRuncancau = false;
            flagdraw = true;
         
        }
        private void BoxMyMark_TextChanged(object sender, EventArgs e)
        {
            if(progressBar1.Value!=0)
            tcp.SendData(Cons.Send_MyMark + BoxMyMark.Text);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (flagReady == false)
                return;

            if (progressBar1.Value <= 0)
            {

                flagReady = false;
                flagRuncancau = false;
                flagdraw = false;
                timer1.Enabled = false;
                Clear_Panel1();
                Clear_LstGold();
                refresh();
                btdao.Enabled = false;
                Thread.Sleep(1000);
                if (Int32.Parse(BoxMyMark.Text) > Int32.Parse(BoxOpMark.Text))
                    MessageBox.Show("Bạn đã thắng"); 
                if (Int32.Parse(BoxMyMark.Text) == Int32.Parse(BoxOpMark.Text))
                    { MessageBox.Show("Hai người đã hòa"); }
                if (Int32.Parse(BoxMyMark.Text) > Int32.Parse(BoxOpMark.Text))
                   { MessageBox.Show("Bạn đã thua"); }
                if (master == false)
                    btbatdau.Enabled = true;
                tcp.SendData(Cons.Send_End + "");
            }
            else
            {
                progressBar1.Value--;
                lbtime.Text = progressBar1.Value.ToString();
            }
        }
     
   

        private void btbatdau_Click(object sender, EventArgs e)
        {
            cancau.Location = new Point(0, 0);
            progressBar1.Maximum = Cons.Time_Play;
            progressBar1.Value = Cons.Time_Play;
            lbtime.Text = Convert.ToString(Cons.Time_Play);
            timer1.Enabled = true;
            timer1.Start();
            btbatdau.Enabled = false;
            btdao.Enabled = false;
            if (master == false)
                tcp.SendData(Cons.Send_Ready+"");
            else
                tcp.SendData(Cons.Send_Start + "");
        }

    }
}
