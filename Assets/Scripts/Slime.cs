using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : MonoBehaviour
{
    public int maxHealth = 5;
    int currHealth; 
    public Animator slimeanim;
    // Start is called before the first frame update
    void Start()
    {
        currHealth = maxHealth;
    }

    public void takeDmg(int dmg){
        currHealth -= dmg;
        AudioManager.Instance.PlaySFX("SlimeHurt");
        slimeanim.SetTrigger("slimeHurt");
        
        if(currHealth <= 0){
            Die();
        }

    }
    void Die(){

        Debug.Log("enemy died");
        slimeanim.SetTrigger("slimeDeath");
        //
        AudioManager.Instance.PlaySFX("SlimeDeath");
        
        //
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
        
    }
}
