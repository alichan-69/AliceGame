using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager3 : MonoBehaviour {

    //定数定義：壁方向
    public const int WALL_FRONT = 1;
    public const int WALL_RIGHT = 2;
    public const int WALL_BACK = 3;
    public const int WALL_LEFT = 4;

    //定数定義：ボタンナンバー
    public const int NUMBER_0 = 0;
    public const int NUMBER_1 = 1;
    public const int NUMBER_2 = 2;
    public const int NUMBER_3 = 3;


    public const int SelectOno1 = 1;
    public const int SelectOno2 = 2;
    public const int SelectOno3 = 3;

    public const int SelectKasa1 = 1;
    public const int SelectKasa2 = 2;
    public const int SelectKasa3 = 3;

    public const int SelectKutusita1 = 1;
    public const int SelectKutusita2 = 2;
    public const int SelectKutusita3 = 3;

    public const int SelectKutusitakara1 = 1;
    public const int SelectKutusitakara2 = 2;
    public const int SelectKutusitakara3 = 3;

    public const int SelectKutusitakuuki1 = 1;
    public const int SelectKutusitakuuki2 = 2;
    public const int SelectKutusitakuuki3 = 3;

    public const int SelectHituzi1 = 1;
    public const int SelectHituzi2 = 2;
    public const int SelectHituzi3 = 3;

    public const int SelectBin1 = 1;
    public const int SelectBin2 = 2;
    public const int SelectBin3 = 3;

    public GameObject[] buttonKagi = new GameObject[4];

    public Sprite[] buttonPicture = new Sprite[4];



    public GameObject ButtonDoar1;
    public GameObject ButtonDoar2;
    public GameObject ButtonDoar4;
    public GameObject ButtonDoar4a;
    public GameObject ButtonDoar6;
    public GameObject ButtonDoar7;
    public GameObject ButtonDoar9;
    public GameObject ButtonDoar10;
    public GameObject ImageDoar9;
    public GameObject ImageDoar10;
    public GameObject ButtonDoaropen1;
    public GameObject ButtonDoaropen2;
    public GameObject ButtonDoaropen4;
    public GameObject ButtonDoaropen6;
    public GameObject ButtonDoaropen7;
    public GameObject ButtonDoaropen9;
    public GameObject ButtonDoaropen10;
    public GameObject ImageDoaropen9;
    public GameObject ImageDoaropen10;
    public GameObject ButtonChain;
    public GameObject ImageMemodoarup;
    public GameObject ButtonMemodoarup;
    public GameObject ButtonMemo;
    public GameObject imageSwitchup;
    public GameObject ButtonRule;
    public Flowchart flowchart;
    public GameObject panelUp;
    public GameObject buttonSouhuukou1;
    public GameObject buttonSouhuukou2;
    public GameObject buttonSouhuukou3;

    //傘
    public GameObject buttonKasa;
    public GameObject imageKasaup;
    public GameObject buttonKasaIconsmall;
    public Sprite KasaPicture;
    public Sprite SelectKasaPicture;

    //斧
    public GameObject buttonOno;
    public GameObject imageOnoup;
    public GameObject buttonOnoIconsmall;
    public Sprite OnoPicture;
    public Sprite SelectOnoPicture;

    //靴下
    public GameObject buttonKutusita;
    public GameObject imageKutusitaup;
    public GameObject buttonKutusitaIconsmall;
    public Sprite KutusitaPicture;
    public Sprite SelectKutusitaPicture;

    //靴下空
    public GameObject imageKutusitakaraup;
    public GameObject buttonKutusitakaraIconsmall;
    public Sprite KutusitakaraPicture;
    public Sprite SelectKutusitakaraPicture;

    //靴下空気
    public GameObject imageKutusitakuukiup;
    public GameObject buttonKutusitakuukiIconsmall;
    public Sprite KutusitakuukiPicture;
    public Sprite SelectKutusitakuukiPicture;

    //羊
    public GameObject buttonHituzi;
    public GameObject imageHituzi;
    public GameObject imageHituziup;
    public GameObject buttonHituziIconsmall;
    public Sprite HituziPicture;
    public Sprite SelectHituziPicture;

    //瓶
    public GameObject buttonBin;
    public GameObject imageBinup;
    public GameObject buttonBinIconsmall;
    public Sprite BinPicture;
    public Sprite SelectBinPicture;

    enum ItemName { 
          Ono,Kasa,Kutusita,Kutusitakara,Kutusitakuuki,Hituzi,Bin
    }

    public GameObject panelWalls;
    public GameObject ButtonRight;
    public GameObject ButtonLeft;





    private int wallNo;
    private int SelectOno;
    private int SelectKasa;
    private int SelectKutusita;
    private int SelectKutusitakara;
    private int SelectKutusitakuuki;
    private int SelectHituzi;
    private int SelectBin;
    private bool doesopenChain;
    private bool doesOnSouhuukou;
    private int[] buttonNumber = new int[4];
    
    

    // Use this for initialization
    void Start () {
        wallNo = WALL_FRONT;
        SelectOno = SelectOno1;
        SelectKasa = SelectKasa1;
        SelectKutusita = SelectKutusita1;
        SelectKutusitakara = SelectKutusitakara1;
        SelectKutusitakuuki = SelectKutusitakuuki1;
        SelectHituzi = SelectHituzi1;
        SelectBin = SelectBin1;
        doesopenChain = false;
        doesOnSouhuukou = false;
        buttonNumber[0] = NUMBER_0;
        buttonNumber[1] = NUMBER_0;
        buttonNumber[2] = NUMBER_0;
        buttonNumber[3] = NUMBER_0;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PushButtonKagi1()
    {
        ChangeButtonNumber(0);
    }

    public void PushButtonKagi2()
    {
        ChangeButtonNumber(1);
    }

    public void PushButtonKagi3()
    {
        ChangeButtonNumber(2);
    }

    public void PushButtonKagi4()
    {
        ChangeButtonNumber(3);
    }

    void ChangeButtonNumber(int buttonNo)
    {
        buttonNumber[buttonNo]++;
        if (buttonNumber[buttonNo] > NUMBER_3)
        {
            buttonNumber[buttonNo] = NUMBER_0;
        }
        buttonKagi[buttonNo].GetComponent<Image>().sprite =
            buttonPicture[buttonNumber[buttonNo]];

        if ((buttonNumber[0] == NUMBER_3) &&
            (buttonNumber[1] == NUMBER_1) &&
            (buttonNumber[2] == NUMBER_1) &&
            (buttonNumber[3] == NUMBER_2))
        {
            if(doesOnSouhuukou == false)
            {
                doesOnSouhuukou = true;
                imageSwitchup.SetActive(false);
                flowchart.ExecuteBlock("Souhuukou");
                buttonSouhuukou1.SetActive(false);
                buttonSouhuukou2.SetActive(true);

            }
        }
    }
    
    public void PushButtonSwitch()
    {
        if(doesOnSouhuukou == false)
        {
            panelUp.SetActive(true);
            imageSwitchup.SetActive(true);
        }
        else
        {
        }
    }

   

    //ドアをタップ
    public void PushButtonDoar1 ()
    {
        ButtonDoar1.SetActive(false);
        ButtonDoaropen1.SetActive(true);
    }

   

    public void PushButtonDoar4a()
    {
        if (doesopenChain == true)
        {           
            ButtonDoar4a.SetActive(false);
            ButtonDoaropen4.SetActive(true);
            flowchart.ExecuteBlock("doesopenChain");
        }
        else
        {
           
        }
    }

    public void PushButtonDoar6()
    {
        ButtonDoar6.SetActive(false);
        ButtonDoaropen6.SetActive(true);
    }

   

    public void PushButtonDoar9()
    {
        ButtonDoar9.SetActive(false);
        ImageDoar9.SetActive(false);
        ButtonDoaropen9.SetActive(true);
        ImageDoaropen9.SetActive(true);
    }

    public void PushButtonDoar10()
    {
        ButtonDoar10.SetActive(false);
        ImageDoar10.SetActive(false);
        ButtonDoaropen10.SetActive(true);
        ImageDoaropen10.SetActive(true);
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
        ButtonDoar4a.SetActive(true);
    }

    public void PushButtonDoaropen6()
    {
        ButtonDoaropen6.SetActive(false);
        ButtonDoar6.SetActive(true);
    }
    
    public void PushButtonDoaropen7()
    {
        ButtonDoaropen7.SetActive(false);
        ButtonDoar7.SetActive(true);
    }
    public void PushButtonDoaropen9()
    {
        ButtonDoaropen9.SetActive(false);
        ImageDoaropen9.SetActive(false);
        ButtonDoar9.SetActive(true);
        ImageDoar9.SetActive(true);
    }

    public void PushButtonDoaropen10()
    {
        ButtonDoaropen10.SetActive(false);
        ImageDoaropen10.SetActive(false);
        ButtonDoar10.SetActive(true);
        ImageDoar10.SetActive(true);
    }

    public void PushButtonTenbin()
    {
        flowchart.ExecuteBlock("天秤");
    }
   
    public void PushButtonChain()
    {if (SelectOno == SelectOno2)
        {
            flowchart.ExecuteBlock("doesCutChain");
            ButtonDoar4.SetActive(false);
            ButtonDoar4a.SetActive(true);
            doesopenChain = true;
        }
        else
        {
           
        }
    }

    public void PushButtonFuck()
    {
        if(SelectKasa == SelectKasa2)
        {
            ButtonDoar7.SetActive(false);
            ButtonDoaropen7.SetActive(true);
        }
        else
        {
          
        }
    }
    public void PushButtonMemoDoar()
    {
        panelUp.SetActive(true);
        ImageMemodoarup.SetActive(true);
    }
    public void PushButtonMemodoarup()
    {
        ButtonMemodoarup.SetActive(false);
        ButtonMemo.SetActive(true);
    }

    public void PushButtonMemo()
    {
        ButtonMemo.SetActive(false);
        ButtonMemodoarup.SetActive(true);
    }

    public void PushButtonKasa()
    {
        
       
        buttonKasaIconsmall.SetActive(true);
        buttonKasa.SetActive(false);
        ClearSelectIcon((int)ItemName.Kasa);
    }

    public void PushButtonOno()
    {
       
        buttonOnoIconsmall.SetActive(true);
        buttonOno.SetActive(false);
        ClearSelectIcon((int)ItemName.Ono);
    }

    public void PushButtonKutusita()
    {
        buttonKutusitaIconsmall.SetActive(true);
        buttonKutusita.SetActive(false);
        ClearSelectIcon((int)ItemName.Kutusita);
    }

    public void PushButtonHituzi()
    {
        buttonHituziIconsmall.SetActive(true);
        buttonHituzi.SetActive(false);
        imageHituzi.SetActive(false);
        ClearSelectIcon((int)ItemName.Hituzi);
    }

    public void PushButtonBin()
    {
       
        buttonBinIconsmall.SetActive(true);
        buttonBin.SetActive(false);
        ClearSelectIcon((int)ItemName.Bin);
    }



    public void PushButtonOkasi()
    {
        buttonKutusitaIconsmall.SetActive(false);
        imageKutusitaup.SetActive(false);
        buttonKutusitakaraIconsmall.SetActive(true);
        ClearSelectIcon((int)ItemName.Kutusitakara);

    }

  

    public void PushButtonHai()
    {
        if(SelectKutusitakuuki == SelectKutusitakuuki2)
        {
            SceneManager.LoadScene("6ConversationScene");
        }
        else { flowchart.ExecuteBlock("2GameoverScene"); }
    }


    public void PushButtonSouhuukou()
    {
        if((SelectKutusitakara == SelectKutusitakara2) &&
           (doesOnSouhuukou == true))
        {
            flowchart.ExecuteBlock("送風口２");
            SelectKutusitakara = SelectKutusitakara1;
            buttonKutusitakaraIconsmall.SetActive(false);
            buttonKutusitakuukiIconsmall.SetActive(true);
            buttonSouhuukou2.SetActive(false);
            buttonSouhuukou3.SetActive(true);

            //ClearSelectIcon((int)ItemName.Kutusitakuuki);


        }
    }

    public void PushButtonSouhuukou2()
    {
        if ((SelectKutusitakara == SelectKutusitakara1) &&
           (doesOnSouhuukou == true))
        {
            flowchart.ExecuteBlock("送風口3");
        }
    }

    public void PushButtonSouhuukou3()
    {
            flowchart.ExecuteBlock("送風口1");
    }

    private void ClearSelectIcon(int num)
    {
        switch (num)
        {
            case (int)ItemName.Ono:
            
                SelectKasa = SelectKasa1;
                SelectKutusita = SelectKutusita1;
                SelectKutusitakara = SelectKutusitakara1;
                SelectKutusitakuuki = SelectKutusitakuuki1;
                SelectHituzi = SelectHituzi1;
                SelectBin = SelectBin1;

                DisplayKasa();
                DisplayKutusita();
                DisplayKutusitakara();
                DisplayKutusitakuuki();
                DisplayHituzi();
                DisplayBin();
                DisplayOno();
                break;
            case (int)ItemName.Kasa:
                SelectOno = SelectOno1;
            
                SelectKutusita = SelectKutusita1;
                SelectKutusitakara = SelectKutusitakara1;
                SelectKutusitakuuki = SelectKutusitakuuki1;
                SelectHituzi = SelectHituzi1;
                SelectBin = SelectBin1;

                DisplayKutusita();
                DisplayKutusitakara();
                DisplayKutusitakuuki();
                DisplayHituzi();
                DisplayBin();
                DisplayOno();
                DisplayKasa();
                break;
            case (int)ItemName.Kutusita:
                SelectOno = SelectOno1;
                SelectKasa = SelectKasa1;
             
                SelectKutusitakara = SelectKutusitakara1;
                SelectKutusitakuuki = SelectKutusitakuuki1;
                SelectHituzi = SelectHituzi1;
                SelectBin = SelectBin1;
        
                DisplayKutusitakara();
                DisplayKutusitakuuki();
                DisplayHituzi();
                DisplayBin();
                DisplayOno();
                DisplayKasa();
                DisplayKutusita();
                break;
            case (int)ItemName.Kutusitakara:
                SelectOno = SelectOno1;
                SelectKasa = SelectKasa1;
                SelectKutusita = SelectKutusita1;
          
                SelectKutusitakuuki = SelectKutusitakuuki1;
                SelectHituzi = SelectHituzi1;
                SelectBin = SelectBin1;
                
                DisplayKutusitakuuki();
                DisplayHituzi();
                DisplayBin();
                DisplayOno();
                DisplayKasa();
                DisplayKutusita();
                DisplayKutusitakara();
                break;
            case (int)ItemName.Kutusitakuuki:
                SelectOno = SelectOno1;
                SelectKasa = SelectKasa1;
                SelectKutusita = SelectKutusita1;
                SelectKutusitakara = SelectKutusitakara1;
            
                SelectHituzi = SelectHituzi1;
                SelectBin = SelectBin1;
               
                DisplayHituzi();
                DisplayBin();
                DisplayOno();
                DisplayKasa();
                DisplayKutusita();
                DisplayKutusitakara();
                DisplayKutusitakuuki();
                break;
            case (int)ItemName.Hituzi:
                SelectOno = SelectOno1;
                SelectKasa = SelectKasa1;
                SelectKutusita = SelectKutusita1;
                SelectKutusitakara = SelectKutusitakara1;
                SelectKutusitakuuki = SelectKutusitakuuki1;
             
                SelectBin = SelectBin1;
               
                DisplayBin();
                DisplayOno();
                DisplayKasa();
                DisplayKutusita();
                DisplayKutusitakara();
                DisplayKutusitakuuki();
                DisplayHituzi();
                break;
            case (int)ItemName.Bin:
                SelectOno = SelectOno1;
                SelectKasa = SelectKasa1;
                SelectKutusita = SelectKutusita1;
                SelectKutusitakara = SelectKutusitakara1;
                SelectKutusitakuuki = SelectKutusitakuuki1;
                SelectHituzi = SelectHituzi1;
               
                DisplayOno();
                DisplayKasa();
                DisplayKutusita();
                DisplayKutusitakara();
                DisplayKutusitakuuki();
                DisplayHituzi();
                DisplayBin();

                break;

        }
      
    }


    //傘アイコンをタップ
    public void PushButtonKasaIconsmall()
    {

        SelectKasa++;
        if (SelectKasa > SelectKasa3)
        {
            SelectKasa = SelectKasa1;
        }
        ClearSelectIcon((int)ItemName.Kasa);
    }
    
    //斧アイコンをタップ
    public void PushButtonOnoIconsmall()
    {
        SelectOno++;
        if (SelectOno > SelectOno3)
        {
            SelectOno = SelectOno1;
        }
        ClearSelectIcon((int)ItemName.Ono);
    }


    //靴下アイコンをタップ
    public void PushButtonKutusitaIconsmall()
    {
        SelectKutusita++;
        if (SelectKutusita > SelectKutusita3)
        {
            SelectKutusita = SelectKutusita1;
        }
        
        ClearSelectIcon((int)ItemName.Kutusita);
    }
    

    //靴下空アイコンをタップ
    public void PushButtonKutusitakaraIconsmall()
    {
        SelectKutusitakara++;
        if (SelectKutusitakara > SelectKutusitakara3)
        {
            SelectKutusitakara = SelectKutusitakara1;
        }
       
        ClearSelectIcon((int)ItemName.Kutusitakara);
    }

    //靴下空気アイコンをタップ
    public void PushButtonKutusitakuukiIconsmall()
    {
        SelectKutusitakuuki++;
        if (SelectKutusitakuuki > SelectKutusitakuuki3)
        {
            SelectKutusitakuuki = SelectKutusitakuuki1;
        }
       
        ClearSelectIcon((int)ItemName.Kutusitakuuki);
    }

    //羊アイコンをタップ
    public void PushButtonHituziIconsmall()
    {
        SelectHituzi++;
        if (SelectHituzi > SelectHituzi3)
        {
            SelectHituzi = SelectHituzi1;
        }
    

        ClearSelectIcon((int)ItemName.Hituzi);
    }


    //瓶アイコンをタップ
    public void PushButtonBinIconsmall()
    {
        SelectBin++;
        if (SelectBin > SelectBin3)
        {
            SelectBin = SelectBin1;
        }
    
        ClearSelectIcon((int)ItemName.Bin);
    }

    //ルールボタンをタップ
    public void PushButtonRule()
    {
        ButtonRule.SetActive(false);
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

    //傘の表示
    void DisplayKasa()
    {
        switch (SelectKasa)
        {
            case SelectKasa1:
                panelUp.SetActive(false);
                buttonKasaIconsmall.GetComponent<Image>().sprite = KasaPicture;
                imageKasaup.SetActive(false);
                flowchart.ExecuteBlock("SelectKasa3");
                flowchart.ExecuteBlock("doesHaveThing0");
                break;
            case SelectKasa2:
                buttonKasaIconsmall.GetComponent<Image>().sprite = SelectKasaPicture;
                flowchart.ExecuteBlock("SelectKasa2");
                flowchart.ExecuteBlock("doesHaveThing1");
                break;
            case SelectKasa3:
                panelUp.SetActive(true);
                imageKasaup.SetActive(true);
                flowchart.ExecuteBlock("SelectKasa3");
                flowchart.ExecuteBlock("doesHaveThing2");
                break;

        }
    }

    //斧の表示
    void DisplayOno()
    {
        switch (SelectOno)
        {
            case SelectOno1:
                panelUp.SetActive(false);
                buttonOnoIconsmall.GetComponent<Image>().sprite = OnoPicture;
                imageOnoup.SetActive(false);
                flowchart.ExecuteBlock("SelectOno3");
                flowchart.ExecuteBlock("doesHaveThing0");
                break;
            case SelectOno2:
                buttonOnoIconsmall.GetComponent<Image>().sprite = SelectOnoPicture;
                flowchart.ExecuteBlock("doesHaveThing1");
                flowchart.ExecuteBlock("SelectOno2");
                break;
            case SelectOno3:
                panelUp.SetActive(true);
                imageOnoup.SetActive(true);
                flowchart.ExecuteBlock("doesHaveThing2");
                flowchart.ExecuteBlock("SelectOno3");
                break;

        }
    }

    //靴下の表示
    void DisplayKutusita()
    {
        switch (SelectKutusita)
        {
            case SelectKutusita1:
                panelUp.SetActive(false);
                buttonKutusitaIconsmall.GetComponent<Image>().sprite = KutusitaPicture;
                imageKutusitaup.SetActive(false);
                flowchart.ExecuteBlock("doesHaveThing0");
                break;
            case SelectKutusita2:
                buttonKutusitaIconsmall.GetComponent<Image>().sprite = SelectKutusitaPicture;
                flowchart.ExecuteBlock("doesHaveThing1");
                break;
            case SelectKutusita3:
                panelUp.SetActive(true);
                imageKutusitaup.SetActive(true);
                flowchart.ExecuteBlock("doesHaveThing2");
                break;

        }
    }

    //靴下空の表示
    void DisplayKutusitakara()
    {
        switch (SelectKutusitakara)
        {
            case SelectKutusitakara1:
                panelUp.SetActive(false);
                buttonKutusitakaraIconsmall.GetComponent<Image>().sprite = KutusitakaraPicture;
                imageKutusitakaraup.SetActive(false);
                flowchart.ExecuteBlock("doesHaveThing0");
                flowchart.ExecuteBlock("SelectKutusitakara3");
                break;
            case SelectKutusitakara2:
                buttonKutusitakaraIconsmall.GetComponent<Image>().sprite = SelectKutusitakaraPicture;
                flowchart.ExecuteBlock("doesHaveThing1");
                flowchart.ExecuteBlock("SelectKutusitakara2");
                break;
            case SelectKutusitakara3:
                panelUp.SetActive(true);
                imageKutusitakaraup.SetActive(true);
                flowchart.ExecuteBlock("doesHaveThing2");
                flowchart.ExecuteBlock("SelectKutusitakara3");
                break;

        }
    }

    //靴下空気の表示
    void DisplayKutusitakuuki()
    {
        switch (SelectKutusitakuuki)
        {
            case SelectKutusitakuuki1:
                panelUp.SetActive(false);
                buttonKutusitakuukiIconsmall.GetComponent<Image>().sprite = KutusitakuukiPicture;
                imageKutusitakuukiup.SetActive(false);
                flowchart.ExecuteBlock("doesHaveThing0");
                flowchart.ExecuteBlock("SelectKutusitakuuki");
                break;
            case SelectKutusitakuuki2:
                buttonKutusitakuukiIconsmall.GetComponent<Image>().sprite = SelectKutusitakuukiPicture;
                flowchart.ExecuteBlock("doesHaveThing1");
                flowchart.ExecuteBlock("SelectKutusitakuuki2");

                break;
            case SelectKutusitakuuki3:
                panelUp.SetActive(true);
                imageKutusitakuukiup.SetActive(true);
                flowchart.ExecuteBlock("doesHaveThing2");
                flowchart.ExecuteBlock("SelectKutusitakuuki3");
                break;

        }
    }


    //羊の表示
    void DisplayHituzi()
    {
        switch (SelectHituzi)
        {
            case SelectHituzi1:
                panelUp.SetActive(false);
                buttonHituziIconsmall.GetComponent<Image>().sprite = HituziPicture;
                imageHituziup.SetActive(false);
                flowchart.ExecuteBlock("doesHaveThing0");
                break;
            case SelectHituzi2:
                buttonHituziIconsmall.GetComponent<Image>().sprite = SelectHituziPicture;
                flowchart.ExecuteBlock("doesHaveThing1");
                break;
            case SelectHituzi3:
                panelUp.SetActive(true);
                imageHituziup.SetActive(true);
                flowchart.ExecuteBlock("doesHaveThing2");
                break;

        }
    }


    //瓶の表示
    void DisplayBin()
    {
        switch (SelectBin)
        {
            case SelectBin1:
                panelUp.SetActive(false);
                buttonBinIconsmall.GetComponent<Image>().sprite = BinPicture;
                imageBinup.SetActive(false);
                flowchart.ExecuteBlock("doesHaveThing0");
                break;
            case SelectBin2:
                buttonBinIconsmall.GetComponent<Image>().sprite = SelectBinPicture;
                flowchart.ExecuteBlock("doesHaveThing1");
                break;
            case SelectBin3:
                panelUp.SetActive(true);
                imageBinup.SetActive(true);
                flowchart.ExecuteBlock("doesHaveThing2");
                break;

        }
    }

  

    //ボタンを消去
    public void ClearButtons()
    {
        panelUp.SetActive(false);
        ImageMemodoarup.SetActive(false);
        ButtonMemodoarup.SetActive(true);
        ButtonMemo.SetActive(false);
        SelectKasa = SelectKasa1;
        DisplayKasa();
        SelectOno = SelectOno1;
        DisplayOno();
        SelectKutusita = SelectKutusita1;
        DisplayKutusita();
        SelectKutusitakara = SelectKutusitakara1;
        DisplayKutusitakara();
        SelectKutusitakuuki = SelectKutusitakuuki1;
        DisplayKutusitakuuki();
        SelectHituzi = SelectHituzi1;
        DisplayHituzi();
        SelectBin = SelectBin1;
        DisplayBin();
        imageSwitchup.SetActive(false);
        buttonNumber[0] = NUMBER_0;
        buttonNumber[1] = NUMBER_0;
        buttonNumber[2] = NUMBER_0;
        buttonNumber[3] = NUMBER_0;
        buttonKagi[0].GetComponent<Image>().sprite =
            buttonPicture[buttonNumber[0]];
        buttonKagi[1].GetComponent<Image>().sprite =
            buttonPicture[buttonNumber[0]];
        buttonKagi[2].GetComponent<Image>().sprite =
            buttonPicture[buttonNumber[0]];
        buttonKagi[3].GetComponent<Image>().sprite =
            buttonPicture[buttonNumber[0]];
      
        


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
