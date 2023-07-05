using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;
public class EnemySpawner : MonoBehaviour {
    public GameObject ScorpionPrefab;
    public GameObject LionPrefab;
    public GameObject BirdPrefab;
    public GameObject HydraPrefab;
    private bool Lion_is_spawn = false;
    private bool Bird_is_spawn = false;
    private bool Hydra_is_spawn = false;
    public int scorpion_respawncooldown = 3;
    public int Lion_respawncooldown = 1;
    public int Hydra_respawncooldown = 120;
    public int Bird_respawncooldown = 180;
    private float timer = 0;
    private float boss_timer = 0;
    private int Scorpioncounter = 1; 
    public int level = 1;
    void Update() {
        Debug.Log("das");
        if(timer < scorpion_respawncooldown) {
            timer += Time.deltaTime;
        } else {
            if(Scorpioncounter == 10) level++;
            timer = 0;
            SpawnScorpion(ScorpionPrefab, level);
        }
        if(Mathf.Floor(boss_timer / Lion_respawncooldown) > 0 && !Lion_is_spawn) {
            SpawnLion(LionPrefab);
            Lion_is_spawn = true;
        }
        if(Mathf.Floor(boss_timer / Hydra_respawncooldown) > 0 && !Hydra_is_spawn) {
            SpawnEnemy(HydraPrefab);
            Hydra_is_spawn = true;
        }
        /*if(Mathf.Floor(boss_timer / Bird_respawncooldown) > 0 && !Bird_is_spawn) {
            SpawnEnemy(BirdPrefab);
            Bird_is_spawn = true;
        }*/ else {
            boss_timer += Time.deltaTime;
        }
    }
    private void SpawnEnemy(GameObject EnemyPrefab) {
        int dice = Random.Range(1, 3);
        if(dice == 1) {
            Instantiate(EnemyPrefab, new Vector3(Random.Range(-25, -19), transform.position.y, Random.Range(-25, 26)), transform.rotation, transform);

        } else {
            Instantiate(EnemyPrefab, new Vector3(Random.Range(20, 26), transform.position.y, Random.Range(-25, 26)), transform.rotation, transform);

        }
    }
    private void SpawnLion(GameObject EnemyPrefab) {
        Instantiate(EnemyPrefab, new Vector3(Random.Range(-25, -19), transform.position.y, Random.Range(-25, 26)), transform.rotation, transform);
        Instantiate(EnemyPrefab, new Vector3(Random.Range(20, 26), transform.position.y, Random.Range(-25, 26)), transform.rotation, transform);

    }
    private void SpawnScorpion(GameObject Scorpionpreset, int quantity) {

        while(quantity > 0) {
            int dice = Random.Range(1, 4);
            if(dice == 1) {
                Instantiate(Scorpionpreset, new Vector3(Random.Range(-25, -19), transform.position.y, Random.Range(-25, 26)), transform.rotation, transform);

            } else if(dice == 2) {
                Instantiate(Scorpionpreset, new Vector3(Random.Range(19, 26), transform.position.y, Random.Range(-25, 26)), transform.rotation, transform);

            } else {
                Instantiate(Scorpionpreset, new Vector3(Random.Range(20, 26), transform.position.y, Random.Range(-25, 26)), transform.rotation, transform);

            }
            quantity--;
        }


    }
}
