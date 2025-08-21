using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public int maxHealth = 15;
    int currHealth; 
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        currHealth = maxHealth;
    }

    public void takeDmg(int dmg){
        currHealth -= dmg;
        AudioManager.Instance.PlaySFX("OtherHurt");
        anim.SetTrigger("enemyHurt");
        
        if(currHealth <= 0){
            Die();
        }

    }
    void Die(){

        Debug.Log("enemy died");
        anim.SetTrigger("enemyDeath");
        //
        AudioManager.Instance.PlaySFX("SkewersDeath");
        
        //
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
    }
}
