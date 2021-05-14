using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Fungus;


public class GameManager2 : MonoBehaviour {

    public enum GameState
    {
        Opening,
        IPlaying,
        YPlaying,
        Clear,
        Over
    }

    public const int SelectCard1 = 1;
    public const int SelectCard2 = 2;
    public const int SelectCard3 = 3;


    //カード
    public GameObject imageCardup;
    public GameObject buttonCardIconsmall;
    public Sprite CardPicture;
    public Sprite SelectCardPicture;

    public GameObject buttonCup1;
    public GameObject buttonCup2;
    public GameObject buttonCup3;
    public GameObject buttonCup4;
    public GameObject buttonCup5;
    public Button buttonDrink;
    public GameObject ImageTurn1;
    public GameObject ImageTurn2;



    public Sprite Cup1Picture;
    public Sprite SelectCup1Picture;
    public Sprite Cup2Picture;
    public Sprite SelectCup2Picture;
    public Sprite Cup3Picture;
    public Sprite SelectCup3Picture;
    public Sprite Cup4Picture;
    public Sprite SelectCup4Picture;
    public Sprite Cup5Picture;
    public Sprite SelectCup5Picture;
    public GameState state;



    public GameObject panelUp;
    public GameObject PanelRule;
    public GameObject panelCup;
    public Flowchart flowchart;



    private int SelectCard;

    private bool[] exist_cup = { true, true, true, true, true };
    private bool doesSelectCup1;
    private bool doesSelectCup2;
    private bool doesSelectCup3;
    private bool doesSelectCup4;
    private bool doesSelectCup5;



    // Use this for initialization
    void Start() {

        SelectCard = SelectCard1;
        doesSelectCup1 = false;
        doesSelectCup2 = false;
        doesSelectCup3 = false;
        doesSelectCup4 = false;
        doesSelectCup5 = false;
        state = GameState.IPlaying;



    }

    // Update is called once per frame
    void Update() {

    }

    public void ClearButton()
    {
        panelUp.SetActive(false);
        imageCardup.SetActive(false);
        SelectCard = SelectCard1;
        DisplayCard();
    }

    public void ClearRule()
    {
        if (PanelRule.activeSelf)
        {
            PanelRule.SetActive(false);
            flowchart.ExecuteBlock("自分のターン");
        }
    }



    public void PushButtonCup1 ()
    {
        doesSelectCup1 = !doesSelectCup1;
        DisplayCup1();
    }

    public void PushButtonCup2()
    {
        doesSelectCup2 = !doesSelectCup2;
        DisplayCup2();
   
    }

    public void PushButtonCup3()
    {
        doesSelectCup3 = !doesSelectCup3;
        DisplayCup3();
       
    }

    public void PushButtonCup4()
    {
        doesSelectCup4 = !doesSelectCup4;
        DisplayCup4();
    }

    public void PushButtonCup5()
    {
        doesSelectCup5 = !doesSelectCup5;
        DisplayCup5();
    }

    public void PushButtonDrink()
    {
        bool sel_cup = false;
        flowchart.SetBooleanVariable("selectcup", false);

        panelCup.SetActive(true);
        if (doesSelectCup1 == true)
        {
            buttonCup1.SetActive(false);
            exist_cup[0] = false;
            if (state == GameState.IPlaying)
            {
                flowchart.ExecuteBlock("1GameOverScene");


            }
           /* else
            {
                SceneManager.LoadScene("4ConversationScene");// 成功の時のシーンを指定
            }*/
            doesSelectCup1 = false;
        }
        if (doesSelectCup2 == true)
        {
            exist_cup[1] = false;
            buttonCup2.SetActive(false);
            sel_cup = true;
            doesSelectCup2 = false;
        }
        if (doesSelectCup3 == true)
        {
            exist_cup[2] = false;
            buttonCup3.SetActive(false);
            sel_cup = true;
            doesSelectCup3 = false;

        }
        if (doesSelectCup4 == true)
        {
            exist_cup[3] = false;
            buttonCup4.SetActive(false);
            sel_cup = true;
            doesSelectCup4 = false;
        }
        if (doesSelectCup5 == true)
        {
            exist_cup[4] = false;
            buttonCup5.SetActive(false);
            sel_cup = true;
            doesSelectCup5 = false;
        }
        if (exist_cup[0] == true && exist_cup[1] == false && exist_cup[2] == false && exist_cup[3] == false && exist_cup[4] == false 
           && sel_cup == true && state == GameState.IPlaying)
        {
            SceneManager.LoadScene("4ConversationScene");/* 成功の時のシーンを指定*/
        }
        if (sel_cup == true)
        {
            flowchart.SetBooleanVariable("selectcup", true);

            if (state == GameState.IPlaying)
            {
                YouPlay();
            }
            else
            {
                IPlay();

            }
        }

    }





