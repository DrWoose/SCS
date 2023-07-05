using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_Sword : MonoBehaviour
{
    public List<GameObject> enemiesInRange = new List<GameObject>();
    public EnemyController Script_EnemyController;
    //int AttackValue = 10;
    // Start is called before the first frame update



        

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            enemiesInRange.Add(other.gameObject);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            enemiesInRange.Remove(other.gameObject);
        }
    }




    public void Attack()
    {
        Debug.Log("Attack");
        foreach (GameObject enemy in enemiesInRange)
        {
            Script_EnemyController = enemy.GetComponent<EnemyController>();
            if (Script_EnemyController != null)
            {
                Script_EnemyController.TakeDamage(10);
            }
        }
    }
}
