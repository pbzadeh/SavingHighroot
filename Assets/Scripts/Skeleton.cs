using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : MonoBehaviour
{

    public int maxHealth = 5;
    int currHealth; 
    public Animator skelAnim;
    private SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        currHealth = maxHealth;
        //spriteRenderer = GetComponent<SpriteRenderer>();
        //spriteRenderer.flipX = true;
    }

    public void takeDmg(int dmg){
        currHealth -= dmg;
        AudioManager.Instance.PlaySFX("SlimeHurt");
        skelAnim.SetTrigger("skeletHurt");
        
        if(currHealth <= 0){
            Die();
        }

    }
    void Die(){

        Debug.Log("enemy died");
        skelAnim.SetTrigger("skeletDeath");
        //
        AudioManager.Instance.PlaySFX("SlimeDeath");
        
        //
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
    }
    


}