    void YouPlay()
    {
    
        state = GameState.YPlaying;
        flowchart.ExecuteBlock("相手のターン");
    }

    void IPlay()
    {

        state = GameState.IPlaying;
        flowchart.ExecuteBlock("自分のターン");
    }



    public void YouSelect()
    {
        bool val = false;
        for (int i = 1; i < 5; i++)
        {
            if (exist_cup[i] == true)
            {
                SelectCup(i);
                val = true;
                break;
            }
            }

        if (!val) SelectCup(0);

        flowchart.ExecuteBlock("飲む相手");
        Invoke("PushButtonDrink", 3.0f);
        



    }


    void SelectCup(int select)
{
    switch (select)
    {
        case 0:
            PushButtonCup1();
            break;
        case 1:
            PushButtonCup2();
            break;
        case 2:
            PushButtonCup3();
            break;
        case 3:
            PushButtonCup4();
            break;
        case 4:
            PushButtonCup5();
            break;
    }
 

}
/*
    void ButtonEnabled()
    {
        buttonCup1.enabled = !buttonCup1.enabled;
        buttonCup2.enabled = !buttonCup2.enabled;
        buttonCup3.enabled = !buttonCup3.enabled;
        buttonCup4.enabled = !buttonCup4.enabled;
        buttonCup5.enabled = !buttonCup5.enabled;
    }
*/
    void DisplayCup1()
    {
        switch (doesSelectCup1)
        {
            case false:
                buttonCup1.GetComponent<Image>().sprite = Cup1Picture;
                break;
            case true:
                buttonCup1.GetComponent<Image>().sprite = SelectCup1Picture;           

                break;

        }
    }

    void DisplayCup2()
    {
        switch (doesSelectCup2)
        {
            case false:
                buttonCup2.GetComponent<Image>().sprite = Cup2Picture;
                break;
            case true:
                buttonCup2.GetComponent<Image>().sprite = SelectCup2Picture;
                break;

        }
    }

    void DisplayCup3()
    {
        switch (doesSelectCup3)
        {
            case false:
                buttonCup3.GetComponent<Image>().sprite = Cup3Picture;
                break;
            case true:
                buttonCup3.GetComponent<Image>().sprite = SelectCup3Picture;
                break;

        }
    }

    void DisplayCup4()
    {
        switch (doesSelectCup4)
        {
            case false:
                buttonCup4.GetComponent<Image>().sprite = Cup4Picture;
                break;
            case true:
                buttonCup4.GetComponent<Image>().sprite = SelectCup4Picture;
                break;

        }
    }

    void DisplayCup5()
    {
        switch (doesSelectCup5)
        {
            case false:
                buttonCup5.GetComponent<Image>().sprite = Cup5Picture;
                break;
            case true:
                buttonCup5.GetComponent<Image>().sprite = SelectCup5Picture;
                break;

        }
    }

    //カード
    public void PushButtonCardIconsmall()
    {
        SelectCard++;
        if (SelectCard > SelectCard3)
        {
            SelectCard = SelectCard1;
        }
        DisplayCard();
    }

    void DisplayCard()
    {
        switch (SelectCard)
        {
            case SelectCard1:
                buttonCardIconsmall.GetComponent<Image>().sprite = CardPicture;
                imageCardup.SetActive(false);
                break;
            case SelectCard2:
                buttonCardIconsmall.GetComponent<Image>().sprite = SelectCardPicture;
                break;
            case SelectCard3:
                panelUp.SetActive(true);
                imageCardup.SetActive(true);
                break;

        }
    }


}
