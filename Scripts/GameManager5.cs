using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager5 : MonoBehaviour
{

    //定数定義：壁方向
    public const int WALL_FRONT = 1;
    public const int WALL_RIGHT = 2;
    public const int WALL_BACK = 3;
    public const int WALL_LEFT = 4;

    public const int SelectMenue1 = 1;
    public const int SelectMenue2 = 2;

    public GameObject panelWalls;

    //メニュー
    public GameObject buttonMenue;
    public GameObject imageMenue;
    public GameObject imageHinto;
    public GameObject imageItem;
    public GameObject imageTitle;
    public GameObject panelsaydialog;
    public Sprite MenuePicture;
    public Sprite SelectMenuePicture;
    public GameObject panelmenu;
    public GameObject ButtonRight;
    public GameObject ButtonLeft;



    private int wallNo;
    private int SelectMenue;

    // Use this for initialization
    void Start()
    {
        wallNo = WALL_FRONT;
        SelectMenue = SelectMenue1;


    }



    // Update is called once per frame
    void Update()
    {


    }

    //メニューをタップ
    public void PushButtonMenue()
    {
        /* SelectMenue++;
         if (SelectMenue > SelectMenue2)
         {
             SelectMenue = SelectMenue1;
         }*/
        if (panelmenu.activeSelf == false)
        {
            DisplayMenue();
        }
        else
        {
            HideMenue();
        }


    }

    //メニューの表示
    void DisplayMenue()
    {
        panelmenu.SetActive(true);
        imageMenue.SetActive(true);
        panelsaydialog.SetActive(false);


    }

    //メニューの非表示
    public void HideMenue()
    {
        panelmenu.SetActive(false);
        panelsaydialog.SetActive(true);

    }


    //ヒントをタップ
    public void PushButtonHinto()
    {
        imageMenue.SetActive(false);
        imageHinto.SetActive(true);
    }

    //アイテムをタップ
    public void PushButtonItem()
    {
        imageMenue.SetActive(false);
        imageItem.SetActive(true);
    }

    //タイトルをタップ
    public void PushButtonTitle()
    {
        imageMenue.SetActive(false);
        imageTitle.SetActive(true);
    }

    //戻るをタップ
    public void PushBuuttonModoru()
    {
        imageHinto.SetActive(false);
        imageItem.SetActive(false);
        imageTitle.SetActive(false);
        imageMenue.SetActive(true);
    }

    //タイトルをタップ
    public void PushButtonTitle2()
    {
        SceneManager.LoadScene("TitleScene");
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
        //ClearButtons();
        //HideMenue();

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
       // ClearButtons();

    }


    //各種表示を消す
    void ClearButtons()
    {
        SelectMenue = SelectMenue1;
        DisplayMenue();
        imageHinto.SetActive(false);
        imageItem.SetActive(false);
        imageMenue.SetActive(false);
        imageTitle.SetActive(false);
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

    public void DelTicket()
    {
        GlobalManager.DelTicket();
    }
}
