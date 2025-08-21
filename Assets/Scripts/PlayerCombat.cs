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
            if (Input.GetMouseButton(0) || Input.GetKeyDown(KeyCode.X)){
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
            Enemy enemyScript = enemy.GetComponent<Enemy>();
            if(enemyScript != null) {
                enemyScript.takeDmg(attackdmg);
                continue;
            }
            Slime slimeScript = enemy.GetComponent<Slime>();
            if(slimeScript != null) {
                slimeScript.takeDmg(attackdmg);
            }
            Skeleton skeletScript = enemy.GetComponent<Skeleton>();
            if(skeletScript != null) {
                skeletScript.takeDmg(attackdmg);
                continue;
            }
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
