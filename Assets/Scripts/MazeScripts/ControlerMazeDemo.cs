using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ControlerMazeDemo : MonoBehaviour
{
    /// Array to hold different maze generation script references
    public GameObject[] MazeScripts;

    // References to different maze generation components
    private Crawler mCrawler;
    private Prims mPrims;
    private Recursive mRecursive;
    private StackMaze mStackMaze;
    private Wilson mWilson;
    private WilsonWithRooms mRooms;
    // Flags to control maze creation, resetting, and destruction
    bool CreateMaze = false;
    bool ResetMaze = false;
    bool DestroyMaze = false;
    int iterMaze = 0; // Index to track current maze generation algorithm
    public TMP_Text text; // Text component to display current maze algorithm name
    public string[] MazeNames; // Names of the maze algorithms for display
    /// <summary>
    /// Initializes maze generation components and sets up the initial state.
    /// Called when the script instance is being loaded.
    /// </summary>
    void Start()
    {
        // Initialize maze generation components from the array
        mCrawler = MazeScripts[0].GetComponent<Crawler>();
        mPrims = MazeScripts[1].GetComponent<Prims>();
        mRecursive = MazeScripts[2].GetComponent<Recursive>();
        mStackMaze = MazeScripts[3].GetComponent<StackMaze>();
        mWilson = MazeScripts[4].GetComponent<Wilson>();
        mRooms = MazeScripts[5].GetComponent<WilsonWithRooms>();
        // Optionally set initial text here (commented-out)
        // text.text = MazeNames[iterMaze];
        //iterMaze++;
    }
    /// <summary>
    /// Handles user input to switch maze generation algorithms and manage maze creation, resetting, and destruction.
    /// Called once per frame.
    /// </summary>
    // Update is called once per frame
    void Update()
    {
        // Switch maze generation algorithm when 'E' key is pressed
        if (Input.GetKeyDown(KeyCode.E))
        {
            iterMaze = (iterMaze + 1)% MazeNames.Length;
            text.text = MazeNames[iterMaze];
        }
        // Create maze when 'Q' key is pressed and CreateMaze flag is true
        if (Input.GetKeyDown(KeyCode.Q) && CreateMaze) 
        {
            switch (iterMaze)
            {
                case 0:
                    mCrawler.CreateMaze();
                    mPrims.DestroyMaze();
                    mRecursive.DestroyMaze();
                    mStackMaze.DestroyMaze();
                    mWilson.DestroyMaze();
                    mRooms.DestroyMaze();
                    break;
                case 1:
                    mCrawler.DestroyMaze();
                    mPrims.CreateMaze();
                    mRecursive.DestroyMaze();
                    mStackMaze.DestroyMaze();
                    mWilson.DestroyMaze();
                    mRooms.DestroyMaze();
                    //Debug.Log("Im Prim");
                    break;
                case 2:
                    mCrawler.DestroyMaze();
                    mPrims.DestroyMaze();
                    mRecursive.CreateMaze();
                    mStackMaze.DestroyMaze();
                    mWilson.DestroyMaze();
                    mRooms.DestroyMaze();
                    break;
                case 3:
                    mCrawler.DestroyMaze();
                    mPrims.DestroyMaze();
                    mRecursive.DestroyMaze();
                    mStackMaze.CreateMaze();
                    mWilson.DestroyMaze();
                    mRooms.DestroyMaze();
                    break;
                case 4:
                    mCrawler.DestroyMaze();
                    mPrims.DestroyMaze();
                    mRecursive.DestroyMaze();
                    mStackMaze.DestroyMaze();
                    mWilson.CreateMaze();
                    mRooms.DestroyMaze();
                    break;
                case 5:
                    mCrawler.DestroyMaze();
                    mPrims.DestroyMaze();
                    mRecursive.DestroyMaze();
                    mStackMaze.DestroyMaze();
                    mWilson.DestroyMaze();
                    mRooms.CreateMaze();
                    break;
            }

        }
        // Reset maze when 'R' key is pressed and ResetMaze flag is true
        if (Input.GetKeyDown(KeyCode.R) && ResetMaze)
        {
            switch (iterMaze)
            {
                case 0:
                    mCrawler.ResetMaze();
                    mPrims.DestroyMaze();
                    mRecursive.DestroyMaze();
                    mStackMaze.DestroyMaze();
                    mWilson.DestroyMaze();
                    mRooms.DestroyMaze();
                    break;
                case 1:
                    mCrawler.DestroyMaze();
                    mPrims.ResetMaze();
                    mRecursive.DestroyMaze();
                    mStackMaze.DestroyMaze();
                    mWilson.DestroyMaze();
                    mRooms.DestroyMaze();
                    break;
                case 2:
                    mCrawler.DestroyMaze();
                    mPrims.DestroyMaze();
                    mRecursive.ResetMaze();
                    mStackMaze.DestroyMaze();
                    mWilson.DestroyMaze();
                    mRooms.DestroyMaze();
                    break;
                case 3:
                    mCrawler.DestroyMaze();
                    mPrims.DestroyMaze();
                    mRecursive.DestroyMaze();
                    mStackMaze.ResetMaze();
                    mWilson.DestroyMaze();
                    mRooms.DestroyMaze();
                    break;
                case 4:
                    mCrawler.DestroyMaze();
                    mPrims.DestroyMaze();
                    mRecursive.DestroyMaze();
                    mStackMaze.DestroyMaze();
                    mWilson.ResetMaze();
                    mRooms.DestroyMaze();
                    break;
                case 5:
                    mCrawler.DestroyMaze();
                    mPrims.DestroyMaze();
                    mRecursive.DestroyMaze();
                    mStackMaze.DestroyMaze();
                    mWilson.DestroyMaze();
                    mRooms.ResetMaze();
                    break;
            }

        }
        // Destroy maze when 'X' key is pressed and DestroyMaze flag is true
        if (Input.GetKeyDown(KeyCode.X) && DestroyMaze)
        {
            mCrawler.DestroyMaze();
            mPrims.DestroyMaze();
            mRecursive.DestroyMaze();
            mStackMaze.DestroyMaze();
            mWilson.DestroyMaze();
            mRooms.DestroyMaze();
        }
    }
    /// <summary>
    /// Sets flags to enable maze creation, resetting, and destruction when the player enters the trigger zone.
    /// </summary>
    /// <param name="other">The collider that entered the trigger zone.</param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            CreateMaze = true;
            ResetMaze = true;
            DestroyMaze = true;
        }
    }
    /// <summary>
    /// Resets flags to disable maze creation, resetting, and destruction when the player exits the trigger zone.
    /// </summary>
    /// <param name="other">The collider that exited the trigger zone.</param>
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            CreateMaze = false;
            ResetMaze = false;
            DestroyMaze = false;
        }
    }
}
