using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Fungus;

using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager1 : MonoBehaviour
{

    //定数定義：壁方向
    public const int WALL_FRONT = 1;
    public const int WALL_RIGHT = 2;
    public const int WALL_BACK = 3;
    public const int WALL_LEFT = 4;

   

 

    public GameObject panelWalls;
    public GameObject panelRule1;
    public GameObject panelRule2;
    public GameObject panelAll;
    public GameObject ButtonRight;
    public GameObject ButtonLeft;

    public Flowchart flowchart;


    private int wallNo;
    private TitleManager titlemanager;
   
    



    void Start()
    {
        wallNo = WALL_FRONT;
       
        GlobalManager.SetContinueflag(2);



    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PushButtonAoi()
    {
        flowchart.ExecuteBlock("アオイ　人");
    }

    public void PushButtonReturn1()
    {
        panelRule1.SetActive(false);
        panelRule2.SetActive(true);
    }

    public void PushButtonReturn2()
    {
        panelRule2.SetActive(false);
        panelRule1.SetActive(true);
    }



    //右ボタンを押した
    public void PushButtonRight()
    {

        wallNo++;
        if (wallNo >= WALL_LEFT)
        {

            ButtonRight.SetActive(false);
            ButtonLeft.SetActive(true);
            wallNo = WALL_LEFT;
        }
        else
        {
            ButtonRight.SetActive(true);
            ButtonLeft.SetActive(true);
        }
        DisplayWall();
        ClearButtons();

    }

    //左ボタンを押した
    public void PushButtonLeft()
    {
        wallNo--;
        if (wallNo <= WALL_FRONT)
        {
            ButtonLeft.SetActive(false);
            ButtonRight.SetActive(true);
            wallNo = WALL_FRONT;
        }
        else
        {
            ButtonLeft.SetActive(true);
            ButtonRight.SetActive(true);
        }
        DisplayWall();
        ClearButtons();

    }



    //各種表示をクリア
    public void ClearButtons()
    {
        if (panelRule1.activeSelf || panelRule2.activeSelf)
        {
            panelRule1.SetActive(false);
            panelRule2.SetActive(false);
            panelAll.SetActive(false);
        }
    }

   

    //向いている壁の方向を表示
    void DisplayWall()
    {
        switch (wallNo)
        {
            case WALL_FRONT:
                panelWalls.transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
                break;
            case WALL_RIGHT:
                panelWalls.transform.localPosition = new Vector3(-1000.0f, 0.0f, 0.0f);
                break;
            case WALL_BACK:
                panelWalls.transform.localPosition = new Vector3(-2000.0f, 0.0f, 0.0f);
                break;
            case WALL_LEFT:
                panelWalls.transform.localPosition = new Vector3(-3000.0f, 0.0f, 0.0f);
                break;

        }
    }



}