using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Fungus;

public class GameManager9 : MonoBehaviour
{

    //定数定義：壁方向
    public const int WALL_FRONT = 1;
    public const int WALL_RIGHT = 2;
    public const int WALL_BACK = 3;
    public const int WALL_LEFT = 4;

    public const int SelectTakarabako1 = 1;
    public const int SelectTakarabako2 = 2;
    public const int SelectTakarabako3 = 3;

    public const int SelectTakarabakoopen1 = 1;
    public const int SelectTakarabakoopen2 = 2;
    public const int SelectTakarabakoopen3 = 3;

    public const int SelectKey1 = 1;
    public const int SelectKey2 = 2;
    public const int SelectKey3 = 3;

    public const int SelectCake1 = 1;
    public const int SelectCake2 = 2;
    public const int SelectCake3 = 3;

    public const int SelectCakeeat1 = 1;
    public const int SelectCakeeat2 = 2;
    public const int SelectCakeeat3 = 3;

    public const int SelectLighter1 = 1;
    public const int SelectLighter2 = 2;
    public const int SelectLighter3 = 3;

    public const int SelectLighteron1 = 1;
    public const int SelectLighteron2 = 2;
    public const int SelectLighteron3 = 3;

    public const int SelectBarru1 = 1;
    public const int SelectBarru2 = 2;
    public const int SelectBarru3 = 3;

    //定数定義：ボタン数
    public const int NUMBER_0 = 0;
    public const int NUMBER_1 = 1;
    public const int NUMBER_2 = 2;
    public const int NUMBER_3 = 3;
    public const int NUMBER_4 = 4;
    public const int NUMBER_5 = 5;
    public const int NUMBER_6 = 6;
    public const int NUMBER_7 = 7;
    public const int NUMBER_8 = 8;
    public const int NUMBER_9 = 9;

    public Flowchart flowchart;
   // public GameObject buttonRule;
    public GameObject panelWalls;
    public GameObject panelall;
    public GameObject ButtonRight;
    public GameObject ButtonLeft;


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
    public GameObject buttonLock;
    public GameObject buttonDaiyayama;
    public GameObject buttonDaiyayamatoke;
    public GameObject imageChocohutaopen;
    public GameObject Itemuppanel;

    //宝箱
    public GameObject buttonTakarabako;
    public GameObject imageTakarabakoup;
    public GameObject buttonTakarabakoIconsmall;
    public Sprite TakarabakoPicture;
    public Sprite SelectTakarabakoPicture;
    public GameObject imagenumberback;

    //宝箱ロック
    public GameObject[] buttonDial = new GameObject[4];

    public Sprite[] buttonPicture = new Sprite[10];

    //宝箱開き
    public GameObject imageTakarabakoopenup;
    public GameObject buttonTakarabakoopenIconsmall;
    public Sprite TakarabakoopenPicture;
    public Sprite SelectTakarabakoopenPicture;

    //鍵
    public GameObject imageKeyup;
    public GameObject buttonKeyIconsmall;
    public Sprite KeyPicture;
    public Sprite SelectKeyPicture;

    //ケーキ
    public GameObject buttonCake;
    public GameObject imageCakeup;
    public GameObject buttonCakeIconsmall;
    public Sprite CakePicture;
    public Sprite SelectCakePicture;

    //ケーキ　食べかけ
    public GameObject imageCakeeatup;
    public GameObject buttonCakeeatIconsmall;
    public Sprite CakeeatPicture;
    public Sprite SelectCakeeatPicture;

    //ライター
    public GameObject imageLighterup;
    public GameObject buttonLighterIconsmall;
    public Sprite LighterPicture;
    public Sprite SelectLighterPicture;

    //ライターオン
    public GameObject imageLighteronup;
    public GameObject buttonLighteronIconsmall;
    public Sprite LighteronPicture;
    public Sprite SelectLighteronPicture;

    //バール
    public GameObject buttonBarru;
    public GameObject imageBarruup;
    public GameObject buttonBarruIconsmall;
    public Sprite BarruPicture;
    public Sprite SelectBarruPicture;

    //タイマー
    public Timer timer;

    //点滅ランプ
    public GameObject lamp1;
    public GameObject lamp2;
    public GameObject lamp3;
    public GameObject lamp4;
    bool sflag = false;
    float st_time=0;
    float c_time=0;
    float cl = 0;

