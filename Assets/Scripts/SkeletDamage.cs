using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletDamage : MonoBehaviour
{
    // Start is called before the first frame update
    public int damageMonster;
    public PlayerHealth playerHP;
    public GameObject Player;
    public float kbforce = 16f;
    public Animator skelAnim;

    private void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.tag == "Player"){
            Vector2 direction = (Player.transform.position - transform.position);
            playerHP.TakeDamagePlayer(damageMonster, direction, kbforce);
            skelAnim.SetTrigger("SkeletAttack");
            
        }
    }
}
