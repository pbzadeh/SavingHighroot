using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonChase : MonoBehaviour
{
    


    public GameObject player;
    public int trackfrom = 50;
    public float speed;
    private float dis;
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rb;
    public Animator skeletAnim;

    bool isMoving;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        //Vector2 dd = player.transform.position - transform.position;
        //spriteRenderer.flipX = dd.x < 0;
        
    }

    // Update is called once per frame
    void Update()
    {
        
        // animator section
        bool currentlyMoving = rb.velocity.magnitude > 0f;

        if (currentlyMoving && !isMoving)
        {
            skeletAnim.SetTrigger("skeletWalkk");
            Debug.Log("Started moving!");
        }
        else if (!currentlyMoving && isMoving)
        {
            
            Debug.Log("Stopped moving!");
        }

        isMoving = currentlyMoving;





        /*else{
            skeletAnim.SetBool("skeletWalkk", false);
        }*/
        dis = Vector2.Distance(player.transform.position, transform.position);
        Vector2 direction = player.transform.position - transform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        
        if(dis < trackfrom){
            transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
        //transform.rotation = Quaternion.Euler(Vector3.forward * angle);

            spriteRenderer.flipX = direction.x > 0;
        }
        
    }
}


