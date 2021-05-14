using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using UnityEngine.UI;
using Fungus;

public class GameManager13 : MonoBehaviour
{

    //定数定義：壁方向
    public const int WALL_FRONT = 1;
    public const int WALL_RIGHT = 2;


    public GameObject buttonTagu;
    public GameObject buttonTaguue;

    public Flowchart flowchart;
    public GameObject panelWalls;

    public GameObject ButtonRight;
    public GameObject ButtonLeft;

    private int wallNo;

    // Use this for initialization
    void Start()
    {
        wallNo = WALL_FRONT;
    }
    
    // Update is called once per frame
    void Update()
    {

    }

    public void PushButtonTagu()
    {
        flowchart.ExecuteBlock("Tagu");
        buttonTagu.SetActive(false);
        buttonTaguue.SetActive(true);
    }

    public void PushButtonTaguue()
    {
        flowchart.ExecuteBlock("Tagu");
        buttonTaguue.SetActive(false);
        buttonTagu.SetActive(true);
    }


    public void PushButtonKyaku1()
    {
        flowchart.ExecuteBlock("Kyaku1");
    }

    public void PushButtonKyaku2()
    {
        flowchart.ExecuteBlock("Kyaku2");
    }

    public void PushButtonDeguti()
    {
        flowchart.ExecuteBlock("Deguti");
    }

    public void PushButtonLight()
    {
        flowchart.ExecuteBlock("Light");
    }

    //右ボタンを押した
    public void PushButtonRight()
    {

        wallNo++;
        if (wallNo >= WALL_RIGHT)
        {
            ButtonRight.SetActive(false);
            ButtonLeft.SetActive(true);
            wallNo = WALL_RIGHT;
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


    }

   

   

    //各種表示を消す
    void ClearButtons()
    {
      
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
                panelWalls.transform.localPosition = new Vector3(-2000.0f, 0.0f, 0.0f);
                break;
           

        }
    }
}

