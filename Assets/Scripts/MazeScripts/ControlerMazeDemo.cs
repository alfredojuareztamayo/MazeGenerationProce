using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ControlerMazeDemo : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] MazeScripts;
    private Crawler mCrawler;
    private Prims mPrims;
    private Recursive mRecursive;
    private StackMaze mStackMaze;
    private Wilson mWilson;
    private WilsonWithRooms mRooms;

    bool CreateMaze = false;
    bool ResetMaze = false;
    bool DestroyMaze = false;
    int iterMaze = 0;
    public TMP_Text text;
    public string[] MazeNames;
    void Start()
    {
        mCrawler = MazeScripts[0].GetComponent<Crawler>();
        mPrims = MazeScripts[1].GetComponent<Prims>();
        mRecursive = MazeScripts[2].GetComponent<Recursive>();
        mStackMaze = MazeScripts[3].GetComponent<StackMaze>();
        mWilson = MazeScripts[4].GetComponent<Wilson>();
        mRooms = MazeScripts[5].GetComponent<WilsonWithRooms>();
        //text.text = MazeNames[iterMaze];
        //iterMaze++;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            iterMaze = (iterMaze + 1)% MazeNames.Length;
            text.text = MazeNames[iterMaze];
        }
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
        if(Input.GetKeyDown(KeyCode.X) && DestroyMaze)
        {
            mCrawler.DestroyMaze();
            mPrims.DestroyMaze();
            mRecursive.DestroyMaze();
            mStackMaze.DestroyMaze();
            mWilson.DestroyMaze();
            mRooms.DestroyMaze();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            CreateMaze = true;
            ResetMaze = true;
            DestroyMaze = true;
        }
    }
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
