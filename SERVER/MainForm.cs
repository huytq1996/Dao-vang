/*
 * Created by SharpDevelop.
 * User: chepchip
 * Date: 4/18/2017
 * Time: 12:18 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Threading;


namespace SERVER
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		public MainForm()
		{
			InitializeComponent();
		}
		
		void MainFormLoad(object sender, EventArgs e)
		{
			CheckForIllegalCrossThreadCalls = false;
		}
        private List<ROOM> lstROOM = new List<ROOM>();
       // private PLAYER []player=new PLAYER[2];
		private TCPModel tcp;
		//private SocketModel[] socket = new SocketModel[100];
		//private int soClientHienTai = 0;
     //   private int soRoomHienTai = 0;
     //   List<GOLD> lstGolg = new List<GOLD>();
       // bool flagservice = true;
        // private int status=0;
        object lockth = new object();
        ROOM FindRoom()
        {
            ROOM room;
            room = lstROOM.Find(x => x.player_S == null);
            return room;
        }

        GOLD Collision(Point pt,ROOM room)
        {
            return room.lstGold.Find(x => x.pos == pt); 
        }
        void HandleClient(PLAYER play, String str)
        {
            ROOM roomofplay = lstROOM.Find(x => x.room == play.Room);
            if (str[0] == Cons.Receive_End)
            {
                play.End = true;
                if (roomofplay.player_M.End == true && roomofplay.player_S.End == true)
                {
                    if (roomofplay.player_S.Mark > roomofplay.player_M.Mark)
                    {
                        roomofplay.player_S.SendResult(1);
                        roomofplay.player_M.SendResult(-1);
                    }
                    if (roomofplay.player_S.Mark < roomofplay.player_M.Mark)
                    {
                        roomofplay.player_S.SendResult(-1);
                        roomofplay.player_M.SendResult(1);
                    }
                    if (roomofplay.player_S.Mark == roomofplay.player_M.Mark)
                    {
                        roomofplay.player_S.SendResult(0);
                        roomofplay.player_M.SendResult(0);
                    }
                    roomofplay.lstGold.Clear();
                    roomofplay.player_S.SendEnd();
                    roomofplay.player_M.SendEnd();
                    roomofplay.player_M.End = false;
                    roomofplay.player_S.End = false;
                    roomofplay.CreatMap();
                 

                }
                return;
            }
            if (str[0] == Cons.Receive_Ready)
            {
                roomofplay.player_M.SendReady();
                Thread.Sleep(15);
                roomofplay.player_M.SendMap(roomofplay.lstGold);
                Thread.Sleep(15);
                //   Thread.Sleep(15);
                roomofplay.player_S.SendMap(roomofplay.lstGold);
                Thread.Sleep(15);
                return;
            }
            if (str[0] == Cons.Receive_Start)
            {
                roomofplay.player_M.SendStart();
                roomofplay.player_S.SendStart();
                return;
            }
            if (str[0] == Cons.Receive_CanCau)
            {
                str = str.Substring(1);
                string[] arrListStr = str.Split(',');
                Point pt = new Point(Int32.Parse(arrListStr[0]), Int32.Parse(arrListStr[1]));
                GOLD remove = new GOLD();
                
                //  lock (lstGolg)
                {
                    remove = Collision(pt,roomofplay);

                    if (remove != null)
                    {

                        if (play == roomofplay.player_M)
                        {
                            
                            roomofplay.player_S.SendGold(remove.pos);
                        }
                        else
                        {
                            roomofplay.player_M.SendGold(remove.pos);
                        }
                       
                        roomofplay.Remove_Gold(remove);
                    }
                }
                return;
            }
            if(str[0] == Cons.Receive_MyMark)
            {

                str = str.Substring(1);
                if (play == roomofplay.player_M)
                {
                   roomofplay.player_S.SendMark(str);

                }
                else
                {
                    roomofplay.player_M.SendMark(str);
                }
                play.Mark = Int32.Parse(str);
                return;
            }
            
        }
	/*	void CreatMap()
        {
            for (int i = 0; i < Cons.Number_Gold_Crearted; i++)
            {
                lstGolg.Add(new GOLD());
            }
        }*/
        void PhucVuPlayer(Object obj)
        {
            string str1 = "";
            PLAYER player = (PLAYER)obj;
            ROOM roomofplay = lstROOM.Find(x => x.room == player.Room);
            while (true)
            {
                //nhan yeu cau va cap nhat giao dien			
                //  while (flagservice) ;
            //    lock (player.sk)
                {
                    str1 = player.sk.ReceiveData();
                    lock (lockth)
                    {
                        
                        if (str1.StartsWith("Socket is closed with") == true)
                        {
                            player.sk.CloseSocket();
                            if(roomofplay.player_M==player&& roomofplay.player_S==null)
                            {
                                lstROOM.Remove(roomofplay);
                                return;
                            }
                            if (roomofplay.player_M == player)
                            {
                                roomofplay.player_M = roomofplay.player_S;
                                roomofplay.player_M.sk.SendData(Cons.Send_Master + "");
                                roomofplay.player_S = null;
                                roomofplay.player_M.StatusConnect = true;
                                roomofplay.player_M.SendDisconnect();
                            }

                            else
                            {
                                roomofplay.player_S = null;
                                roomofplay.player_M.SendDisconnect();
                            }
                            return;
                        }
                        HandleClient(player, str1);
                    }
                    textBox4.AppendText(str1 + "\n");

                }
            }
        }
        public void PhucVuYeuCauRoom(Object obj)
        {
            ROOM room = (ROOM)obj;
            //  string str1 = "";
            //phuc vu client nhieu lan
            if (room.player_M.StatusConnect != true)
            {
                Thread p1 = new Thread(PhucVuPlayer);
                p1.Start(room.player_M);
            }
            Thread p2 = new Thread(PhucVuPlayer);
            p2.Start(room.player_S);
        }
 
       /* public void ChapNhanKetNoi()
        {
            //chap nhan ket noi
            ROOM room = new ROOM();
           // PLAYER Player1=new PLAYER(),Player2 = new PLAYER();
            int status = -1;
            String str = "";
            int NumberofPlayer = 0;
            while (NumberofPlayer < 2)
            {
                Socket s = tcp.SetUpANewConnection(ref status);
                SocketModel   socket = new SocketModel(s);
                str = str + socket.GetRemoteEndpoint() + "\n";
                textBox3.AppendText(str);
                textBox3.Update();
                if(FindRoom()==null)
                    if (soClientHienTai % 2 == 0)
                    {
                        room.Add_Player_M(new PLAYER(0, socket));
                        room.player_M.SendMaster();
                        Thread.Sleep(15);
                    
                    }
                    else
                    {
                        room.Add_Player_S(new PLAYER(0, socket));
                        Thread.Sleep(15);
                    
                      //  Thread.Sleep(15);
                    }
                else
                {
                    room.Add_Player_S(new PLAYER(0, socket));
                    Thread.Sleep(15);
                }
                soClientHienTai++;
                NumberofPlayer++;
            }
            //cap nhat giao dien
          //  string a = "9";
            room.Set_Room(soRoomHienTai);
            room.player_M.SendRoom();
            Thread.Sleep(15);
            // while (room.player_M.sk.ReceiveData() != a) ;
            room.player_S.SendRoom();
            Thread.Sleep(15);
            // while (room.player_S.sk.ReceiveData() != a) ;
            room.CreatMap();
            room.player_M.SendMap(room.lstGold);
            Thread.Sleep(15);
            //   Thread.Sleep(15);
            room.player_S.SendMap(room.lstGold);
            Thread.Sleep(15);
            // Thread.Sleep(15);

            lstROOM.Add(room);
            soRoomHienTai++;
            
        }*/
        public void AcceptConnect()
        {
            ROOM room;
            int status = -1;
            Socket s = tcp.SetUpANewConnection(ref status);
            SocketModel socket = new SocketModel(s);
            String str = "";
            str = str + socket.GetRemoteEndpoint() + "\n";
            textBox3.AppendText(str);
            textBox3.Update();
            room = FindRoom();
            if (room == null)
            {
                room = new ROOM();
                room.Add_Player_M(new PLAYER(0, socket));
                room.player_M.SendMaster();
                Thread.Sleep(15);
           
                Thread.Sleep(15);
                lstROOM.Add(room);
                room.Set_Room_Player_M(lstROOM.Count);
                room.player_M.SendRoom();
            }
            else
            {
                room.Add_Player_S(new PLAYER(0, socket));
                Thread.Sleep(15);
                room.Set_Room_Player_S(room.player_M.Room);
                // while (room.player_M.sk.ReceiveData() != a) ;
                room.player_S.SendRoom();
                Thread.Sleep(15);
                // while (room.player_S.sk.ReceiveData() != a) ;
                room.Clear_LstGold();
                room.CreatMap();
                room.player_M.SendMap(room.lstGold);
                Thread.Sleep(15);
                //   Thread.Sleep(15);
                room.player_S.SendMap(room.lstGold);
                Thread.Sleep(15);
                // Thread.Sleep(15);
                Thread t = new Thread(PhucVuYeuCauRoom);
                t.Start(room);
            }
        }
        public void MultiScript(){
            //Phuc vu nhieu PHIEN client
            
			while (true)
            {
                //Step 2.1: Cho va chap nhan ket noi tu client

                AcceptConnect();
				//Step 2.2: Phuc vu yeu cau	
			//	Thread t = new Thread(PhucVuYeuCauRoom);
			//	t.Start(soRoomHienTai-1);		
                
			}
    
           // flagservice = false;
        }
        public void KhoiDongServer()
        {
            tcp = new TCPModel(textBox1.Text, int.Parse(textBox2.Text));
            button1.Enabled = false;
            tcp.Listen();
        }
        void Button1Click(object sender, EventArgs e)
		{
			//Step 1: Bat server
			KhoiDongServer();
			//Step 2: Chap nhan ket noi va phuc vu yeu cau
			//--- Phai bo vao thread vi step 2.1 se lam treo may (doi client moi ket noi) ---//
			Thread t = new Thread(MultiScript);
			t.Start();
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
