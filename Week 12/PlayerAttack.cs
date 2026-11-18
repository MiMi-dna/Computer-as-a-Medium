using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
    public Animator animator;
    public static bool IsAttacking { get; private set; }
    public Transform firePoint;
    public GameObject bulletPrefab;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        IsAttacking = Attack();
        Shoot();
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
        if (Keyboard.current.fKey.wasPressedThisFrame) //one time press of the f key will instantiate a bullet at the fire point's position and rotation, no copies are created/multiple bullets are not created
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation); //this creates a copy of the bullet prefab at the fire point's position and rotation, which is set in the inspector
    }
}



