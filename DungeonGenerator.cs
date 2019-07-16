using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class DungeonGenerator : MonoBehaviour
{
    List<Room> map;
    public int RoomNum;

    // Start is called before the first frame update
    void Start()
    {
        GenerateDungeon();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
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
            int randWidth = (int) UnityEngine.Random.Range(3.0f, 9.0f);
            int randHeigh = (int) UnityEngine.Random.Range(3.0f, 9.0f);
            //Debug.Log(randWidth);
            //Debug.Log(randHeigh);
            int[] pos = getRandomPointInCircle();
            Room room = new Room(pos[0],pos[1],randWidth, randHeigh);
            map.Add(room);
        }
    }

    int[] getRandomPointInCircle()
    {

        int[] aux = new int[2];
        float radius = 20;
        //float r = radius*Mathf.Sqrt(UnityEngine.Random.Range(0.0f,1.0f));
        //float point = ((2/(radius*radius))*r);
        float theta = (float)(2*Mathf.PI*UnityEngine.Random.Range(0.0f,1.0f));
        float r = (radius * Mathf.Sqrt(UnityEngine.Random.Range(0.0f,1.0f))); 
        int x = (int)(r*Mathf.Cos(theta));
        int y = (int)(r*Mathf.Sin(theta));
        aux[0] = x;
        aux[1] = y;
            Debug.Log(aux[0]);
            Debug.Log(aux[1]);
        return aux;
    }

    void OnDrawGizmos() 
    {	
        if(map != null)	
        {
            foreach(Room rooms in map)
            {
                
                Gizmos.color = Color.grey;
		        Vector3 pos = new Vector3(rooms.posX,0,rooms.posY);
		        Gizmos.DrawCube(pos, new Vector3(rooms.roomWidth,0,rooms.roomHeight));
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
