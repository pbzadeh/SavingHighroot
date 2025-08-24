using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tree : MonoBehaviour
{
    public int maxHealth = 70;
    int currHealth; 
    public Animator anim;
    public GameObject LifeTree;
    // Start is called before the first frame update
    void Start()
    {
        currHealth = maxHealth;
        LifeTree.SetActive(false);
        AudioManager.Instance.PlayMusic("BackGround2");
    }

    public void takeDmg(int dmg){
        currHealth -= dmg;
        AudioManager.Instance.PlaySFX("TreeHurt");
        anim.SetTrigger("TreeDamage");
        
        if(currHealth <= 0){
            Die();
            
            
        }

    }
    void Die(){

        Debug.Log("enemy died");
        anim.SetTrigger("TreeDeath");
        //
        AudioManager.Instance.PlaySFX("TreeHurt");
        
        //
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
        Des();
        Invoke( "gg", 3f) ;
        

    }
    void Des(){
        LifeTree.SetActive(true);

        
    }
    void gg(){
        SceneManager.LoadScene("GoodGame");
    }
}
