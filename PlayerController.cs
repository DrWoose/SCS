using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    float Speed;
    public Slider healthBar;
    public int Blood;
    public int GameMode;
    bool TimerActing;
    KeyCode[] keySequence;
    int currentKeyIndex = 0;
    int ReviveTimes = 0;
    int InstructNum = 0;
    int level = 1;
    Coroutine deathTimer;
    public Script_UI_Instruct Script_Instruct;
    public Script_UI_GameOver Script_GameOver;

    public float pushPower = 100.0f;
    public float pushRadius = 30.0f;

    bool isRightDirection = true;
    public GameObject RightPlayer;
    public GameObject LeftPlayer;
    public Script_Sword RightSword;
    public Script_Sword LeftSword;



    KeyCode[] possibleKeys = new KeyCode[] { KeyCode.W, KeyCode.A, KeyCode.S, KeyCode.D };
    void Start()
    {
        GameMode = 0;
        Blood = 100;
        //0：Normal
        //1：UI
        //2：FallDown
        //3：GameOver
        Speed = 5.0f;
        healthBar.maxValue = 100;
    }

    

    // Update is called once per frame
    void Update()
    {
        switch(GameMode)
        {
            case 0: //Normal
                break;
            case 1: //UI
                return;
            case 2: //Fall Down
                break;
            case 3: //Game Over 
                return;
        }

        if(GameMode == 0)
        {
            ////Mode：Normal////
            //Check Death
            if (Blood <= 0)
            {
                GameMode = 2;
                PrepareGameMode2();

            }

            //Movement
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");
            Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
            transform.position = transform.position + movement * Speed * Time.deltaTime;

        
            //if 目前方向與目前朝向不一樣則轉換
            if(moveHorizontal==1 && isRightDirection==false)
            {
                RightPlayer.SetActive(true);
                LeftPlayer.SetActive(false);
                isRightDirection = true;
            }
            else if (moveHorizontal==-1 && isRightDirection==true)
            {
                RightPlayer.SetActive(false);
                LeftPlayer.SetActive(true);
                isRightDirection = false;
            }



            //Attack
            if (Input.GetKeyDown(KeyCode.J))
            {
                //Debug.Log("Sword attack!");
                StartCoroutine(Attack());



                Blood = Blood - 50;
                healthBar.value = Blood;
            }
            
        }
        else if(GameMode == 2)
        {

            if (Input.GetKeyDown(keySequence[currentKeyIndex]))
            {

                Script_Instruct.RemoveInstruct(level, currentKeyIndex);
                currentKeyIndex++;


                if (currentKeyIndex >= keySequence.Length)
                {
                    SuccessRevive();
                }
            }

            //開啟指令UI
            //根據難度(玩家復活次數)隨機生成指令
            //等待輸入指定Input
            //
        }



        ////Mode：UI////



        ////Mode：GameOver////


    }

    
    public void PrepareGameMode2()
    {
        ////Mode：FallDown////
        deathTimer = StartCoroutine(DeathTimer()); //計時
        GenerateInstruct();
        Script_Instruct.ShowUI_Instruct(level, keySequence);
        currentKeyIndex = 0;
    }

    void GenerateInstruct()
    {
        switch (ReviveTimes)
        {
            case 0:
            case 1:
                InstructNum = 1;
                level = 1;
                keySequence = new KeyCode[InstructNum];
                break;

            case 2:
            case 3:
                InstructNum = 3;
                level = 2;
                keySequence = new KeyCode[InstructNum];
                break;

            case 4:
            case 5:
                InstructNum = 5;
                level = 3;
                keySequence = new KeyCode[InstructNum];
                break;

            case 6:
            case 7:
                InstructNum = 7;
                level = 4;
                keySequence = new KeyCode[InstructNum];
                break;

            case 8:
            case 9:
                InstructNum = 9;
                level = 5;
                keySequence = new KeyCode[InstructNum];
                break;

            default:
                InstructNum = 11;
                level = 6;
                keySequence = new KeyCode[InstructNum];
                break;
        }

        for (int i = 0; i < InstructNum; i++)
        {
            int keyIndex = UnityEngine.Random.Range(0, possibleKeys.Length);
            keySequence[i] = possibleKeys[keyIndex];
           
        }
    }

    void SuccessRevive()
    {

        KnockBackEnemy();
        //KnockBackEnemy();
        if (deathTimer != null)
        {
            StopCoroutine(deathTimer);
            deathTimer = null;
        }
        
        currentKeyIndex = 0;
        GameMode = 0;
        Blood = 100;
        healthBar.value = Blood;
        ReviveTimes++;
        Script_Instruct.HideUI_Instruct();
        Debug.Log("You Revive!");
    }


void GameOver()
    {
        GameMode = 3;
        Script_GameOver.ShowUI_GameOver();
        Debug.Log("GameOver");
        //計算分數總結

        //呼叫 UI
    }

    IEnumerator DeathTimer()
    {
        Debug.Log("Timer started");
        yield return new WaitForSeconds(4);
        GameOver();
    }
    public void OnDestroy() {
        
    }

    public void KnockBackEnemy()
    {
        int AwayNum = 0;
        
        // 獲取玩家周圍的所有物體
        Collider[] colliders = Physics.OverlapSphere(transform.position, pushRadius);

        // 遍歷並推開所有敵人
        foreach (var collider in colliders)
        {
            if (collider.gameObject.CompareTag("Enemy"))
            {

                AwayNum++;
                
                Rigidbody enemyRb = collider.GetComponent<Rigidbody>();
                if (enemyRb != null)
                {
                   
                    Vector3 pushDirection = collider.transform.position - transform.position;
                    enemyRb.AddForce(pushDirection.normalized * pushPower, ForceMode.Impulse);
                }
            }
        }

        Debug.Log(AwayNum);
        
        
    }

    public void TakeDamaged(int DamageValue)
    {
        Blood = Blood - DamageValue;
        healthBar.value = Blood;
        Debug.Log(DamageValue);

    }

    IEnumerator Attack()
    {
        if (isRightDirection == true)
        {
            RightSword.Attack();
        }
        else
        {
            LeftSword.Attack();
        }

        yield return new WaitForSeconds(0.06f);


    }
}
