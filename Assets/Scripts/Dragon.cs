using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragon : MonoBehaviour
{
    public int maxHealth = 15;
    int currHealth; 
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        currHealth = maxHealth;
        rb = GetComponent<Rigidbody2D>();
    }

    public void takeDmg(int dmg){
        currHealth -= dmg;
        AudioManager.Instance.PlaySFX("DragonHurt");
        
        
        if(currHealth <= 0){
            Die();
        }

    }
    void Die(){

        Debug.Log("enemy died");
       
        //
        AudioManager.Instance.PlaySFX("DragonHurt");
        
        //
        GetComponent<Collider2D>().enabled = false;
        rb.gravityScale = 1;
        this.enabled = false;

    }
}
