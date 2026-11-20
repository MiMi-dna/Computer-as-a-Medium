using UnityEngine;
using TMPro;
public class PlayerMana : MonoBehaviour
{
    public float maxMana = 100f;
    public float minMana = 0f;
    public float currentMana;
    private float startingMana = 100f;
    private float regenRate = 3.0f;
    private float timeElapsed = 0.0f;
    private float regenDelay = 1.0f;
    [SerializeField] private TMP_Text manaText;
    public float decreaseAmnt = 10f;

    void Start()
    {
        currentMana = startingMana;
        manaText.text = "Mana: " + Mathf.FloorToInt(currentMana);
    }
    void Update()
    {
        RegenMana();
        
    }

    public void DecreaseMana()
    {
        if (PlayerAttack.IsAttacking)
        {
            currentMana -= decreaseAmnt; 
            if (currentMana < minMana)
            {
                currentMana = minMana;
            }
            manaText.text = "Mana: " + Mathf.FloorToInt(currentMana);
        }
    }

    void RegenMana()
    {
        if (PlayerAttack.IsAttacking)
        {
            timeElapsed = 0.0f; // Reset cooldown if attacking
            return;
        }

        if (currentMana < maxMana)
        {
            if (timeElapsed < regenDelay)
            {
                timeElapsed += Time.deltaTime;
                return;
            }

            currentMana += regenRate;
            manaText.text = "Mana: " + Mathf.FloorToInt(currentMana);
            timeElapsed = 0.0f; // Reset cooldown after regeneration
        }
        else if (currentMana >= maxMana)
        {
            currentMana = maxMana;
        }
    }
}

