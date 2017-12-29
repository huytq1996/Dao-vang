using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Net.Sockets;
namespace SERVER
{
    class PLAYER
    {
        public int Mark;
        public bool StatusConnect;
        public SocketModel sk;
        public int Room;
        public bool End;
        //public PLAYER() { };
        public PLAYER(int mark,SocketModel s)
        {

            this.Mark = mark;
            this.sk = s;
            this.StatusConnect = false;
        }
        object lockthis = new object();
        public void SendMap(List<GOLD> Golg)
        {
            String str = "";
            str = str + Cons.Send_map;
            foreach (GOLD p in Golg)
                str =str+ p.GOLDtoString();
           // lock (sk)
            {
                this.sk.SendData(str);
              //  while (sk.ReceiveData()[0] != Cons.Receive_OK) ;//{ this.sk.SendData(str); };
            }
        }
        public void SendGold(Point Golg)
        {
            string str = "";
            str = str + Cons.Send_Golg + Convert.ToString(Golg.X) +','+ Convert.ToString(Golg.Y);
           // lock (sk)
            {
                this.sk.SendData(str);
                //while (sk.ReceiveData() != Cons.Receive_OK) { this.sk.SendData(str); } ;
            }
        }
        public void SendMark(string str)
        {
          //  lock (sk)
            {
                this.sk.SendData(Cons.Send_OpMark + str);
               // while (sk.ReceiveData() != Cons.Receive_OK) { this.sk.SendData(Cons.Send_OpMark + str); };
            }
        }
        public void SendStart()
        {
          //  lock (sk)
            {
                this.sk.SendData(Cons.Send_Start + "");
              //  while (sk.ReceiveData() != Cons.Receive_OK) { this.sk.SendData(Cons.Send_Start + ""); } ;
            }
        }
        public void SendMaster()
        {
          //  lock (sk)
            {
                this.sk.SendData(Cons.Send_Master + "");
              //  while (sk.ReceiveData() != Cons.Receive_OK) { this.sk.SendData(Cons.Send_Master + ""); };
            }
        }
        public void SetRoom(int x)
        {
            this.Room=x;
        }
        public int GetRoom()
        {
            return this.Room ;
        }
        public void SendRoom()
        {
           lock (lockthis)
            {
                sk.SendData(Cons.Send_Room + Convert.ToString(Room));
             //   while (sk.ReceiveData()[0] != Cons.Receive_OK) ;// { sk.SendData(Cons.Send_Room + Convert.ToString(Room)); };
            }
        }
        public void SendReady()
        {
           // lock (sk)
            {
                sk.SendData(Cons.Send_Ready + "");
              //  while (sk.ReceiveData() != Cons.Receive_OK) { sk.SendData(Cons.Send_Ready + ""); } ;
            }
        }
        public void SendDisconnect()
        {
            // lock (sk)
            {
                sk.SendData(Cons.Send_OpDisconnect + "");
                //  while (sk.ReceiveData() != Cons.Receive_OK) { sk.SendData(Cons.Send_Ready + ""); } ;
            }
        }
        public void SendEnd()
        {
            sk.SendData(Cons.Send_End + "");
        }
        public void SendResult(int result)
        {
            if(result==1)
            sk.SendData(Cons.Send_Result+"4");
            if(result == 0)
                sk.SendData(Cons.Send_Result + "5");
            if (result == -1)
                sk.SendData(Cons.Send_Result + "6");
        }
    }
}