    enum ItemName
    {
           Takarabako,Takarabakoopen,Key,Cake,Cakeeat,Lighter,Lighteron,Barru
    }

    private int wallNo;
    private int SelectTakarabako;
    private int SelectTakarabakoopen;
    private int SelectKey;
    private int SelectCake;
    private int SelectCakeeat;
    private int SelectLighter;
    private int SelectLighteron;
    private int SelectBarru;
    private int[] buttonNumber = new int[4];
    private bool doesUnlockKey;
    private bool doesOpenTobira;

    // Use this for initialization
    void Start()
    {
        wallNo = WALL_FRONT;
        SelectTakarabako = SelectTakarabako1;
        SelectTakarabakoopen = SelectTakarabakoopen1;
        SelectKey = SelectKey1;
        SelectCake = SelectCake1;
        SelectCakeeat = SelectCakeeat1;
        SelectLighter = SelectLighter1;
        SelectLighteron = SelectLighteron1;
        SelectBarru = SelectBarru1;
        buttonNumber [0] = NUMBER_0;
        buttonNumber [1] = NUMBER_0;
        buttonNumber [2] = NUMBER_0;
        buttonNumber [3] = NUMBER_0;
        doesUnlockKey = false;
        doesOpenTobira = false;
        

    }

    // Update is called once per frame
    void Update()
    {
        //パネルが点滅する
        c_time = Time.time;
        /*
        if ( sflag == true && (c_time - st_time ) > 0.5)
        {
            lamp1.SetActive(!lamp1.activeSelf);
            lamp2.SetActive(!lamp2.activeSelf);
            lamp3.SetActive(!lamp3.activeSelf);
            lamp4.SetActive(!lamp4.activeSelf);
            if (lamp1.activeSelf)
            {
                cl = cl + 0.01f;
                lamp1.GetComponent<Image>().color = new Color(1.0f, 1.0f, 1.0f, cl);
                lamp2.GetComponent<Image>().color = new Color(1.0f, 1.0f, 1.0f, cl);
                lamp3.GetComponent<Image>().color = new Color(1.0f, 1.0f, 1.0f, cl);
                lamp4.GetComponent<Image>().color = new Color(1.0f, 1.0f, 1.0f, cl);
                st_time = c_time;
            }
        }
        */


    }
    
    public void PushButtonDial1()
    {
        flowchart.ExecuteBlock("Dial");
        ChangeButtonNumber(0);
    }
    
    public void PushButtonDial2()
    {
        flowchart.ExecuteBlock("Dial");
        ChangeButtonNumber(1);
    }

    public void PushButtonDial3()
    {
        flowchart.ExecuteBlock("Dial");
        ChangeButtonNumber(2);
    }

    public void PushButtonDial4()
    {
        flowchart.ExecuteBlock("Dial");
        ChangeButtonNumber(3);
    }
    //ボタンの数字変更
    void ChangeButtonNumber (int buttonNo)
    {
        buttonNumber[buttonNo]++;
        if(buttonNumber[buttonNo] > NUMBER_9)
        {
            buttonNumber[buttonNo] = NUMBER_0;
        }
        //ボタン画像変更
        buttonDial[buttonNo].GetComponent<Image>().sprite =
            buttonPicture[buttonNumber[buttonNo]];

        //ボタン色チェック
        if ((buttonNumber[0] == NUMBER_4) &&
            (buttonNumber[1] == NUMBER_7) &&
            (buttonNumber[2] == NUMBER_0) &&
            (buttonNumber[3] == NUMBER_2))
        {
            flowchart.ExecuteBlock("Hiraku");
            SelectTakarabako = SelectTakarabako1;
            DisplayTakarabako();
            buttonTakarabakoIconsmall.SetActive(false);
            buttonTakarabakoopenIconsmall.SetActive(true);
            SelectTakarabakoopen = SelectTakarabakoopen3;
            DisplayTakarabakoopen();
           
        }
        
    }

