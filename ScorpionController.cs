using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScorpionController : MonoBehaviour
{
    public float knockbackForce;
    public GameObject player;
    public GameObject terrain;
    public EnemySpawner level;
    //Animator animator;
    [SerializeField] private EnemyAttackCooldown enemy_attack_cooldown;

    private int scorpion_HP = 100;
    public int scorpion_ATK = 5;
    public int scorpion_speed = 1;
    public int scorpion_cooldown = 1;
    private float timer = 0;
    private float speed = 3f;
    void Start() {
        player = GameObject.FindWithTag("Player");
        terrain = GameObject.FindWithTag("Terrain");
        level = GameObject.FindGameObjectWithTag("Spawner").GetComponent<EnemySpawner>();
        Debug.Log(level.level);
        scorpion_HP *= level.level;
        //animator = GetComponent<Animator>();
        //Debug.Log(terrain.name);
        Physics.IgnoreCollision(gameObject.GetComponent<Collider>(), terrain.GetComponent<Collider>(), true);
    }
    void Update() {
        
        // Game mode:
        //0：Normal
        //1：UI
        //2：FallDown
        //3：GameOver
        if(player.GetComponent<PlayerController>().GameMode == 0) {
            Vector3 player_position = new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z);
            transform.position = Vector3.MoveTowards(transform.position, player_position, scorpion_speed * Time.deltaTime);
            //Debug.Log(player_position);
        }

    }

    private void OnTriggerStay(Collider other) {
        Debug.Log("hit");
        if(enemy_attack_cooldown.IsCoolingDown)
            return;
        if(player.GetComponent<PlayerController>().GameMode != 0)
            return;
        if(other.gameObject.tag == ("Player")) {
            gameObject.GetComponent<Animator>().CrossFadeInFixedTime("AttackAnimtion", 0);
            player.GetComponent<PlayerController>().TakeDamaged(scorpion_ATK);
            TakeDamage(10);
            //Debug.Log(player.GetComponent<PlayerController>().Blood);
        }
        if(player.GetComponent<PlayerController>().Blood <= 0) {
            player.GetComponent<PlayerController>().GameMode = 2;
            player.GetComponent<PlayerController>().PrepareGameMode2();
        }
        enemy_attack_cooldown.StartCooldown();
    }

    public void TakeDamage(int DamageValue) {
        /*
        rb = GetComponent<Rigidbody>();
        knockbackForce = 0.1f;
        if (rb != null)
        {
            // 這將敵人推開一定的距離
            Vector3 knockbackDirection = (transform.position - GameObject.Find("Player").transform.position).normalized;
            rb.AddForce(knockbackDirection * knockbackForce, ForceMode.Impulse);
        }
        */

        int Blood = scorpion_HP;

        Debug.Log(Blood);
        Blood = Blood - DamageValue;
        //Debug.Log("Oops！");
        if(Blood <= 0) {
            Destroy(gameObject);
        }



    }
}
