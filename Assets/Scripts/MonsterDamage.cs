using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterDamage : MonoBehaviour
{

    public int damageMonster;
    public PlayerHealth playerHP;
    public GameObject Player;
    public float kbforce = 14f;

    private void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.tag == "Player"){
            Vector2 direction = (Player.transform.position - transform.position);
            playerHP.TakeDamagePlayer(damageMonster, direction, kbforce);
            
        }
    }
}
