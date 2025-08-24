using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endgamedialougetrigger : MonoBehaviour
{
    public GameObject diabox;
    private int talkcnt = 0;
    // Start is called before the first frame update
    void Start()
    {
        diabox.SetActive(false);
        AudioManager.Instance.PlayMusic("BackGround2");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.CompareTag("Player") //&& talkcnt < 1
        ) // Make sure Player has "Player" tag
        {
            AudioManager.Instance.PlaySFX("EndgameEnter");
            diabox.SetActive(true);
            talkcnt ++;
        }

    }
    

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
             
                diabox.SetActive(false);
                 // O\tionally close on exit
                 Destroy(gameObject);
        }
    }
}
