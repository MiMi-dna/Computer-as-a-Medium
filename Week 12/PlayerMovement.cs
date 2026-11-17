using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    private float speedX = 0f;
    private float speedY = 0f;
    public Rigidbody2D rb;
    public SpriteRenderer spriteRenderer;
    public Transform weaponPivot;
    public Knockback knockback;

    public Sprite beartop;
    public Sprite beardown;
    public Sprite bearleft;
    public Sprite bearright;

    void Update()
    {
        Movement();
    }

    void Movement()
    {
        // Horizontal Movement
        if (Keyboard.current.aKey.isPressed || Keyboard.current.leftArrowKey.isPressed)
        {
            speedX = -moveSpeed;
            Face(bearleft, 90f);
        }
        else if (Keyboard.current.dKey.isPressed || Keyboard.current.rightArrowKey.isPressed)
        {
            speedX = moveSpeed;
            Face(bearright, 270f);
        }
        else
        {
            speedX = 0;
        }

        // Vertical Movement
        if (Keyboard.current.wKey.isPressed || Keyboard.current.upArrowKey.isPressed)
        {
            speedY = moveSpeed;
            Face(beartop, 0f);
        }
        else if (Keyboard.current.sKey.isPressed || Keyboard.current.downArrowKey.isPressed)
        {
            speedY = -moveSpeed;
            Face(beardown, 180f);
        }
        else
        {
            speedY = 0;
        }

        // don't overwrite the knockback push while it's happening
        if (knockback == null || !knockback.isKnockedBack)
        {
            rb.linearVelocity = new Vector2(speedX, speedY);
        }
    }

    void Face(Sprite sprite, float angle)
    {
        spriteRenderer.sprite = sprite;

        if (weaponPivot != null)
        {
            weaponPivot.localRotation = Quaternion.Euler(0f, 0f, angle);
        }
    }
}