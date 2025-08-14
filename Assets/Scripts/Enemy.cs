using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public int maxHealth = 10;
    int currHealth; 
    // Start is called before the first frame update
    void Start()
    {
        currHealth = maxHealth;
    }

    public void takeDmg(int dmg){
        currHealth -= dmg;

        if(currHealth <= 0){
            Die();
        }
    }
    void Die(){

        Debug.Log("enemy died");
        //

        //
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
    }
}
