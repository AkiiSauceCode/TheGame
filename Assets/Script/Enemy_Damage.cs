using UnityEngine;

public class Enemy_Damage : MonoBehaviour
{
    public int damage = 1; 
    public Transform attactPoint;
    public float weaponRange;
    public LayerMask playerLayer;
/*
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerHealth>().ChangeHealth(-damage);
        }
    }
*/
    public void Attack()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(attactPoint.position, weaponRange, playerLayer);
        if(hits.Length > 0)
        {
            hits[0].GetComponent<PlayerHealth>().ChangeHealth(-damage);
        }
    }

}
