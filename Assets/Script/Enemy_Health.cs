using UnityEngine;

public class Enemy_Health : MonoBehaviour
{
    public int Maxhealth;
    public int CurrentHealth;

    void Start()
    {
        CurrentHealth = Maxhealth;
    }

    public void ChangeHealth(int amount) 
    {
        CurrentHealth += amount;

        if (CurrentHealth > Maxhealth)
        {
            CurrentHealth = Maxhealth;
        }

        else if (CurrentHealth <= 0) 
        {
            Destroy(gameObject);
        }
    }
}
