using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterDamage : MonoBehaviour
{

    public int damageMonster;
    public PlayerHealth playerHP;

    private void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.tag == "Player"){
            playerHP.TakeDamagePlayer(damageMonster);
        }
    }
}
