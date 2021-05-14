using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Fungus;

public class GameManager12 : MonoBehaviour
{

    //定数定義：壁方向
    public const int WALL_FRONT = 1;
    public const int WALL_RIGHT = 2;
    public const int WALL_BACK = 3;
    public const int WALL_LEFT = 4;
    
    public const int SelectKey1 = 1;
    public const int SelectKey2 = 2;
    public const int SelectKey3 = 3;
    
    public const int SelectTegamiopen1 = 1;
    public const int SelectTegamiopen2 = 2;
    public const int SelectTegamiopen3 = 3;

  
    public GameObject panelWalls;
    public Flowchart flowchart;
    


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
    public GameObject buttonTobira;
    public GameObject buttonTobiraopen;
    public GameObject buttonDoar;
    public GameObject buttonDoaropen;
    public GameObject Itemuppanel;
 

    //カギ
    public GameObject imageKeyup;
    public GameObject buttonKeyIconsmall;
    public Sprite KeyPicture;
    public Sprite SelectKeyPicture;

    //手紙
    public GameObject buttonTegami;
  

    //手紙開き
    public GameObject imageTegamiopenIcon;
    public GameObject buttonTegamiopenIconsmall;
    public Sprite TegamiopenPicture;
    public Sprite SelectTegamiopenPicture;

    public GameObject ButtonRight;
    public GameObject ButtonLeft;

    enum ItemName
    {
      Key,Tegamiopen
    }

    private int wallNo;
    private int SelectKey;
    private int SelectTegami;
    private int SelectTegamiopen;
   

    // Use this for initialization
    void Start()
    {
        wallNo = WALL_FRONT;
        SelectKey = SelectKey1;
        SelectTegamiopen = SelectTegamiopen1;
       

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

 

    public void PushButtonTobira()
    {
        buttonTobira.SetActive(false);
        buttonTobiraopen.SetActive(true);
    }

    public void PushButtonTobiraopen()
    {
        buttonTobiraopen.SetActive(false);
        buttonTobira.SetActive(true);
    }

     

   
    public void PushButtonDoar()
    {
        if (SelectKey == SelectKey2)
        {
            buttonDoar.SetActive(false);
            buttonDoaropen.SetActive(true);
            buttonKeyIconsmall.SetActive(false);
            
        }
        else
        {
            
        }
    }


    private void ClearSelectIcon(int num)
    {
        switch (num)
        {
            case (int)ItemName.Key:
                SelectTegamiopen = SelectTegamiopen1;
                
                DisplayTegamiopen();
                DisplayKey();
                break;
            case (int)ItemName.Tegamiopen:
                SelectKey = SelectKey1;
              
                DisplayKey();
                DisplayTegamiopen();
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
   
    public void PushButtonTegami()
    {
        buttonTegamiopenIconsmall.SetActive(true);
        buttonTegami.SetActive(false);
    }

    //開きアイコンをタップ
    public void PushButtonTegamiopenIconsmall()
    {
        SelectTegamiopen++;
        if (SelectTegamiopen > SelectTegamiopen3)
        {
            SelectTegamiopen = SelectTegamiopen1;
        }
     
        ClearSelectIcon((int)ItemName.Tegamiopen);
    }

    //手紙開きの表示
    void DisplayTegamiopen()
    {
        switch (SelectTegamiopen)
        {
            case SelectTegamiopen1:
                Itemuppanel.SetActive(false);
                buttonTegamiopenIconsmall.GetComponent<Image>().sprite = TegamiopenPicture;
                Itemuppanel.SetActive(false);
                imageTegamiopenIcon.SetActive(false);
                break;
            case SelectTegamiopen2:
                buttonTegamiopenIconsmall.GetComponent<Image>().sprite = SelectTegamiopenPicture;
                break;
            case SelectTegamiopen3:
                Itemuppanel.SetActive(true);
                imageTegamiopenIcon.SetActive(true);
                break;

        }
    }


    //鍵の表示
    void DisplayKey()
    {
        switch (SelectKey)
        {
            case SelectKey1:
                Itemuppanel.SetActive(false);
                buttonKeyIconsmall.GetComponent<Image>().sprite = KeyPicture;
                Itemuppanel.SetActive(false);
                imageKeyup.SetActive(false);
                flowchart.ExecuteBlock("SelectKey3");
                break;
            case SelectKey2:
                buttonKeyIconsmall.GetComponent<Image>().sprite = SelectKeyPicture;
                flowchart.ExecuteBlock("SelectKey2");
                break;
            case SelectKey3:
                flowchart.ExecuteBlock("SelectKey3");
                Itemuppanel.SetActive(true);
                imageKeyup.SetActive(true);
                break;

        }
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
    //各種表示を消す
    public void ClearButtons()
    {
        SelectKey = SelectKey1;
        DisplayKey();
        SelectTegamiopen = SelectTegamiopen1;
        DisplayTegamiopen();
        Itemuppanel.SetActive(false);

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

