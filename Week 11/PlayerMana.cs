using UnityEngine;
using TMPro;

public class PlayerMana : MonoBehaviour
{
        public int mana = 100;

    public TMP_Text manaText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        manaText.text = "Mana: " + mana;
    }

    // Update is called once per frame
    void Update()
    {
        manaText.text = "Mana: " + mana;


        //each attack costs 10 mana
        if (PlayerAttack.IsAttacking || JumpAttack.IsAttacking)
        {
            mana -= 10;
        }
        if (mana < 0)
        {
            mana = 0;
        }
        manaText.text = "Mana: " + mana;
    }
}
