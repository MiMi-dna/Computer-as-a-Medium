using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
    public Animator animator;
    public static bool IsAttacking { get; private set; }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        IsAttacking = Attack();
    }

    public bool Attack()

    {
        if (Keyboard.current.fKey.wasPressedThisFrame){
            animator.SetBool("attack", true);
            IsAttacking = true;
        }
        else
        {
            animator.SetBool("attack", false);
            IsAttacking = false;
        }
        return IsAttacking;
    }
}

