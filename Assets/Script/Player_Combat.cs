using UnityEngine;

public class Player_Combat : MonoBehaviour 
{
    public Transform attackpoint;
    public float weaponrange = 1;
    public LayerMask enemylayer;
    public int damage;

   public Animator anim;
   public float cooldown = 1f;
   private float timer;

   private void Update()
   {
    if (timer > 0)
    {
        timer -= Time.deltaTime;
    }
   }
   
   public void Attack()
   {
    if (timer <= 0)
        {
          anim.SetBool("isAttacking", true);

          timer = cooldown;
        }
       
   }

    public void DealDamage() 
    {
        Collider2D[] enemies = Physics2D.OverlapCircleAll(attackpoint.position, weaponrange, enemylayer);

        if (enemies.Length > 0)
        {
            enemies[0].GetComponent<Enemy_Health>().ChangeHealth(-damage);
        }
    }

   public void FinishAttacking()
   {
       anim.SetBool("isAttacking", false);
   }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackpoint.position, weaponrange);
    }
}
