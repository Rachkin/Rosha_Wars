using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject EmptyRoom;
    public GameObject BonusRoom;
    public GameObject StartRoom;
    public GameObject FinshRoom;
    public GameObject FiledRoom;
    private int[][] MAZE;
    public int maze_size;
    private pair bonus;
   // private Random rand = new Random();
    void Start()
    {
        GenMaze();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void GenMaze()
    {
        bool isDone = false;
     //   MapMaze();
        while (!isDone)
        {
            MapMaze();
            isDone = CheckMaze();
        }
        MAZE[0][0] = 3;
        MAZE[maze_size - 1][maze_size - 1] = 4;
        MAZE[bonus.x][bonus.y] = 6;

        BuildMaze();
    }
    void MapMaze()
    {
        Debug.Log("Start Map Maze");

        MAZE = new int[maze_size][];
       // MAZE[0] = new int[maze_size + 2];
       // MAZE[maze_size+1] = new int[maze_size + 2];
       // for (int i = 0; i < maze_size + 2; i++) MAZE[0][i] = 1;
       // for (int i = 0; i < maze_size + 2; i++) MAZE[maze_size+1][i] = 1;
        for (int i = 0; i < maze_size; i++)
        {
            MAZE[i] = new int[maze_size];
          //  MAZE[i][0] = 1;
          //  MAZE[i][maze_size + 1] = 1;
            for (int j = 0; j < maze_size; j++)
            {
                MAZE[i][j] = Random.Range(1, 3);
            }

        }
        MAZE[0][0] = 2;
        MAZE[maze_size - 1][maze_size - 1] = 2;
        bonus.x = Random.Range(1, maze_size-1);
        bonus.y = Random.Range(1, maze_size-1);
        MAZE[bonus.x][bonus.y] = 2;

        Debug.Log("Succesfully Map Maze");
    }
    public struct pair
    {
        public int x;
        public int y;
    }
    bool CheckMaze()
    {
        Queue<pair> que = new Queue<pair>();
        pair v;
        v.x = 0;
        v.y = 0;
        que.Enqueue(v);
        while(que.Count > 0)
        {
            v = que.Peek();
            que.Dequeue();
            if (v.x < 0 || v.x >= maze_size || v.y < 0 || v.y >= maze_size || MAZE[v.x][v.y] != 2) continue;
            MAZE[v.x][v.y] = 0;
            v.x++;
            que.Enqueue(v);
            v.x--;
            v.y++;
            que.Enqueue(v);
            v.y--;
            v.x--;
            que.Enqueue(v);
            v.x++;
            v.y--;
            que.Enqueue(v);
            v.y++;

        }
        if (MAZE[maze_size-1][maze_size-1] == 0 && MAZE[bonus.x][bonus.y] == 0) return true;
        else return false;

    }
    void BuildMaze()
    {
        Debug.Log("Start Build Maze");

        for (int i = 0; i < maze_size; i++)
        {
            for (int j = 0; j < maze_size; j++)
            {
                Vector3 position = new Vector3(i * 3, 0, j * 3);
                if (MAZE[i][j] == 1)
                {
                    Instantiate(FiledRoom, position, Quaternion.identity);
                }
                if (MAZE[i][j] == 0)
                {
                    Instantiate(EmptyRoom, position, Quaternion.identity);
                }
                if(MAZE[i][j] == 3)
                {
                    Instantiate(StartRoom, position, Quaternion.identity);
                }
                if (MAZE[i][j] == 4)
                {
                    Instantiate(FinshRoom, position, Quaternion.identity);
                }
                if (MAZE[i][j] == 5)
                {
                    Instantiate(BonusRoom, position, Quaternion.identity);
                }
                if (MAZE[i][j] == 6)
                {
                    Instantiate(BonusRoom, position, Quaternion.identity);
                }
            }
        }
        for (int j = -1; j < maze_size +1; j++)
        {
            Vector3 position = new Vector3(-1 * 3, 0, j * 3);
            Instantiate(FiledRoom, position, Quaternion.identity);
        }
        for (int j = 1; j < maze_size+1; j++)
        {
            Vector3 position = new Vector3(j * 3, 0, -1 * 3);
            Instantiate(FiledRoom, position, Quaternion.identity);
        }
        for (int j = 0; j < maze_size+1; j++)
        {
            Vector3 position = new Vector3((maze_size) * 3, 0, j * 3);
            Instantiate(FiledRoom, position, Quaternion.identity);
        }
        for (int j = 0; j < maze_size-1; j++)
        {
            Vector3 position = new Vector3(j * 3, 0, (maze_size) * 3);
            Instantiate(FiledRoom, position, Quaternion.identity);
        }
        Debug.Log("Succesfully Build Maze");
    }


}
