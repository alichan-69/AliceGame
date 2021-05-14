using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Fungus;

public class GameManager10 : MonoBehaviour
{

    //定数定義：壁方向
    public const int WALL_FRONT = 1;
    public const int WALL_RIGHT = 2;
    public const int WALL_BACK = 3;
    public const int WALL_LEFT = 4;

    public Flowchart flowchart;
    public GameObject panelWalls;
    
    public GameObject buttonCupcake1;
    public GameObject buttonCupcake2;
    public GameObject buttonCupcake3;
    public GameObject buttonCupcake4;
    public GameObject imageCupcake;
    public GameObject buttonCupcakesmall;
    public GameObject buttonMacaron2;
    public GameObject buttonMacaron5;
    public GameObject buttonMacaron2hiraki;
    public GameObject buttonMacaron5hiraki;

    private int wallNo;
    public GameObject ButtonRight;
    public GameObject ButtonLeft;

    // Use this for initialization
    void Start()
    {
        wallNo = WALL_FRONT;

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PushButtonOri()
    {
        flowchart.ExecuteBlock("檻");
    }

    public void PushButtonCupcake()
    {
        flowchart.ExecuteBlock("Cupcake");
        buttonCupcake1.SetActive(false);
        buttonCupcake2.SetActive(false);
        buttonCupcake3.SetActive(false);
        buttonCupcake4.SetActive(false);
        imageCupcake.SetActive(false);
        buttonCupcakesmall.SetActive(true);
    }

    public void PushButtonCupcakesmall()
    {
        flowchart.ExecuteBlock("Cupcake");
        buttonCupcakesmall.SetActive(false);
        buttonCupcake1.SetActive(true);
        buttonCupcake2.SetActive(true);
        buttonCupcake3.SetActive(true);
        buttonCupcake4.SetActive(true);
        imageCupcake.SetActive(true);
    }

    public void PushButtonMacaron2()
    {
        flowchart.ExecuteBlock("Macaron");
        buttonMacaron2.SetActive(false);
        buttonMacaron2hiraki.SetActive(true);
    }

    public void PushbuttonMacaron2hiraki()
    {
        flowchart.ExecuteBlock("Macaron");
        buttonMacaron2hiraki.SetActive(false);
        buttonMacaron2.SetActive(true);
    }

    public void PushButtonMacaron5()
    {
        flowchart.ExecuteBlock("Macaron");
        buttonMacaron5.SetActive(false);
        buttonMacaron5hiraki.SetActive(true);
    }

    public void PushbuttonMacaron5hiraki()
    {
        flowchart.ExecuteBlock("Macaron");
        buttonMacaron5hiraki.SetActive(false);
        buttonMacaron5.SetActive(true);
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

