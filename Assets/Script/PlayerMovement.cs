using System.Collections;
using Unity.VisualScripting;
using UnityEditor.Tilemaps;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed = 5;
    public int facingdirection = 1; 

    public Rigidbody2D rb;
    public Animator anim;

    public Player_Combat player_Combat;

    private bool isKnockback;

    private void Update ()
    {
        if (Input.GetButtonDown("Slash"))
        {
            player_Combat.Attack();
        }
    }



 
    // Update is called once per frame
    void FixedUpdate()
    {
        if (isKnockback == false)
        {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");

            if (horizontal > 0 && transform.localScale.x < 0 ||
                horizontal < 0 && transform.localScale.x > 0)
            {
                Flip();
            }

            anim.SetFloat("horizontal", Mathf.Abs(horizontal));
            anim.SetFloat("vertical", Mathf.Abs(vertical));

            rb.linearVelocity = new Vector2(horizontal, vertical) * speed;
        }
    }

    void Flip() 
    {
        facingdirection *= -1;
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
    }

    public void knockback(Transform enemy, float force, float stuntime) 
    {
        isKnockback = true;
        Vector2 direction = (transform.position - enemy.position).normalized;
        rb.linearVelocity = direction * force;
        StartCoroutine(KnockbackCounter(stuntime));
    }

    IEnumerator KnockbackCounter(float stuntime) 
    {
        yield return new WaitForSeconds(stuntime);
        rb.linearVelocity = Vector2.zero;
        isKnockback = false;
    }
}
