using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Fungus;
using UnityEngine.SceneManagement;

public class GameManager15 : MonoBehaviour {

    public Image clear;
    public Image miss;
   
    public GameObject Item1;
    public GameObject Item2;
    public GameObject Item3;
    public GameObject Item4;
    public GameObject Item5;
    public GameObject Item6;
    public GameObject panelUp;
    public GameObject ButtonSelect;
    public GameObject ItemPos;
    public GameObject ItemPos2;
    public GameObject panelall;
    private int q2_1;
    public Image gage;
    public Sprite gage2;
    public Sprite gage1;
    public Sprite gage0;
    private int gage_count;

    public Flowchart flowchart;


    // Use this for initialization
    void Start () {
        q2_1 = 0;
        gage_count = 3;
       
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void DelGage()
    {
        gage_count = gage_count - 1;
       
        switch (gage_count)
        {
            case 2: gage.sprite = gage2;
                break;
            case 1: gage.sprite = gage1;
                break;
            case 0: gage.sprite = gage0;
                flowchart.ExecuteBlock("4GameoverScene");
              
                break;
        } 

    }

    public void ShowResult(bool val)
    {
        if (val)
        {
            clear.enabled = true;
            //clear.CrossFadeAlpha(0.0f, 5.0f, false)
        }
        else
        {
         // miss.enabled = true;
         // miss.CrossFadeAlpha(0.0f, 5.0f, true);
         // miss.enabled = false;
        }

    }


    public void ShowPanelUp(GameObject sel)
    {
        panelUp.SetActive(true);
        sel.SetActive(true);
        ButtonSelect.SetActive(true);

    }

    public void ClearPanel()
    {
        panelUp.SetActive(false);
        Item1.SetActive(false);
        Item2.SetActive(false);
        Item3.SetActive(false);
        Item4.SetActive(false);
        Item5.SetActive(false);
        Item6.SetActive(false);
        ButtonSelect.SetActive(false);
    }

    public void SelectBadPosition(int status)
    {
        ItemPos.SetActive(false);
        ItemPos2.SetActive(false);
        if (status == 3)
        {
            flowchart.ExecuteBlock("間違い3");
        }
        else if (status == 5)
        {
            flowchart.ExecuteBlock("間違い5");
        }
    }

    public void SelectItem(int quest,int num)
    {
        switch (quest)
        {
            case 2:
                if (q2_1 == 0)
                {
                    q2_1 = num;
                }
                else if ((q2_1 == 4 && num == 6) || (q2_1 == 6 && num == 4))
                {
                    flowchart.ExecuteBlock("集合写真");
                }
                else
                {
                    q2_1 = 0;                 
                    flowchart.ExecuteBlock("間違い1");
                }
                break;
            case 3:
                if (num == 1)
                {
                    flowchart.ExecuteBlock("花園孤児院のポスター");
                }
                else
                {
                    flowchart.ExecuteBlock("間違い2");
                }
                break;
            case 5:
                if (num == 2)
                {
                    flowchart.ExecuteBlock("カルテ");
                }
                else
                {
                    flowchart.ExecuteBlock("間違い4");
                }
                break;
            case 7:
                if (num == 5)
                {
                    flowchart.ExecuteBlock("手紙");
                }
                else
                {
                    flowchart.ExecuteBlock("間違い6");
                }
                break;
            }
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
                        flowchart.ExecuteBlock("会話1");
                        flag = false;
                    }

                }

            }


        }
    }


}
