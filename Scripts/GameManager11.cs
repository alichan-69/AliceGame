using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Fungus;

public class GameManager11 : MonoBehaviour
{

    //定数定義：壁方向
    public const int WALL_FRONT = 1;
    public const int WALL_RIGHT = 2;
    public const int WALL_BACK = 3;
    public const int WALL_LEFT = 4;

    public const int SelectNoa1 = 1;
    public const int SelectNoa2 = 2;
    public const int SelectNoa3 = 3;
    public const int SelectNoa4 = 4;

    public Flowchart flowchart;
    public GameObject panelWalls;

    public GameObject buttonCupcake1;
    public GameObject buttonCupcake2;
    public GameObject buttonCupcake3;
    public GameObject buttonCupcake4;
    public GameObject imageCupcake;
    public GameObject buttonCupcakesmall;
    public GameObject buttonMacaron2;
    public GameObject imageMacaron2;
    public GameObject buttonMacaron5;
    public GameObject buttonMacaron2hiraki;
    public GameObject imageMacaron2hiraki;
    public GameObject buttonMacaron5hiraki;
    public GameObject buttonNoa1;
    public GameObject buttonNoa2;
    public GameObject buttonNoa31;
    public GameObject buttonNoa32;
    public GameObject buttonNoa33;
    public GameObject buttonNoa34;
    public GameObject buttonNoa35;
    public GameObject imageNoa;
    public GameObject buttonRule;
    public GameObject ButtonRight;
    public GameObject ButtonLeft;


    private int wallNo;
    private int SelectNoa;
    private bool doesPushNoa1;
    private bool doesPushNoa2;

    // Use this for initialization
    void Start()
    {
        wallNo = WALL_FRONT;
        doesPushNoa1 = false;
        doesPushNoa2 = false;

    }


    // Update is called once per frame
    void Update()
    {

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

    public void PushButtonOri()
    {
        flowchart.ExecuteBlock("檻");
    }

    public void PushButtonMacaron2()
    {
        flowchart.ExecuteBlock("Macaron");
        buttonMacaron2.SetActive(false);
        imageMacaron2.SetActive(false);
        buttonMacaron2hiraki.SetActive(true);
        imageMacaron2hiraki.SetActive(true);
    }

    public void PushbuttonMacaron2hiraki()
    {
        flowchart.ExecuteBlock("Macaron");
        buttonMacaron2hiraki.SetActive(false);
        imageMacaron2hiraki.SetActive(false);
        buttonMacaron2.SetActive(true);
        imageMacaron2.SetActive(true);
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

   
    public void PushButtonNoa1()
    {
        flowchart.ExecuteBlock("Noa1");
        doesPushNoa1 = true;
    }

    public void PushButtonNoa2()
    {
        flowchart.ExecuteBlock("Noa1");
        doesPushNoa2 = true;
    }

    public void PushButtonNoa3()
    {
        SelectNoa++;
        if (SelectNoa == SelectNoa3)
        {
            SelectNoa = SelectNoa3;
        }
        DisplayNoa();
    }

    //ノアの表示
    void DisplayNoa()
    {
        switch (SelectNoa)
        {
            case SelectNoa1:
                flowchart.ExecuteBlock("Noa2");
                break;
            case SelectNoa2:
                flowchart.ExecuteBlock("Noa3");
                break;
            case SelectNoa3:
                flowchart.ExecuteBlock("Noa4");
                break;
        }
    }

    public void PushButtonRule()
    {
        buttonRule.SetActive(false);
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
        if(doesPushNoa1 == true)
        {
            buttonNoa2.SetActive(true);
            buttonNoa1.SetActive(false);
        }

        if (doesPushNoa2 == true)
        {
            buttonNoa31.SetActive(true);
            buttonNoa32.SetActive(true);
            buttonNoa33.SetActive(true);
            buttonNoa34.SetActive(true);
            buttonNoa35.SetActive(true);
            imageNoa.SetActive(true);
            buttonNoa2.SetActive(false);
        }


    }

    //左ボタンを押した
    public void PushButtonLeft()
    {
        wallNo--;
        if (wallNo <= WALL_FRONT)
        {
            ButtonRight.SetActive(true);
            ButtonLeft.SetActive(false);
            wallNo = WALL_FRONT;
        }
        else
        {
            ButtonRight.SetActive(true);
            ButtonLeft.SetActive(true);
        }
        DisplayWall();
        ClearButtons();

        if (doesPushNoa1 == true)
        {
            buttonNoa2.SetActive(true);
            buttonNoa1.SetActive(false);
        }

        if (doesPushNoa2 == true)
        {
            buttonNoa31.SetActive(true);
            buttonNoa32.SetActive(true);
            buttonNoa33.SetActive(true);
            buttonNoa34.SetActive(true);
            buttonNoa35.SetActive(true);
            imageNoa.SetActive(true);
            buttonNoa2.SetActive(false);
        }


    }
    
    //各種表示を消す
    void ClearButtons()
    {
        buttonRule.SetActive(false);
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

