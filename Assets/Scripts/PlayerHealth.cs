using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public Animator anim;
    public int maxHealthPlayer = 50;
    public int health;
    public Image healthBar;
    public float nextHealTime = 0f;
    public Animator myanim;
    // Start is called before the first frame update
    void Start()
    {
        health = maxHealthPlayer;
    }   

    void Update(){
        if(Time.time >= nextHealTime){
            if (Input.GetKeyDown(KeyCode.G)){
                HealPlayer(5);
                nextHealTime = Time.time + 1f / 0.25f;
            }
        }
    }
    /* public void TakeDamagePlayer(int damage){
        health -= damage;
        AudioManager.Instance.PlaySFX("PlayerHurt");
        if(health <= 0){
            AudioManager.Instance.PlaySFX("PlayerDeath");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        healthBar.fillAmount = (float)health / maxHealthPlayer;

    } */
    public void TakeDamagePlayer(int damage, Vector2 knockbackDirection, float knockbackForce)
    {
        // Reduce health, etc.
        health -= damage;
        AudioManager.Instance.PlaySFX("Hurt");
        myanim.SetTrigger("Hurting");
        // Apply knockback
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
         // Optionally stop current motion for consistent knockback
        rb.velocity = Vector2.zero;
        rb.AddForce(knockbackDirection.normalized * knockbackForce, ForceMode2D.Impulse);
        if(health <= 0){
            AudioManager.Instance.PlaySFX("PlayerDeath");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        
        healthBar.fillAmount = (float)health / maxHealthPlayer;
    }
    public void HealPlayer(int heal){
        health += heal;
        health = Mathf.Clamp(health, 0, maxHealthPlayer);
        AudioManager.Instance.PlaySFX("PlayerHeal");
        healthBar.fillAmount = (float)health / maxHealthPlayer;

    }
}
