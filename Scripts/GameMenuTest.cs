using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Video;
using Fungus;


public class GameMenuTest : MonoBehaviour
{
    private const int Hinto1 = 1;
    private const int Hinto2 = 2;
    private const int Hinto3 = 3;
    private const int HintoK = 4;

    public GameObject Backpanel;
    public GameObject Menupanel;
    public GameObject Itemspanel;
    public GameObject Hintpanel;
    public GameObject Moviepanel;
    public GameObject Moviecontrol;
    public GameObject Messagepanel;
    public GameObject Itempanel;
    public GameObject Titlepanel;
    public VideoPlayer mPlayer;
    public Image MessageImage;
    public Sprite clear_hint;
    public Sprite hint1;
    public Sprite hint2;
    public Sprite hint3;
    public int select_item = 0;
    public Flowchart item_flowchart;
    public Sprite Item1;
    public Sprite Item2;
    public Sprite Item3;
    public Sprite Item4;
    public Sprite Item5;
    public Sprite Item6;
    public Sprite Item7;
    public Sprite Item8;
    public Sprite Item9;
    public Sprite Item10;
    public Sprite Item11;
    public Sprite Item12;
    public GameObject Text;

    private int Button;




    // Use this for initialization
    void Start()
    {

        HideMenu();
        Button = Hinto1;




    }

    // Update is called once per frame
    void Update()
    {



    }




    public void ShowMenu()
    {
        if (Menupanel.activeSelf)
        {
            HideMenu();
        }
        else
        {
            HideMenu();
            Backpanel.SetActive(true);
            Menupanel.SetActive(true);
        }
    }

    public void HideMenu()
    {
        Backpanel.SetActive(false);
        Menupanel.SetActive(false);
        Itemspanel.SetActive(false);
        Hintpanel.SetActive(false);
        Moviepanel.SetActive(false);
        Messagepanel.SetActive(false);
        Itempanel.SetActive(false);
    }

    public void ReturnMenu()
    {
        Titlepanel.SetActive(false);
        Itemspanel.SetActive(false);
        Hintpanel.SetActive(false);
        Menupanel.SetActive(true);

    }

    public void ReturnItemsPanel()
    {
        Itempanel.SetActive(false);
        Itemspanel.SetActive(true);
    }

    public void ReturnHintPanel()
    {
        Messagepanel.SetActive(false);
        Moviepanel.SetActive(false);
        Hintpanel.SetActive(true);

    }


    public void ShowTitleScene()
    {
        SceneManager.LoadScene("TitleScene");

    }

    public void ShowTitlePanel()
    {
        Menupanel.SetActive(false);
        Titlepanel.SetActive(true);
    }

    public void ShowItemsPanel()
    {
        Menupanel.SetActive(false);
        Itemspanel.SetActive(true);
        Itempanel.SetActive(false);

    }

    public void ShowItem(int item_num)
    {
        Itempanel.SetActive(true);
        item_flowchart.SetIntegerVariable("item_num", item_num);


        switch (item_num)
        {
            case 1:
                Itempanel.GetComponent<Image>().sprite = Item1;

                break;
            case 2:
                Itempanel.GetComponent<Image>().sprite = Item2;

                break;
            case 3:
                Itempanel.GetComponent<Image>().sprite = Item3;

                break;
            case 4:
                Itempanel.GetComponent<Image>().sprite = Item4;

                break;
            case 5:
                Itempanel.GetComponent<Image>().sprite = Item5;

                break;
            case 6:
                Itempanel.GetComponent<Image>().sprite = Item6;

                break;
            case 7:
                Itempanel.GetComponent<Image>().sprite = Item7;

                break;
            case 8:
                Itempanel.GetComponent<Image>().sprite = Item8;
                break;
            case 9:
                Itempanel.GetComponent<Image>().sprite = Item11;
                break;
            case 10:
                Itempanel.GetComponent<Image>().sprite = Item10;

                break;
            case 11:
                Itempanel.GetComponent<Image>().sprite = Item11;

                break;
            case 12:
                Itempanel.GetComponent<Image>().sprite = Item12;

                break;
        }




    }

    public void ShowHint()
    {
        Menupanel.SetActive(false);
        Hintpanel.SetActive(true);

    }
    public void ShowMessage()
    {
        switch (Button)
        {
            case Hinto1:
                DisplayMessage("ヒント1");
                break;
            case Hinto2:
                DisplayMessage("ヒント2");
                break;
            case Hinto3:
                DisplayMessage("ヒント3");
                break;
            case HintoK:
                DisplayMessage("ヒントが解放されました！");
                break;

        }
        Hintpanel.SetActive(false);
        Moviepanel.SetActive(false);
        Messagepanel.SetActive(true);

    }

    public void H1()
    {
        Button = Hinto1;
    }

    public void H2()
    {
        Button = Hinto2;
    }

    public void H3()
    {
        Button = Hinto3;
    }

    public void HK()
    {
        Button = HintoK;
    }

    public void ShowMovie()
    {
        Hintpanel.SetActive(false);
        Moviepanel.SetActive(true);

    }

    public void PlayMovie()
    {
        Moviecontrol.SetActive(true);
        mPlayer.Play();
    }

    public void StopMovie()
    {
        if (!mPlayer.isPlaying)
        {
            mPlayer.Pause();
            Moviecontrol.SetActive(false);
        }
    }

    public void ActionMovie()
    {
        Moviepanel.SetActive(false);
    }

    //メッセージを表示
    void DisplayMessage(string mes)
    {
        Text.GetComponent<Text>().text = mes;
    }



}
