using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SERVER
{
    class ROOM
    {
        public PLAYER player_M;
        public PLAYER player_S;
        public List<GOLD> lstGold;
        public int room;
        public ROOM()
        {
            lstGold = new List<GOLD>();
        }
        public void Add_Player_M(PLAYER player)
        {
            player_M = player;
        }
        public void Add_Player_S(PLAYER player)
        {
            player_S = player;
        }
        public void Remove_Gold(GOLD a)
        {
            lstGold.Remove(a);
        }
        public void Clear_LstGold()
        {
            lstGold.Clear();
        }
        public void CreatMap()
        {
            for (int i = 0; i < Cons.Number_Gold_Crearted; i++)
            {
                lstGold.Add(new GOLD());
            }
        }
        public void Set_Room_Player_M(int x)
        {
            room = x;
            player_M.Room = x;
           // player_S.Room = x;

        }
        public void Set_Room_Player_S(int x)
        {
          //  room = x;
            player_S.Room = x;

        }
        public void Find_Room(int x)
        {
            
        }

    }
}
