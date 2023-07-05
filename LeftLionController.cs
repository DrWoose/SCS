using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftLionController : MonoBehaviour {
    public float knockbackForce;
    public GameObject player;
    public GameObject terrain;
    [SerializeField] private LionAttackCooldown Lion_attack_cooldown;

    public int Lion_HP = 5000;
    public int Lion_ATK = 40;
    public int Lion_Speed = 1;
    public int Lion_cooldown = 5;
    public bool is_Attacking_player = false;

    void Start() {
        player = GameObject.FindWithTag("Player");
        terrain = GameObject.FindWithTag("Terrain");
        //Debug.Log(terrain.name);
        Physics.IgnoreCollision(gameObject.GetComponent<Collider>(), terrain.GetComponent<Collider>(), true);
    }
    void Update() {
        // Game mode:
        //0�GNormal
        //1�GUI
        //2�GFallDown
        //3�GGameOver
        if(player.GetComponent<PlayerController>().GameMode == 0) {
            Vector3 player_position = new Vector3(transform.position.x, transform.position.y, player.transform.position.z);
            transform.position = Vector3.MoveTowards(transform.position, player_position, Lion_Speed * Time.deltaTime);
            //Debug.Log(transform.position);
            //Debug.Log(player_position);
        }
        if(is_Attacking_player && !Lion_attack_cooldown.IsCoolingDown && player.GetComponent<PlayerController>().GameMode == 0) {
            gameObject.GetComponent<Animator>().CrossFadeInFixedTime("LionAttack", 0);

            player.GetComponent<PlayerController>().TakeDamaged(Lion_ATK);

            if(player.GetComponent<PlayerController>().Blood <= 0) {
                player.GetComponent<PlayerController>().GameMode = 2;
                player.GetComponent<PlayerController>().PrepareGameMode2();
            }
            Lion_attack_cooldown.StartCooldown();
        }

    }
    private void OnTriggerEnter(Collider other) {
        if(Lion_attack_cooldown.IsCoolingDown)
            return;
        if(player.GetComponent<PlayerController>().GameMode != 0)
            return;

        if(other.gameObject.tag == ("Player")) {
            is_Attacking_player = true;

        }

    }
    private void OnTriggerExit(Collider other) {

        if(other.gameObject.tag == ("Player")) {
            is_Attacking_player = false;

        }
    }
    /*private void OnTriggerStay(Collider other) {

        
        if(Lion_attack_cooldown.IsCoolingDown)
            return;
        Debug.Log("lion");
        if(player.GetComponent<PlayerController>().GameMode != 0)
            return;

        if(other.gameObject.tag == ("Player")) {
            
            player.GetComponent<PlayerController>().TakeDamaged(Lion_ATK);
        }
        if(player.GetComponent<PlayerController>().Blood <= 0) {
            player.GetComponent<PlayerController>().GameMode = 2;
            player.GetComponent<PlayerController>().PrepareGameMode2();
        }
        Lion_attack_cooldown.StartCooldown();
    }*/

    public void TakeDamage(int DamageValue) {
        /*
        rb = GetComponent<Rigidbody>();
        knockbackForce = 0.1f;
        if (rb != null)
        {
            // �o�N�ĤH���}�@�w���Z��
            Vector3 knockbackDirection = (transform.position - GameObject.Find("Player").transform.position).normalized;
            rb.AddForce(knockbackDirection * knockbackForce, ForceMode.Impulse);
        }
        */

        int Blood = Lion_HP;
        Blood = Blood - DamageValue;
        //Debug.Log("Oops�I");
        if(Blood <= 0) {
            Destroy(gameObject);
        }



    }
}
