using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR;

public class EnemyController : MonoBehaviour {

    Rigidbody rb;
    public float knockbackForce;
    public GameObject player;
    public GameObject terrain;
    [SerializeField] private EnemyAttackCooldown enemy_attack_cooldown;


    private float speed = 3f;
    void Start () {
        player = GameObject.FindWithTag("Player");
        terrain = GameObject.FindWithTag("Terrain");
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
            transform.position = Vector3.MoveTowards(transform.position, player_position, speed * Time.deltaTime);
            //Debug.Log(player_position);
        }

    }
    
    private void OnTriggerStay(Collider other) {
        if(enemy_attack_cooldown.IsCoolingDown) return;
        if(player.GetComponent <PlayerController>().GameMode != 0) return;
        if(other.gameObject.tag == ("Player")) {
            //
            //player.GetComponent<PlayerController>().TakeDamaged(10);
            //Debug.Log(player.GetComponent<PlayerController>().Blood);
        }
        if(player.GetComponent<PlayerController>().Blood <= 0) {
            player.GetComponent<PlayerController>().GameMode = 2;
            player.GetComponent<PlayerController>().PrepareGameMode2();
        }
        enemy_attack_cooldown.StartCooldown();
    }

    int Blood = 100;
    public void TakeDamage(int DamageValue)
    {
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

        Blood = Blood - DamageValue;
        //Debug.Log("Oops！");
        if (Blood<=0)
        {
            Destroy(gameObject);

        }


        
    }

}
