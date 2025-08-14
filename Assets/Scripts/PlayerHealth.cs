using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    public int maxHealthPlayer = 10;
    public int health;
    // Start is called before the first frame update
    void Start()
    {
        health = maxHealthPlayer;
    }   

    void Update(){

    }
    public void TakeDamagePlayer(int damage){
        health -= damage;
        if(health <= 0){
            Destroy(gameObject);
        }
    }
}
