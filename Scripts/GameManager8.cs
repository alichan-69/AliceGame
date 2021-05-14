using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Fungus;

public class GameManager8 : MonoBehaviour
{

    //定数定義：壁方向
    public const int WALL_FRONT = 1;
    public const int WALL_RIGHT = 2;
    public const int WALL_BACK = 3;
    public const int WALL_LEFT = 4;

   

    public const int SelectKey1 = 1;
    public const int SelectKey2 = 2;
    public const int SelectKey3 = 3;

    public const int SelectZyuu1 = 1;
    public const int SelectZyuu2 = 2;
    public const int SelectZyuu3 = 3;

  






    public GameObject ButtonDoar1;
    public GameObject ButtonDoar2;
    public GameObject ButtonDoar4;
    public GameObject ButtonDoar6;
    public GameObject ButtonDoar7;
    public GameObject ButtonDoar9;
    public GameObject ButtonDoar10;
    public GameObject imageDoar9;
    public GameObject imageDoar10;
    public GameObject ButtonDoaropen1;
    public GameObject ButtonDoaropen2;
    public GameObject ButtonDoaropen4;
    public GameObject ButtonDoaropen6;
    public GameObject ButtonDoaropen9;
    public GameObject ButtonDoaropen10;
    public GameObject imageDoaropen9;
    public GameObject imageDoaropen10;
    public GameObject ItemupPanel;

  
    //カギ
    public GameObject imageKeyup;
    public GameObject buttonKeyIconsmall;
    public Sprite KeyPicture;
    public Sprite SelectKeyPicture;

    //銃
    public GameObject buttonZyuu;
    public GameObject imageZyuuup;
    public GameObject buttonZyuuIconsmall;
    public Sprite ZyuuPicture;
    public Sprite SelectZyuuPicture;



    public GameObject ButtonRight;
    public GameObject ButtonLeft;

    public GameObject panelWalls;
    public Flowchart flowchart;

    private int wallNo;
    private int SelectKey;
    private int SelectZyuu;
   

    enum ItemName
    {
        Key, Zyuu
    }



    // Use this for initialization
    void Start()
    {
        wallNo = WALL_FRONT;
        SelectKey = SelectKey1;
        SelectZyuu = SelectZyuu1;
    }

    // Update is called once per frame
    void Update()
    {

    }

    //天秤
    public void PushbuttonTenbin()
    {
        flowchart.ExecuteBlock("天秤");
    }

    //ドアをタップ
    public void PushButtonDoar1()
    {
        ButtonDoar1.SetActive(false);
        ButtonDoaropen1.SetActive(true);
    }

    public void PushButtonDoar2()
    {
        if (SelectKey == SelectKey2)
        {
            ButtonDoar2.SetActive(false);
            ButtonDoaropen2.SetActive(true);
            buttonKeyIconsmall.SetActive(false);
        }
    }

    

    public void PushButtonDoar4()
    {
        ButtonDoaropen4.SetActive(true);
        ButtonDoar4.SetActive(false);
    }

   

  

    public void PushButtonDoar6()
    {
        ButtonDoar6.SetActive(false);
        ButtonDoaropen6.SetActive(true);
    }

   

  
    public void PushButtonDoar9()
    {
        ButtonDoar9.SetActive(false);
        imageDoar9.SetActive(false);
        ButtonDoaropen9.SetActive(true);
        imageDoaropen9.SetActive(true);
    }

    public void PushButtonDoar10()
    {
        ButtonDoar10.SetActive(false);
        imageDoar10.SetActive(false);
        ButtonDoaropen10.SetActive(true);
        imageDoaropen10.SetActive(true);
    }

    public void PushButtonDoaropen1()
    {
        ButtonDoaropen1.SetActive(false);
        ButtonDoar1.SetActive(true);
    }

    public void PushButtonDoaropen2()
    {
        ButtonDoaropen2.SetActive(false);
        ButtonDoar2.SetActive(true);
    }

    public void PushButtonDoaropen4()
    {
        ButtonDoaropen4.SetActive(false);
        ButtonDoar4.SetActive(true);
    }

    public void PushButtonDoaropen6()
    {
        ButtonDoaropen6.SetActive(false);
        ButtonDoar6.SetActive(true);
    }

    public void PushButtonDoaropen7()
    {
        
        ButtonDoar7.SetActive(true);
    }
    public void PushButtonDoaropen9()
    {
        ButtonDoaropen9.SetActive(false);
        imageDoaropen9.SetActive(false);
        ButtonDoar9.SetActive(true);
        imageDoar9.SetActive(true);
    }

    public void PushButtonDoaropen10()
    {
        ButtonDoaropen10.SetActive(false);
        imageDoaropen10.SetActive(false);
        ButtonDoar10.SetActive(true);
        imageDoar10.SetActive(true);
    }




    private void ClearSelectIcon(int num)
    {
        switch (num)
        {
            case (int)ItemName.Key:
                SelectZyuu = SelectZyuu1;
                
                DisplayZyuu();
                DisplayKey();
                break;
            case (int)ItemName.Zyuu:
                SelectKey = SelectKey1;
             
                DisplayKey();
                DisplayZyuu();
                break;
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
        ClearSelectIcon((int)ItemName.Key);
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

    public void PushButtonZyuu()
    {
       
     
        buttonZyuuIconsmall.SetActive(true);
        buttonZyuu.SetActive(false);
        
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



    //鍵の表示
    void DisplayKey()
    {
        switch (SelectKey)
        {
            case SelectKey1:
                ItemupPanel.SetActive(false);
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

    //銃の表示
    void DisplayZyuu()
    {
        switch (SelectZyuu)
        {
            case SelectZyuu1:
                ItemupPanel.SetActive(false);
                buttonZyuuIconsmall.GetComponent<Image>().sprite = ZyuuPicture;
                imageZyuuup.SetActive(false);
                break;
            case SelectZyuu2:
                buttonZyuuIconsmall.GetComponent<Image>().sprite = SelectZyuuPicture;
                break;
            case SelectZyuu3:
                ItemupPanel.SetActive(true);
                imageZyuuup.SetActive(true);
                break;

        }
    }

   
    //ボタンを消去
    public void ClearButtons()
    {
       
       
        SelectZyuu = SelectZyuu1;
        DisplayZyuu();
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

