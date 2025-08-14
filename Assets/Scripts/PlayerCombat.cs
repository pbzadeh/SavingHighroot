using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
   
    public Animator anim;

    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
    public int attackdmg = 4;

    public float attackRate = 4f;
    float nextattackTime = 0f;
    // Update is called once per frame
    void Update()
    {
        if(Time.time >= nextattackTime){
            if (Input.GetMouseButton(0)){
                Attack();
                nextattackTime = Time.time + 1f / attackRate;
            }
        }
        
    }
    void Attack(){
        //
        anim.SetTrigger("Attacking");
        //
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        foreach(Collider2D enemy in hitEnemies){
            enemy.GetComponent<Enemy>().takeDmg(attackdmg);
        }
        //
    }
    
    void OnDrawGizmosSelected(){
        if(attackPoint == null){
            return;
        }
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);  
    }
    
}
