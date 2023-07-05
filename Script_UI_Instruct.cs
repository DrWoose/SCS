using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;




public class Script_UI_Instruct : MonoBehaviour
{
    public GameObject UI_InteractCanva;

    public GameObject UI_Level1;
    public GameObject UI_Level2;
    public GameObject UI_Level3;
    public GameObject UI_Level4;
    public GameObject UI_Level5;
    public GameObject UI_Level6;

    public Text[] A;
    public Text[] B;
    public Text[] C;
    public Text[] D;
    public Text[] E;
    public Text[] F;



    public Text A1;

    public Text B1;
    public Text B2;
    public Text B3;

    public Text C1;
    public Text C2;
    public Text C3;
    public Text C4;
    public Text C5;

    public Text D1;
    public Text D2;
    public Text D3;
    public Text D4;
    public Text D5;
    public Text D6;
    public Text D7;

    public Text E1;
    public Text E2;
    public Text E3;
    public Text E4;
    public Text E5;
    public Text E6;
    public Text E7;
    public Text E8;
    public Text E9;

    public Text F1;
    public Text F2;
    public Text F3;
    public Text F4;
    public Text F5;
    public Text F6;
    public Text F7;
    public Text F8;
    public Text F9;
    public Text F10;
    public Text F11;
    // Start is called before the first frame update

    int CurrentLevel;

    void Start()
    {
        // Initialize the arrays
        A = new Text[] { A1 };
        B = new Text[] { B1, B2, B3 };
        C = new Text[] { C1, C2, C3, C4, C5 };
        D = new Text[] { D1, D2, D3, D4, D5, D6, D7 };
        E = new Text[] { E1, E2, E3, E4, E5, E6, E7, E8, E9 };
        F = new Text[] { F1, F2, F3, F4, F5, F6, F7, F8, F9, F10, F11 };

        // Your other code...
    }


    public void ShowUI_Instruct(int level, KeyCode[] KeySequence)
    {
        
        UI_InteractCanva.SetActive(true);
        switch(level) 
        {
            case 1:
                CurrentLevel = 1;
                UI_Level1.SetActive(true);
                A1.text = KeySequence[0].ToString();
                foreach (Text text in A)
                {
                    text.gameObject.SetActive(true);
                }
                break;
            case 2:
                CurrentLevel = 2;
                UI_Level2.SetActive(true);
                B1.text = KeySequence[0].ToString();
                B2.text = KeySequence[1].ToString();
                B3.text = KeySequence[2].ToString();
                foreach (Text text in B)
                {
                    text.gameObject.SetActive(true);
                }
                break;
            case 3:
                CurrentLevel = 3;
                UI_Level3.SetActive(true);
                C1.text = KeySequence[0].ToString();
                C2.text = KeySequence[1].ToString();
                C3.text = KeySequence[2].ToString();
                C4.text = KeySequence[3].ToString();
                C5.text = KeySequence[4].ToString();
                foreach (Text text in C)
                {
                    text.gameObject.SetActive(true);
                }
                break;
            case 4:
                CurrentLevel = 4;
                UI_Level4.SetActive(true);
                D1.text = KeySequence[0].ToString();
                D2.text = KeySequence[1].ToString();
                D3.text = KeySequence[2].ToString();
                D4.text = KeySequence[3].ToString();
                D5.text = KeySequence[4].ToString();
                D6.text = KeySequence[5].ToString();
                D7.text = KeySequence[6].ToString();
                foreach (Text text in D)
                {
                    text.gameObject.SetActive(true);
                }
                break;
            case 5:
                CurrentLevel = 5;
                UI_Level5.SetActive(true);
                E1.text = KeySequence[0].ToString();
                E2.text = KeySequence[1].ToString();
                E3.text = KeySequence[2].ToString();
                E4.text = KeySequence[3].ToString();
                E5.text = KeySequence[4].ToString();
                E6.text = KeySequence[5].ToString();
                E7.text = KeySequence[6].ToString();
                E8.text = KeySequence[7].ToString();
                E9.text = KeySequence[8].ToString();
                foreach (Text text in E)
                {
                    text.gameObject.SetActive(true);
                }
                break;
            case 6:
                CurrentLevel = 6;
                UI_Level6.SetActive(true);
                F1.text = KeySequence[0].ToString();
                F2.text = KeySequence[1].ToString();
                F3.text = KeySequence[2].ToString();
                F4.text = KeySequence[3].ToString();
                F5.text = KeySequence[4].ToString();
                F6.text = KeySequence[5].ToString();
                F7.text = KeySequence[6].ToString();
                F8.text = KeySequence[7].ToString();
                F9.text = KeySequence[8].ToString();
                F10.text = KeySequence[9].ToString();
                F11.text = KeySequence[10].ToString();
                foreach (Text text in F)
                {
                    text.gameObject.SetActive(true);
                }
                break;
        }




    }

    public void HideUI_Instruct()
    {
        
        switch(CurrentLevel)
        {
            case 1:
                UI_Level1.SetActive(false);
                break;
            case 2:
                UI_Level2.SetActive(false);
                break;
            case 3:
                UI_Level3.SetActive(false);
                break;
            case 4:
                UI_Level4.SetActive(false);
                break;
            case 5:
                UI_Level5.SetActive(false);
                break;
            case 6:
                UI_Level6.SetActive(false);
                break;
        }

        UI_InteractCanva.SetActive(false);
    }

    public void RemoveInstruct(int level, int index)
    {
        switch(level)
        {
            case 1:
                A[index].gameObject.SetActive(false);
                break;
            case 2:
                B[index].gameObject.SetActive(false);
                break;
            case 3:
                C[index].gameObject.SetActive(false);
                break;
            case 4:
                D[index].gameObject.SetActive(false);
                break;
            case 5:
                E[index].gameObject.SetActive(false);
                break;
            case 6:
                F[index].gameObject.SetActive(false);
                break;
        }
    }
}
