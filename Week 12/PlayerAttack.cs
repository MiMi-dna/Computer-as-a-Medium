using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
    public Animator animator;
    public static bool IsAttacking { get; private set; }
    public GameObject bulletPrefab;
    public Transform firePoint;
    PlayerMana playerMana;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerMana = GetComponent<PlayerMana>();
    }

    // Update is called once per frame
    void Update()
    {
            if (playerMana.currentMana > playerMana.minMana)
            {
                IsAttacking = Attack();
                Shoot();
            }
            else
            {
                IsAttacking = false;
                animator.SetBool("attack", false);
            }
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


    void Shoot()
    {
        if (Keyboard.current.fKey.wasPressedThisFrame)
        {
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        }
    }
}
