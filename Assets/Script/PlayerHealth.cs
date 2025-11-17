using UnityEngine;
using TMPro;

public class PlayerHealth : MonoBehaviour
{

    public int MaximumHealth;
    public int CurrentHealth;
    public TMP_Text healthtext;
    public Animator Healthtextanim;

    private void Start()
    {
        healthtext.text = "HP: " + CurrentHealth + " / " + MaximumHealth;
    }


    public void ChangeHealth(int amount) 
    {
        CurrentHealth += amount;
        Healthtextanim.Play("TextUpdate");

        healthtext.text = "HP: " + CurrentHealth + " / " + MaximumHealth;

        if (CurrentHealth <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}
