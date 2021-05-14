using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Fungus;

public class GameManager6 : MonoBehaviour
{

    //定数定義：壁方向
    public const int WALL_FRONT = 1;
    public const int WALL_RIGHT = 2;
    public const int WALL_BACK = 3;
    public const int WALL_LEFT = 4;

    public const int SelectKey1 = 1;
    public const int SelectKey2 = 2;
    public const int SelectKey3 = 3;

    public Flowchart flowchart;
    public GameObject panelWalls;

   
    public GameObject buttonDoar;
    public GameObject ImageDoar;
    public GameObject buttonDoaropen;
    public GameObject ItemupPanel;

   

    //鍵
    public GameObject imageKeyup;
    public GameObject buttonKeyIconsmall;
    public Sprite KeyPicture;
    public Sprite SelectKeyPicture;

    private int wallNo;
    private int SelectKey;
    public GameObject ButtonRight;
    public GameObject ButtonLeft;



    // Use this for initialization
    void Start()
    {
        wallNo = WALL_FRONT;
        SelectKey = SelectKey1;
       
        

    }

   

    // Update is called once per frame
    void Update()
    {

    }

    public void PushButtonReo()
    {
        flowchart.ExecuteBlock("レオ");
    }
   
    public void PushButtonDoar()
    {
        if (SelectKey == SelectKey2)
        {
          
            ImageDoar.SetActive(false);
            buttonDoaropen.SetActive(true);
        }
        else
        {
            
    }
    }

    //鍵アイコンをタップ
    public void PushButtonKeyIconsmall()
    {
        SelectKey++;
        if (SelectKey > SelectKey3)
        {
            SelectKey = SelectKey1;
        }
        DisplayKey();
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
        ClearButtons();

    }
  
 

    //鍵の表示
    void DisplayKey()
    {
        switch (SelectKey)
        {
            case SelectKey1:
                buttonKeyIconsmall.GetComponent<Image>().sprite = KeyPicture;
                imageKeyup.SetActive(false);
                flowchart.ExecuteBlock("SelectKey3");
                break;
            case SelectKey2:
                buttonKeyIconsmall.GetComponent<Image>().sprite = SelectKeyPicture;
                flowchart.ExecuteBlock("SelectKey2");
                break;
            case SelectKey3:
                ItemupPanel.SetActive(true);
                imageKeyup.SetActive(true);
                flowchart.ExecuteBlock("SelectKey3");
                break;

        }
    }

   
    //各種表示を消す
    public void ClearButtons()
    {
       
        SelectKey = SelectKey1;
        DisplayKey();
        ItemupPanel.SetActive(false);


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

