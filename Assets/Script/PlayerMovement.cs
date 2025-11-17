using Unity.VisualScripting;
using UnityEditor.Tilemaps;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed = 5;
    public int facingdirection = 1; 

    public Rigidbody2D rb;
    public Animator anim;



 
    // Update is called once per frame
    void FixedUpdate()
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

        rb.linearVelocity = new Vector2 (horizontal, vertical) * speed;

    }

    void Flip() 
    {
        facingdirection *= -1;
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
    }
}
