using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDash : MonoBehaviour
{
    public float dashSpeed = 30f;
    public float dashDuration = 0.2f;
    public float dashCooldown = 0.75f;
    public Animator playerAnim;
    private Rigidbody2D rb;
    private bool isDashing;
    private float dashTimeLeft;
    private float lastDashTime;
    private int dashDirection = 1; // 1 = right, -1 = left
    private TrailRenderer trailRenderer;
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        trailRenderer = GetComponent<TrailRenderer>();
        if(trailRenderer != null) trailRenderer.enabled = false;
    }

    void Update()
    {
        // Check left/right input
        if (!isDashing && Time.time >= lastDashTime + dashCooldown)
        {
            if (Input.GetMouseButtonDown(1) || Input.GetKeyDown(KeyCode.LeftControl))
            {
                float horizontalInput = Input.GetAxisRaw("Horizontal");
                if (horizontalInput != 0)
                {
                    dashDirection = horizontalInput > 0 ? 1 : -1;
                    isDashing = true;
                    dashTimeLeft = dashDuration;
                    lastDashTime = Time.time;
                    playerAnim.SetTrigger("Dashing");
                    AudioManager.Instance.PlaySFX("Whoosh");
                    // Enable trail
                    if(trailRenderer != null)
                        trailRenderer.enabled = true;
                }
            }
        }

        if (isDashing)
        {
            if (dashTimeLeft > 0)
            {
                rb.velocity = new Vector2(dashDirection * dashSpeed, rb.velocity.y);
                dashTimeLeft -= Time.deltaTime;
            }
            else
            {
                rb.velocity = new Vector2(0, rb.velocity.y);
                isDashing = false;

                // Disable trail
                if(trailRenderer != null)
                    trailRenderer.enabled = false;
            }
        }
    }
}
