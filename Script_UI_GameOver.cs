using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_UI_GameOver : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject UI_GameOver;

    public void ShowUI_GameOver()
    {
        UI_GameOver.SetActive(true);
    }
}
