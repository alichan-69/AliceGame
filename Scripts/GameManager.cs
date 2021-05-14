using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{

    //定数定義：壁方向
    public const int WALL_FRONT = 1;
    public const int WALL_RIGHT = 2;
    public const int WALL_BACK = 3;
    public const int WALL_LEFT = 4;

    public const int SelectStick1 = 1;
    public const int SelectStick2 = 2;
    public const int SelectStick3 = 3;

    public const int SelectHasami1 = 1;
    public const int SelectHasami2 = 2;
    public const int SelectHasami3 = 3;

    public const int SelectPenti1 = 1;
    public const int SelectPenti2 = 2;
    public const int SelectPenti3 = 3;

    public const int SelectBear1 = 1;
    public const int SelectBear2 = 2;
    public const int SelectBear3 = 3;

    public const int SelectBearopen1 = 1;
    public const int SelectBearopen2 = 2;
    public const int SelectBearopen3 = 3;

    public const int SelectKey1 = 1;
    public const int SelectKey2 = 2;
    public const int SelectKey3 = 3;
  


    //杖
    public GameObject buttonStick;
    public GameObject imageStick;
    public GameObject imageStickup;
    public GameObject buttonStickIconsmall;
    public Sprite StickPicture;
    public Sprite SelectStickPicture;

    //ハサミ
    public GameObject buttonHasami;
    public GameObject imageHasamiup;
    public GameObject buttonHasamiIconsmall;
    public Sprite HasamiPicture;
    public Sprite SelectHasamiPicture;

    //ペンチ
    public GameObject buttonPenti;
    public GameObject imagePentiup;
    public GameObject buttonPentiIconsmall;
    public Sprite PentiPicture;
    public Sprite SelectPentiPicture;

    //クマ
    public GameObject buttonBear;
    public GameObject imageBearup;
    public GameObject buttonBearIconsmall;
    public Sprite BearPicture;
    public Sprite SelectBearPicture;

    //クマ開き
    public GameObject buttonBear2;
    public GameObject imageBearopenup;
    public GameObject buttonBearopenIconsmall;
    public Sprite BearopenPicture;
    public Sprite SelectBearopenPicture;

    //鍵
    public GameObject imageKeyup;
    public GameObject buttonKeyIconsmall;
    public Sprite KeyPicture;
    public Sprite SelectKeyPicture;

    //ドア
    public GameObject buttonDoar;
    public GameObject buttonDoaropen;
    
    //鎖
    public GameObject buttonChain;

    public GameObject buttonRule;
    public Flowchart flowchart;

    public GameObject panelWalls;
    public GameObject panelUp;

    public GameObject ButtonRight;
    public GameObject ButtonLeft;


    private int wallNo;
    private int SelectStick;
    private int SelectHasami;
    private int SelectPenti;
    private int SelectBear;
    private int SelectBearopen;
    private int SelectKey;

    private bool doesSelectStick;
    private bool doesSelectHasami;
    private bool doesSelectPenti;
    private bool doesSelectKey;
    private bool doesHaveStick;
    private bool doesHaveHasami;
    private bool doesHavePenti;
    private bool doesHaveKey;
    private bool doesCutChain;


    enum ItemName
    {
        Stick, Hasami, Penti, Bear, Key, Bearopen
    }

    

    void Start()
    {
        wallNo = WALL_FRONT;
        SelectKey = SelectKey1;
        SelectHasami = SelectHasami1;
        SelectPenti = SelectPenti1;
        SelectStick = SelectStick1;
        SelectBear = SelectBear1;
        SelectBearopen = SelectBearopen1;
        doesSelectStick = false;
        doesSelectHasami = false;
        doesSelectPenti = false;
        doesSelectKey = false;
        doesHaveStick = false;
        doesHaveHasami = false;
        doesHavePenti = false;
        doesHaveKey = false;
        doesCutChain = false;

}

    // Update is called once per frame
    void Update()
    {

    }




    public void PushButtonStick()
    {
        buttonStickIconsmall.SetActive(true);
        doesHaveStick = true;
        buttonStick.SetActive(false);
        imageStick.SetActive(false);

    }

    public void PushButtonHasami()
    {
        buttonHasamiIconsmall.SetActive(true);
        doesHaveHasami = true;
        buttonHasami.SetActive(false);
    }

    public void PushButtonPenti()
    {
        if (doesHaveStick == true && SelectStick == SelectStick2)
        {
            buttonPentiIconsmall.SetActive(true);
            doesHavePenti = true;
            buttonPenti.SetActive(false);
            buttonStickIconsmall.SetActive(false);
        }
        else
        {
           
        }

    }







    //メモをタップ
    public void PushButtonTana()
    {
       
    }
    public void PushButtonUsagi()
    {
       
    }
    public void PushButtonOokami()
    {
       
    }
    public void PushButtonNeko()
    {
       
    }
    public void PushButtonNeko2()
    {
        
    }
    public void PushButtonBear()
    {
        if (doesCutChain == true)
        {
           
            buttonBearIconsmall.SetActive(true);
            buttonBear.SetActive(false);
        }
        else
        {
           
        }
    }

    public void PushButtonBearup()
    {
        if (doesHaveHasami == true && SelectHasami == SelectHasami2)
        {
            buttonHasamiIconsmall.SetActive(false);
            SelectBear = SelectBear1;
            DisplayBear();
            buttonBearIconsmall.SetActive(false);
            SelectBearopen = SelectBearopen3;
            DisplayBearopen();
            buttonBearopenIconsmall.SetActive(true);
           
        }
    }

    public void PushButtonKey()
    {
        imageBearopenup.SetActive(false);
        buttonBearopenIconsmall.SetActive(false);
        buttonKeyIconsmall.SetActive(true);
        doesHaveKey = true;
    } 


    public void PushButtonChain()
    {
        if (doesHavePenti == true && SelectPenti == SelectPenti2)
        {
            buttonPentiIconsmall.SetActive(false);
            doesCutChain = true;
            buttonChain.SetActive(false);
        }
        else
        {
           

        }
    }

    public void PushButtonDoar()
    {if(doesHaveKey == true && SelectKey == SelectKey2)
        {
            buttonDoar.SetActive(false);
            buttonDoaropen.SetActive(true);
        }
       else{  }

    }
    

    public void ClearIconSelect(int num)
    {
        switch (num)
        {
            case (int)ItemName.Stick:
          
                SelectHasami = SelectHasami1;
                SelectPenti = SelectPenti1;
                SelectBear = SelectBear1;
                SelectBearopen = SelectBearopen1;
                SelectKey = SelectKey1;
               
                DisplayHasami();
                DisplayPenti();
                DisplayBear();
                DisplayBearopen();
                DisplayKey();
                DisplayStick();
                break;
            case (int)ItemName.Hasami:
                SelectStick = SelectStick1;
             
                SelectPenti = SelectPenti1;
                if (SelectBear != SelectBear3 || SelectHasami == SelectHasami3)
                {
                    SelectBear = SelectBear1;
                }
                SelectBearopen = SelectBearopen1;
                SelectKey = SelectKey1;
              
                DisplayPenti();
              
                DisplayBearopen();
                DisplayKey();
                DisplayStick();
                if (SelectHasami == SelectHasami3)
                {        
                    DisplayBear();
                    DisplayHasami();
                }
                else
                {      
                    DisplayHasami();
                    DisplayBear();
                }
                
                break;
            case (int)ItemName.Penti:
                SelectStick = SelectStick1;
                SelectHasami = SelectHasami1;
               
                SelectBear = SelectBear1;
                SelectBearopen = SelectBearopen1;
                SelectKey = SelectKey1;
               
                DisplayBear();
                DisplayBearopen();
                DisplayKey();
                DisplayStick();
                DisplayHasami();
                DisplayPenti();
                break;
            case (int)ItemName.Bear:
                SelectStick = SelectStick1;
                SelectHasami = SelectHasami1;
                SelectPenti = SelectPenti1;
            
                SelectBearopen = SelectBearopen1;
                SelectKey = SelectKey1;
              
                DisplayBearopen();
                DisplayKey();
                DisplayStick();
                DisplayHasami();
                DisplayPenti();
                DisplayBear();
                break;
            case (int)ItemName.Bearopen:
                SelectStick = SelectStick1;
                SelectHasami = SelectHasami1;
                SelectPenti = SelectPenti1;
                SelectBear = SelectBear1;
              
                SelectKey = SelectKey1;
               
                DisplayKey();
                DisplayStick();
                DisplayHasami();
                DisplayPenti();
                DisplayBear();
                DisplayBearopen();
                break;
            case (int)ItemName.Key:
                SelectStick = SelectStick1;
                SelectHasami = SelectHasami1;
                SelectPenti = SelectPenti1;
                SelectBear = SelectBear1;
                SelectBearopen = SelectBearopen1;

                
                DisplayStick();
                DisplayHasami();
                DisplayPenti();
                DisplayBear();
                DisplayBearopen();
                DisplayKey();
                break;
        }
     
    }

    //杖アイコン
    public void PushButtonStickIconsmall()
    {
       
        SelectStick++;
        if (SelectStick > SelectStick3)
        {
            SelectStick = SelectStick1;
        }
        ClearIconSelect((int)ItemName.Stick);

    }

    //ハサミアイコン
    public void PushButtonHasamiIconsmall()
    {
       
        SelectHasami++;
        if (SelectHasami > SelectHasami3)
        {
            SelectHasami = SelectHasami1;
        }
        ClearIconSelect((int)ItemName.Hasami);
    }

    //ペンチアイコン
    public void PushButtonPentiIconsmall()
    {
       
        SelectPenti++;
        if (SelectPenti > SelectPenti3)
        {
            SelectPenti = SelectPenti1;
        }
        ClearIconSelect((int)ItemName.Penti);
    }

    //クマアイコン
    public void PushButtonBearIconsmall()
    {
      
        SelectBear++;
        if (SelectBear > SelectBear3)
        {
            SelectBear = SelectBear1;
        }
        ClearIconSelect((int)ItemName.Bear);
    }

    //クマ開きアイコン
    public void PushButtonBearopenIconsmall()
    {
        
        SelectBearopen++;
        if (SelectBearopen > SelectBearopen3)
        {
            SelectBearopen = SelectBearopen1;
        }
        ClearIconSelect((int)ItemName.Bearopen);
    }

    //鍵アイコン
    public void PushButtonKeyIconsmall()
    {
        
        SelectKey++;
        if (SelectKey > SelectKey3)
        {
            SelectKey = SelectKey1;
        }
        ClearIconSelect((int)ItemName.Key);
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
        SelectStick = SelectStick1;
        DisplayStick();
        SelectHasami = SelectHasami1;
        DisplayHasami();
        SelectPenti = SelectPenti1;
        DisplayPenti();
        SelectBear = SelectBear1;
        DisplayBear();
        SelectBearopen = SelectBearopen1;
        DisplayBearopen();
        SelectKey = SelectKey1;
        DisplayKey();
        panelUp.SetActive(false);



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

    //杖
    void DisplayStick()
    {
        switch (SelectStick)
        {
            case SelectStick1:
                panelUp.SetActive(false);
                buttonStickIconsmall.GetComponent<Image>().sprite = StickPicture;
                imageStickup.SetActive(false);
                flowchart.ExecuteBlock("SelectStick3");
                break;
            case SelectStick2:
                buttonStickIconsmall.GetComponent<Image>().sprite = SelectStickPicture;
                doesSelectStick = true;
                flowchart.ExecuteBlock("SelectStick2");
                break;
            case SelectStick3:
                panelUp.SetActive(true);
                imageStickup.SetActive(true);
                doesSelectStick = false;
                flowchart.ExecuteBlock("SelectStick3");
                break;

        }
    }

    void DisplayHasami()
    {
        switch (SelectHasami)
        {
            case SelectHasami1:
                panelUp.SetActive(false);
                buttonHasamiIconsmall.GetComponent<Image>().sprite = HasamiPicture;
                imageHasamiup.SetActive(false);
                flowchart.ExecuteBlock("SelectHasami3");
                break;
            case SelectHasami2:
                buttonHasamiIconsmall.GetComponent<Image>().sprite = SelectHasamiPicture;
                doesSelectHasami = true;
                flowchart.ExecuteBlock("SelectHasami2");
                break;
            case SelectHasami3:
                panelUp.SetActive(true);
                imageHasamiup.SetActive(true);
                doesSelectHasami = false;
                flowchart.ExecuteBlock("SelectHasami3");
                break;

        }
    }

    void DisplayPenti()
    {
        switch (SelectPenti)
        {
            case SelectPenti1:
                panelUp.SetActive(false);
                buttonPentiIconsmall.GetComponent<Image>().sprite = PentiPicture;
                imagePentiup.SetActive(false);
                flowchart.ExecuteBlock("SelectPenti3");
                break;
            case SelectPenti2:
                buttonPentiIconsmall.GetComponent<Image>().sprite = SelectPentiPicture;
                doesSelectPenti = true;
                flowchart.ExecuteBlock("SelectPenti2");
                break;
            case SelectPenti3:
                panelUp.SetActive(true);
                imagePentiup.SetActive(true);
                doesSelectPenti = false;
                flowchart.ExecuteBlock("SelectPenti3");
                break;

        }
    }

    void DisplayBear()
    {
        switch (SelectBear)
        {
            case SelectBear1:
                panelUp.SetActive(false);
                buttonBearIconsmall.GetComponent<Image>().sprite = BearPicture;
                imageBearup.SetActive(false);
                break;
            case SelectBear2:
                buttonBearIconsmall.GetComponent<Image>().sprite = SelectBearPicture;
                break;
            case SelectBear3:
                panelUp.SetActive(true);
                imageBearup.SetActive(true);
                break;

        }
    }

    void DisplayBearopen()
    {
        switch (SelectBearopen)
        {
            case SelectBearopen1:
                panelUp.SetActive(false);
                buttonBearopenIconsmall.GetComponent<Image>().sprite = BearopenPicture;
                imageBearopenup.SetActive(false);
                break;
            case SelectBearopen2:
                buttonBearopenIconsmall.GetComponent<Image>().sprite = SelectBearopenPicture;
                break;
            case SelectBearopen3:
                panelUp.SetActive(true);
                buttonBearopenIconsmall.GetComponent<Image>().sprite = SelectBearopenPicture;
                imageBearopenup.SetActive(true);
                break;

        }
    }



    void DisplayKey()
    {
        switch (SelectKey)
        {
            case SelectKey1:
                panelUp.SetActive(false);
                buttonKeyIconsmall.GetComponent<Image>().sprite = KeyPicture;
                imageKeyup.SetActive(false);
                flowchart.ExecuteBlock("SelectKey3");
                break;
            case SelectKey2:
                buttonKeyIconsmall.GetComponent<Image>().sprite = SelectKeyPicture;
                doesSelectKey = true;
                flowchart.ExecuteBlock("SelectKey2");
                break;
            case SelectKey3:
                panelUp.SetActive(true);
                imageKeyup.SetActive(true);
                doesSelectKey = false;
                flowchart.ExecuteBlock("SelectKey3");
                break;

        }
    }

  





}