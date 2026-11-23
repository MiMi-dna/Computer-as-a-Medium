using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerMana))]

public class PlayerAttack : MonoBehaviour
{
    private static readonly int AttackHash = Animator.StringToHash("attack"); //optimizing string comparison, it turns the string "attack" and converts it to an integer making comparisons faster
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
                animator.SetBool(AttackHash, false);
            }
    }

    public bool Attack()
    {
        if (Keyboard.current.fKey.wasPressedThisFrame){
            animator.SetBool(AttackHash, true);
            IsAttacking = true;
            playerMana.DecreaseMana();
        }
        else
        {
            animator.SetBool(AttackHash, false);
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
