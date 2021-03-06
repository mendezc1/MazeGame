﻿// remember you can NOT have even numbers of height or width in this style of block maze
// to ensure we can get walls around all tunnels...  so use 21 x 13 , or 7 x 7 for examples.

using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class MazeGenerator : MonoBehaviour
{
    public int width, height;
    public Material brick;
    private int[,] Maze;
    private List<Vector3> pathMazes = new List<Vector3>();
    private Stack<Vector2> _tiletoTry = new Stack<Vector2>();
    private List<Vector2> offsets = new List<Vector2> { new Vector2(0, 1), new Vector2(0, -1), new Vector2(1, 0), new Vector2(-1, 0) };
    private System.Random rnd = new System.Random();
    private int _width, _height;
    private Vector2 _currentTile;
    public String MazeString;
    public GameObject player;
    
    /*
    //stupid stuff for time
    float startTime;
    bool reset; 
    */
    public Vector2 CurrentTile
    {
        get { return _currentTile; }
        private set
        {
            if (value.x < 1 || value.x >= this.width - 1 || value.y < 1 || value.y >= this.height - 1)
            {
                throw new ArgumentException("Width and Height must be greater than 2 to make a maze");
            }
            _currentTile = value;
        }
    }
    private static MazeGenerator instance;
    public static MazeGenerator Instance
    {
        get { return instance; }
    }
    void Awake() {
        instance = this;
        
    }
    void Start()
    {
        player = GameObject.FindGameObjectsWithTag("Player")[0];
        //reset = false;
        //startTime = Time.time;
        MakeBlocks();
    }

    // end of main program

    // ============= subroutines ============
    public int get_width()
    {
        return width;
    }

    public int get_height()
    {
        return height;
    }
    void MakeBlocks()
    {
        
        Maze = new int[width, height];
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                Maze[x, y] = 1;
            }
        }
        CurrentTile = Vector2.one;
        _tiletoTry.Push(CurrentTile);
        Maze = CreateMaze();  // generate the maze in Maze Array.
        GameObject ptype = null;
        
        for (int i = 0; i <= Maze.GetUpperBound(0); i++)
        {
            for (int j = 0; j <= Maze.GetUpperBound(1); j++)
            {
                if (Maze[i, j] == 1)
                {

                    MazeString = MazeString + "X";  // added to create String
                    if (i == 0 && j == 1)
                    {
                        create_wall_brick("wall_brick_40_staggered", "Home", new Vector3(-1, 0, 0), new Vector3(.2f, .15f, .2f));
                        create_wall_brick("wall_brick_40_staggered", "Home", new Vector3(-2, 0, 0), new Vector3(.2f, .15f, .2f));
                      //  create_wall_brick("wall_brick_40_staggered", "Home", new Vector3(-2, 0, 1), new Vector3(.2f, .15f, .2f));
                        create_wall_brick("wall_brick_40_staggered", "Home", new Vector3(-2, 0, 2), new Vector3(.2f, .15f, .2f));
                        create_wall_brick("wall_brick_40_staggered", "Home", new Vector3(-1, 0, 2), new Vector3(.2f, .15f, .2f));
                        //   create_wall_brick("wall_brick_40_staggered", "Home", new Vector3(0, 0, 1), new Vector3(.2f, .025f, .2f));
                        //    create_wall_brick("wall_brick_40_staggered", "Home", new Vector3(-1, 0, 1), new Vector3(.2f, .025f, .2f));

                        continue;

                    }
                    else if (i == width-1 && j == height-2) {
                        
                        create_wall_brick("wall_brick_40_staggered", "End", new Vector3(width, 0, height-1), new Vector3(.2f, .15f, .2f));
                        create_wall_brick("wall_brick_40_staggered", "End", new Vector3(width, 0, height-3), new Vector3(.2f, .15f, .2f));
                        create_wall_brick("wall_brick_40_staggered", "End", new Vector3(width+1, 0, height-1), new Vector3(.2f, .15f, .2f));
                        //create_wall_brick("wall_brick_40_staggered", "End", new Vector3(width+1, 0, height-2), new Vector3(.2f, .15f, .2f));
                        create_wall_brick("wall_brick_40_staggered", "End", new Vector3(width+1, 0, height-3), new Vector3(.2f, .15f, .2f));
                       // create_wall_brick("wall_brick_40_staggered", "End", new Vector3(width+3, 0, height-1), new Vector3(.2f, .025f, .2f));
                       // create_wall_brick("wall_brick_40_staggered", "End", new Vector3(width+3, 0, height-2), new Vector3(.2f, .025f, .2f));

                        continue;
                    }
                    ptype = (GameObject)Instantiate(Resources.Load("wall_brick_40_staggered"));
                    ptype.name = "Cube";
                    ptype.isStatic = true;
                    ptype.AddComponent<block_properties>();
                    ptype.AddComponent<BoxCollider>();
                    ptype.GetComponent<BoxCollider>().center = new Vector3(0,20,0);
                    ptype.GetComponent<BoxCollider>().size = new Vector3(40, 40, 40);
                    ptype.tag = "unmarked_block";
                    
                    if (i==0 || i==width-1 || j == 0 || j == height - 1){
                        ptype.tag = "edge_block";
                    }
                    // To increase path distance increase i, j multipliers and localscale at same rate
                    ptype.transform.position = new Vector3(i * 8 * ptype.transform.localScale.x, 0, j * 8 * ptype.transform.localScale.z);
					ptype.transform.localScale = new Vector3(.2f, .15f, .2f);
                    //if (brick != null) { ptype.GetComponent<Renderer>().material = brick; }
                    ptype.transform.parent = transform;
                }
                //creating floors
                else if (Maze[i, j] == 0)
                {
                    MazeString = MazeString + "0"; // added to create String
                    pathMazes.Add(new Vector3(i, 0, j));
/*
                    ptype = (GameObject)Instantiate(Resources.Load("wall_brick_40_staggered"));
                    ptype.name = "Floor";
                
           
                    ptype.isStatic = true;
                    ptype.AddComponent<block_properties>();
                    ptype.AddComponent<BoxCollider>();
                    ptype.GetComponent<BoxCollider>().center = new Vector3(0, 20, 0);
                    ptype.GetComponent<BoxCollider>().size = new Vector3(40, 40, 40);
                    // ptype.tag = "unmarked_floor";

                    // To increase path distance increase i, j multipliers and localscale at same rate
   

                    ptype.transform.position = new Vector3(i *8* ptype.transform.localScale.x, 0, j *8* ptype.transform.localScale.y);
                    //   if (brick != null) { ptype.GetComponent<Renderer>().material = brick; }
                    ptype.transform.localScale = new Vector3(.2f, .2f, .02f);
                    ptype.transform.rotation = Quaternion.Euler(-90, -90, 0);
                    ptype.transform.parent = transform;
*/
                }
            }
            MazeString = MazeString + "\n";  // added to create String
        }
        print(MazeString);  // added to create String
        print(pathMazes[0]);
    }

    // =======================================
    public int[,] CreateMaze()
    {

        //local variable to store neighbors to the current square as we work our way through the maze
        List<Vector2> neighbors;
        //as long as there are still tiles to try
        while (_tiletoTry.Count > 0)
        {
            //excavate the square we are on
            Maze[(int)CurrentTile.x, (int)CurrentTile.y] = 0;
            //get all valid neighbors for the new tile
            neighbors = GetValidNeighbors(CurrentTile);
            //if there are any interesting looking neighbors
            if (neighbors.Count > 0)
            {
                //remember this tile, by putting it on the stack
                _tiletoTry.Push(CurrentTile);
                //move on to a random of the neighboring tiles
                CurrentTile = neighbors[rnd.Next(neighbors.Count)];
            }
            else
            {
                //if there were no neighbors to try, we are at a dead-end toss this tile out
                //(thereby returning to a previous tile in the list to check).
                CurrentTile = _tiletoTry.Pop();
            }
        }
        print("Maze Generated ...");
        return Maze;
    }

    // ================================================
    // Get all the prospective neighboring tiles "centerTile" The tile to test
    // All and any valid neighbors</returns>
    private List<Vector2> GetValidNeighbors(Vector2 centerTile)
    {
        List<Vector2> validNeighbors = new List<Vector2>();
        //Check all four directions around the tile
        foreach (var offset in offsets)
        {
            //find the neighbor's position
            Vector2 toCheck = new Vector2(centerTile.x + offset.x, centerTile.y + offset.y);
            //make sure the tile is not on both an even X-axis and an even Y-axis
            //to ensure we can get walls around all tunnels
            if (toCheck.x % 2 == 1 || toCheck.y % 2 == 1)
            {

                //if the potential neighbor is unexcavated (==1)
                //and still has three walls intact (new territory)
                if (Maze[(int)toCheck.x, (int)toCheck.y] == 1 && HasThreeWallsIntact(toCheck))
                {

                    //add the neighbor
                    validNeighbors.Add(toCheck);
                }
            }
        }
        return validNeighbors;
    }
    // ================================================
    // Counts the number of intact walls around a tile
    //"Vector2ToCheck">The coordinates of the tile to check
    //Whether there are three intact walls (the tile has not been dug into earlier.
    private bool HasThreeWallsIntact(Vector2 Vector2ToCheck)
    {

        int intactWallCounter = 0;
        //Check all four directions around the tile
        foreach (var offset in offsets)
        {

            //find the neighbor's position
            Vector2 neighborToCheck = new Vector2(Vector2ToCheck.x + offset.x, Vector2ToCheck.y + offset.y);
            //make sure it is inside the maze, and it hasn't been dug out yet
            if (IsInside(neighborToCheck) && Maze[(int)neighborToCheck.x, (int)neighborToCheck.y] == 1)
            {
                intactWallCounter++;
            }
        }
        //tell whether three walls are intact
        return intactWallCounter == 3;
    }

    // ================================================
    private bool IsInside(Vector2 p)
    {
        //return p.x >= 0  p.y >= 0  p.x < width  p.y < height;
        return p.x >= 0 && p.y >= 0 && p.x < width && p.y < height;
    }
    void Update()
    {
      /*
      //regenerates maze after X seconds 
      if(Time.time - startTime >= 10)
        {
            startTime = Time.time;
            destroy_unmarked_blocks();

            MakeBlocks();
            clear_path();
        }
      */
        
        if (Input.GetKeyDown("1"))
        {
            //print("keyPressed");
            //destroy_unmarked_blocks();
            //MakeBlocks();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
        }

    }
    //destory all blocks that haven't been marked with chalk (i.e. items with tag "unmarked_block")
   

    void create_wall_brick(string resource, string tag, Vector3 position, Vector3 scale)
    {
        GameObject ptype = (GameObject)Instantiate(Resources.Load(resource));
        ptype.name = "StartOrEnd";
        ptype.isStatic = true;
        ptype.AddComponent<block_properties>();
        ptype.AddComponent<BoxCollider>();
        ptype.GetComponent<BoxCollider>().center = new Vector3(0, 20, 0);
        ptype.GetComponent<BoxCollider>().size = new Vector3(40, 40, 40);
        ptype.tag = tag;
        // To increase path distance increase i, j multipliers and localscale at same rate
        ptype.transform.position = new Vector3 (position.x *8 * ptype.transform.localScale.x, 0, position.z *8 * ptype.transform.localScale.x) ;
        ptype.transform.localScale = scale;
        //if (brick != null) { ptype.GetComponent<Renderer>().material = brick; }
        ptype.transform.parent = transform;
    }
    
}
