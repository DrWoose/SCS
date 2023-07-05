using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HydraController : MonoBehaviour {
    public float knockbackForce;
    public GameObject player;
    public GameObject terrain;
    public GameObject enemySpawner;
    [SerializeField] private HydraAttackCooldown Hydra_attack_cooldown;

    public int Hydra_HP = 5000;
    public int Hydra_ATK = 20;
    public int Hydra_Speed = 2;
    public int Hydra_cooldown = 1;
    private float timer = 0;

    public bool is_Attacking_player = false;
    void Start() {
        player = GameObject.FindWithTag("Player");
        terrain = GameObject.FindWithTag("Terrain");
        enemySpawner = GameObject.FindWithTag("Spawner");
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

            if(timer % 10 == 0 && timer > 0) {
                int dice = Random.Range(1, 5);
                if(dice > 0) {
                    transform.position = Vector3.MoveTowards(transform.position, player_position, Hydra_Speed * Time.deltaTime * 10);
                    Debug.Log("AAA");
                } else {
                    transform.position = Vector3.MoveTowards(transform.position, player_position, Hydra_Speed * Time.deltaTime);
                }
            } else {
                transform.position = Vector3.MoveTowards(transform.position, player_position, Hydra_Speed * Time.deltaTime);
                            }

            //Debug.Log(player_position);
        }
        if(is_Attacking_player && !Hydra_attack_cooldown.IsCoolingDown && player.GetComponent<PlayerController>().GameMode == 0) {
            player.GetComponent<PlayerController>().TakeDamaged(Hydra_ATK);
            if(player.GetComponent<PlayerController>().Blood <= 0) {
                player.GetComponent<PlayerController>().GameMode = 2;
                player.GetComponent<PlayerController>().PrepareGameMode2();
            }
            Hydra_attack_cooldown.StartCooldown();
        }
        timer += Time.deltaTime;
    }
    private void OnTriggerEnter(Collider other) {
        if(Hydra_attack_cooldown.IsCoolingDown)
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
    /*
        private void OnTriggerStay(Collider other) {
            if(Hydra_attack_cooldown.IsCoolingDown)
                return;
            if(player.GetComponent<PlayerController>().GameMode != 0)
                return;
            if(other.gameObject.tag == ("Player")) {

                player.GetComponent<PlayerController>().TakeDamaged(Hydra_ATK);
                //Debug.Log(player.GetComponent<PlayerController>().Blood);
            }
            if(player.GetComponent<PlayerController>().Blood <= 0) {
                player.GetComponent<PlayerController>().GameMode = 2;
                player.GetComponent<PlayerController>().PrepareGameMode2();
            }
            Hydra_attack_cooldown.StartCooldown();
        }
    */
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
        int Blood = Hydra_HP;
        Blood = Blood - DamageValue;
        //Debug.Log("Oops！");
        if(Blood <= 0) {
            Destroy(gameObject);
        }



    }
}
