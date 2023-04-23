using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public PlayerHealth playerHealth; 
    public int damage; 


    private void OnCollisionEnter2D(Collision2D collision) {
        Debug.Log("on Collision");
        if(collision.gameObject.tag == "Player") {
            playerHealth.TakeDamage(damage); 
        }
    }


}
