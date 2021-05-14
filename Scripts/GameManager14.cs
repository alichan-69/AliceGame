using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using UnityEngine.UI;
using Fungus;

public class GameManager14 : MonoBehaviour
{

    //定数定義：壁方向
    public const int WALL_FRONT = 1;
    public const int WALL_RIGHT = 2;
    
    public const int SelectOil1 = 1;
    public const int SelectOil2 = 2;
    public const int SelectOil3 = 3;

    public const int SelectZyuu1 = 1;
    public const int SelectZyuu2 = 2;
    public const int SelectZyuu3 = 3;


    public Flowchart flowchart;
    public GameObject panelWalls;

    public GameObject buttonTagu;
    public GameObject buttonTaguue;
    public GameObject buttonHako;
    public GameObject buttonHakoopen;
    
    //オイル
    public GameObject imageOilup;
    public GameObject buttonOilIconsmall;
    public Sprite OilPicture;
    public Sprite SelectOilPicture;
    public GameObject buttonOil;

    //銃
    public GameObject imageZyuuup;
    public GameObject buttonZyuuIconsmall;
    public Sprite ZyuuPicture;
    public Sprite SelectZyuuPicture;

    public GameObject panelUp;

    public GameObject ButtonRight;
    public GameObject ButtonLeft;


    enum ItemName
    {
        Oil, Zyuu
    }

    private int wallNo;
    private int SelectOil;
    private int SelectZyuu;
    private bool doesSelectLight;
    private bool doesHaveOil;



    // Use this for initialization
    void Start()
    {
        wallNo = WALL_FRONT;
        SelectOil = SelectOil1;
        SelectZyuu = SelectZyuu1;
        doesSelectLight = false;
        doesHaveOil = false;



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
       
        if(SelectOil == SelectOil2)
        {
            SelectOil = SelectOil1;
            DisplayOil();
            buttonOilIconsmall.SetActive(false);
            doesHaveOil = true;
            flowchart.ExecuteBlock("SelectOil3");
            flowchart.ExecuteBlock("DoesHaveOil");
        }
    }

    public void PushButtonHako()
    {
        int val;
        val = GlobalManager.Sceneflag & 0x6248;

        if (val == 0x6248)
        {
            flowchart.ExecuteBlock("DoesBadEnd");

        }
    }

    public void PushButtonDeguti()
    {
        flowchart.ExecuteBlock("Deguti");
       
    }

    public void PushButtonKyaku2()
    {
        flowchart.ExecuteBlock("Kyaku2");
      
    }

    public void PushButtonLight()
    {

        flowchart.ExecuteBlock("Light");
        flowchart.ExecuteBlock("DoesSelectLight");
    }

    public void PushButtonAkausa()
    {
      

    }


    private void ClearSelectIcon(int num)
    {
        switch (num)
        {
            case (int)ItemName.Oil:
                SelectZyuu = SelectZyuu1;

                DisplayZyuu();
                DisplayOil();
                break;
            case (int)ItemName.Zyuu:
                
                SelectOil = SelectOil1;

                DisplayOil();
                DisplayZyuu();
                break;
        }
      
    }


    //オイルアイコンをタップ
    public void PushButtonOilIconsmall()
    {
        SelectOil++;
        if (SelectOil > SelectOil3)
        {
            SelectOil = SelectOil1;
        }
      
        ClearSelectIcon((int)ItemName.Oil);
    }
    
    public void PushButtonOil()
    {
        buttonOilIconsmall.SetActive(true);
        buttonOil.SetActive(false);
        ClearSelectIcon((int)ItemName.Oil);
    }

    //オイルの表示
    void DisplayOil()
    {
        switch (SelectOil)
        {
            case SelectOil1:
                panelUp.SetActive(false);
                buttonOilIconsmall.GetComponent<Image>().sprite = OilPicture;
                flowchart.ExecuteBlock("SelectOil3");
                imageOilup.SetActive(false);
                break;
            case SelectOil2:
                buttonOilIconsmall.GetComponent<Image>().sprite = SelectOilPicture;
                flowchart.ExecuteBlock("SelectOil2");
                break;
            case SelectOil3:
                panelUp.SetActive(true);
                imageOilup.SetActive(true);
                flowchart.ExecuteBlock("SelectOil3");
                break;

        }
    }

    //銃アイコンをタップ
    public void PushButtonZyuuIconsmall()
    {
        SelectZyuu++;
        if (SelectZyuu > SelectZyuu3)
        {
            SelectZyuu = SelectZyuu1;
        }
       
        ClearSelectIcon((int)ItemName.Zyuu);
    }

    //銃の表示
    void DisplayZyuu()
    {
        switch (SelectZyuu)
        {
            case SelectZyuu1:
                panelUp.SetActive(false);
                buttonZyuuIconsmall.GetComponent<Image>().sprite = ZyuuPicture;
                flowchart.ExecuteBlock("SelectZyuu3");
                imageZyuuup.SetActive(false);
                break;
            case SelectZyuu2:
                flowchart.ExecuteBlock("SelectZyuu2");
                buttonZyuuIconsmall.GetComponent<Image>().sprite = SelectZyuuPicture;
                break;
            case SelectZyuu3:
                panelUp.SetActive(true);
                flowchart.ExecuteBlock("SelectZyuu3");
                imageZyuuup.SetActive(true);
                break;

        }
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

    //各種表示を消す
    public void ClearButtons()
    {
        SelectOil = SelectOil1;
        DisplayOil();
        SelectZyuu = SelectZyuu1;
        DisplayZyuu();
        doesSelectLight = (false);
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