    public void PushButtonModoru()
    {
        Itemuppanel.SetActive(true);
        imagenumberback.SetActive(false);
        imageTakarabakoup.SetActive(true);
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
    
    public void PushButtonDaiyayama()
    {
        if(SelectLighteron == SelectLighteron2)
        {
            buttonDaiyayama.SetActive(false);
            buttonDaiyayamatoke.SetActive(true);
            buttonLighteronIconsmall.SetActive(false);
        }
        else {  }
    }

    public void PushButtonTobira()
    {
        if(doesUnlockKey == true)
        {
            buttonTobira.SetActive(false);
            buttonTobiraopen.SetActive(true);
            doesOpenTobira = true;
            
        }
        else
        {
        }
    }

    public void PushButtonTobiraopen()
    {
        buttonTobiraopen.SetActive(false);
        buttonTobira.SetActive(true);
        doesOpenTobira = false;
      
    }

    public void PushButtonLock()
    {
        if(SelectKey == SelectKey2)
        {
            buttonLock.SetActive(false);
            doesUnlockKey = true;
            buttonKeyIconsmall.SetActive(false);
            flowchart.ExecuteBlock("DoesOpenKey");
        }
        else
        {
        }
    }

    public void PushButtonChocohuta()
    {
        if(SelectBarru == SelectBarru2)
        {
            buttonBarruIconsmall.SetActive(false);
            imageChocohutaopen.SetActive(true);
        }
        else {  }
    }

   public void PushButtonRule()
    {
       
        panelall.SetActive(false);
        timer.TimerStart();
        sflag = true;
        st_time = Time.time;
        
    }

    public void ClearChildren()
    {
        bool flag = true;

        if (panelall.transform.childCount > 0)
        {
            foreach (Transform child in panelall.transform)
            {
                if (child.gameObject.activeSelf)
                {
                    panelall.transform.gameObject.SetActive(false);
                    child.gameObject.SetActive(false);
                    if (flag)
                    {
                        timer.TimerStart();
                        sflag = true;
                        st_time = Time.time;
                        flag = false;
                    }
                   

                }

            }
           

        }
       

    }

    public void PushButtonNumber()
    {
        Itemuppanel.SetActive(true);
        imagenumberback.SetActive(true);
        imageTakarabakoup.SetActive(false);
    }


    private void ClearSelectIcon(int num)
    {
        switch (num)
        {
            case (int)ItemName.Takarabako:
             
                SelectTakarabakoopen = SelectTakarabakoopen1;
                SelectKey = SelectKey1;
                SelectCake = SelectCake1;
                SelectCakeeat = SelectCakeeat1;
                SelectLighter = SelectLighter1;
                SelectLighteron = SelectLighteron1;
                SelectBarru = SelectBarru1;
                
                DisplayTakarabakoopen();
                DisplayKey();
                DisplayCake();
                DisplayCakeeat();
                DisplayLighter();
                DisplayLighteron();
                DisplayBarru();
                DisplayTakarabako();
                break;
            case (int)ItemName.Takarabakoopen:
                SelectTakarabako = SelectTakarabako1;
             
                SelectKey = SelectKey1;
                SelectCake = SelectCake1;
                SelectCakeeat = SelectCakeeat1;
                SelectLighter = SelectLighter1;
                SelectLighteron = SelectLighteron1;
                SelectBarru = SelectBarru1;
                
                DisplayKey();
                DisplayCake();
                DisplayCakeeat();
                DisplayLighter();
                DisplayLighteron();
                DisplayBarru();
                DisplayTakarabako();
                DisplayTakarabakoopen();
                break;
            case (int)ItemName.Key:
                SelectTakarabako = SelectTakarabako1;
                SelectTakarabakoopen = SelectTakarabakoopen1;
             
                SelectCake = SelectCake1;
                SelectCakeeat = SelectCakeeat1;
                SelectLighter = SelectLighter1;
                SelectLighteron = SelectLighteron1;
                SelectBarru = SelectBarru1;
                
                DisplayCake();
                DisplayCakeeat();
                DisplayLighter();
                DisplayLighteron();
                DisplayBarru();
                DisplayTakarabako();
                DisplayTakarabakoopen();
                DisplayKey();
                break;
            case (int)ItemName.Cake:
                SelectTakarabako = SelectTakarabako1;
                SelectTakarabakoopen = SelectTakarabakoopen1;
                SelectKey = SelectKey1;
             
                SelectCakeeat = SelectCakeeat1;
                SelectLighter = SelectLighter1;
                SelectLighteron = SelectLighteron1;
                SelectBarru = SelectBarru1;
               
                DisplayCakeeat();
                DisplayLighter();
                DisplayLighteron();
                DisplayBarru();
                DisplayTakarabako();
                DisplayTakarabakoopen();
                DisplayKey();
                DisplayCake();
                break;
            case (int)ItemName.Cakeeat:
                SelectTakarabako = SelectTakarabako1;
                SelectTakarabakoopen = SelectTakarabakoopen1;
                SelectKey = SelectKey1;
                SelectCake = SelectCake1;
              
                SelectLighter = SelectLighter1;
                SelectLighteron = SelectLighteron1;
                SelectBarru = SelectBarru1;
                
                DisplayLighter();
                DisplayLighteron();
                DisplayBarru();
                DisplayTakarabako();
                DisplayTakarabakoopen();
                DisplayKey();
                DisplayCake();
                DisplayCakeeat();
                break;
            case (int)ItemName.Lighter:
                SelectTakarabako = SelectTakarabako1;
                SelectTakarabakoopen = SelectTakarabakoopen1;
                SelectKey = SelectKey1;
                SelectCake = SelectCake1;
                SelectCakeeat = SelectCakeeat1;
           
                SelectLighteron = SelectLighteron1;
                SelectBarru = SelectBarru1;
                
                DisplayLighteron();
                DisplayBarru();
                DisplayTakarabako();
                DisplayTakarabakoopen();
                DisplayKey();
                DisplayCake();
                DisplayCakeeat();
                DisplayLighter();
                break;
            case (int)ItemName.Lighteron:
                SelectTakarabako = SelectTakarabako1;
                SelectTakarabakoopen = SelectTakarabakoopen1;
                SelectKey = SelectKey1;
                SelectCake = SelectCake1;
                SelectCakeeat = SelectCakeeat1;
                SelectLighter = SelectLighter1;
              
                SelectBarru = SelectBarru1;
               
                DisplayBarru();
                DisplayTakarabako();
                DisplayTakarabakoopen();
                DisplayKey();
                DisplayCake();
                DisplayCakeeat();
                DisplayLighter();
                DisplayLighteron();
                break;
            case (int)ItemName.Barru:
                SelectTakarabako = SelectTakarabako1;
                SelectTakarabakoopen = SelectTakarabakoopen1;
                SelectKey = SelectKey1;
                SelectCake = SelectCake1;
                SelectCakeeat = SelectCakeeat1;
                SelectLighter = SelectLighter1;
                SelectLighteron = SelectLighteron1;
               
                DisplayTakarabako();
                DisplayTakarabakoopen();
                DisplayKey();
                DisplayCake();
                DisplayCakeeat();
                DisplayLighter();
                DisplayLighteron();
                DisplayBarru();

                break;

        }
    
    }


    //宝箱アイコンをタップ
    public void PushButtonTakarabakoIconsmall()
    {
        SelectTakarabako++;
        if (SelectTakarabako > SelectTakarabako3)
        {
            SelectTakarabako = SelectTakarabako1;
        }
      
        ClearSelectIcon((int)ItemName.Takarabako);
    }

    public void PushButtonTakarabako()
    {
        buttonTakarabakoIconsmall.SetActive(true);
        buttonTakarabako.SetActive(false);
        ClearSelectIcon((int)ItemName.Takarabako);
    }

    //宝箱の表示
    void DisplayTakarabako()
    {
        switch (SelectTakarabako)
        {
            case SelectTakarabako1:
                buttonTakarabakoIconsmall.GetComponent<Image>().sprite = TakarabakoPicture;
                Itemuppanel.SetActive(false);
                imageTakarabakoup.SetActive(false);
                imagenumberback.SetActive(false);
                buttonNumber[0] = NUMBER_0;
                buttonNumber[1] = NUMBER_0;
                buttonNumber[2] = NUMBER_0;
                buttonNumber[3] = NUMBER_0;
                buttonDial[0].GetComponent<Image>().sprite =
                    buttonPicture[buttonNumber[0]];
                buttonDial[1].GetComponent<Image>().sprite =
                    buttonPicture[buttonNumber[0]];
                buttonDial[2].GetComponent<Image>().sprite =
                    buttonPicture[buttonNumber[0]];
                buttonDial[3].GetComponent<Image>().sprite =
                    buttonPicture[buttonNumber[0]];
                break;
            case SelectTakarabako2:
                buttonTakarabakoIconsmall.GetComponent<Image>().sprite = SelectTakarabakoPicture;
                break;
            case SelectTakarabako3:
                Itemuppanel.SetActive(true);
                imageTakarabakoup.SetActive(true);
                break;

        }
    }

    //宝箱開きアイコンをタップ
    public void PushButtonTakarabakoopenIconsmall()
    {
        SelectTakarabakoopen++;
        if (SelectTakarabakoopen > SelectTakarabakoopen3)
        {
            SelectTakarabakoopen = SelectTakarabakoopen1;
        }
       
        ClearSelectIcon((int)ItemName.Takarabakoopen);
    }

    //宝箱の表示
    void DisplayTakarabakoopen()
    {
        switch (SelectTakarabakoopen)
        {
            case SelectTakarabakoopen1:
                Itemuppanel.SetActive(false);
                buttonTakarabakoopenIconsmall.GetComponent<Image>().sprite = TakarabakoopenPicture;
                imageTakarabakoopenup.SetActive(false);
                break;
            case SelectTakarabakoopen2:
                buttonTakarabakoopenIconsmall.GetComponent<Image>().sprite = SelectTakarabakoopenPicture;
                break;
            case SelectTakarabakoopen3:
                Itemuppanel.SetActive(true);
                imageTakarabakoopenup.SetActive(true);
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

    //鍵の表示
    void DisplayKey()
    {
        switch (SelectKey)
        {
            case SelectKey1:
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
                Itemuppanel.SetActive(true);
                imageKeyup.SetActive(true);
                flowchart.ExecuteBlock("SelectKey3");
                break;

        }
    }
    
    public void PushButtonKey()
    {
        buttonTakarabakoopenIconsmall.SetActive(false);
        SelectTakarabakoopen = SelectTakarabakoopen1;
        DisplayTakarabakoopen();
        buttonKeyIconsmall.SetActive(true);
        ClearSelectIcon((int)ItemName.Key);
    }


    //ケーキアイコンをタップ
    public void PushButtonCakeIconsmall()
    {
        SelectCake++;
        if (SelectCake > SelectCake3)
        {
            SelectCake = SelectCake1;
        }
     
        ClearSelectIcon((int)ItemName.Cake);
    }

    //ケーキの表示
    void DisplayCake()
    {
        switch (SelectCake)
        {
            case SelectCake1:
                buttonCakeIconsmall.GetComponent<Image>().sprite = CakePicture;
                Itemuppanel.SetActive(false);
                imageCakeup.SetActive(false);
                break;
            case SelectCake2:
                buttonCakeIconsmall.GetComponent<Image>().sprite = SelectCakePicture;
                break;
            case SelectCake3:
                Itemuppanel.SetActive(true);
                imageCakeup.SetActive(true);
                break;

        }
    }

    public void PushButtonCake()
    {
        if (doesOpenTobira == true)
        {
         
            buttonCakeIconsmall.SetActive(true);
            buttonCake.SetActive(false);
            ClearSelectIcon((int)ItemName.Cake);
        }
       
    }

    public void PushButtonCake2()
    {
        SelectCake = SelectCake1;
        DisplayCake();
        buttonCakeIconsmall.SetActive(false);
        SelectCakeeat = SelectCakeeat3;
        DisplayCakeeat();
        buttonCakeeatIconsmall.SetActive(true);
        ClearSelectIcon((int)ItemName.Cakeeat);
    }



    //ケーキ食べかけアイコンをタップ
    public void PushButtonCakeeatIconsmall()
    {
        SelectCakeeat++;
        if (SelectCakeeat > SelectCakeeat3)
        {
            SelectCakeeat = SelectCakeeat1;
        }
      
        ClearSelectIcon((int)ItemName.Cakeeat);
    }

    //ケーキたべかけの表示
    void DisplayCakeeat()
    {
        switch (SelectCakeeat)
        {
            case SelectCakeeat1:
                buttonCakeeatIconsmall.GetComponent<Image>().sprite = CakeeatPicture;
                Itemuppanel.SetActive(false);
                imageCakeeatup.SetActive(false);
                break;
            case SelectCakeeat2:
                buttonCakeeatIconsmall.GetComponent<Image>().sprite = SelectCakeeatPicture;
                break;
            case SelectCakeeat3:
                buttonCakeeatIconsmall.GetComponent<Image>().sprite = SelectCakeeatPicture;
                Itemuppanel.SetActive(true);
                imageCakeeatup.SetActive(true);
                break;

        }
    }

    //ライターアイコンをタップ
    public void PushButtonLighterIconsmall()
    {
        SelectLighter++;
        if (SelectLighter > SelectLighter3)
        {
            SelectLighter = SelectLighter1;
        }
   
        ClearSelectIcon((int)ItemName.Lighter);
    }

    //ライターの表示
    void DisplayLighter()
    {
        switch (SelectLighter)
        {
            case SelectLighter1:
                buttonLighterIconsmall.GetComponent<Image>().sprite = LighterPicture;
                Itemuppanel.SetActive(false);
                imageLighterup.SetActive(false);
                break;
            case SelectLighter2:
                buttonLighterIconsmall.GetComponent<Image>().sprite = SelectLighterPicture;
                break;
            case SelectLighter3:
                Itemuppanel.SetActive(true);
                imageLighterup.SetActive(true);
                break;

        }
    }
    
    public void PushButtonLighter()
    {
        SelectCakeeat = SelectCakeeat1;
        DisplayCakeeat();
        buttonCakeeatIconsmall.SetActive(false);
        buttonLighterIconsmall.SetActive(true);
        ClearSelectIcon((int)ItemName.Lighter);
    }

    public void PushButtonLighter2()
    {
        SelectLighter = SelectLighter1;
        DisplayLighter();
        buttonLighterIconsmall.SetActive(false);
        SelectLighteron = SelectLighteron3;
        DisplayLighteron();
        buttonLighteronIconsmall.SetActive(true);
        ClearSelectIcon((int)ItemName.Lighteron);
    }



    //ライターオンアイコンをタップ
    public void PushButtonLighteronIconsmall()
    {
        SelectLighteron++;
        if (SelectLighteron > SelectLighteron3)
        {
            SelectLighteron = SelectLighteron1;
        }
       
        ClearSelectIcon((int)ItemName.Lighteron);
    }

    //ライターオンの表示
    void DisplayLighteron()
    {
        switch (SelectLighteron)
        {
            case SelectLighteron1:
                buttonLighteronIconsmall.GetComponent<Image>().sprite = LighteronPicture;
                Itemuppanel.SetActive(false);
                imageLighteronup.SetActive(false);
                flowchart.ExecuteBlock("SelectLighteron3");
                break;
            case SelectLighteron2:
                buttonLighteronIconsmall.GetComponent<Image>().sprite = SelectLighteronPicture;
                flowchart.ExecuteBlock("SelectLighteron2");
                break;
            case SelectLighteron3:
                Itemuppanel.SetActive(true);
                imageLighteronup.SetActive(true);
                buttonLighteronIconsmall.GetComponent<Image>().sprite = SelectLighteronPicture;
                flowchart.ExecuteBlock("SelectLighteron3");
                break;

        }
    }

    //バールアイコンをタップ
    public void PushButtonBarruIconsmall()
    {
        SelectBarru++;
        if (SelectBarru > SelectBarru3)
        {
            SelectBarru = SelectBarru1;
        }
      
        ClearSelectIcon((int)ItemName.Barru);
    }

    //バールの表示
    void DisplayBarru()
    {
        switch (SelectBarru)
        {
            case SelectBarru1:
                buttonBarruIconsmall.GetComponent<Image>().sprite = BarruPicture;
                Itemuppanel.SetActive(false);
                imageBarruup.SetActive(false);
                flowchart.ExecuteBlock("SelectBarru3");
                break;
            case SelectBarru2:
                buttonBarruIconsmall.GetComponent<Image>().sprite = SelectBarruPicture;
                flowchart.ExecuteBlock("SelectBarru2");
                break;
            case SelectBarru3:
                Itemuppanel.SetActive(true);
                imageBarruup.SetActive(true);
                flowchart.ExecuteBlock("SelectBarru3");
                break;

        }
    }

    public void PushButtonBarru()
    {
        buttonBarru.SetActive(false);
        buttonBarruIconsmall.SetActive(true);
        ClearSelectIcon((int)ItemName.Barru);

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
        Clearbuttons();


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
        Clearbuttons();


    }

    //各種表示をクリア
    public void Clearbuttons()
    {
        SelectTakarabako = SelectTakarabako1;
        DisplayTakarabako();
        SelectTakarabakoopen = SelectTakarabakoopen1;
        DisplayTakarabakoopen();
        SelectKey = SelectKey1;
        DisplayKey();
        SelectCake = SelectCake1;
        DisplayCake();
        SelectCakeeat = SelectCakeeat1;
        DisplayCakeeat();
        SelectLighter = SelectLighter1;
        DisplayLighter();
        SelectLighteron = SelectLighteron1;
        DisplayLighteron();
        SelectBarru = SelectBarru1;
        DisplayBarru();
      //  buttonRule.SetActive(false);
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
