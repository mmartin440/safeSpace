using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 
public class PlayerHealth : MonoBehaviour
{
    static public int health; 
    public int maxHealth = 10; 
    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth; 
    }

    public void TakeDamage (int damage) {
        health -= damage; 
        if(health <= 0 ) {
            Destroy(gameObject); 
            LevelManager.instance.Respawn(); 
        }
    }
}
