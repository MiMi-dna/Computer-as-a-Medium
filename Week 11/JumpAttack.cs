using UnityEngine;
using UnityEngine.InputSystem;

public class JumpAttack : MonoBehaviour
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
        IsAttacking = Jump();
    }

    public bool Jump()

    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame){
            animator.SetBool("jump", true);
            IsAttacking = true;
        }
        else
        {
            animator.SetBool("jump", false);
            IsAttacking = false;
        }
        return IsAttacking;
    }
}
