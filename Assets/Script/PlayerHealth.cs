using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    public int MaximumHealth;
    public int CurrentHealth;

    public void ChangeHealth(int amount) 
    {
        CurrentHealth += amount;

        if (CurrentHealth <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}
