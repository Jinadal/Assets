using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonGenerator : MonoBehaviour
{
    List<Room> map;
    public int RoomNum;

    // Start is called before the first frame update
    void Start()
    {
        GenerateDungeon();
    }

    void GenerateDungeon()
    {
        map = new List<Room>();
        GenerateRooms();
    }

    void GenerateRooms()
    {
        for(int i = 0; i < RoomNum; i++)
        {
            int randWidth = (int) Random.Range(3.0f, 9.0f);
            int randHeigh = (int) Random.Range(3.0f, 9.0f);
            Debug.Log(randWidth);
            Debug.Log(randHeigh);
            Room room = new Room(2,2,randWidth, randHeigh);
            map.Add(room);
        }
    }

    void OnDrawGizmos() 
    {	
        int count = 0;
        if(map != null)	
        {
            foreach(Room rooms in map)
            {
                
                Gizmos.color = Color.grey;
		        Vector3 pos = new Vector3(count*count,0,count*count);
		        Gizmos.DrawCube(pos, new Vector3(rooms.roomWidth,0,rooms.roomHeight));
                count++;
            }
        }
	}


    class Room
    {
        public int roomWidth;
        public int roomHeight;
        public int posX;
        public int posY;

        public Room( int _posX, int _posY, int _roomWidth, int _roomHeight)
        {
            roomWidth = _roomWidth;
            roomHeight= _roomHeight;
            posX = _posX;
            posY = _posY;
        }
    }
}
